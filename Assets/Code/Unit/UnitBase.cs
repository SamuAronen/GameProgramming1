using System.Collections;
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
        #endregion

        #region Unity Messages

        protected virtual void Awake()
        {
            Health = gameObject.GetOrAddComponent<Health>();
            Mover = gameObject.GetOrAddComponent<Mover>();
        }

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

        protected abstract void Die();
        public abstract int ProjectileLayer { get; }

        #endregion
    }
}