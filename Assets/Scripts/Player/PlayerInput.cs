using UnityEngine;
using Lean.Touch;

namespace MagicSpace.NinjaDash
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField]
        private VectorUnityEvent OnPlayerSwipe;

        private void HandleFingerSwipe(LeanFinger finger)
        {
            Vector3 direction = (finger.LastScreenPosition - finger.StartScreenPosition).normalized;
            Debug.DrawLine(this.transform.position, this.transform.position + direction * 10, Color.red, 3);
            OnPlayerSwipe.Invoke(direction);
        }

        private void Awake()
        {
            LeanTouch.OnFingerSwipe += HandleFingerSwipe;
        }

        private void OnDestroy()
        {
            LeanTouch.OnFingerSwipe -= HandleFingerSwipe;
        }
    }
}
