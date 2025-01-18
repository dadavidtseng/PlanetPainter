using Data;
using UnityEngine;
using Zenject;

namespace MainCamera
{
    public class CameraView : MonoBehaviour
    {
        [Inject] private readonly GameData gameData;
        
        [SerializeField] private new Camera         camera;
        [SerializeField] private     SpriteRenderer cameraFrame;
        [SerializeField] private     Sprite[]   targetSpriteList;

        private void Start()
        {
            cameraFrame.sprite = targetSpriteList[gameData.difficulty];
        }

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