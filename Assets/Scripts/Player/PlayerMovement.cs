using UnityEngine;
using UnityEngine.Events;

namespace MagicSpace.NinjaDash
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private float dashPower;
        [SerializeField]
        private float maxDashDistance;
        [SerializeField]
        private IntVariable playerMoves;
        [SerializeField]
        private float linearDragAfterKill;
        [SerializeField]
        private float dragDuration;

        private float currentDragTime;
        private float defaultDragValue;
        private bool isKillBufferActive = false;
        private bool isDashing = false;
        private Vector3 dashOriginPos;

        private Rigidbody2D thisRigidbody;
        private Transform thisTransform;

        public UnityEvent OnDash;

        public void Dash(Vector3 direction)
        {
            if (playerMoves == null || playerMoves.Value <= 0)
            {
                return;
            }

            if (isDashing)
            {
                return;
            }

            Stop();

            isDashing = true;
            dashOriginPos = thisTransform.position;
            thisRigidbody.AddForce(direction * dashPower, ForceMode2D.Impulse);
            OnDash.Invoke();
        }

        public void Stop()
        {
            thisRigidbody.velocity = Vector3.zero;
            isKillBufferActive = false;
            thisRigidbody.drag = defaultDragValue;
            isDashing = false;
        }

        public void KillBuffer()
        {
            thisRigidbody.drag = linearDragAfterKill;
            isKillBufferActive = true;
            currentDragTime = 0;
        }

        private void LerpKillBuffer()
        {
            currentDragTime += Time.deltaTime;
            if (currentDragTime > dragDuration)
            {
                currentDragTime = dragDuration;
                isKillBufferActive = false;
                thisRigidbody.drag = defaultDragValue;
            }

            var lerpPercentage = currentDragTime / dragDuration;
            thisRigidbody.drag = Mathf.Lerp(linearDragAfterKill, defaultDragValue, lerpPercentage);
        }

        private void CheckDashDistance()
        {
            var currentDist = Vector3.Distance(dashOriginPos, transform.position);
            if (currentDist >= maxDashDistance)
            {
                Stop();
            }
        }

        private void Awake()
        {
            Debug.Assert(dashPower > 0, "dashPower must be a value higher than zero!");
            thisRigidbody = this.GetComponent<Rigidbody2D>();
            thisTransform = transform;
            defaultDragValue = thisRigidbody.drag;
        }

        private void Update()
        {
            if (isKillBufferActive)
            {
                LerpKillBuffer();
            }

            if (isDashing)
            {
                CheckDashDistance();
            }
        }
    }
}
