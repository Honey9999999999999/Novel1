using Fungus;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            character.GetComponent<Character>().SetNameText(Progress.instance.save.playerInfo.playerName);

            foreach (var playerName in playerNames)
            {
                playerName.text = Progress.instance.save.playerInfo.playerName;
            }
        }
    }
}
