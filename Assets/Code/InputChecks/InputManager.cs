using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using GameProgramming1.Configs;
using GameProgramming1.Systems;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace GameProgramming1.InputChecks
{
    // Control method types are added here
    public enum InputMethodType
    {
        KeyboardArrows,
        KeyboardWasd,
        Joy1,
        Joy2
    }

    [RequireComponent(typeof(PlayerUnit))] public class InputManager : MonoBehaviour
    {
        private PlayerUnit _playerUnit;
        private string _horizontalAxisName;
        private string _verticalAxisName;
        private string _shootButton;

        private bool _keys = false;

        // Use this for initialization
        void Awake()
        {
            _playerUnit = GetComponent<PlayerUnit>();
        }

        /// <summary>
        /// Setups Input method which is gotten from PlayerData and set during player instantiation
        /// </summary>
        /// <param name="inputMethod">Type of input for the player</param>
        public void InitInputMethod(InputMethodType inputMethod)
        {
            switch (inputMethod)
            {
                case InputMethodType.KeyboardArrows:
                    _horizontalAxisName = Config.InputArrowHorizontalName;
                    _verticalAxisName = Config.InputArrowVerticalName;
                    _shootButton = Config.InputArrowShootName;
                    _keys = true;
                    break;

                case InputMethodType.KeyboardWasd:
                    _horizontalAxisName = Config.InputWasdHorizontalName;
                    _verticalAxisName = Config.InputWasdVerticalName;
                    _shootButton = Config.InputWasdShootName;

                    break;

                case InputMethodType.Joy1:
                    _horizontalAxisName = Config.InputJoy1HorizontalName;
                    _verticalAxisName = Config.InputJoy1VerticalName;
                    _shootButton = Config.InputJoy1ShootName;
                    break;

                case InputMethodType.Joy2:
                    _horizontalAxisName = Config.InputJoy2HorizontalName;
                    _verticalAxisName = Config.InputJoy2VerticalName;
                    _shootButton = Config.InputJoy2ShootName;
                    break;

                default:
                    Debug.LogError("Incorrect input type for " + gameObject.name);
                    break;
            }
        }

        // Update input here
        void Update()
        {
            bool shoot = Input.GetButton(_shootButton);
            float horizontalMovement = Input.GetAxis(_horizontalAxisName);
            float verticalMovement = Input.GetAxis(_verticalAxisName);

            // Send the input to PlayerUnit
            _playerUnit.Move(horizontalMovement, verticalMovement);
            _playerUnit.Shoot(shoot);

            PollSave();
        }

        private void PollSave()
        {
            if (_keys && Input.GetKeyDown(KeyCode.F2))
            {
                Global.Instance.SaveManager.Save(Global.Instance.CurrentGameData,DateTime.Now.ToString("yyyy-MM-dd_hh--mm-ss"));
            }
        }
    }
}