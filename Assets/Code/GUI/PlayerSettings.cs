using GameProgramming1.Systems;
using UnityEngine;
using UnityEngine.UI;


namespace GameProgramming1.GUI
{
    public class PlayerSettings : Window
    {
        [SerializeField] private Dropdown _playerCountDropdown;
        [SerializeField] private PlayerSettingsItem[] _items;

        private MenuManager _menuManager;

        public void Init(MenuManager menuManager)
        {
            // Todo Init player co8nt dropdown

            _menuManager = menuManager;


            foreach (var playerSettingsItem in _items)
            {
                playerSettingsItem.Init();
            }

        }
    }
}