//----------------------------------------------------------------------------------------------------
// DoorView.cs
//----------------------------------------------------------------------------------------------------

//----------------------------------------------------------------------------------------------------

using Data;
using DG.Tweening;
using Game;
using Interactable;
using Player;
using Switch;
using UnityEngine;
using Zenject;

//----------------------------------------------------------------------------------------------------
namespace Door
{
    public class DoorView : BaseInteractableView
    {
        [Inject] private readonly SignalBus        signalBus;
        [Inject] private readonly GameData         gameData;
        [Inject] private readonly DoorFacade       facade;
        [Inject] private readonly DoorRepository   repository;
        [Inject] private readonly SwitchRepository switchRepository;
        [Inject] private readonly IPlayerService   playerService;
        [Inject] private readonly IGameService     gameService;

        [SerializeField] private SpriteRenderer targetSpriteRenderer;
        [SerializeField] private SpriteRenderer lockSpriteRenderer;
        [SerializeField] private BoxCollider2D  blockCollider;
        [SerializeField] private BoxCollider2D  detectCollider;
        [SerializeField] private Sprite[]       targetFrontSprites;
        [SerializeField] private Sprite[]       targetSideSprites;

        private bool isLocked = true;

        //----------------------------------------------------------------------------------------------------
        private void OnEnable()
        {
            signalBus.Subscribe<OnSwitchColorChanged>(OnSwitchColorChanged);
        }

        //----------------------------------------------------------------------------------------------------
        private void OnDisable()
        {
            signalBus.Unsubscribe<OnSwitchColorChanged>(OnSwitchColorChanged);
        }

        //----------------------------------------------------------------------------------------------------
        private void OnSwitchColorChanged(OnSwitchColorChanged e)
        {
            if (IsInteracted())
                return;

            if (e.index != facade.GetRegisteredSwitchIndex())
                return;

            if ((int)e.color == (int)facade.GetDoorColor())
            {
                lockSpriteRenderer.DOFade(0.0f, 0.2f);
                isLocked = false;
            }

            if ((int)e.color != (int)facade.GetDoorColor())
            {
                lockSpriteRenderer.DOFade(1.0f, 0.2f);
                isLocked = true;
            }
        }

        //----------------------------------------------------------------------------------------------------
        public override void Interact()
        {
            if (!CanInteract())
                return;

            SetSprite(GetTargetSprites()[3]);
            blockCollider.enabled = false;
            SetIsInteracted(true);

            if (repository.IsAllDoorsOpen())
            {
                gameService.ChangeState(GameState.GameOver);

                DOTween.Sequence()
                    .AppendInterval(0.5f)
                    .AppendCallback(() => gameService.ChangeState(GameState.Result));
            }

            Debug.Log($"DOOR #{facade.GetDoorIndex()} | Interact");
        }

        //----------------------------------------------------------------------------------------------------
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player"))
                return;

            if (isLocked)
                return;

            if ((int)facade.GetDoorColor() == (int)playerService.GetPlayerColor())
                SetCanInteract(true);

            Debug.Log($"DOOR #{facade.GetDoorIndex()} | canInteract: {canInteract}");
        }

        //----------------------------------------------------------------------------------------------------
        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.CompareTag("Player"))
                return;

            SetCanInteract(false);
            Debug.Log($"DOOR #{facade.GetDoorIndex()} | canInteract: {canInteract}");
        }

        //----------------------------------------------------------------------------------------------------
        private Transform      GetTransform()                      => transform;
        public  Vector3        GetPosition()                       => transform.position;
        public  SpriteRenderer GetTargetSpriteRenderer()           => targetSpriteRenderer;
        public  SpriteRenderer GetLockSpriteRenderer()             => lockSpriteRenderer;
        public  void           SetPosition(Vector2 targetPosition) => GetTransform().position = targetPosition;
        public  void           SetSprite(Sprite targetSprite)      => spriteRenderer.sprite = targetSprite;

        //----------------------------------------------------------------------------------------------------
        public Sprite[] GetTargetSprites()
        {
            if (facade.GetDoorType() == DoorType.Front)
                return targetFrontSprites;

            if (facade.GetDoorType() == DoorType.Back)
                return targetFrontSprites;

            if (facade.GetDoorType() == DoorType.Left)
                return targetSideSprites;

            if (facade.GetDoorType() == DoorType.Right)
                return targetSideSprites;

            return new Sprite[] { };
        }
    }
}