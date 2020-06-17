using UnityEngine;
using System;

namespace MagicSpace.NinjaDash
{
    [CreateAssetMenu(menuName = "Config/Variables/Int")]
    public class IntVariable : ScriptableObject
    {
        [SerializeField]
        private int value;

        private int localVal;

        public int Value { get { return localVal; } }

        public event Action OnValueUpdated;

        public void InitValue()
        {
            localVal = value;
        }

        public void SetValue(int valueSet)
        {
            localVal = valueSet;
            if (OnValueUpdated != null)
            {
                OnValueUpdated();
            }
        }

        public void AddValue(int valueToAdd)
        {
            localVal += valueToAdd;
            if (OnValueUpdated != null)
            {
                OnValueUpdated();
            }
        }
    }
}
