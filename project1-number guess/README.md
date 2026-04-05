# Project 1 - Number Guess

A small Unity practice project where the game guesses the player's number.

## Type
Practice project

## About
This project is a simple logic and UI exercise. The player thinks of a number, and the game keeps generating a guess between minimum and maximum limits. The player responds with whether the target number is greater or smaller, and the range is updated.

## Gameplay Flow
- Start at the start scene.
- Move to the core game scene.
- Use the UI buttons to tell the game if your number is higher or lower than the current guess.
- Continue until the guess matches your number.

## Main Scenes
- start game
- core game
- end game

## Key Scripts
- Assets/script/numbers.cs: Handles random guessing and min/max range updates.
- Assets/script/MySceneManager.cs: Handles scene switching and quitting.

## Controls
- Mouse click on UI buttons (Greater / Smaller / Next).

## Learning Goals
- Basic game flow using scenes
- Working with UI text (TextMeshPro)
- Simple random-range logic