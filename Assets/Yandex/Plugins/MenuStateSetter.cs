using UnityEngine;
using UnityEngine.UI;

public class MenuStateSetter : MonoBehaviour
{
    [SerializeField] private GameObject Buttons;
    [SerializeField] private Button loadButton;
    [SerializeField] private Button autoButton;

    private void Start()
    {
        SetAutoState();
    }
    
    public void SetAutoState(string state)
    {
        Progress.instance.playerAutorizetedState = ConvertString(state);
        SetAutoState();
    }
    private void SetAutoState()
    {
        bool state = Progress.instance.playerAutorizetedState;

        if (autoButton.gameObject.activeSelf == state && state)
            Buttons.transform.position += new Vector3(0, -50, 0);

        loadButton.interactable = state && Progress.instance.save.level != 0;
        autoButton.gameObject.SetActive(!state);
    }

    private bool ConvertString(string state) => state == "true";
}
