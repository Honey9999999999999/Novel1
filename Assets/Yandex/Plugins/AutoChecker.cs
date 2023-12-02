using UnityEngine;
using UnityEngine.UI;

public class AutoChecker : MonoBehaviour
{
    [SerializeField] private GameObject Buttons;
    [SerializeField] private Button loadButton;
    [SerializeField] private Button autoButton;
    public void SetAutoState(string state)
    {
        bool _state = state == "true";

        Progress.instance.playerAutorizetedState = _state;

        if (autoButton.gameObject.activeSelf == _state && _state)
            Buttons.transform.position += new Vector3(0, -50, 0);

        loadButton.interactable = _state;
        autoButton.gameObject.SetActive(!_state);
        
    }
}
