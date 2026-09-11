[Root](../../../AGENTS.md) > `Assets/Scripts/Switch/`

# Switch

Implements pooled color-changing switches. `SwitchSpawner` reads authored configuration, `SwitchFacade` owns pooled lifecycle/repository registration, and `SwitchView` exposes interaction. `SwitchColorHandler` maps player color to switch color and publishes `OnSwitchColorChanged`; Door listens to this signal to unlock matching doors.

Key files: `SwitchSpawner.cs`, `SwitchFacade.cs`, `SwitchView.cs`, `SwitchColorHandler.cs`, `SwitchEvent.cs`, `Project.Switch.asmdef`. Depends on Data, Player, Interactable, and Extenject. No tests discovered.
