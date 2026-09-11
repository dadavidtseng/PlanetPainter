[Root](../../../AGENTS.md) > `Assets/Scripts/MenuScene/`

# MenuScene

Scene-level UI for level selection and the storyboard. `MenuInstaller` binds the menu service/handler and declares the menu signal. `UI_Menu` controls difficulty-gated level buttons and scene navigation; `UI_StoryBoard` performs page-curl/flip animation and emits completion events.

Key files: `MenuInstaller.cs`, `UI/UI_Menu.cs`, `UI/UI_StoryBoard.cs`, `Type/`. Depends on Menu, Data, Audio, SceneTransition, Extenject, DOTween, and TextMeshPro. No tests discovered.
