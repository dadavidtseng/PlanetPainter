//----------------------------------------------------------------------------------------------------
// AudioView.cs
//----------------------------------------------------------------------------------------------------

//----------------------------------------------------------------------------------------------------

using UnityEngine;

//----------------------------------------------------------------------------------------------------
namespace Audio
{
    public class AudioView : MonoBehaviour
    {
        [SerializeField] private AudioSource bgm;
        [SerializeField] private AudioSource buttonClickAudioSource;
        [SerializeField] private AudioClip   buttonClickAudioClip;

        //----------------------------------------------------------------------------------------------------
        public void PlayBackgroundMusic(AudioClip clip)
        {
            bgm.clip = clip;

            bgm.Play();
        }

        //----------------------------------------------------------------------------------------------------
        public void StopBackgroundMusic()
        {
            bgm.Stop();
        }

        public void PlayButtonClickAudio() => buttonClickAudioSource.PlayOneShot(buttonClickAudioClip);
        public void PlayOneShotAudio(AudioSource source, AudioClip clip) => source.PlayOneShot(clip);
        public void PauseAudio(AudioSource source) => source.Pause();
        public void ResumeAudio(AudioSource source) => source.Play();
        public void StartAudio(AudioSource source) => source.Play();
        public void StopAudio(AudioSource source) => source.Pause();
        public void SetBgmVolume(float volume) => bgm.volume = volume;
        public void SetSfxVolume(AudioSource source, float volume) => source.volume = volume;
    }
}