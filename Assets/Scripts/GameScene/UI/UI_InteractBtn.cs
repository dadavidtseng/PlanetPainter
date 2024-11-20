using Audio;
using DG.Tweening;
using Door;
using Game;
using Player;
using Switch;
using UnityEngine;
using Zenject;

namespace GameScene
{
    public class UI_InteractBtn : MonoBehaviour
    {
        [Inject] private IAudioService    audioService;
        [Inject] private IPlayerService   playerService;
        [Inject] private IGameService     gameService;
        [Inject] private DoorRepository   doorRepository;
        [Inject] private SwitchRepository switchRepository;

        [SerializeField] private AudioSource interactAudioSource;
        [SerializeField] private AudioClip   doorSound;
        [SerializeField] private AudioClip   switchSound;

        public void InteractWithDoor()
        {
            audioService.PlayButtonClickAudio();

            var doorAmount = doorRepository.GetDoorCount();

            for (int i = 0; i < doorAmount; i++)
            {
                var doorFacade = doorRepository.GetDoorFacade(i);

                if (!doorFacade.CanInteract())
                    continue;

                if (doorFacade.IsInteracted())
                    continue;

                if ((int)doorFacade.GetDoorColor() != (int)playerService.GetPlayerColor())
                    continue;

                doorFacade.Interact();

                if (gameService.GetGameState() != GameState.GameOver)
                {
                    DOTween.Sequence()
                           .AppendCallback(() => playerService.SetPaintingAnimationTrigger(true))
                           .JoinCallback(() => audioService.PlayOneShotAudio(interactAudioSource, doorSound))
                           .AppendInterval(2.0f)
                           .AppendCallback(() => playerService.SetPaintingAnimationTrigger(false));
                }

                doorFacade.SetCanInteract(false);
            }
        }

        //  Switch should be linked to one door / multiple doors 
        public void InteractWithSwitch()
        {
            audioService.PlayButtonClickAudio();

            var switchAmount = switchRepository.GetSwitchCount();

            for (int i = 0; i < switchAmount; i++)
            {
                var switchFacade = switchRepository.GetSwitchFacade(i);

                if (!switchFacade.CanInteract())
                    continue;

                if ((int)switchFacade.GetSwitchColor() == (int)playerService.GetPlayerColor())
                    continue;

                switchFacade.Interact();

                DOTween.Sequence()
                       .AppendCallback(() => playerService.SetPaintingAnimationTrigger(true))
                       .JoinCallback(() => audioService.PlayOneShotAudio(interactAudioSource, switchSound))
                       .AppendInterval(2.0f)
                       .AppendCallback(() => playerService.SetPaintingAnimationTrigger(false));

                switchFacade.SetCanInteract(false);
            }
        }
    }
}