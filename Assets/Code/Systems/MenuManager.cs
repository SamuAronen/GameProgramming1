using System.Collections;
using System.Collections.Generic;
using GameProgramming1.Data;
using GameProgramming1.GUI;
using GameProgramming1.InputChecks;
using UnityEngine;

namespace GameProgramming1.Systems
{
    public class MenuManager : SceneManager
    {
        private LoadWindow _loadWindow;
        private PlayerSettings _playerSettingsWindow;
        private void Awake()
        {
            _loadWindow = GetComponentInChildren<LoadWindow>(true);
            _loadWindow.Init(this);
            _loadWindow.Close();

            _playerSettingsWindow = GetComponentInChildren<PlayerSettings>(true);
            _playerSettingsWindow.Init(this);

            // Todo

        }
        public void StartGame()
        {
            Global.Instance.CurrentGameData = new GameData()
            {
                Level = 1,
                PlayerDatas = new List<PlayerData>()
                {
                    new PlayerData()
                    {
                        Id = PlayerData.PlayerId.Player1,
                        UnitType = PlayerUnit.UnitType.Heavy,
                        Lives = 3,
                        InputMethodType = InputMethodType.KeyboardArrows
                    },
                    new PlayerData()
                    {
                        Id = PlayerData.PlayerId.Player2,
                        UnitType = PlayerUnit.UnitType.Fast,
                        Lives = 3,
                        InputMethodType = InputMethodType.KeyboardWasd
                    },

                     new PlayerData()
                    {
                        Id = PlayerData.PlayerId.Player3,
                        UnitType = PlayerUnit.UnitType.Balanced,
                        Lives = 3,
                        InputMethodType = InputMethodType.KeyboardArrows
                    },
                    new PlayerData()
                    {
                        Id = PlayerData.PlayerId.Player4,
                        UnitType = PlayerUnit.UnitType.Fast,
                        Lives = 3,
                        InputMethodType = InputMethodType.KeyboardWasd
                    }
                }
            };

            Debug.Log
            (
                "Loading game, wait for 5sec");
            Global.Instance.GameManager.PerformTransition
                (GameStateTransitionType.MenuToInGame);
        }

        public void OpenLoadWindow()
        {
            _loadWindow.Open();
        }

        public void LoadGame(string loadFileName)
        {

            _loadWindow.Close();
            GameData loadData = Global.Instance.SaveManager.Load(loadFileName);
            Global.Instance.CurrentGameData = loadData;
            Global.Instance.GameManager.PerformTransition(GameStateTransitionType.MenuToInGame);
        }


        public void QuitGame()
        {
            Application.Quit
                ();
        }

        public override GameStateType StateType
        {
            get { return GameStateType.MenuState; }
        }
    }
}