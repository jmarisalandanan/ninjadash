using UnityEngine;
using Cinemachine;

namespace MagicSpace.NinjaDash
{
    [RequireComponent(typeof(CinemachineVirtualCamera))]
    public class CameraZoomer : CinemachineExtension
    {
        private CinemachineVirtualCamera virtualCamera;
        private bool isLerping = false;
        private float currentLerpTime;
        private float maxLerpTime = 0.7f;
        private float initialZoomAmount;
        private float targetZoomAmount;

        public void ZoomLerp(float zoomValue)
        {
            initialZoomAmount = virtualCamera.m_Lens.OrthographicSize;
            currentLerpTime = 0;
            targetZoomAmount = zoomValue;
            isLerping = true;
        }

        protected override void Awake()
        {
            base.Awake();
            virtualCamera = this.GetComponent<CinemachineVirtualCamera>();
        }

        protected override void PostPipelineStageCallback(
            CinemachineVirtualCameraBase vcam,
            CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
        {
            if (isLerping)
            {
                currentLerpTime += Time.fixedDeltaTime;
                if (currentLerpTime >= maxLerpTime)
                {
                    currentLerpTime = maxLerpTime;
                }

                var perc = currentLerpTime / maxLerpTime;
                virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(initialZoomAmount, targetZoomAmount, perc);
            }
        }
    }
}
