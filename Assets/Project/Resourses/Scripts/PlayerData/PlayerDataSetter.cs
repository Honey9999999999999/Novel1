using Fungus;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Project.Resourses.Scripts
{
    public class PlayerDataSetter : MonoBehaviour
    {
        [SerializeField] private Character player;
        [SerializeField] private List<Text> playerNames;

        private void OnEnable()
        {
            SaveManager.OnVarLoaded += SetName;
        }
        private void OnDisable()
        {
            SaveManager.OnVarLoaded -= SetName;
        }

        public void SetName() 
        {
            if (player == null)
                throw new Exception("Player is not find");

            player.SetNameText(Progress.instance.save.playerInfo.playerName);

            foreach (var playerName in playerNames)
            {
                playerName.text = Progress.instance.save.playerInfo.playerName;
            }
        }
    }
}
