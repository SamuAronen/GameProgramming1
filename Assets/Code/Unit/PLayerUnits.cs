using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using GameProgramming1.Data;

namespace GameProgramming1
{
    class PLayerUnits : MonoBehaviour
    {
        private Dictionary<PlayerData.PlayerId, PlayerUnit> _players = new Dictionary<PlayerData.PlayerId, PlayerUnit>();

        public void Init(params PlayerData[] players)
        {
            foreach (PlayerData playerData in players)
            {
               // Get Prefab by UnitType
               // Initialize unit
               // Add player to dictionary
            }
        }
    }
}