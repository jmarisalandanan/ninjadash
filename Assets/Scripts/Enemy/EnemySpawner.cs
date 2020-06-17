using UnityEngine;

namespace MagicSpace.NinjaDash
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField]
        private Enemy enemyPrefab;
        [SerializeField]
        private EnemyUnityEvent OnEnemySpawn;

        public void SpawnEnemy(Transform point)
        {
            var spawn = GameObject.Instantiate(enemyPrefab, point);
            var spawnPos = transform.position;
            spawnPos.y += Random.Range(1, 5);
            if (point.position.x >= 0)
            {
                spawnPos.x = 5;
            }
            else
            {
                spawnPos.x = -5;
            }
            spawn.transform.position = spawnPos;
            spawn.Spawn(point.position);

            OnEnemySpawn.Invoke(spawn);
        }

    }
}
