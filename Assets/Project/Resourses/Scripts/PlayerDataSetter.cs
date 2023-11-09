using Fungus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace Assets.Project.Resourses.Scripts
{
    public class PlayerDataSetter : MonoBehaviour
    {
        [SerializeField] private Character character;
        [SerializeField] private List<Text> playerNames;
        

        private void Start()
        {            
            SetName();
        }

        public void SetName() 
        {
            character.GetComponent<Character>().SetNameText(MainCharacterData.namePlayer);

            foreach (var playerName in playerNames)
            {
                playerName.text = MainCharacterData.namePlayer;
            }
        }
    }
}
