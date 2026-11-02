# Rolling to the Future

Rolling to the Future is a Unity VR marble game project by Team 4.  
Players cooperate in a VR environment to move a ball through maze-like stages, interact with doors and mechanisms, and reach goals across multiple levels.

## Preview

<img src="https://github.com/user-attachments/assets/49857f4d-bd0c-4acc-a0a3-d6a767cf0821">

## Demo Video

https://youtu.be/Plefl_rVZMQ

## Project Highlights

- **VR interaction** with Meta/Oculus input (`OVRInput`) for in-game actions.
- **Level switching flow** with a networked level manager (`Unity.Netcode`).
- **Puzzle mechanics** including:
  - Blue/Red door toggles
  - Rotating stone groups
  - Spring bounce pads
  - Ball respawn and goal effects
- **Pause board + pointer UI** for in-game control.

## Main Scenes

Core scenes are under `Assets/Scenes/`, including:

- `New Root.unity` (currently enabled in build settings)
- `root.unity`
- `Lv.1.unity`
- `Lv.2.unity`
- `Lv.3.unity`
- `Lv.4.unity`

## Key Scripts

- `Assets/Script/Game Manager.cs`  
  Handles networked level activation and synchronization.

- `Assets/Script/Ball.cs`  
  Manages ball respawn, fall detection, and goal visual feedback.

- `Assets/Script/Maze Aligner.cs`  
  Aligns and scales the maze based on both hand/controller transforms.

- `Assets/Script/BRDoorController.cs` + `Assets/Script/BRteam.cs`  
  Implements Blue/Red role-based door interaction.

- `Assets/Script/PauseController.cs` + `Assets/Script/LaserPointer.cs`  
  Controls pause UI visibility and pointer ray rendering.

## Requirements

- **Unity Editor:** `6000.0.63f1`
- **XR/VR Packages:** Oculus + XR Management + Meta XR SDK (from `Packages/manifest.json`)

## How to Run

1. Open the project in **Unity Hub** with editor version `6000.0.63f1`.
2. Let Unity resolve packages from `Packages/manifest.json`.
3. Open `Assets/Scenes/New Root.unity`.
4. Press **Play** in the editor, or build and run on your target VR device.

## Repository Structure (high level)

- `Assets/Script/` - Team gameplay and interaction scripts
- `Assets/Scenes/` - Main game scenes and level content
- `Packages/manifest.json` - Unity package dependencies
- `ProjectSettings/` - Unity project/editor and build settings
