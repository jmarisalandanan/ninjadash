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
        private float maxKnockbackDistance;
        [SerializeField]
        private IntVariable playerMoves;

        private bool isDashing = false;
        private bool isKnockBack = false;

        private Vector3 dashOriginPos;
        private Vector3 lastDashDir;

        private Rigidbody2D thisRigidbody;
        private Transform thisTransform;

        public UnityEvent OnDash;

        public void Dash(Vector3 direction)
        {
            if (playerMoves == null || playerMoves.Value <= 0)
            {
                return;
            }

            if (isDashing || isKnockBack)
            {
                return;
            }

            Stop();

            isDashing = true;
            lastDashDir = direction;
            dashOriginPos = thisTransform.position;
            thisRigidbody.AddForce(direction * dashPower, ForceMode2D.Impulse);
            OnDash.Invoke();
        }

        public void Stop()
        {
            thisRigidbody.velocity = Vector3.zero;
            isDashing = false;
            isKnockBack = false;
        }

        public void KnockBack()
        {
            Stop();
            dashOriginPos = thisTransform.position;
            thisRigidbody.AddForce((lastDashDir * (dashPower)) * -1f, ForceMode2D.Impulse);
            isKnockBack = true;
        }

        private void CheckDashDistance(float distance)
        {
            var currentDist = Vector3.Distance(dashOriginPos, thisTransform.position);
            if (currentDist >= distance)
            {
                Stop();
            }
        }

        private void Awake()
        {
            Debug.Assert(dashPower > 0, "dashPower must be a value higher than zero!");
            thisRigidbody = this.GetComponent<Rigidbody2D>();
            thisTransform = transform;
        }

        private void Update()
        {
            if (isDashing)
            {
                CheckDashDistance(maxDashDistance);
            }
            if (isKnockBack)
            {
                CheckDashDistance(maxKnockbackDistance);
            }
        }
    }
}
