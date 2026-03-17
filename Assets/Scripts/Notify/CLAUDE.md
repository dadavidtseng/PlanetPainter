# Notify

> [← Root](../../../CLAUDE.md) · `Assets/Scripts/Notify/`

Notification popup service for in-game messages.

## Interface — `INotifyService`

```csharp
void Show(string title, string content, Action confirm = null, Action cancel = null);
void Close();
```

## DI Bindings (via MainInstaller)

```csharp
Container.BindInterfacesAndSelfTo<NotifyService>().AsSingle();
Container.Bind<NotifyView>().FromComponentInHierarchy().AsSingle();
```

## NotifyView

Injects: IAudioService

- Dynamic button visibility based on action presence
- DOTween animations: scale (0.5s in, 0.3s out), fade
- Elastic ease for pop-in, cubic for pop-out
- Audio feedback on show/hide (`popInAudioClip`, `popOutAudioClip`)
- Button listeners auto-close popup on click

## Dependencies

- Zenject, DOTween, TextMeshPro
- Audio module
- Assembly: `Project.Notify`
