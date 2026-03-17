# IntroScene

> [← Root](../../../CLAUDE.md) · `Assets/Scripts/IntroScene/`

Intro video splash screen played on first launch.

## UI_Intro

Injects: ISceneService

- Plays two sequential video clips (`videoA` → `videoB`)
- Subscribes to `VideoPlayer.loopPointReached` event
- Transitions to scene 1 (Menu) after both videos complete

## Dependencies

- Zenject, UnityEngine.Video
- SceneTransition module
- Assembly: `Project.Intro`
