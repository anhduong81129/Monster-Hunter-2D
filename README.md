# Monster Hunter Survival 2D

A **2D top-down survival game** developed with **Unity and C#**.  
The player must survive endless waves of monsters while automatically attacking with a rotating sword.

This project demonstrates **game mechanics design, basic AI behavior, and mathematical algorithms used in gameplay systems**.

---

## Game Overview

**Genre:** Survival / Action  
**Platform:** Mobile (Unity 2D)  
**Engine:** Unity  
**Language:** C#

Players control a character using a **virtual joystick** and must avoid or eliminate monsters to survive as long as possible and achieve a high score.

---

## Key Features

- **Mobile Joystick Movement** for smooth player control
- **Enemy AI System** where monsters chase the player
- **Endless Monster Spawning** around the player
- **Automatic Sword Attack** rotating around the character
- **Score System** based on defeated monsters
- **Pause / Resume / Replay** game state system

---

## Game Systems

| System | Description |
|------|-------------|
| Player Movement | Controlled by floating joystick |
| Monster AI | Enemies chase the player |
| Monster Spawning | Random spawn in a circular radius |
| Combat System | Sword destroys monsters on contact |
| Score System | Score increases when enemies are defeated |
| Game State | Pause, resume and restart |

---

### Algorithms Used

## Circular Random Spawn
Monsters spawn evenly around the player using polar coordinates.

x = cos(angle) * spawnDistance
y = sin(angle) * spawnDistance
spawnPosition = playerPosition + offset

## Vector Normalization (Enemy AI)
Allows monsters to move toward the player with constant speed.

direction = playerPosition - monsterPosition
movement = direction.normalized * speed * deltaTime


### Sword Orbit Rotation
Creates a circular orbit movement around the player.

angle += rotationSpeed * deltaTime
x = cos(angle) * radius
y = sin(angle) * radius


---

## Project Structure

| Script | Responsibility |
|------|---------------|
| Player.cs | Player movement and collision detection |
| MonsterAI.cs | Enemy chasing behavior |
| MonsterSpawner.cs | Spawn monsters around player |
| SwordController.cs | Sword rotation and attack |
| PauseManager.cs | Pause / resume game |
| ScoreUI.cs | Display player score |

---

## Controls

| Action | Input |
|------|------|
| Move Player | Floating Joystick |
| Pause Game | Pause Button |
| Resume Game | Resume Button |
| Replay | Replay Button |

---

## Tools & Technologies

- Unity 2D
- C#
- TextMeshPro
- Floating Joystick UI

---

## Learning Outcomes

Through this project I practiced:

- Designing **gameplay systems**
- Implementing **basic enemy AI**
- Using **vector math and trigonometry in gameplay**
- Structuring a **Unity game project**
- Building a **mobile-friendly control system**

---