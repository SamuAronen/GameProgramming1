using GameProgramming1.Data;
using GameProgramming1.InputChecks;
using GameProgramming1.Systems;
using UnityEngine;
using UnityEngine.UI;


namespace GameProgramming1.GUI
{
    public class PlayerSettingsItem : MonoBehaviour
    {

        [SerializeField] private PlayerData.PlayerId _id;
        [SerializeField] private Text _playerIdText;

        private ControllerSelector _controllerSelector;
        private PlayerUnitSelector _playerUnitSelector;
        public void Init()
        {
            _controllerSelector = GetComponentInChildren<ControllerSelector>(true);

            _controllerSelector.Init(_id,InputMethodType.KeyboardArrows);

            _playerIdText.text = string.Format("Player {0}", (int) _id);

            _playerUnitSelector = GetComponentInChildren<PlayerUnitSelector>();
            _playerUnitSelector.Init();
        }
    }
}