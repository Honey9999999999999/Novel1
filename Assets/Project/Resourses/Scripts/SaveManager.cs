using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SaveManager : MonoBehaviour
{
    Fungus.SaveManager saveManager;
    private void Start()
    {
        Progress.instance.OnSaveLoaded += CheckSaves;
        saveManager = FungusManager.Instance.SaveManager;
    }
    public void CheckSaves()
    {
        if (Progress.instance.save.level.Equals(0))
            gameObject.GetComponent<Button>().interactable = false;
    }

    public void Save()
    {
        saveManager.AddSavePoint("JOJO", "Kurwa");
        saveManager.Save("JOJO");
        Progress.instance.Save();
    }

    public void Load()
    {
        saveManager.Load("JOJO");
        Debug.Log(saveManager.NumSavePoints);
        Debug.Log(saveManager.NumRewoundSavePoints);
        SceneManager.LoadScene(Progress.instance.save.level);
    }
}
