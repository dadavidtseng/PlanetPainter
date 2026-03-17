# Audio

> [← Root](../../../CLAUDE.md) · `Assets/Scripts/Audio/`

BGM and SFX playback service.

## Interface — `IAudioService`

```csharp
void PlayBackgroundMusic(AudioClip clip);
void StopBackgroundMusic();
void PlayButtonClickAudio();
void PlayOneShotAudio(AudioSource source, AudioClip clip);
void PauseAudio(AudioSource source);
void ResumeAudio(AudioSource source);
void StartAudio(AudioSource source);
void StopAudio(AudioSource source);
void SetBgmVolume(float volume);
void SetSfxVolume(AudioSource source, float volume);
```

## DI Bindings (via MainInstaller)

```csharp
Container.BindInterfacesAndSelfTo<AudioService>().AsSingle();
Container.Bind<AudioView>().FromComponentInHierarchy().AsSingle();
```

## AudioView — Serialized Fields

- `AudioSource bgm` — background music channel
- `AudioSource buttonClickAudioSource` — UI click SFX
- `AudioClip buttonClickAudioClip` — click sound asset

All `AudioService` methods delegate directly to `AudioView`.

## Dependencies

- Zenject
- Assembly: `Project.Audio`
