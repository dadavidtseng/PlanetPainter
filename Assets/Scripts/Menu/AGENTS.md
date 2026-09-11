[Root](../../../AGENTS.md) > `Assets/Scripts/Menu/`

# Menu

Owns the level-select menu state machine. `MenuService` implements `IMenuService` (declared in the historically misnamed `ITitleService.cs`), while `MenuStateHandler` publishes `OnMenuStateChanged`. States are Menu and StoryBoard; subscribers are `UI_Menu` and `UI_StoryBoard`.

Key files: `MenuService.cs`, `ITitleService.cs`, `MenuEvent.cs`, `Handler/`, `Type/`, `Project.Menu.asmdef`. Depends on Extenject. No tests discovered.
