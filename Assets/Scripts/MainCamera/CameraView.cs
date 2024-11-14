using UnityEngine;

namespace MainCamera
{
    public class CameraView : MonoBehaviour
    {
        [SerializeField] private new Camera camera;

        public void SetCameraPosition(Vector3 targetPosition)
        {
            if (camera != null)
                camera.transform.position = targetPosition;
            else
                Debug.LogWarning("PostProcessing camera is not found!");
        }

        public void ResetCameraPosition()
        {
            var targetPosition = new Vector3(0, 0, -10);

            camera!.transform.position = targetPosition;
        }

        public Transform GetCameraTransform() => camera?.transform;
    }
}