using UnityEngine;

namespace MagicSpace.NinjaDash
{
    [RequireComponent(typeof(EnemyMovement))]
    public class Enemy : MonoBehaviour
    {
        public VectorUnityEvent OnEnemyMove;
        public EnemyUnityEvent OnEnemyDie;

        public void Spawn(Vector3 targetPos)
        {
            OnEnemyMove.Invoke(targetPos);
        }

        public void Die()
        {
            OnEnemyDie.Invoke(this);
        }

    }
}
