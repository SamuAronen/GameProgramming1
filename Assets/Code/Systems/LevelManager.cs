using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using GameProgramming1.Data;
using GameProgramming1.InputChecks;

namespace GameProgramming1.Systems
{
    public class LevelManager : SceneManager
    {
        // Add reference to InputManager here
        public PlayerUnits PlayerUnits { get; private set; }
        public EnemyUnits EnemyUnits { get; private set; }

        public override GameStateType StateType
        {
            get { return GameStateType.InGameState; }
        }

        protected void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            PlayerUnits = GetComponentInChildren<PlayerUnits>();
            EnemyUnits = GetComponentInChildren<EnemyUnits>();

            // Get player data from GameManager (new data or savd data)
            PlayerData playerData1 = new PlayerData()
            {
                Id = PlayerData.PlayerId.Player1,
                UnitType = PlayerUnit.UnitType.Heavy,
                Lives = 3,
                InputMethodType = InputMethodType.KeyboardArrows
            };

            PlayerData playerData2 = new PlayerData()
            {
                Id = PlayerData.PlayerId.Player2,
                UnitType = PlayerUnit.UnitType.Fast,
                Lives = 3,
                InputMethodType = InputMethodType.KeyboardWasd
            };




            PlayerUnits.Init(playerData1, playerData2);
            EnemyUnits.Init();
        }
    }
}