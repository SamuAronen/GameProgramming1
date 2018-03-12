﻿using System.Collections;
using System.Collections.Generic;
using GameProgramming1.Utility;
using UnityEngine;

namespace GameProgramming1
{
    public abstract class UnitBase : MonoBehaviour
    {
        #region Properties

        public IHealth Health { get; protected set; }
        public IMover Mover { get; protected set; }
        public WeaponController Weapons { get; protected set; }

        #endregion

        #region Unity Messages

        #endregion

        #region Public interface

        public void TakeDamage(int amount)
        {
            if (Health.TakeDamage(amount))
            {
                Die();
            }
        }

        #endregion

        #region Abstracts

        public abstract int ProjectileLayer { get; }

        #endregion

        protected void InitRequiredComponents()
        {
            Health = gameObject.GetOrAddComponent<Health>();
            Mover = gameObject.GetOrAddComponent<Mover>();
            Weapons = gameObject.GetComponentInChildren<WeaponController>();
            Health.HealthChanged += HealthChanged;

            if (Weapons != null)
            {
                Weapons.Init();
            }
        }

        private void HealthChanged(object sender, HealthChangedEventArgs args)
        {
            if (args.CurrentHealth <= 0)
            {
                Die();
            }
        }

        protected virtual void Die()
        {
            Health.HealthChanged -= HealthChanged;

        }
    }
}