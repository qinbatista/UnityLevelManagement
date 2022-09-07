using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System.Security.Cryptography;
public class JsonServer
{
    static readonly string _filename = "saveData1.sav";
    public static string GetSavePath()
    {
        Debug.Log(Application.persistentDataPath + "/" + _filename);
        return Application.persistentDataPath + "/" + _filename;
    }
    public void Save(SaveData data)
    {
        data.hashValue = String.Empty;
        string json = JsonUtility.ToJson(data);
        data.hashValue = GetSHA256(json);
        json = JsonUtility.ToJson(data);
        Debug.Log("hash string =" + data.hashValue);
        string saveFileName = GetSavePath();
        FileStream fileStream = new FileStream(saveFileName, FileMode.Create);
        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(json);
        }
    }
    public bool Load(SaveData data)
    {
        string loadFileName = GetSavePath();
        if (File.Exists(loadFileName))
        {
            // FileStream fileStream = new FileStream(loadFileName, FileMode.Open);
            using (StreamReader reader = new StreamReader(loadFileName))
            {
                string json = reader.ReadToEnd();
                //check hash before reading
                if(CheckData(json))
                {
                    Debug.Log("hash are equal");
                    JsonUtility.FromJsonOverwrite(json, data);
                }
                else
                {
                    Debug.Log("JsonServer Load: invalid hash. Aborting file read.");
                }
            }
            return true;
        }
        return false;
    }
    bool CheckData(string json)
    {
        SaveData tempSaveData = new SaveData();
        JsonUtility.FromJsonOverwrite(json, tempSaveData);
        string oldHash = tempSaveData.hashValue;

        tempSaveData.hashValue = string.Empty;
        string tempJson = JsonUtility.ToJson(tempSaveData);
        string newHash = GetSHA256(tempJson);
        return (oldHash == newHash);
    }
    public void Delete()
    {
        string deleteFileName = GetSavePath();
        if (File.Exists(deleteFileName))
        {
            File.Delete(deleteFileName);
        }
    }
    public string GetHexStringFromHash(byte[] hash)
    {
        string hexString = String.Empty;
        foreach (byte b in hash)
        {
            hexString += b.ToString("x2");
        }
        return hexString;
    }
    string GetSHA256(string text)
    {
        byte[] textToBytes = Encoding.UTF8.GetBytes(text);
        SHA256Managed mySHA256 = new SHA256Managed();
        byte[] hashValue = mySHA256.ComputeHash(textToBytes);
        // return System.BitConverter.ToString(hashValue);
        return GetHexStringFromHash(hashValue);
    }
}
