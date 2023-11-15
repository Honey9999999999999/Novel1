using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private List<GameObject> dialogPanels;
    [SerializeField] private GameObject menu;
    [SerializeField] private Flowchart flowchart;

    private Block activeBlock;
    private int activeCommand;

    public void Toggle()
    {
        var saveManager = FungusManager.Instance.SaveManager;
        menu.SetActive(!menu.activeSelf);

        if (dialogPanels.Count > 0)
            foreach (var panel in dialogPanels)
            {
                panel.SetActive(!menu.activeSelf);
            }
    }
}
