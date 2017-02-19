using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using GameProgramming1.Data;
using GameProgramming1.InputChecks;
using GameProgramming1.Systems;

namespace GameProgramming1
{
    public class PlayerUnits : MonoBehaviour
    {
        private Dictionary<PlayerData.PlayerId, PlayerUnit> _players = new Dictionary<PlayerData.PlayerId, PlayerUnit>();

        public void Init(params PlayerData[] players)
        {
            foreach (PlayerData playerData in players)
            {
                // Get Prefab by UnitType
                PlayerUnit unitPrefab = Global.Instance.Prefabs.GetPlayerUnitPrefab(playerData.UnitType);

                if (unitPrefab != null)
                {
                    // Initialize unit
                    PlayerUnit unit = Instantiate(unitPrefab, transform);
                    unit.transform.position = Vector3.zero;
                    unit.transform.rotation = Quaternion.identity;
                    unit.GetComponent<InputManager>().InitInputMethod(playerData.InputMethodType);
                    unit.Init(playerData);


                    _players.Add(playerData.Id, unit);
                }
                else
                {
                    Debug.LogError("Unit prefab with type " +playerData.UnitType+ " could not be found!");
                }

                // Add player to dictionary
            }
        }
    }
}