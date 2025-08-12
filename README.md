# 🏃‍♂️ Bahun-D-Run: Ultimate 3D Endless Runner

<div align="center">

![Unity](https://img.shields.io/badge/Unity-2020.3.11f1-000000?style=for-the-badge&logo=unity)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp)
![Platform](https://img.shields.io/badge/Android-3DDC84?style=for-the-badge&logo=android)
![License](https://img.shields.io/badge/License-MIT-blue?style=for-the-badge)

**An immersive 3D endless runner game built with Unity featuring dynamic world curving, power-ups, and customizable characters.**

[🎮 Play Now](#getting-started) • [📖 Documentation](#features) • [🛠️ Development](#development) • [🤝 Contributing](#contributing)

</div>

---

## 🌟 Overview

Bahun-D-Run is a high-performance 3D endless runner that combines classic gameplay mechanics with modern visual effects. Players navigate through an infinite curved world, collecting coins, avoiding obstacles, and utilizing power-ups to achieve the highest scores possible.

### ✨ Key Highlights

- 🌍 **Curved World Mechanics** - Dynamic world curvature for immersive gameplay
- 🎯 **Precise Controls** - Responsive touch and keyboard input system
- 💎 **Power-Up System** - Flying abilities, magnets, and special effects
- 🎨 **Character Customization** - Multiple skins and customization options
- 📊 **Performance Optimized** - Object pooling and efficient resource management
- 🎵 **Audio Experience** - Dynamic sound effects and background music
- 📱 **Mobile Ready** - Optimized for Android devices

---

## 🚀 Features

### 🎮 Core Gameplay
- **Endless Running**: Procedurally generated infinite track system
- **Three-Lane Movement**: Smooth left/right lane switching with animations
- **Jump & Slide**: Vertical movement mechanics for obstacle avoidance
- **Distance Tracking**: Real-time distance measurement and leaderboards
- **Coin Collection**: Collectible currency system with persistent storage

### 🎯 Power-Up System
- **🪶 Flying Power**: 
  - Temporary flight ability with wing animations
  - Aerial coin collection patterns
  - Gravity-defying movement mechanics
  
- **🧲 Magnet Power**: 
  - Automatic coin attraction
  - Extended collection radius
  - Visual magnetic effects

### 🎨 Visual Effects
- **World Curvature**: Custom shaders for realistic curved world effect
- **Smooth Animations**: Fluid character movement and transitions
- **Dynamic Lighting**: Responsive lighting system
- **Particle Effects**: Enhanced visual feedback for actions

### 🎵 Audio System
- **Dynamic Sound Effects**: Context-aware audio feedback
- **Layered Audio**: Multiple audio sources for immersive experience
- **Sound Pools**: Optimized audio management

### 🛠️ Technical Features
- **Object Pooling**: Efficient memory management for coins and obstacles
- **Floating Origin**: Prevents floating-point precision issues
- **Performance Optimization**: 60+ FPS on mobile devices
- **Save System**: Persistent player progress and customizations

---

## 📋 System Requirements

### Minimum Requirements
- **Unity Version**: 2020.3.11f1 or later
- **Platform**: Android API Level 21+
- **RAM**: 2GB
- **Storage**: 500MB free space
- **Graphics**: OpenGL ES 3.0 support

### Recommended
- **Unity Version**: 2021.3 LTS
- **Platform**: Android API Level 28+
- **RAM**: 4GB+
- **Storage**: 1GB free space
- **Graphics**: Vulkan API support

---

## 🎯 Getting Started

### Quick Setup

1. **Clone the Repository**
   ```bash
   git clone https://github.com/yourusername/Bahun-D-Run.git
   cd Bahun-D-Run
   ```

2. **Open in Unity**
   - Launch Unity Hub
   - Click "Open" and select the project folder
   - Wait for Unity to import all assets

3. **Build Settings**
   - Go to File → Build Settings
   - Select Android platform
   - Click "Switch Platform"
   - Configure player settings as needed

4. **Play**
   - Press Play in Unity Editor, or
   - Build and deploy to Android device

### 🎮 Controls

#### Touch Controls (Mobile)
- **Swipe Up**: Jump over obstacles
- **Swipe Down**: Slide under obstacles
- **Swipe Left/Right**: Change lanes
- **Tap**: Start game / Activate powers

#### Keyboard Controls (Desktop Testing)
- **W**: Jump
- **S**: Slide
- **A/D**: Move left/right
- **Space**: Start game

---

## 🏗️ Architecture

### 📁 Project Structure
```
Bahun-D-Run/
├── Assets/
│   ├── SCRIPTS/          # Core game logic
│   │   ├── PlayerMovement.cs      # Main character controller
│   │   ├── TrackManager.cs        # Procedural track generation
│   │   ├── CoinSpawner.cs         # Coin placement system
│   │   ├── PowerUPSpawn.cs        # Power-up management
│   │   └── ObjectPool.cs          # Memory optimization
│   ├── Scenes/           # Game scenes
│   ├── Materials/        # Visual materials and shaders
│   ├── Models/          # 3D character and environment models
│   └── Audio/           # Sound effects and music
├── ProjectSettings/     # Unity configuration
└── README.md           # This file
```

### 🔧 Core Components

#### PlayerMovement.cs
The heart of the game, handling:
- **Input Processing**: Touch gestures and keyboard input
- **Animation Control**: Character state management
- **Physics Integration**: Rigidbody-based movement
- **Collision Detection**: Obstacle and collectible interactions
- **Audio Management**: Sound effect triggering

#### TrackManager.cs
Procedural content generation:
- **Infinite Track**: Seamless tile positioning
- **Random Generation**: Varied obstacle placement
- **Performance Optimization**: Tile recycling system

#### ObjectPool.cs
Memory management system:
- **Coin Pooling**: Reusable coin instances
- **Performance**: Reduced garbage collection
- **Scalability**: Dynamic pool sizing

---

## 🎨 Customization

### Character Skins
The game includes a comprehensive customization system:

```csharp
// Customization scripts location
Assets/SCRIPTS/CUSTUM/
├── BODY.cs      # Body customization
├── TOP.cs       # Upper clothing
├── BOTTOM.cs    # Lower clothing
├── SHOE.cs      # Footwear options
├── EYE.cs       # Eye variations
└── EYELASH.cs   # Eyelash styles
```

### Adding New Skins
1. Create new material variants
2. Update customization scripts
3. Configure UI elements
4. Test in-game appearance

---

## 🔧 Development

### Building the Project

#### For Android
```bash
# Unity command line build
Unity.exe -batchmode -quit -projectPath . -buildTarget Android -buildPath ./Builds/Android/Bahun-D-Run.apk
```

#### Development Workflow
1. **Scene Management**: Use `Game` scene for main gameplay
2. **Testing**: Utilize Unity Play Mode for rapid iteration
3. **Profiling**: Monitor performance with Unity Profiler
4. **Version Control**: Follow Git best practices

### Code Quality Standards
- **Naming Conventions**: Follow C# standards
- **Documentation**: Inline comments for complex logic
- **Performance**: Regular profiling and optimization
- **Testing**: Thorough device testing

---

## 📊 Performance Optimization

### Current Optimizations
- **Object Pooling**: Prevents memory allocation spikes
- **Floating Origin**: Maintains precision at large distances  
- **LOD System**: Distance-based detail reduction
- **Audio Management**: Efficient sound processing
- **Texture Streaming**: Dynamic texture loading

### Performance Metrics
- **Target FPS**: 60 FPS on mid-range devices
- **Memory Usage**: <200MB RAM on mobile
- **Battery Impact**: Optimized for extended gameplay
- **Loading Time**: <5 seconds initial load

---

## 🎵 Audio Implementation

### Sound Categories
- **Gameplay SFX**: Jump, slide, coin collection
- **Power-up Audio**: Flight activation, magnet effects
- **UI Sounds**: Menu interactions, game over
- **Ambient Audio**: Background atmosphere

### Audio Optimization
- **Compression**: Optimized file formats
- **3D Audio**: Spatial sound positioning
- **Dynamic Loading**: Memory-efficient audio streaming

---

## 🧪 Testing

### Testing Checklist
- [ ] **Gameplay Flow**: Start to game over sequence
- [ ] **Input Response**: All control methods functional
- [ ] **Performance**: Stable 60 FPS during gameplay
- [ ] **Audio**: All sound effects playing correctly
- [ ] **Persistence**: Save data maintains between sessions
- [ ] **Power-ups**: All abilities working as intended
- [ ] **UI Navigation**: Smooth menu transitions

### Supported Devices
- **Android 7.0+** (API Level 24+)
- **2GB RAM minimum**
- **OpenGL ES 3.0 support**
- **1080p resolution optimized**

---

## 🤝 Contributing

We welcome contributions! Here's how to get started:

### Development Setup
1. Fork the repository
2. Create a feature branch: `git checkout -b feature/amazing-feature`
3. Make your changes
4. Test thoroughly
5. Commit: `git commit -m 'Add amazing feature'`
6. Push: `git push origin feature/amazing-feature`
7. Open a Pull Request

### Contribution Guidelines
- **Code Style**: Follow existing patterns
- **Documentation**: Update README for new features
- **Testing**: Ensure all functionality works
- **Performance**: Maintain optimization standards

---

## 📝 Changelog

### Version 1.0.0 (Current)
- ✅ Core endless runner mechanics
- ✅ Power-up system implementation
- ✅ Character customization
- ✅ Mobile optimization
- ✅ Save system integration

### Planned Features
- 🔄 **Leaderboards**: Global score tracking
- 🔄 **Achievements**: Goal-based progression
- 🔄 **Shop System**: Enhanced monetization
- 🔄 **Daily Challenges**: Recurring objectives
- 🔄 **Multiplayer**: Competitive modes

---

## 🐛 Known Issues

- **Performance**: Occasional frame drops on older devices
- **Audio**: Rare sound overlap on rapid inputs
- **UI**: Minor scaling issues on ultra-wide screens

*Issues are actively being tracked and resolved.*

---

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

```
MIT License

Copyright (c) 2024 Bahun-D-Run Development Team

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.
```

---

## 🙏 Acknowledgments

- **Unity Technologies** - Game engine and development tools
- **TextMeshPro** - Advanced text rendering system
- **Community Contributors** - Bug reports and feature suggestions
- **Beta Testers** - Invaluable feedback and quality assurance

---

## 📞 Support

### Getting Help
- 📧 **Email**: support@bahundrun.com
- 💬 **Discord**: [Join our community](https://discord.gg/bahundrun)
- 🐛 **Issues**: [GitHub Issues](https://github.com/yourusername/Bahun-D-Run/issues)
- 📖 **Wiki**: [Detailed Documentation](https://github.com/yourusername/Bahun-D-Run/wiki)

### FAQ
**Q: How do I unlock new characters?**
A: Collect coins during gameplay and purchase skins in the customization menu.

**Q: Can I play offline?**
A: Yes! The game works completely offline with local save data.

**Q: How do I report bugs?**
A: Please use our GitHub Issues page with detailed reproduction steps.

---

<div align="center">

**⭐ Star this project if you found it helpful! ⭐**

Made with ❤️ by the Bahun-D-Run Development Team

[🔝 Back to Top](#-bahun-d-run-ultimate-3d-endless-runner)

</div>
