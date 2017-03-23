using System.Collections;
using System.Collections.Generic;
using GameProgramming1.Systems;
using UnityEngine;

namespace GameProgramming1.Level
{
    public abstract class ConditionBase : MonoBehaviour
    {
        protected bool _conditionProcessing = false;

      public LevelManager LevelManager { get; private set; }

        public bool IsConditionMet { get; protected set; }

        public void Init(LevelManager levelManager)
        {
            LevelManager = levelManager;
            Initialize();
        }

        public void ConditionProcessFinished()
        {
            _conditionProcessing = false;
        }

        protected abstract void Initialize();
    }
}