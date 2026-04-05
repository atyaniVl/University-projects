# Project 3 - Police Car Game

A Unity practice project focused on lane-based movement, shooting, enemy spawning, scoring, and UI/game-state management.

## Type
Practice project

## About
The player controls a police car, switches lanes, shoots enemies, and tries to reach a score target before health reaches zero.

## Gameplay Loop
- Start from the main menu and enter the game scene.
- Move left and right between lanes.
- Shoot incoming enemies.
- Earn score by destroying enemies.
- Win when score reaches the goal, or lose when health is depleted.

## Main Scenes
- mainMenu
- game

## Key Systems
- Lane-based movement and shooting cooldown
- Enemy and bullet interactions
- Health and score tracking
- Win/lose UI display
- Pause menu support (keyboard and mobile methods)

## Key Scripts
- Assets/script/Player.cs
- Assets/script/Enemy.cs
- Assets/script/Bullet.cs
- Assets/script/Spawner.cs
- Assets/script/UImanager.cs
- Assets/script/Scenes.cs

## Controls
- Left Arrow / A: move left lane
- Right Arrow / D: move right lane
- Space: shoot
- Escape: pause/unpause

## Learning Goals
- Core arcade loop design
- Input handling and cooldown logic
- UI state transitions
- Time.timeScale based pause flow