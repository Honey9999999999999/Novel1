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

    public List<bool> stars = new List<bool>() 
    { 
        false,
        false,
        false,
        false,
        false
    };

    public int GetCountStars()
    {
        int result = 0;

        foreach (var item in stars)
            if (item)
                result++;

        return result;
    }
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
    public static event Action SaveLoaded;

    public Save save;

    public bool playerAutorizationState;

    [DllImport("__Internal")]
    private static extern void SaveExtern(string data);
    [DllImport("__Internal")]
    private static extern void LoadExtern();
    [DllImport("__Internal")]
    private static extern void SaveLocalExtern(string key, string data);
    [DllImport("__Internal")]
    private static extern void LoadLocalExtern(string key);

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
        if (playerAutorizationState)
            SaveExtern(jsonString);
        else
            SaveLocalExtern("save1", jsonString);
    }

    public void Load()
    {
        if (playerAutorizationState)
            LoadExtern();
        else
            LoadLocalExtern("save1");
    }

    public void SetPlayerInfo(string value)
    {
        Debug.Log(value);
        save = JsonUtility.FromJson<Save>(value);
        Debug.Log("Player info is setted");
        SaveLoaded?.Invoke();        
    }
}
