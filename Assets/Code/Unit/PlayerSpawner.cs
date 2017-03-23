using System.Collections;
using System.Collections.Generic;
using GameProgramming1.Data;
using UnityEngine;

namespace GameProgramming1
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] private Transform[] _spawnPoints;

        public PlayerUnit CreateAndSpawnPlayer(PlayerData.PlayerId id, PlayerUnit unitPrefab, Transform parentTransform)
        {
            PlayerUnit playerUnit = null;

            if ((int) id <= 0) return null;

            Vector3 spawnPoint = Vector3.zero;
            bool pointFound = false;

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

        public void ReSpawnPlayer(PlayerUnit unit)
        {
            PlayerData.PlayerId id = unit.Data.Id;

            if ((int) id <= 0) return;

            var spawnPoint = _spawnPoints[(int) id - 1].position;

            unit.transform.position = spawnPoint;
        }
    }
}