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
        void SetAudioSourceVolume(float   volume);
    }
}