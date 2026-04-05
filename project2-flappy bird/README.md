# Project 2 - Flappy Bird

A Unity practice project inspired by Flappy Bird, built to practice 2D movement, spawning, collision handling, and scene flow.

## Type
Practice project

## About
The player controls a bird that must pass obstacles, collect score triggers, and survive until reaching the goal. The project includes menu, game, win, lose, and credits scenes.

## Gameplay Loop
- Start from the main menu.
- Press play to begin.
- Tap/click to flap upward while gravity pulls the bird down.
- Avoid obstacle collisions and out-of-bounds movement.
- Collect score objects until reaching the target score to win.

## Main Scenes
- mainMenu
- game
- lose
- win
- credits

## Key Systems
- Player movement with Rigidbody2D force
- Obstacle spawning with timed invoke
- Health and score UI
- Win and lose transitions
- Credits text spawning and scrolling

## Key Scripts
- Assets/scripts/Bird.cs
- Assets/scripts/SpawnManager.cs
- Assets/scripts/Rock.cs
- Assets/scripts/BackgroundManager.cs
- Assets/scripts/MySceneManager.cs

## Controls
- Space or left mouse click: flap/jump

## Learning Goals
- 2D physics gameplay
- Trigger/collision handling
- Scene management
- Basic audio feedback and UI updates