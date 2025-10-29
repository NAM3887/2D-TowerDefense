#2D Tower Defense - Scripts Only
This repository contains the C# scripts for my 2D Tower Defense game developed in Unity.
It focuses on core gameplay mechanics including tower placement, enemy waves, and UI updates.
The full game build (playable demo) is hosted separately.

Demo
Play the game here: [Here]

Project Structure
Scripts/
Buildings – Logic for towers, placement, and building behaviors
EnemyScripts – Enemy behaviors, health, movement, and special abilities
Managers – Level Manager, Wave Manager, Currency and Lives management
UI – Scripts for updating text, menus, and popups
Bullet.cs – Handles projectile behavior and damage
Plot.cs – Handles plot tile interactions
Features Implemented
Tower placement and selection
Enemy waves with life tracking
Wave and Lives UI text updates via events
Currency system using events
Menu improvements: round display, tower stats, affordability popups
Dev Log Example (8/7/25)
Added text boxes for current wave and player lives
Used events to update UI without tight coupling
Learned about event-driven design in Unity and its benefits
Plans: Clean up code, refine event usage, integrate currency updates via events, and experiment with C# interfaces for better modularity
Skills Demonstrated
Unity C# scripting and OOP
Event-driven programming
Game mechanics design
UI updates and interaction
Code planning and iterative development
Notes
This repo contains only scripts, no assets or builds
Full playable demo link is provided above
Scripts are structured for readability and maintainability
