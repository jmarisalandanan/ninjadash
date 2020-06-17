using System.Collections.Generic;
using UnityEngine;

namespace MagicSpace.NinjaDash
{
    public class EnemyController : MonoBehaviour
    {
        private List<Enemy> activeEnemies = new List<Enemy>();

        public void AddEnemyToList(Enemy enemy)
        {
            activeEnemies.Add(enemy);
            enemy.OnEnemyDie.AddListener(RemoveEnemyFromList);
        }

        public void RemoveEnemyFromList(Enemy enemy)
        {
            activeEnemies.Remove(enemy);
            enemy.OnEnemyDie.RemoveListener(RemoveEnemyFromList);
        }

        public void MoveAllTo(Vector3 position)
        {
            foreach (var enemy in activeEnemies)
            {
                enemy.OnEnemyMove.Invoke(position);
            }
        }
    }
}
