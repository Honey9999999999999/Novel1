using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SaveManager : MonoBehaviour
{
    [SerializeField] private Flowchart flowchart;
    private void Start()
    {
        Progress.instance.OnSaveLoaded += CheckSaves;
    }
    public void CheckSaves()
    {
        if (Progress.instance.save.level.Equals(0))
            gameObject.GetComponent<Button>().interactable = false;
    }

    public void Save()
    {
        Progress.instance.Save();
    }

    public void Load()
    {
        SceneManager.LoadScene(Progress.instance.save.level);
    }
    public void LoadVariables()
    {
        flowchart.SetStringVariable("playerName", Progress.instance.save.playerInfo.playerName);

        flowchart.SetIntegerVariable("C_Level", Progress.instance.save.playerInfo.cSharp);
        flowchart.SetIntegerVariable("Unity_Level", Progress.instance.save.playerInfo.unity);
        flowchart.SetIntegerVariable("Blender_Level", Progress.instance.save.playerInfo.blender);

        flowchart.SetIntegerVariable("Morgan_Friendhsip", Progress.instance.save.playerInfo.morgan);
        //flowchart.SetIntegerVariable("playerName", Progress.instance.save.playerInfo.vondarm);
        flowchart.SetIntegerVariable("Joly_Friendhsip", Progress.instance.save.playerInfo.joly);
    }

    public void SaveScene() => Progress.instance.save.level = SceneManager.GetActiveScene().buildIndex;
    public void SaveName(string name) => Progress.instance.save.playerInfo.playerName = name;
    public void SaveCSharp(int value) => Progress.instance.save.playerInfo.cSharp = value;
    public void SaveUnity(int value) => Progress.instance.save.playerInfo.unity = value;
    public void SaveBlender(int value) => Progress.instance.save.playerInfo.blender = value;
    public void SaveMorgan(int value) => Progress.instance.save.playerInfo.morgan = value;
    public void SaveJoly(int value) => Progress.instance.save.playerInfo.joly = value;
    public void SaveVondarm(int value) => Progress.instance.save.playerInfo.vondarm = value;
    

    public void SaveReset()
    {
        Progress.instance.save.level = 0;

        Progress.instance.save.playerInfo.cSharp = 0;
        Progress.instance.save.playerInfo.blender = 0;
        Progress.instance.save.playerInfo.unity = 0;

        Progress.instance.save.playerInfo.morgan = 0;
        Progress.instance.save.playerInfo.vondarm = 0;
        Progress.instance.save.playerInfo.joly = 0;

        Save();
    }
}
