using UnityEngine;
using UnityEngine.UI;

namespace MagicSpace.NinjaDash
{
    public class FloatVariableFillBarDisplay : MonoBehaviour
    {
        [SerializeField]
        private FloatVariable floatVariable;

        [SerializeField]
        private Image fillBar;

        private void OnValueUpdated()
        {
            fillBar.fillAmount = floatVariable.Value / floatVariable.DefaultValue;
        }

        private void Awake()
        {
            floatVariable.InitValue();
        }

        private void OnEnable()
        {
            floatVariable.OnValueUpdated += OnValueUpdated;
        }

        private void OnDisable()
        {
            floatVariable.OnValueUpdated -= OnValueUpdated;
        }
    }
}
