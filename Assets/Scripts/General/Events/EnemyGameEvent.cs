using System.Collections.Generic;
using UnityEngine;

namespace MagicSpace.NinjaDash
{
    [CreateAssetMenu(menuName = "GameEvents/EnemyEvent")]
    public class EnemyGameEvent : ScriptableObject
    {
        private List<EnemyGameEventListener> listeners = new List<EnemyGameEventListener>();
        public void Raise(Enemy enemy)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
                listeners[i].OnEventRaised(enemy);
        }

        public void RegisterListener(EnemyGameEventListener listener)
        {
            listeners.Add(listener);
        }

        public void UnRegisterListener(EnemyGameEventListener listener)
        {
            listeners.Remove(listener);
        }
    }
}
