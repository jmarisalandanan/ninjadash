using UnityEngine;
using System.Collections.Generic;

namespace MagicSpace.NinjaDash
{
    public class WaveController : MonoBehaviour
    {
        [SerializeField]
        private List<Transform> spawnPosition;

        [SerializeField]
        private EnemySpawner enemySpawner;

        public void SpawnWave()
        {
            foreach (var point in spawnPosition)
            {
                enemySpawner.SpawnEnemy(point);
            }
        }

        private void Awake()
        {
            SpawnWave();
        }
    }
}
