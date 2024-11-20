using System;
using UnityEngine;
using Zenject;

namespace Switch
{
    public class SwitchFacade : MonoBehaviour, IPoolable<int, SwitchColor, Vector2, IMemoryPool>, IDisposable
    {
        [Inject] private SwitchView       view;
        [Inject] private SwitchRepository repository;

        private int         index;
        private SwitchColor color;
        private Vector2     position;
        private IMemoryPool pool;

        public void OnSpawned(int index, SwitchColor color, Vector2 position, IMemoryPool pool)
        {
            this.index    = index;
            this.color    = color;
            this.position = position;
            this.pool     = pool;

            view.SetPosition(position);
            view.SetSprite(view.GetTargetSprites()[(int)color]);

            repository.AddSwitch(index, this);
        }

        public void OnDespawned()
        {
            repository.RemoveSwitch(index);

            pool = null;
        }

        public void Dispose()
        {
            pool.Despawn(this);
        }

        public SwitchColor GetSwitchColor()                 => color;
        public int         GetSwitchIndex()                 => index;
        public void        Interact()                       => view.Interact();
        public void        SetCanInteract(bool canInteract) => view.SetCanInteract(canInteract);
        public bool        CanInteract()                    => view.CanInteract();
        public bool        IsInteracted()                   => view.IsInteracted();

        #region Factory & Pool

        public class SwitchFactory : PlaceholderFactory<int, SwitchColor, Vector2, SwitchFacade>
        {
        }

        public class SwitchFacadePool : MonoPoolableMemoryPool<int, SwitchColor, Vector2, IMemoryPool, SwitchFacade>
        {
        }

        #endregion
    }
}