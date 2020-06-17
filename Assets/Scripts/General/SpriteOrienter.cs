using UnityEngine;

namespace MagicSpace.NinjaDash
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteOrienter : MonoBehaviour
    {
        private SpriteRenderer spriteToOrient;

        public void FaceDirection(Vector3 direction)
        {
            if (direction.x < 0)
            {
                spriteToOrient.flipX = true;
            }
            else
            {
                spriteToOrient.flipX = false;
            }
        }

        public void FaceTarget(Vector3 target)
        {
            var direction = (target - transform.position).normalized;
            FaceDirection(direction);
        }

        private void Awake()
        {
            spriteToOrient = this.GetComponent<SpriteRenderer>();
        }
    }
}
