﻿using UnityEngine;

namespace GameProgramming1.Systems
{
    public class ProjectilePool : GenericPool<Projectile>
    {
        [SerializeField] private Projectile.ProjectileType _projectileType;

        public Projectile.ProjectileType ProjectileType
        {
            get { return _projectileType; }
        }


        protected override void Deactivate(Projectile item)
        {
            item.transform.position = Vector3.zero;
            item.transform.rotation = Quaternion.identity;
            item.RigidBody.velocity = Vector3.zero;

            base.Deactivate(item);
        }
    }
}