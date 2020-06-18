using UnityEngine;
using UnityEngine.Events;

namespace MagicSpace.NinjaDash
{
    [RequireComponent(typeof(EnemyMovement))]
    public class Enemy : MonoBehaviour
    {
        public VectorUnityEvent OnEnemyMove;
        public EnemyUnityEvent OnEnemyDie;
        public UnityEvent OnCounterStart;
        public EnemyUnityEvent OnCounterEnd;

        public void Spawn(Vector3 targetPos)
        {
            OnEnemyMove.Invoke(targetPos);
        }

        public void Die()
        {
            OnEnemyDie.Invoke(this);
        }

        public void StartCounteringPhase()
        {
            Debug.Log("Starting counter phase");
            OnCounterStart.Invoke();
        }

        public void EndCounteringPhase()
        {
            OnCounterEnd.Invoke(this);
        }
    }
}
