using UnityEngine;

namespace Audio
{
    public interface IAudioService
    {
        void PlayBackgroundMusic(AudioClip clip);
        void StopBackgroundMusic();
        void PlayButtonClickAudio();
        void PlayOneShotAudio(AudioSource source, AudioClip clip);
        void PauseAudio(AudioSource       source);
        void ResumeAudio(AudioSource      source);
        void StartAudio(AudioSource       source);
        void StopAudio(AudioSource        source);
        void SetBgmVolume(float           volume);
        void SetSfxVolume(AudioSource     source,float   volume);
    }
}