using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Project.Resourses.Scripts
{
    public class PlayerDataGetter : MonoBehaviour
    {
        [SerializeField] private Text nameText;

        public void GetName()
        {
            if (nameText.text == "")
                nameText.text = "Main Hero";

            MainCharacterData.namePlayer = nameText.text;
        }
    }
}
