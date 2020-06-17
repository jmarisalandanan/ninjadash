using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace MagicSpace.NinjaDash
{
    public class IntVariableDisplay : MonoBehaviour
    {
        [SerializeField]
        private IntVariable intVariable;
        [SerializeField]
        private TextMeshProUGUI textDisplay;
        [SerializeField]
        private bool initOnAwake = true;

        public void InitializeIntVariable()
        {
            intVariable.InitValue();
        }

        public void SetDisplay()
        {
            textDisplay.text = intVariable.Value.ToString();
        }

        private void Awake()
        {
            if (initOnAwake)
            {
                intVariable.InitValue();
            }
        }

        private void OnEnable()
        {
            intVariable.OnValueUpdated += SetDisplay;
        }

        private void OnDisable()
        {
            intVariable.OnValueUpdated -= SetDisplay;
        }
    }
}
