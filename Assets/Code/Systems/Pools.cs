using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameProgramming1.Systems
{
    public class Pools : MonoBehaviour
    {
        [SerializeField] private List<ProjectilePool> _projectilePools = new List<ProjectilePool>();

        [SerializeField] private AsteroidPool _asteroidPool;

        public void Init()
        {
            _asteroidPool.Init();
            foreach (var projectilePool in _projectilePools)
            {
               
                projectilePool.Init();
            }
        }

        public AsteroidPool AsteroidPool { get { return _asteroidPool; } }


        public ProjectilePool GetPool(Projectile.ProjectileType projectileType)
        {
            ProjectilePool result = null;
            foreach (var projectilePool in _projectilePools)
            {
                if (projectilePool.ProjectileType == projectileType)
                {
                    result = projectilePool;
                    break;
                }
            }

            return result;
        }
    }
}