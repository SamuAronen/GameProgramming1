﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameProgramming1.Configs;
using GameProgramming1.Utility;
using GameProgramming1.WaypointSystem;
using UnityEngine;

namespace GameProgramming1
{
    public class EnemyUnit : UnitBase
    {

        private IPathUser _pathUser;

        public EnemyUnits EnemyUnits{get; private set; }

        public override int ProjectileLayer
        {
            get { return LayerMask.NameToLayer(Config.EnemyProjectileLayerName); }
        }

        public void Init(EnemyUnits enemyUnits, Path path)
        {
            InitRequiredComponents();
            EnemyUnits = enemyUnits;
            _pathUser = gameObject.GetOrAddComponent<PathUser>();

            _pathUser.Init(Mover, path);
        }

        protected override void Die()
        {
            // Handle dying properly. Instantiat explosion, play sound effect etc
            gameObject.SetActive(false);
            EnemyUnits.EnemyDied(this);

            base.Die();
        }
    }
}