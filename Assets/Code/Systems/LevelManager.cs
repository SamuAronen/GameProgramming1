using System;
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

        public ConditionBase[] Conditions
        {
            get { return _conditions; }
        }

        private PlayerSpawner _playerSpawner;

        public PlayerSpawner PlayerSpawner
        {
            get { return _playerSpawner; }
        }

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

            Debug.Log("init level manager");
            PlayerUnits = GetComponentInChildren<PlayerUnits>();
            EnemyUnits = GetComponentInChildren<EnemyUnits>();
            EnemyUnits.Init();
            _playerSpawner = GetComponentInChildren<PlayerSpawner>();
            _enemySpawners = GetComponentsInChildren<EnemySpawner>();

            foreach (var enemySpawner in _enemySpawners)
            {
                enemySpawner.Init(EnemyUnits);
            }

#if UNITY_EDITOR
            if (Global.Instance.CurrentGameData == null)
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
            }
#endif

            PlayerData[] playerDatas = Global.Instance.CurrentGameData.PlayerDatas.ToArray();

            PlayerUnits.Init(_playerSpawner, playerDatas);

            // All conditions should be parented to LevelManager
            _conditions = GetComponentsInChildren<ConditionBase>();
            foreach (var condition in _conditions)
            {
                condition.Init(this);
            }

            Global.Instance.GameManager.GameStateChanged += ResetConditions;
        }

        private void ResetConditions(GameStateType obj)
        {
            foreach (ConditionBase c in _conditions)
            {
                c.ConditionProcessFinished();
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