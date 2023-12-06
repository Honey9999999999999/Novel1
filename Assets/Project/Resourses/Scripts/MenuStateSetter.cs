using UnityEngine;
using UnityEngine.UI;

public class MenuStateSetter : MonoBehaviour
{
    [SerializeField] private GameObject dialogCloud;
    [SerializeField] private GameObject messegeBox;
    [SerializeField] private GameObject Buttons;
    [SerializeField] private Button loadButton;
    [SerializeField] private Button autoButton;

    private Save _save;

    private void OnEnable()
    {
        Progress.SaveLoaded += SetMenuState;
        Progress.SaveLoaded += CheckSave;
    }
    private void OnDisable()
    {
        Progress.SaveLoaded -= SetMenuState;
        Progress.SaveLoaded -= CheckSave;
    }

    private void Start()
    {
        if (Progress.instance.save.level != 0 || Progress.instance.playerAutorizationState)
            SetMenuState();
    }
    
    public void SetAutoState(string state)
    {
        Progress.instance.playerAutorizationState = ConvertString(state);

        if (Progress.instance.playerAutorizationState)
        {
            _save = Progress.instance.save;
            Progress.instance.Load();            
        }            
    }

    private void CheckSave()
    {
        if (_save != null && (Progress.instance.save.level > 0 ||
                Progress.instance.save.GetCountStars() > 0))
        {
            messegeBox.SetActive(true);
        }
    }

    public void loadOld()
    {
        Progress.instance.save = _save;
        _save = null;
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
