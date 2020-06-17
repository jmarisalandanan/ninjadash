using UnityEngine;

namespace MagicSpace.NinjaDash
{
    public class EnemyMovement : MonoBehaviour
    {
        private float currentMoveTime;
        private float totalMoveTime;
        private bool isMoving = false;
        private Vector3 startPosition;
        private Vector3 targetPosition;

        public void Move(Vector3 toPosition)
        {
            startPosition = transform.position;
            targetPosition = toPosition;
            totalMoveTime = Random.Range(0.3f, 0.6f);
            currentMoveTime = 0;
            isMoving = true;
        }

        private void LerpToPosition()
        {
            currentMoveTime += Time.deltaTime;
            if (currentMoveTime > totalMoveTime)
            {
                currentMoveTime = totalMoveTime;
                isMoving = false;
            }

            var lerpPercentage = currentMoveTime / totalMoveTime;
            transform.position = Vector3.Lerp(startPosition, targetPosition, lerpPercentage);
        }

        private void Update()
        {
            if (isMoving)
            {
                LerpToPosition();
            }
        }
    }
}
