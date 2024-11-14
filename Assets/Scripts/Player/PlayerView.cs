using Audio;
using Data;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerView : MonoBehaviour
    {
        [Inject] private readonly PlayerCollisionHandler collisionHandler;
        [Inject] private readonly GameData               gameData;
        [Inject] private readonly IAudioService          audioService;

        [SerializeField] private new Transform      transform;
        [SerializeField] private new Collider2D     collider2D;
        [SerializeField] private     SpriteRenderer spriteRenderer;
        [SerializeField] private     Animator       animator;
        [SerializeField] private     ParticleSystem mushroomParticleSystem;
        [SerializeField] private     Material[]     mushroomMaterials;
        [SerializeField] private     AudioSource    stateAudioSource;
        [SerializeField] private     AudioSource    collisionAudioSource;
        [SerializeField] private     AudioClip      waterBoxSound;
        [SerializeField] private     AudioClip      painterBoxSound;
        [SerializeField] private     AudioClip      blockerBoxSound;

        private static readonly int PLAYER_COLOR     = Animator.StringToHash("PlayerColor");
        private static readonly int PLAYER_DIRECTION = Animator.StringToHash("PlayerDirection");
        private static readonly int IS_PAINTING      = Animator.StringToHash("isPainting");
        private static readonly int IS_WALKING       = Animator.StringToHash("isWalking");

        public AudioSource GetStateAudioSource()     => stateAudioSource;
        public AudioSource GetCollisionAudioSource() => collisionAudioSource;
        public AudioClip   GetWaterBoxSound()        => waterBoxSound;
        public AudioClip   GetPainterBoxSound()      => painterBoxSound;
        public AudioClip   GetBlockerBoxSound()      => blockerBoxSound;


        private void Start()
        {
            SetPosition(gameData.playerSpawnPosition);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            collisionHandler.HandleTriggerEnter2D(other);
            // Instantiate(mushroomPrefab, GetPosition(), Quaternion.identity);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            collisionHandler.HandleTriggerExit2D(other);
        }

        private void OnCollisionEnter(Collision other)
        {
            collisionHandler.HandleCollisionEnter2D(other);
        }

        public Transform      GetTransform()      => transform;
        public SpriteRenderer GetSpriteRenderer() => spriteRenderer;

        public Vector3        GetPosition()                       => GetTransform().position;
        public void           SetPosition(Vector3 targetPosition) => GetTransform().position = targetPosition;
        public Bounds         GetColliderBound()                  => collider2D.bounds;
        public ParticleSystem GetMushroomParticleSystem()         => mushroomParticleSystem;
        public Material[]     GetMushroomMaterials()              => mushroomMaterials;

        public void SetAnimationFloat(int playerColor, int playerDirection)
        {
            animator.SetFloat(PLAYER_COLOR,     playerColor);
            animator.SetFloat(PLAYER_DIRECTION, playerDirection);
        }

        public void SetWalkingAnimationTrigger(bool  isWalking)  => animator.SetBool(IS_WALKING,  isWalking);
        public void SetPaintingAnimationTrigger(bool isPainting) => animator.SetBool(IS_PAINTING, isPainting);
        public void PlayResultAnimation()                        => animator.Play("Player_Dance");

        public void StartStateAudio() => audioService.StartAudio(stateAudioSource);
        public void StopStateAudio()  => audioService.StopAudio(stateAudioSource);
    }
}