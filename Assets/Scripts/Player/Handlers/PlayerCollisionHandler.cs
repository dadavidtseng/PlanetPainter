using Audio;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerCollisionHandler
    {
        [Inject] private readonly PlayerView         view;
        [Inject] private readonly PlayerColorHandler colorHandler;
        [Inject] private readonly PlayerMoveHandler  moveHandler;
        [Inject] private readonly IAudioService      audioService;

        private Sequence painterBoxSequence;
        private Sequence blockerBoxSequence;
        private Sequence waterBoxSequence;
        private Sequence wallSequence;

        public void HandleTriggerEnter2D(Collider2D other)
        {
            // OnEnterWaterBox
            if (other.gameObject.CompareTag("WaterBox"))
            {
                colorHandler.ChangeColor(PlayerColor.Original);
            }

            // OnEnterPainterBox
            if (other.gameObject.CompareTag("PainterBox_Red"))
            {
                colorHandler.ChangeColor(PlayerColor.Red);

                view.GetMushroomParticleSystem().GetComponent<Renderer>().material =
                    view.GetMushroomMaterials()[(int)colorHandler.GetColor()];

                painterBoxSequence.Kill();

                painterBoxSequence = DOTween.Sequence()
                                            .AppendCallback(() => view.GetMushroomParticleSystem().Play())
                                            .OnComplete(() =>
                                                            audioService
                                                               .PlayOneShotAudio(view.GetCollisionAudioSource(),
                                                                                 view.GetPainterBoxSound()));
            }

            if (other.gameObject.CompareTag("PainterBox_Blue"))
            {
                colorHandler.ChangeColor(PlayerColor.Blue);

                view.GetMushroomParticleSystem().GetComponent<Renderer>().material =
                    view.GetMushroomMaterials()[(int)colorHandler.GetColor()];

                view.GetMushroomParticleSystem().Play();

                painterBoxSequence.Kill();

                painterBoxSequence = DOTween.Sequence()
                                            .AppendCallback(() => view.GetMushroomParticleSystem().Play())
                                            .OnComplete(() =>
                                                            audioService
                                                               .PlayOneShotAudio(view.GetCollisionAudioSource(),
                                                                                 view.GetPainterBoxSound()));
            }

            if (other.gameObject.CompareTag("PainterBox_Yellow"))
            {
                colorHandler.ChangeColor(PlayerColor.Yellow);

                view.GetMushroomParticleSystem().GetComponent<Renderer>().material =
                    view.GetMushroomMaterials()[(int)colorHandler.GetColor()];

                view.GetMushroomParticleSystem().Play();

                painterBoxSequence.Kill();

                painterBoxSequence = DOTween.Sequence()
                                            .AppendCallback(() => view.GetMushroomParticleSystem().Play())
                                            .OnComplete(() =>
                                                            audioService
                                                               .PlayOneShotAudio(view.GetCollisionAudioSource(),
                                                                                 view.GetPainterBoxSound()));
            }

            if (other.gameObject.CompareTag("BlockerBox_Red"))
            {
                if (colorHandler.GetColor() != PlayerColor.Red)
                {
                    moveHandler.SetMoveSpeed(0.0f);

                    view.SetPosition(view.GetPosition() + moveHandler.GetMoveBackVelocity());

                    blockerBoxSequence.Kill();

                    blockerBoxSequence = DOTween.Sequence()
                                                .AppendCallback(() => view.GetMushroomParticleSystem().Play())
                                                .OnComplete(() =>
                                                                audioService
                                                                   .PlayOneShotAudio(view.GetCollisionAudioSource(),
                                                                                     view.GetBlockerBoxSound()));
                }
            }

            if (other.gameObject.CompareTag("BlockerBox_Blue"))
            {
                if (colorHandler.GetColor() != PlayerColor.Blue)
                {
                    moveHandler.SetMoveSpeed(0.0f);

                    view.SetPosition(view.GetPosition() + moveHandler.GetMoveBackVelocity());

                    blockerBoxSequence.Kill();

                    blockerBoxSequence = DOTween.Sequence()
                                                .AppendCallback(() => view.GetMushroomParticleSystem().Play())
                                                .OnComplete(() =>
                                                                audioService
                                                                   .PlayOneShotAudio(view.GetCollisionAudioSource(),
                                                                                     view.GetBlockerBoxSound()));
                }
            }

            if (other.gameObject.CompareTag("BlockerBox_Yellow"))
            {
                if (colorHandler.GetColor() != PlayerColor.Yellow)
                {
                    moveHandler.SetMoveSpeed(0.0f);

                    view.SetPosition(view.GetPosition() + moveHandler.GetMoveBackVelocity());

                    blockerBoxSequence.Kill();

                    blockerBoxSequence = DOTween.Sequence()
                                                .AppendCallback(() => view.GetMushroomParticleSystem().Play())
                                                .OnComplete(() =>
                                                                audioService
                                                                   .PlayOneShotAudio(view.GetCollisionAudioSource(),
                                                                                     view.GetBlockerBoxSound()));
                }
            }
        }

        public void HandleTriggerExit2D(Collider2D other)
        {
            moveHandler.SetMoveSpeed(5.0f);
        }

        public void HandleCollisionEnter2D(Collision other)
        {
            if (other.gameObject.CompareTag("Wall"))
            {
                moveHandler.SetMoveSpeed(0.0f);

                view.SetPosition(view.GetPosition() + moveHandler.GetMoveBackVelocity());

                wallSequence.Kill();

                wallSequence = DOTween.Sequence()
                                      .AppendCallback(() =>
                                                          audioService.PlayOneShotAudio(view.GetCollisionAudioSource(),
                                                                                        view.GetBlockerBoxSound()));
            }
        }
    }
}