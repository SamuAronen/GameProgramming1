using System.Collections;
using System.Collections.Generic;
using GameProgramming1.Data;
using GameProgramming1.InputChecks;
using UnityEngine;

namespace GameProgramming1.Systems
{
    public class MenuManager : SceneManager
    {
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
                    }
                }
            };

            Debug.Log
            (
                "Loading game, wait for 5sec");
            Global.Instance.GameManager.PerformTransition
                (GameStateTransitionType.MenuToInGame);
        }

        public
            void LoadGame()
        {
        }


        public
            void QuitGame()
        {
            Application.Quit
                ();
        }

        public override
            GameStateType StateType
        {
            get { return GameStateType.MenuState; }
        }
    }
}