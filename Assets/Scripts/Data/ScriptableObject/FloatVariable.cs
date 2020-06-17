using UnityEngine;
using System;

namespace MagicSpace.NinjaDash
{
    [CreateAssetMenu(menuName = "Config/Variables/Float")]
    public class FloatVariable : ScriptableObject
    {
        [SerializeField]
        private float value;

        private float localVal;

        public float Value { get { return localVal; } }
        public float DefaultValue { get { return value; } }

        public event Action OnValueUpdated;

        public void InitValue()
        {
            localVal = value;
        }

        public void SetValue(float valueSet)
        {
            localVal = valueSet;
            if (OnValueUpdated != null)
            {
                OnValueUpdated();
            }
        }

        public void AddValue(float valueToAdd)
        {
            localVal += valueToAdd;
            if (OnValueUpdated != null)
            {
                OnValueUpdated();
            }
        }

        public void SubtractValue(float valueToSubtract)
        {
            localVal -= valueToSubtract;
            if (OnValueUpdated != null)
            {
                OnValueUpdated();
            }
        }
    }
}
