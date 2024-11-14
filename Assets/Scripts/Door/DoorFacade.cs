using System;
using UnityEngine;
using Zenject;

namespace Door
{
    public class DoorFacade : MonoBehaviour, IPoolable<int, int, DoorColor, Vector2, IMemoryPool>, IDisposable
    {
        [Inject] private DoorView       view;
        [Inject] private DoorRepository repository;

        private int         doorIndex;
        private int         switchIndex;
        private DoorColor   color;
        private Vector2     position;
        private IMemoryPool pool;

        public void OnSpawned(int doorIndex, int switchIndex, DoorColor color, Vector2 position, IMemoryPool pool)
        {
            this.doorIndex   = doorIndex;
            this.switchIndex = switchIndex;
            this.color       = color;
            this.position    = position;
            this.pool        = pool;

            view.SetPosition(position);
            view.SetSprite(view.GetTargetSprites()[(int)color]);

            repository.AddDoor(doorIndex, this);
        }

        public void OnDespawned()
        {
            repository.RemoveDoor(doorIndex);

            pool = null;
        }

        public void Dispose()
        {
            pool.Despawn(this);
        }

        public DoorColor GetDoorColor()                   => color;
        public int       GetDoorIndex()                   => doorIndex;
        public int       GetRegisteredSwitchIndex()       => switchIndex;
        public void      Interact()                       => view.Interact();
        public void      SetCanInteract(bool canInteract) => view.SetCanInteract(canInteract);
        public bool      CanInteract()                    => view.CanInteract();
        public bool      IsInteracted()                   => view.IsInteracted();


        #region Factory & Pool

        public class DoorFactory : PlaceholderFactory<int, int, DoorColor, Vector2, DoorFacade>
        {
        }

        public class DoorFacadePool : MonoPoolableMemoryPool<int, int, DoorColor, Vector2, IMemoryPool, DoorFacade>
        {
        }

        #endregion
    }
}