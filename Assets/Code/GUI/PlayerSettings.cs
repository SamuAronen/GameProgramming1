﻿using System.Collections.Generic;
using GameProgramming1.Data;
using GameProgramming1.Systems;
using UnityEngine;
using UnityEngine.UI;
using GameProgramming1.Configs;


namespace GameProgramming1.GUI
{
    public class PlayerSettings : Window
    {
        [SerializeField] private Dropdown _playerCountDropdown;
        [SerializeField] private PlayerSettingsItem[] _items;

        private MenuManager _menuManager;

        public int PlayerCount { get; private set; }


        public void Init(MenuManager menuManager)
        {
            _playerCountDropdown.onValueChanged.AddListener(OnValueChanged);
            _playerCountDropdown.value = 0;
            OnValueChanged(0);

            _menuManager = menuManager;


            foreach (var playerSettingsItem in _items)
            {
                playerSettingsItem.Init();
            }
        }

        public void StartGame()
        {
            List< PlayerData> playerDatas = new List<PlayerData>();

            for (int i = 0; i < PlayerCount; i++)
            {
                var settingsItem = _items[i];
                var playerData = new PlayerData()
                {
                    InputMethodType = settingsItem.Controller,
                    Id = settingsItem.PlayerId,
                    UnitType = settingsItem.UnitType,
                    Lives = Config.Lives
                };

                playerDatas.Add(playerData);
            }

            _menuManager.StartGame(playerDatas);
        }

        private void OnValueChanged(int index)
        {
            PlayerCount = int.Parse(_playerCountDropdown.options[index].text);

            int playerCount;

            if (int.TryParse(_playerCountDropdown.options[index].text, out playerCount))
            {
                PlayerCount = playerCount;

                for (int i = 0; i < _items.Length; i++)
                {
                    _items[i].gameObject.SetActive(PlayerCount >= i + 1);
                }
            }
        }
    }
}