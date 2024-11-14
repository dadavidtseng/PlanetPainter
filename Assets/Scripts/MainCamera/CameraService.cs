using UnityEngine;
using Zenject;

namespace MainCamera
{
    public class CameraService : ICameraService
    {
        [Inject] private readonly CameraView view;

        public void      SetCameraPosition(Vector3 targetPosition) => view.SetCameraPosition(targetPosition);
        public Transform GetCameraTransform()                      => view.GetCameraTransform();
        public void      ResetCameraPosition()                     => view.ResetCameraPosition();
    }
}