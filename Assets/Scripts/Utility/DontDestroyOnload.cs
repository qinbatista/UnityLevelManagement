using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnload : MonoBehaviour
{
    void Awake()
    {
        transform.SetParent(null);
        DontDestroyOnLoad(this);
    }
}
