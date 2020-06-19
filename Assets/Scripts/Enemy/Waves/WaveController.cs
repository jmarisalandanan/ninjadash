using UnityEngine;
using System.Collections.Generic;
using MagicSpace.Extensions;

namespace MagicSpace.NinjaDash
{
    public class WaveController : MonoBehaviour
    {
        // Change to use IntVariable
        private const int COUNTERING_ENEMY_PER_WAVE = 1;

        [SerializeField]
        private List<Transform> spawnPosition;

        [SerializeField]
        private EnemySpawner enemySpawner;

        private List<Enemy> waveEnemies = new List<Enemy>();

        public void SpawnWave()
        {
            foreach (var point in spawnPosition)
            {
                var enemy = enemySpawner.SpawnEnemy(point);
                waveEnemies.Add(enemy);
            }
            InitiateCountering();
        }

        private void InitiateCountering()
        {
            // Get Random enemy
            waveEnemies.FYShuffle();
            for (int i = 0; i < COUNTERING_ENEMY_PER_WAVE; i++)
            {
                var enemy = waveEnemies[i];
                if (!enemy.IsDead)
                {
                    enemy.PrepareCounterPhase();
                    enemy.OnCounterEnd.AddListener(EnemyCounterEnds);
                }
            }
        }

        private void EnemyCounterEnds(Enemy enemy)
        {
            enemy.OnCounterEnd.RemoveListener(EnemyCounterEnds);
            InitiateCountering();
        }

        private void Awake()
        {
            waveEnemies.Clear();
            SpawnWave();
        }
    }
}
