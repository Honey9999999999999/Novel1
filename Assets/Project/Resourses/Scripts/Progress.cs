using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


[Serializable]
public class Save
{
    public int level;
    public PlayerInfo playerInfo;
}

[Serializable]
public class PlayerInfo
{
    public string playerName;

    public int cSharp;
    public int blender;
    public int unity;

    public int morgan;
    public int vondarm;
    public int joly;
}

public class Progress : MonoBehaviour
{
    public event Action OnSaveLoaded;

    public Save save;    

    [DllImport("__Internal")]
    private static extern void SaveExtern(string data);
    [DllImport("__Internal")]
    private static extern void LoadExtern();

    public static Progress instance;

    private void Awake()
    {
        if(instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            instance = this;            
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Save()
    {
        string jsonString = JsonUtility.ToJson(save);
        //SaveExtern(jsonString);
    }
    public void Load()
    {
        //LoadExtern();
    }

    public void SetPlayerInfo(string value)
    {
        save = JsonUtility.FromJson<Save>(value);
        OnSaveLoaded?.Invoke();
    }

    

    
}
