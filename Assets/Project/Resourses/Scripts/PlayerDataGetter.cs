using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Project.Resourses.Scripts
{
    public class PlayerDataGetter : MonoBehaviour
    {
        [SerializeField] private TMP_InputField nameText;

        public void GetName()
        {
            if (!nameText.text.Equals(""))
                MainCharacterData.namePlayer = nameText.text;
        }
    }
}
