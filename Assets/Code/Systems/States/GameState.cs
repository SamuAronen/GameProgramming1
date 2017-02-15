using System.Collections.Generic;
using GameProgramming1.Configs;
using UnityEngine;

namespace GameProgramming1.Systems.States
{
    class GameState : GameStateBase
    {
        public int CurrentLevelIndex { get; private set; }

        public override string SceneName
        {
            get
            {
                try
                {
                    return Config.LevelNames[CurrentLevelIndex];
                }
                catch (KeyNotFoundException exception)
                {
                    Debug.LogException(exception);
                    return null;
                }
            }
        }

        public GameState(int levelIndex) : base()
        {
            State = GameStateType.InGameState;
            CurrentLevelIndex = levelIndex;
            AddTransition(GameStateTransitionType.InGameToGameOver, GameStateType.GameOverState);
            AddTransition(GameStateTransitionType.InGameToMenu, GameStateType.MenuState);
        }

        public GameState() : this(1)
        {
        }
    }
}