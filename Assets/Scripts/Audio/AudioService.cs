//----------------------------------------------------------------------------------------------------
// AudioService.cs
//----------------------------------------------------------------------------------------------------

//----------------------------------------------------------------------------------------------------

using UnityEngine;
using Zenject;

//----------------------------------------------------------------------------------------------------
namespace Audio
{
    public class AudioService : IAudioService
    {
        [Inject] private readonly AudioView view;

        public void PlayBackgroundMusic(AudioClip clip)                  => view.PlayBackgroundMusic(clip);
        public void StopBackgroundMusic()                                => view.StopBackgroundMusic();
        public void PlayButtonClickAudio()                               => view.PlayButtonClickAudio();
        public void PlayOneShotAudio(AudioSource source, AudioClip clip) => view.PlayOneShotAudio(source, clip);
        public void PauseAudio(AudioSource source)                       => view.PauseAudio(source);
        public void ResumeAudio(AudioSource source)                      => view.ResumeAudio(source);
        public void StartAudio(AudioSource source)                       => view.StartAudio(source);
        public void StopAudio(AudioSource source)                        => view.StopAudio(source);
        public void SetBgmVolume(float volume)                           => view.SetBgmVolume(volume);
        public void SetSfxVolume(AudioSource source, float volume)       => view.SetSfxVolume(source, volume);
    }
}