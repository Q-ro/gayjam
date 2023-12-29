using UnityEngine;
using Cinemachine;
using Scrips.PlayerInput;

namespace Scrips.Extensions
{
    public class CinemachinePOVExtension : CinemachineExtension
    {
        [SerializeField] InputManager inputManager;
        [SerializeField] private float horizontalSpeed = 10f;
        [SerializeField] private float verticalSpeed = 10f;
        [SerializeField] private float clampAngle = 80f;
        Vector3 startingRotation;

        protected override void Awake()
        {
            base.Awake();
        }

        protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
        {
            //if (vcam.Follow)
            //{
            //    if (stage == CinemachineCore.Stage.Aim)
            //    {
            //        if (startingRotation == null) startingRotation = transform.localRotation.eulerAngles;
            //        Vector2 deltaInput = inputManager.GetLookPerformed();
            //        startingRotation.x = deltaInput.x * verticalSpeed * deltaTime;
            //        startingRotation.y = deltaInput.y * horizontalSpeed * deltaTime;
            //        startingRotation.y = Mathf.Clamp(startingRotation.y, -clampAngle, clampAngle);
            //        state.RawOrientation = Quaternion.Euler(-startingRotation.y, startingRotation.x, 0f);
            //    }
            //}
        }
    }
}
