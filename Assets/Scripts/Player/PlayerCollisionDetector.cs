using UnityEngine;
using UnityEngine.Events;

namespace MagicSpace.NinjaDash
{
    public class PlayerCollisionDetector : MonoBehaviour
    {
        [SerializeField]
        private LayerMask layerToDetect;

        [SerializeField]
        private GameObjectUnityEvent OnCollision;

        void OnCollisionEnter2D(Collision2D collision)
        {
            if ((layerToDetect.value & 1 << collision.gameObject.layer) != 0)
            {
                OnCollision.Invoke(collision.gameObject);
            }
        }
    }
}
