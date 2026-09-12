# Planet Painter

[![Unity](https://img.shields.io/badge/Unity-6000.3.10f1-57b85a.svg?logo=unity&logoColor=white)](https://unity.com/)
[![Platform](https://img.shields.io/badge/Target-Android-3ddc84.svg?logo=android&logoColor=white)](https://developer.android.com/)
[![License](https://img.shields.io/badge/License-Apache--2.0-blue.svg)](LICENSE)

> A colorful isometric puzzle adventure by Wintermoon Studio.

Planet Painter is a 2D/isometric Unity game about restoring color to faded planets. Guide Cosmo through compact environmental puzzles, absorb colors, paint the world, and use color-matched interactions to unlock the path forward.

<p align="center">
  <img src="Docs/.gitbook/assets/image%20(4)%20(1).png" alt="Planet Painter title screen" width="820">
</p>

## At a glance

- Explore eight handcrafted levels across distinct planets.
- Move with an on-screen D-pad and interact with switches and doors.
- Absorb red, blue, and yellow colors from Painter Boxes.
- Paint the ground as Cosmo moves through each level.
- Match switch colors to their linked doors to open new routes.
- Avoid Blocker Boxes, and use Water Boxes when you need to clear Cosmo's color.
- Complete the level by opening its doors; paint the whole map for the highest completion.

## Game loop

```text
Move → absorb a color → paint the map → recolor switches → open doors → reach the exit
```

Cosmo's current color is both a tool and a constraint. It determines which obstacles can be crossed and which switches can be activated, so each level asks you to plan a route through movement, painting, and color changes.

## Getting started

### Requirements

- Unity `6000.3.10f1` (see `ProjectSettings/ProjectVersion.txt`)
- Unity Hub with the Android Build Support module for Android builds
- Git

### Open the project

```bash
git clone https://github.com/dadavidtseng/PlanetPainter.git
cd PlanetPainter
```

Open the repository in Unity Hub using the project version above. For a quick editor playthrough, open `Assets/Scenes/Intro.unity` or `Assets/Scenes/Title.unity` and press Play.

### Build for Android

1. Open **File → Build Profiles** (or **Build Settings**, depending on the Unity editor UI).
2. Select **Android** and switch the active platform if needed.
3. Confirm the scenes in the build list.
4. Build, or use **Build and Run** with a connected device.

The project is designed around a tablet experience and has been tested against an Android-oriented 16:10 layout. Other devices and platforms may require additional tuning.

## Scenes

| Scene | Purpose |
| --- | --- |
| `Intro` | Optional opening flipbook / intro flow |
| `Title` | Title screen, settings, credits, and quit flow |
| `Menu` | Level selection and storyboard access |
| `Game` | Gameplay, HUD, pause, and level result UI |
| `Main` | Cross-scene bootstrap and shared services |

The normal flow is `Main → Intro (optional) → Title → Menu → Game`.

## Controls

The game is built for touch-first play:

- **D-pad** — move Cosmo
- **Interact** — activate a nearby switch or door
- **Pause** — open the pause menu

The game uses a top-down camera with a faux 45-degree isometric presentation. The camera follows Cosmo while the world is painted on a grid.

## Project structure

```text
PlanetPainter/
├── Assets/
│   ├── Arts/          # Art, audio, animation, tilemap, and video assets
│   ├── Data/          # ScriptableObjects and authored game data
│   ├── Prefabs/       # Reusable gameplay and UI prefabs
│   ├── Scenes/        # Intro, title, menu, main, and gameplay scenes
│   └── Scripts/       # Runtime systems, installers, handlers, and UI
├── Docs/              # Game design and gameplay documentation
├── Packages/          # Unity package manifest and dependencies
├── ProjectSettings/   # Unity editor and build configuration
└── LICENSE            # Apache License 2.0
```

Runtime code is split into small Unity assemblies under `Assets/Scripts`. The main systems are:

- **Game** — level bootstrap and gameplay state
- **Player** — movement, collision, animation, and color state
- **Map** — tile painting and completion percentage
- **Switch / Door** — pooled color interactables and lock state
- **SceneTransition** — scene loading and fade transitions
- **Audio / Notify / Camera** — shared presentation services

Extenject (Zenject) composes the services through scene and prefab installers. Zenject signals and UniRx observables connect state changes between gameplay, UI, and presentation layers, while ScriptableObjects hold authored level and scene data.

## Documentation

The [`Docs/`](Docs/) directory contains the game's design reference, including:

- [Game Design Document](Docs/README.md)
- [Gameplay overview](Docs/gameplay/README.md)
- [Controls](Docs/gameplay/controls.md)
- [Player objectives](Docs/gameplay/players-objective.md)
- [Level progression](Docs/world-layout/level-progression.md)
- [Level details](Docs/level-details/README.md)
- [Android submission notes](Docs/android-submission.md)

Repository architecture notes are maintained in [`AGENTS.md`](AGENTS.md) and the module-level guides under `Assets/Scripts/**/AGENTS.md`.

## Team

Planet Painter was developed by Wintermoon Studio:

| Role | Contributor |
| --- | --- |
| Level design | Cheng Huang |
| Level design | Sereen Hamideh |
| Art | Bess Qu |
| Art | Ray Yin |
| Programming and architecture | Yu-Wei Tseng |

## Contributing

Issues and improvements are welcome. Before opening a pull request:

1. Keep changes focused and follow the existing C# and Unity conventions.
2. Preserve installer bindings, signal contracts, and pooled object lifecycles.
3. Test the affected scene in Unity Play Mode.
4. Include a concise description of the change and any platform-specific considerations.

There is currently no dedicated automated gameplay test suite, so scene-level verification is especially important.

## License

Planet Painter is distributed under the [Apache License 2.0](LICENSE).
