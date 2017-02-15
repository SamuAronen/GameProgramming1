using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameProgramming1.Systems.States;
using UnityEngine;

namespace GameProgramming1.Systems
{
    public abstract class SceneManager : MonoBehaviour
    {
        private GameStateBase _associatedState;

        public abstract GameStateType StateType { get; }

        public virtual GameStateBase AssociatedState
        {
            get
            {
                if (_associatedState == null)
                {
                    _associatedState = Global.Instance.GameManager.GetStateByStateType(StateType);
                }
                return _associatedState;
            }
        }
    }
}