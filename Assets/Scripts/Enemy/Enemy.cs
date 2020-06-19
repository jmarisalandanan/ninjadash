using UnityEngine;
using UnityEngine.Events;
using Timers;

namespace MagicSpace.NinjaDash
{
    [RequireComponent(typeof(EnemyMovement))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField]
        private FloatVariable counterDurationVariable;

        public VectorUnityEvent OnEnemyMove;
        public EnemyUnityEvent OnEnemyDie;
        public UnityEvent OnCounterPrepare;
        public UnityEvent OnCounterStart;
        public UnityEvent OnCounter;
        public EnemyUnityEvent OnCounterEnd;

        private bool isCountering = false;
        private bool isDead = false;

        public bool IsDead { get { return isDead; } }

        public void Spawn(Vector3 targetPos)
        {
            OnEnemyMove.Invoke(targetPos);
        }

        public void Hit()
        {
            if (isCountering)
            {
                OnCounter.Invoke();
            }
            else
            {
                OnEnemyDie.Invoke(this);
                isDead = true;
            }
        }

        public void PrepareCounterPhase()
        {
            OnCounterPrepare.Invoke();
            TimersManager.SetTimer(this, counterDurationVariable.Value / 2, StartCounter);
        }

        public void EndCounteringPhase()
        {
            isCountering = false;
            OnCounterEnd.Invoke(this);
        }

        private void StartCounter()
        {
            OnCounterStart.Invoke();
            isCountering = true;
            TimersManager.SetTimer(this, counterDurationVariable.Value, EndCounteringPhase);
        }

        private void Awake()
        {
            Debug.Assert(counterDurationVariable != null, "Counter duration variable is null");
            counterDurationVariable.InitValue();
        }
    }
}
