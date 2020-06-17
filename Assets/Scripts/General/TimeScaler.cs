using UnityEngine;

namespace MagicSpace.NinjaDash
{
    public class TimeScaler : MonoBehaviour
    {
        private float currentLerpTime;
        private float maxLerpTime = 0.3f;
        private float targetScale;
        private float initialScale;
        private bool isLerping = false;

        public void ChangeTimeScale(float toScale)
        {
            Time.timeScale = toScale;
        }

        public void LerpTimeScale(float toScale)
        {
            initialScale = Time.timeScale;
            currentLerpTime = 0f;
            targetScale = toScale;
            isLerping = true;
        }

        private void Awake()
        {
            Time.timeScale = 1;
        }

        private void Update()
        {
            if (isLerping)
            {
                currentLerpTime += Time.unscaledDeltaTime;
                if (currentLerpTime >= maxLerpTime)
                {
                    currentLerpTime = maxLerpTime;
                }
                var perc = currentLerpTime / maxLerpTime;
                Time.timeScale = Mathf.Lerp(initialScale, targetScale, perc);
            }
        }
    }
}
