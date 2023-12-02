using UnityEngine;
using UnityEngine.UI;

public class MenuStateSetter : MonoBehaviour
{
    [SerializeField] private GameObject dialogCloud;
    [SerializeField] private GameObject Buttons;
    [SerializeField] private Button loadButton;
    [SerializeField] private Button autoButton;    

    private void OnEnable()
    {
        Progress.OnSaveLoaded += SetMenuState;
    }
    private void OnDisable()
    {
        Progress.OnSaveLoaded -= SetMenuState;
    }

    private void Start()
    {
        if (Progress.instance.save.level != 0)
            SetMenuState();
    }
    
    public void SetAutoState(string state)
    {
        Progress.instance.playerAutorizationState = ConvertString(state);

        if (Progress.instance.playerAutorizationState)
            Progress.instance.Load();
    }
    private void SetMenuState()
    {
        bool state = Progress.instance.playerAutorizationState;

        if (autoButton.gameObject.activeSelf == state && state)
            Buttons.transform.position += new Vector3(0, -50, 0);

        Debug.Log("///" + JsonUtility.ToJson(Progress.instance.save) + "///");
        loadButton.interactable = Progress.instance.save.level != 0;        
        autoButton.gameObject.SetActive(!state);
        dialogCloud.SetActive(!state);
    }

    private bool ConvertString(string state) => state == "true";
}
