﻿using System;
using Game;
using MainCamera;
using SceneTransition;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerMoveHandler : IInitializable, ITickable, IDisposable
    {
        [Inject] private readonly SignalBus          signalBus;
        [Inject] private readonly PlayerView         view;
        [Inject] private readonly PlayerStateHandler stateHandler;
        [Inject] private readonly ICameraService     cameraService;
        [Inject] private readonly ISceneService      sceneService;
        [Inject] private readonly IGameService       gameService;

        private float   moveSpeed = 5f;
        private Vector2 movement;

        public void Initialize()
        {
            signalBus.Subscribe<OnGameStateChanged>(OnGameStateChanged);
        }

        private void OnGameStateChanged(OnGameStateChanged e)
        {
            if (e.preState == GameState.Tutorial)
            {
                var targetPosition = new Vector3(view.GetPosition().x, view.GetPosition().y, -10f);

                cameraService.SetCameraPosition(targetPosition);
            }
        }

        public void Tick()
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            if (movement != Vector2.zero)
            {
                MoveCharacter();
            }
        }

        private void MoveCharacter()
        {
            if (movement.x > 0)
            {
                Move(Vector3.right);
            }
            else if (movement.x < 0)
            {
                Move(Vector3.left);
            }
            else if (movement.y > 0)
            {
                Move(Vector3.up);
            }
            else if (movement.y < 0)
            {
                Move(Vector3.down);
            }
        }

        public void Move(Vector3 direction)
        {
            if (gameService.GetGameState() != GameState.Game)
                return;
            
            view.GetTransform().position += direction * moveSpeed * Time.deltaTime;

            var targetPosition = new Vector3(view.GetTransform().position.x, view.GetTransform().position.y, -10.0f);

            cameraService.SetCameraPosition(targetPosition);
        }

        public void SetMoveSpeed(float targetSpeed) => moveSpeed = targetSpeed;

        public Vector3 GetMoveBackVelocity()
        {
            return stateHandler.GetPreState() switch
                   {
                       PlayerState.IdleUp    => Vector3.down  * 0.2f,
                       PlayerState.IdleDown  => Vector3.up    * 0.2f,
                       PlayerState.IdleLeft  => Vector3.right * 0.2f,
                       PlayerState.IdleRight => Vector3.left  * 0.2f,
                       _                     => Vector3.zero
                   };
        }

        public void Dispose()
        {
            signalBus.Unsubscribe<OnGameStateChanged>(OnGameStateChanged);
        }
    }
}