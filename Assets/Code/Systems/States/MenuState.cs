using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameProgramming1.Configs;

namespace GameProgramming1.Systems.States
{
    public class MenuState : GameStateBase
    {
        public override string SceneName
        {
            get { return Config.MenuSceneName; }
        }


        public MenuState()
        {
            State = GameStateType.MenuState;
            AddTransition(GameStateTransitionType.MenuToInGame, GameStateType.InGameState);
        }
    }
}
