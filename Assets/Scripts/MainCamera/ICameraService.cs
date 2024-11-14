using UnityEngine;

namespace MainCamera
{
    public interface ICameraService
    {
        void SetCameraPosition(Vector3 targetPosition);
        Transform GetCameraTransform();
        void ResetCameraPosition();
    }
}