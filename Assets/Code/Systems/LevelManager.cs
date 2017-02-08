﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using GameProgramming1.Data;

namespace GameProgramming1.Systems
{
    public class LevelManager : SceneManager
    {

        // Add reference to InputManager here
        public PlayerUnits PlayerUnits { get; private set; }
        public EnemyUnits EnemyUnits { get; private set; }

        protected void Awake()
        {
            Initialize();
            
        }

        private void Initialize()
        {
            PlayerUnits = GetComponentInChildren<PlayerUnits>();
            EnemyUnits = GetComponentInChildren<EnemyUnits>();

            // Get player data from GameManager (new data or savd data)
            PlayerData playerData = new PlayerData()
            {
                Id = PlayerData.PlayerId.Player1,
                UnitType = PlayerUnit.UnitType.Heavy,
                Lives = 3
            };

            PlayerUnits.Init(playerData);
            EnemyUnits.Init();
        }
    }
}