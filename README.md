# 🎨 Planet Painter

[![License](https://img.shields.io/badge/License-Apache_2.0-blue.svg)](LICENSE)
[![Unity](https://img.shields.io/badge/Unity-6000.1.14f1-brightgreen.svg)](https://unity.com/)
[![Platform](https://img.shields.io/badge/Platform-Android-green.svg)](https://developer.android.com/)

> **Developed by Wintermoon Studio** - A charming color-changing adventure puzzle game

## 🌟 Game Overview

**Planet Painter** is a single-player mobile puzzle game where players solve challenges to progress through planets and restore color to different worlds!

As Cosmo, a color-changing chameleon, players interact with color-absorbing mushrooms that have drained the world's colorful vibrancy. By walking through these mushrooms, players repaint the environment, interact with objects, and complete levels to bring life back to each planet.

Featuring a cute art style and whimsical fantasy backgrounds, Planet Painter appeals to children and fans of cartoon visuals, offering a charming protagonist and delightful gameplay.

## ✨ Core Gameplay

### 🎮 Game Pillars
- **Move** - Control the character freely within the game world and interact with different objects
- **Paint** - When the character has color, paint ground tiles and certain objects to enable specific interactions
- **Color Change** - The player character's color changes based on interactions with gameplay objects
- **Cute Post-Apocalyptic World of Color** - A post-apocalyptic world with a cute chameleon as the main character

### 🎯 Game Objectives
- Explore 8 unique levels across different planets
- Repaint each planet to restore its vibrancy
- Complete majority of painting to earn special rewards
- Solve environmental puzzles using color mechanics

### 🕹️ Interactive Elements
- **Switch** - Control various mechanisms
- **Door** - Requires specific conditions to open
- **Painter Box** - Provides new colors to the player
- **Blocker Box** - Requires correct color to remove
- **Water Box** - Clears color from the player character

## 🛠️ Technical Specifications

- **Game Engine**: Unity 6000.1.14f1
- **Target Platform**: Android
- **Optimized For**: Lenovo M11 tablets
- **Screen Resolution**: 1920 x 1200
- **Camera Perspective**: 45-degree isometric view
- **Dependency Injection**: Zenject
- **License**: Apache License 2.0

## 🏗️ Project Structure

```
PlanetPainter/
├── Assets/
│   ├── Arts/           # Art assets (animations, audio, images, fonts, etc.)
│   ├── Data/           # Game data
│   ├── Materials/      # Material files
│   ├── Prefabs/        # Prefab objects
│   ├── Scenes/         # Game scenes
│   │   ├── Title.unity
│   │   ├── Menu.unity
│   │   ├── Main.unity
│   │   ├── Game.unity
│   │   └── Intro.unity
│   ├── Scripts/        # Source code
│   │   ├── Audio/      # Audio system
│   │   ├── Game/       # Core game logic
│   │   ├── Player/     # Player controller
│   │   ├── Map/        # Map system
│   │   └── UI/         # User interface
│   └── Settings/       # Project settings
├── Docs/               # Game design documents
├── Builds/             # Build outputs
└── ProjectSettings/    # Unity project settings
```

## 🎨 Development Team - Wintermoon Studio

| Position | Name | Responsibilities |
|----------|------|-----------------|
| Level Designer | Cheng Huang | Level design and balance |
| Level Designer | Sereen Hamideh | Level design and game flow |
| Artist | Bess Qu | Visual art and character design |
| Artist | Ray Yin | Environment art and UI design |
| Programmer | Yu-Wei Tseng | Game programming and system architecture |

## 🚀 Getting Started

### System Requirements
- Unity 6000.1.14f1 or higher
- Android SDK (for Android builds)
- Recommended RAM: 8GB or more

### Installation & Setup
1. Clone this repository:
   ```bash
   git clone [repository-url]
   cd PlanetPainter
   ```

2. Open the project with Unity Hub
3. Ensure Android Build Support module is installed
4. Open the `Assets/Scenes/Title.unity` scene
5. Click the Play button to start the game

### Building for Android
1. Go to File > Build Settings
2. Select Android platform
3. Configure Player Settings
4. Click Build or Build and Run

## 📖 Documentation

Complete game design documentation is available in the `/Docs` folder, including:

- [Game Design Document](Docs/README.md) - Complete design overview
- [Core Concepts](Docs/concept/) - Game philosophy and core mechanics
- [Gameplay Details](Docs/gameplay/) - Detailed gameplay mechanics
- [Level Design](Docs/level-details.md) - Level design specifications
- [Menu System](Docs/menu-system.md) - UI/UX design

## 🎯 Target Audience

- **Primary Audience**: Children and fans of cartoon-style games
- **Game Genre**: Casual puzzle game
- **Session Length**: 5-10 minutes per level
- **Difficulty**: Moderate, with progressive challenge

## 🌈 Key Features

- **Intuitive Touch Controls** - Optimized for touch devices
- **Rich Visual Feedback** - Vibrant color changes and particle effects
- **Immersive Audio Design** - Engaging sound effects and music
- **Progressive Learning Curve** - From simple to complex level design
- **Achievement System** - Rewards for completing specific objectives

## 📱 Platform Details

Planet Painter is optimized for Android devices, specifically designed for:
- Tablet gameplay experience
- Touch-based interaction
- Portrait and landscape orientations
- Various Android screen sizes

## 🔧 Architecture

The project uses a modular architecture with:
- **Zenject** for dependency injection
- **Service-oriented design** for game systems
- **Event-driven communication** between components
- **Scriptable Objects** for data management

## 📝 License

This project is licensed under the [Apache License 2.0](LICENSE). See the LICENSE file for details.

## 🤝 Contributing

We welcome contributions! Please ensure you:

1. Follow the existing code style
2. Write appropriate documentation for new features
3. Test your changes thoroughly
4. Provide clear commit messages

## 📞 Contact

For questions or suggestions, please contact the Wintermoon Studio development team.

---

*Let's bring color back to this faded world together!* 🎨✨