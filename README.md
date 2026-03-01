SpaceSoldier — Modular FPS Prototype (Unity)

Custom FPS prototype focused on modular system architecture, input abstraction, and explicit game state control. The project explores scalable structure for gameplay systems while keeping Unity integration isolated where possible. Core gameplay logic is separated from engine-specific components and organized into independent systems.

Architecture

The project follows a layered modular design:

Bootstrap layer — initializes global systems and manages scene loading
Systems layer — gameplay orchestration (player, character, weapon)
Input layer — abstraction over multiple input sources
UI layer — state visualization and optional mobile input
Gameplay layer — core mechanics (movement, weapon, health)

Structure:

Bootstrap
   │
   ▼
GlobalContainerSystems
   │
   ▼
Scene Systems
   │
   ├─ PlayerSystem
   ├─ CharacterSystem
   ├─ UISystem
   └─ CameraView

Gameplay logic is separated from Unity lifecycle where possible. MonoBehaviour classes primarily act as adapters between Unity and core systems.

Bootstrap System

A minimal bootstrap container replaces heavy DI frameworks (Zenject, etc.).

Responsibilities:

initialize global services

manage scene transitions

provide shared systems through a global container

avoid static singleton dependencies

Structure:

Bootstrap
   │
   ├─ PlayerInput
   ├─ ApplicationData
   └─ BootstrapEvents

Scene-specific initialization is handled by scene bootstrap components.

Input Architecture

Input handling is abstracted from gameplay logic. The system supports multiple input sources without modifying gameplay code.

Supported input sources:

Unity legacy Input API

Unity Input System

UI joystick (mobile)

Structure:

Input Sources
   │
   ├─ PlayerInputOld
   ├─ PlayerInputNew
   └─ UIInputAdapter
        │
        ▼
PlayerInput
        │
        ▼
CharacterInput / WeaponInput / CameraInput

Gameplay systems receive only domain-specific input objects, not raw engine input.

Character System

The character system manages player-controlled entities and encapsulates movement, rotation, health, and weapon interaction.

Structure:

CharacterSystem
      │
      ▼
CharacterController
   │        │
   ▼        ▼
Movement   WeaponController

Responsibilities:

character lifecycle

movement physics

view orientation

health state

weapon integration

Character behavior is split into specialized components (movement, rotation) to isolate responsibilities.

Weapon System

The weapon controller implements a simple hitscan shooting system.

Features:

raycast-based shooting

reload timer

cooldown control

muzzle flash animation

ammo state tracking

damage interface (ITakeDamageable)

Structure:

WeaponController
   │
   ├─ cooldown timer
   ├─ reload logic
   └─ raycast hit detection

Weapon state is synchronized with UI through a container data model.

UI Layer

The UI system visualizes gameplay state and optionally generates input for mobile platforms.

Structure:

UISystem
   │
   ├─ UIInputAdapter
   ├─ UICharacter
   └─ UIWeapon

Responsibilities:

display character health

display weapon state

provide joystick input

dispatch UI input events

UI components subscribe to gameplay state changes and do not mutate gameplay state directly.

State and Data Flow

Gameplay systems rely on explicit state containers instead of implicit engine state.

Key principles:

explicit state mutation

event-driven UI updates

clear separation between simulation and rendering

deterministic update order

Example flow:

Input
  │
  ▼
PlayerController
  │
  ▼
CharacterController
  │
  ├─ Movement update
  └─ Weapon update
  │
  ▼
UI reacts to state changes
Engine Interaction

Unity is used primarily as a runtime environment and rendering layer.

Unity responsibilities:

lifecycle callbacks (Awake, Update, FixedUpdate)

physics (Rigidbody)

scene loading

animation

visual effects

Gameplay systems avoid direct dependency on Unity where possible, allowing clearer control over state and update flow.

Design Focus

This prototype emphasizes:

modular gameplay architecture

input abstraction

minimal dependency injection approach

explicit system boundaries

scalable project structure

The project serves as a preparation stage before developing a larger gameplay-oriented pet project.
