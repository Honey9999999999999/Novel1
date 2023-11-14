using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private GameObject dialogs;
    [SerializeField] private GameObject menu;

    public void Toggle()
    {
        dialogs.SetActive(!dialogs.activeSelf);
        menu.SetActive(!menu.activeSelf);
    }
}
