using System.Collections;
using System.Collections.Generic;
using System;


[Serializable]
public class SaveData
{
    public string playerName;
    private readonly string defaultPlayerName = "Player";
    public string hashValue;
    public float masterVolume;
    public float sfxVolume;
    public float musicVolume;

    public SaveData()
    {
        playerName = defaultPlayerName;
        masterVolume = 0f;
        sfxVolume = 0f;
        musicVolume = 0f;
    }

}

