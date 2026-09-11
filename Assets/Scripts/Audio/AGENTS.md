[Root](../../../AGENTS.md) > `Assets/Scripts/Audio/`

# Audio

Owns background music and sound-effect playback. `AudioService` implements `IAudioService` and delegates to the scene `AudioView`; `MainInstaller` binds both as cross-scene singletons. `AudioView` serializes BGM, button-click, and SFX channels. Depends on Extenject and Unity audio APIs. No tests discovered.

Key files: `AudioService.cs`, `IAudioService.cs`, `AudioView.cs`, `Project.Audio.asmdef`.
