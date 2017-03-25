using System.Collections;
using System.Collections.Generic;
using GameProgramming1.Data;
using UnityEngine;

namespace GameProgramming1
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] private Transform[] _spawnPoints;

        /// <summary>
        /// Spawns and instantiates the given player unit to the world
        /// </summary>
        /// <param name="id">Id of the player which will be instantiated</param>
        /// <param name="unitPrefab">Unit type prefab which will be instantiated</param>
        /// <param name="parentTransform">Transform in the scene to which the unit will be set as child</param>
        /// <returns>The instantiated unit</returns>
        public PlayerUnit CreateAndSpawnPlayer(PlayerData.PlayerId id, PlayerUnit unitPrefab, Transform parentTransform)
        {
            PlayerUnit playerUnit = null;

            if ((int) id <= 0) return null;

            Vector3 spawnPoint = Vector3.zero;
            bool pointFound = false;

            // Find spawn position which matches player ID
            if (_spawnPoints[(int) id - 1] != null)
            {
                spawnPoint = _spawnPoints[(int) id - 1].position;

                pointFound = true;
            }

            Debug.Log("point found");

            if (pointFound)
            {
                playerUnit = Instantiate(unitPrefab, spawnPoint, Quaternion.identity, parentTransform);
            }
            else
            {
                Debug.LogError("Could not find a spawn point for the given player ID!");
            }

            return playerUnit;
        }

        /// <summary>
        /// Moves the player back to it's spawn position
        /// </summary>
        /// <param name="unit">The unit which will be moved back</param>
        public void ReSpawnPlayer(PlayerUnit unit)
        {
            PlayerData.PlayerId id = unit.Data.Id;

            if ((int) id <= 0) return;

            // Get the correct spawning position according to the player ID
            var spawnPoint = _spawnPoints[(int) id - 1].position;

            unit.transform.position = spawnPoint;
        }
    }
}