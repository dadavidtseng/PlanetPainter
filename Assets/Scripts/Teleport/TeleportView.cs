using System;
using DG.Tweening;
using MainCamera;
using Player;
using UnityEngine;
using Zenject;

namespace Teleport
{
    public class TeleportView : MonoBehaviour
    {
        [Inject] private readonly IPlayerService playerService;
        [Inject] private readonly ICameraService cameraService;

        public void OnTriggerEnter2D(Collider2D other)
        {
            var cameraTargetPos = new Vector3(14,   0,     -10);
            var playerTargetPos = new Vector3(9.5f, -0.5f, 0);

            cameraService.GetCameraTransform().DOMove(cameraTargetPos, 1.0f).SetEase(Ease.Linear);
            playerService.GetPlayerTransform().DOMove(playerTargetPos, 1.0f).SetEase(Ease.Linear);
        }
    }
}