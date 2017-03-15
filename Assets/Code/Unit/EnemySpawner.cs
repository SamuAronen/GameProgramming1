using System.Collections;
using System.Collections.Generic;
using GameProgramming1.Systems;
using GameProgramming1.WaypointSystem;
using UnityEngine;

namespace GameProgramming1.Level
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyUnit _enemyPrefab;
        [SerializeField] private float _spawnInterval = 1f;
        [SerializeField] private int _maxAmount;
        [SerializeField] private Path _path;

        private EnemyUnits _enemyUnits;
        private int _spawnCount = 0;

        public void Init(EnemyUnits enemyUnits)
        {
            _enemyUnits = enemyUnits;
            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            while (_spawnCount <= _maxAmount)
            {
                //EnemyUnit enemyUnit = Instantiate(_enemyPrefab,transform.position,Quaternion.identity);

                EnemyUnit enemyUnit = Global.Instance.Pools.AsteroidPool.GetPooledObject();
                enemyUnit.transform.position = transform.position;
                enemyUnit.transform.rotation = Quaternion.identity;

                enemyUnit.gameObject.SetActive(true);

                enemyUnit.Init(_enemyUnits,_path);
                _spawnCount++;

                yield return new WaitForSeconds(_spawnInterval);
            }
        }

    }
}