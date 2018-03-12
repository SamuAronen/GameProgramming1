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

        public InputMethodType Controller
        {
            get { return _controllerSelector.Controller; }
        }

        public PlayerUnit.UnitType UnitType
        {
            get { return _playerUnitSelector.SelectedUnitType; }
        }

        public PlayerData.PlayerId PlayerId { get { return _id; } }

        public void Init()
        {
            _controllerSelector = GetComponentInChildren<ControllerSelector>(true);

            _controllerSelector.Init(_id, InputMethodType.KeyboardArrows);


            _playerUnitSelector = GetComponentInChildren<PlayerUnitSelector>();
            _playerUnitSelector.Init(_id);

            _playerIdText.text = string.Format("Player {0}", (int) _id);
        }
    }
}