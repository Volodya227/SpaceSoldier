SpaceSoldier — Modular FPS Prototype (Unity)

Custom FPS prototype focused on modular gameplay architecture and input abstraction.
The project explores how gameplay systems can be structured independently from Unity-specific components.

Core idea:
Separate gameplay logic from engine infrastructure while keeping the project lightweight and framework-free.

Architecture

The project is organized into independent systems:

Bootstrap — initializes global services and manages scene loading  
Systems — gameplay orchestration (player, character, weapon)  
Input Layer — abstraction over multiple input sources  
UI Layer — gameplay state visualization  
Camera — view control

MonoBehaviour classes primarily act as adapters between Unity and the core systems.

Input System

Input handling is fully abstracted from gameplay logic.  
Gameplay systems receive domain-specific input objects instead of raw Unity input.

Supported input sources:
- Unity Legacy Input
- Unity Input System
- Mobile UI joystick

This allows switching input implementations without modifying gameplay systems.

Bootstrap

A lightweight bootstrap container replaces heavy DI frameworks.

Responsibilities:
- initialize global services
- manage scene transitions
- expose shared systems through a global container

Tech

Unity  
C#  
Custom lightweight bootstrap (no external DI frameworks)
