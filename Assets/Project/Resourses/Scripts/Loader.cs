using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Loader : MonoBehaviour
{
    private void OnEnable()
    {
        Progress.instance.OnSaveLoaded += CheckSaves;
    }
    public void CheckSaves()
    {
        if (Progress.instance.save.level.Equals(0))
            gameObject.GetComponent<Button>().interactable = false;
    }

    public void Load()
    {
        SceneManager.LoadScene(Progress.instance.save.level);
    }
}
