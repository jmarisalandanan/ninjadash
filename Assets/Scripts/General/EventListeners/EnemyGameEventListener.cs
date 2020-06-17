using UnityEngine;

namespace MagicSpace.NinjaDash
{
    public class EnemyGameEventListener : MonoBehaviour
    {
        public EnemyGameEvent gameEvent;
        public EnemyUnityEvent response;

        private void OnEnable()
        {
            gameEvent.RegisterListener(this);
        }
        private void OnDisable()
        {
            gameEvent.UnRegisterListener(this);
        }

        public void OnEventRaised(Enemy enemy)
        {
            response.Invoke(enemy);
        }
    }
}
