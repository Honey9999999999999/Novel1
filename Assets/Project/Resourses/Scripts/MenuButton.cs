using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private List<GameObject> dialogPanels;
    [SerializeField] private GameObject menu;
    [SerializeField] private Flowchart flowchart;

    private Block activeBlock;
    private int activeCommand;

    public void Toggle()
    {
        menu.SetActive(!menu.activeSelf);

        if (dialogPanels.Count > 0)
            foreach (var panel in dialogPanels)
            {
                panel.SetActive(!menu.activeSelf);
            }

        if(flowchart != null)
            if (menu.activeSelf)
            {
                activeBlock = flowchart.SelectedBlock;
                activeCommand = activeBlock.ActiveCommand.CommandIndex;
                flowchart.SelectedBlock.Stop();
            }
            else
                StartCoroutine(activeBlock.Execute(activeCommand));
    }
}
