[Root](../../../AGENTS.md) > `Assets/Scripts/Notify/`

# Notify

Notification popup service. `NotifyService` implements `INotifyService` and delegates title/content/action presentation to `NotifyView`; the view handles optional button visibility, DOTween pop-in/out, and audio feedback. Bound as a cross-scene singleton by `MainInstaller`. Depends on Audio, Extenject, DOTween, and TextMeshPro. No tests discovered.
