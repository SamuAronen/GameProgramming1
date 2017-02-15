using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameProgramming1.Configs
{
    public static class Config
    {
        public const string MenuSceneName = "Menu";
    //    public const string

        public static readonly Dictionary<int, string> LevelNames = new Dictionary<int, string>()
        {
            {1, "Level1"},
            {2, "Level2"},

        };

        public const string PlayerProjectileLayerName = "PlayerProjectile";
        public const string EnemyProjectileLayerName = "EnemyProjectile";

        public const string InputArrowHorizontalName = "ArrowHorizontal";
        public const string InputArrowVerticalName = "ArrowVertical";
        public const string InputArrowShootName = "ArrowShoot";


        public const string InputWasdHorizontalName = "WasdHorizontal";
        public const string InputWasdVerticalName = "WasdVertical";
        public const string InputWasdShootName = "WasdShoot";


        public const string InputJoy1HorizontalName = "Joy1Horizontal";
        public const string InputJoy1VerticalName = "Joy1Vertical";

    }
}