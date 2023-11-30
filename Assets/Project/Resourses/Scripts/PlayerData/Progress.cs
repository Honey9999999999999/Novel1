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

    public Dictionary<string, bool> stars = new()
    {
        { "Good1", false },
        { "Good2", false },
        { "Bad1", false },
        { "Bad2", false },
        { "Secret", false }
    };
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
        SaveExtern(jsonString);
        Debug.Log("Saving success");
    }
    public void Load()
    {
        LoadExtern();
        Debug.Log("Loading success");
    }

    public void SetPlayerInfo(string value)
    {
        Debug.Log(value);
        save = JsonUtility.FromJson<Save>(value);
        OnSaveLoaded?.Invoke();
    }
}
