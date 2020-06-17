using UnityEngine;

namespace MagicSpace.NinjaDash
{
    [RequireComponent(typeof(Collision2D))]
    public class TriggerDetector : MonoBehaviour
    {
        [SerializeField]
        private LayerMask layerToDetect;

        [SerializeField]
        private GameObjectUnityEvent OnTriggerHit;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if ((layerToDetect.value & 1 << collision.gameObject.layer) != 0)
            {
                OnTriggerHit.Invoke(collision.gameObject);
            }
        }
    }
}
