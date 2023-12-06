using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private List<GameObject> dialogPanels;
    [SerializeField] private GameObject menu;

    public void Toggle()
    {
        menu.SetActive(!menu.activeSelf);

        if (dialogPanels.Count > 0)
            foreach (var panel in dialogPanels)
            {
                panel.SetActive(!menu.activeSelf);
            }

        
    }
}
