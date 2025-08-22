# unity-junior-programmer-pathway

Offered by [Unity's Junior Programmer Pathway](https://learn.unity.com/pathway/junior-programmer). All content is Copyright © 2025 Unity Technologies. The following files are offered from Unity as part of their free Junior Programmer Pathway. As stated by Unity:

"Welcome to Junior Programmer! Designed for anyone interested in learning to code or obtaining an entry-level Unity role, this pathway assumes a basic knowledge of Unity and has no math prerequisites. Junior Programmer prepares you to get Unity Certified so that you can demonstrate your job-readiness to employers."

[![Watch the video](https://img.youtube.com/vi/IKXY7uTB_Fs/hqdefault.jpg)](https://www.youtube.com/watch?v=IKXY7uTB_Fs "Play on YouTube")

The following contains the following projects in the Junior Programmer Pathway.

## Contents

### Challenge 5
A food-themed clicking game challenge where players must click on falling food items while avoiding skulls. This challenge focuses on UI interactions, difficulty settings, and game state management.

### Error Project
A Unity debugging exercise designed to teach developers how to identify and fix common compilation errors in C# scripts. Includes practice with syntax errors, missing references, and proper Unity component setup.

### Prototype 1
Car driving simulation introducing fundamental Unity concepts including transforms, physics, and basic player input controls.

### Prototype 6
Advanced Unity game mechanics implementation featuring object pooling, collision detection, boundary management, and optimized performance techniques.

### Prototype 7 - Counting Project
An interactive counting system that tracks collisions with objects in a 3D environment. Features a trigger-based counter with UI display showing real-time count updates when spheres pass through a designated area.

## Progress Log

### 2025-08-22
- Started Prototype 7: Counting Project implementation
  - Created interactive counting system with trigger-based collision detection
  - Added Counter.cs script to track and display collision counts
  - Set up 3D environment with physics-enabled spheres
  - Implemented UI text display for real-time count updates
  - Configured box collider trigger zone for object detection
  - Added Unity scene with multiple falling spheres for testing counter functionality

### 2025-08-20
- Started Error Project: Unity debugging exercise
  - Added CongratScript.cs with syntax errors for debugging practice
  - Included particle effects and text mesh components
  - Set up project files and meta data
- Fixed compilation errors in Error Project CongratScript
  - Added missing System.Collections.Generic namespace for List<> support
  - Fixed missing semicolon after CurrentText initialization
  - Added proper float literals (f suffix) for all float values
  - Corrected spelling from "Congratulation" to "Congratulations"
  - Fixed bracket misalignment in Update method
  - Initialized List<string> to prevent null reference exceptions
  - Added text rotation animation with Quaternion.Euler
- Finished Error Project: Completed Unity debugging challenge
  - Built WebGL version of the project
  - Created build profiles for web deployment
  - Updated Unity project settings and dependencies
  - Upgraded Universal Render Pipeline settings
  - Successfully exported project with all fixes applied

### 2025-08-18
- Added Challenge 5 project files from Unity Learn's Junior Programmer Pathway
- Set up project structure with proper .gitignore for Unity projects
- Initialized repository with base Unity project files
- Completed Challenge 5: Fixed clicking game bugs
  - Fixed difficulty selection to properly adjust spawn rates
  - Corrected score display to show actual score value
  - Changed target interaction from hover to click for proper gameplay
  - Enabled restart button functionality after game over
  - Added proper difficulty scaling to game mechanics
- Added Prototype 1: Car driving simulation
- Completed Prototype 6: Implemented advanced Unity features
  - Added object pooling system for efficient game object management
  - Implemented collision detection and boundary management
  - Created modular scripts for player control and camera follow
  - Optimized performance with object pooling instead of instantiation/destruction
  - Enhanced player controller with configurable movement parameters
