using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameProgramming1.Systems
{
    public class MenuManager : SceneManager
    {
        public void StartGame()
        {
            Global.Instance.GameManager.PerformTransition(GameStateTransitionType.MenuToInGame);
        }

        public void LoadGame()
        {
            
        }


        public void QuitGame()
        {
            Application.Quit();
        }

        public override GameStateType StateType
        {
            get { return  GameStateType.MenuState;}
        }
    }
}