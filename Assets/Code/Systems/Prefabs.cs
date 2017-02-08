using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using ProjectileType = GameProgramming1.Projectile.ProjectileType;


namespace GameProgramming1.Systems
{
    public class Prefabs : MonoBehaviour
    {
        [SerializeField] private PlayerUnit[] _playerUnitPrefabs;


        public PlayerUnit GetPlayerUnitPrefab(PlayerUnit.UnitType type)
        {
            PlayerUnit result = null;

            for (int i = 0; i < _playerUnitPrefabs.Length; i++)
            {
                if (_playerUnitPrefabs[i].Type == type)
                {
                    result = _playerUnitPrefabs[i];
                    break;
                }
            }

            // Linq
            //return _playerUnitPrefabs.FirstOrDefault(prefab => prefab.Type == type);

            return result;
        }
    }
}