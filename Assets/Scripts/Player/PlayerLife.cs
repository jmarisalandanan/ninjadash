using UnityEngine;

namespace MagicSpace.NinjaDash
{
    public class PlayerLife : MonoBehaviour
    {
        [SerializeField]
        private IntVariable playerMoveData;
        [SerializeField]
        private FloatVariable playerLifeData;

        private bool isLifeTicking = false;

        public VectorUnityEvent OnPlayerDeath;

        public void OnMove()
        {
            playerMoveData.SetValue(playerMoveData.Value - 1);
        }

        public void OnHit()
        {
            playerMoveData.InitValue();
            playerLifeData.InitValue();
        }

        public void StartLifeTicking()
        {
            isLifeTicking = true;
        }

        private void Awake()
        {
            Debug.Assert(playerMoveData != null, "PlayerMoveData is null, please assign value in inspector");
            playerMoveData.InitValue();
            playerLifeData.InitValue();
        }

        private void Update()
        {
            if (isLifeTicking)
            {
                playerLifeData.SubtractValue(Time.deltaTime);
                if (playerLifeData.Value <= 0)
                {
                    isLifeTicking = false;
                    OnPlayerDeath.Invoke(transform.position);
                }
            }
        }
    }
}
