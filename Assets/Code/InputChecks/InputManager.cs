using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using GameProgramming1.Configs;
using UnityEngine;

namespace GameProgramming1.InputChecks
{

    public enum InputMethodType
    {
        KeyboardArrows,
        KeyboardWasd,
        Joy1

    }

    [RequireComponent(typeof(PlayerUnit))]
    public class InputManager : MonoBehaviour
    {
     

        public InputMethodType InputMethod{ set { _inputMethod = value; }  }

        private InputMethodType _inputMethod;
        private PlayerUnit _playerUnit;
        private string _horizontalAxisName;
        private string _verticalAxisName;
        private string _shootButton;



        // Use this for initialization
        void Awake()
        {
            _playerUnit = GetComponent<PlayerUnit>();
        }

        void Start()
        {
            switch (_inputMethod)
            {
                    case InputMethodType.KeyboardArrows:
                    _horizontalAxisName = Config.InputArrowHorizontalName;
                    _verticalAxisName = Config.InputArrowVerticalName;
                    _shootButton = Config.InputArrowShootName;

                    break;

                case InputMethodType.KeyboardWasd:
                    _horizontalAxisName = Config.InputWasdHorizontalName;
                    _verticalAxisName = Config.InputWasdVerticalName;
                    _shootButton = Config.InputWasdShootName;

                    break;

                case InputMethodType.Joy1:
                    _horizontalAxisName = Config.InputArrowHorizontalName;
                    _verticalAxisName = Config.InputArrowVerticalName;
                    break;

            }

        }

        // Update is called once per frame
        void Update()
        {


            bool shoot = Input.GetButton(_shootButton);
            float horizontalMovement = Input.GetAxis(_horizontalAxisName);
            float verticalMovement = Input.GetAxis(_verticalAxisName);


            _playerUnit.UpdateUnit(horizontalMovement,verticalMovement, shoot);

        }
    }
}