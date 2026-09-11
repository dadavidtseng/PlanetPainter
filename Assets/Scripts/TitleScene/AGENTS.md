[Root](../../../AGENTS.md) > `Assets/Scripts/TitleScene/`

# TitleScene

Scene UI for title, settings, credits, and quit confirmation. `TitleInstaller` binds the title service/handler and declares the title signal. `UI_Title` starts BGM and navigates to Menu; `UI_Setting`, `UI_Credit`, and `UI_Quit` react to title-state changes. After difficulty 7, title UI opens credits and advances the stored difficulty to 8.

Key files: `TitleInstaller.cs`, `UI/`, `Project.TitleScene.asmdef`. Depends on Title, Data, Audio, SceneTransition, Misc, Extenject, and DOTween. No tests discovered.
