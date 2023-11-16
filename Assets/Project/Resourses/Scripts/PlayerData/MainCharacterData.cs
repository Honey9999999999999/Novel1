using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCharacterData : MonoBehaviour
{
    public string playerName;

    public int cSharp;
    public int unity;
    public int blender;

    public int morgan;
    public int vondarm;
    public int joly;

    public static MainCharacterData mainCharacter;

    private void Awake()
    {
        if (mainCharacter == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            mainCharacter = this;
        }
        else
            Destroy(gameObject);
    }
}
