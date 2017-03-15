using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameProgramming1.Level;
using UnityEngine;

namespace GameProgramming1.Level
{
    class EnemiesKilledCondition : ConditionBase
    {
        [SerializeField] private int _enemyCount;

        private int _enemiesKilled;


        protected override void Initialize()
        {
            LevelManager.EnemyUnits.EnemyDestroyed += HandleEnemyDestroyed;
        }

        private void HandleEnemyDestroyed(EnemyUnit enemy)
        {
            _enemiesKilled++;

            if (_enemiesKilled >= _enemyCount)
            {
                IsConditionMet = true;
                LevelManager.ConditionMet(this);
            }
        }
    }
}
