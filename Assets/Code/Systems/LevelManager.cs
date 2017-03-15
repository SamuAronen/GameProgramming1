using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using GameProgramming1.Data;
using GameProgramming1.InputChecks;
using GameProgramming1.Level;
using GameProgramming1.Systems.States;

namespace GameProgramming1.Systems
{
    public class LevelManager : SceneManager
    {
        private ConditionBase[] _conditions;
        private EnemySpawner[] _enemySpawners;

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

            PlayerData[] playerDatas = Global.Instance.CurrentGameData.PlayerDatas.ToArray();

            PlayerUnits.Init(playerDatas);


            // Gets player data from GameManager (new data or saved data)

            // Currently Creates players and sets their input type here
            //PlayerData playerData1 = new PlayerData()
            //{
            //    Id = PlayerData.PlayerId.Player1,
            //    UnitType = PlayerUnit.UnitType.Heavy,
            //    Lives = 3,
            //    InputMethodType = InputMethodType.KeyboardArrows
            //};

            //PlayerData playerData2 = new PlayerData()
            //{
            //    Id = PlayerData.PlayerId.Player2,
            //    UnitType = PlayerUnit.UnitType.Fast,
            //    Lives = 3,
            //    InputMethodType = InputMethodType.KeyboardWasd
            //};

            //PlayerData playerData3 = new PlayerData()
            //{
            //    Id = PlayerData.PlayerId.Player3,
            //    UnitType = PlayerUnit.UnitType.Balanced,
            //    Lives = 3,
            //    InputMethodType = InputMethodType.Joy1
            //};

            //PlayerData playerData4 = new PlayerData()
            //{
            //    Id = PlayerData.PlayerId.Player4,
            //    UnitType = PlayerUnit.UnitType.Heavy,
            //    Lives = 3,
            //    InputMethodType = InputMethodType.Joy2
            //};

            //PlayerUnits.Init(playerData1, playerData2, playerData3, playerData4);
            EnemyUnits.Init();

            _enemySpawners = GetComponentsInChildren<EnemySpawner>();
            foreach (var enemySpawner in _enemySpawners)
            {
                enemySpawner.Init(EnemyUnits);
            }

            // All conditions should be parented to LevelManager
            _conditions = GetComponentsInChildren<ConditionBase>();
            foreach (var condition in _conditions)
            {
                condition.Init(this);
            }

         
        }

        public void ConditionMet(ConditionBase condition)
        {
            bool areConditionsMet = true;

            foreach (ConditionBase c in _conditions)
            {
                if (!c.IsConditionMet)
                {
                    areConditionsMet = false;
                    break;
                }
            }

            if (areConditionsMet)
            {
                (AssociatedState as GameState).LevelCompleted();
            }
        }
    }
}