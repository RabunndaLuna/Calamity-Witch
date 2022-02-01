# Release Notes

## Overview
**With each milestone, provide a _brief_ summary of the implementation that was completed.**

These notes should include what is done, how to launch/test it, and any known bugs. _(These release notes should also be included in the tag itself.)_

## Milestone 1
- Set up initial Monogame Project
- Set up a finite state machine using enums and switch statements
- Put in a placeholder title screen 

## Milestone 2
- External Tool: Mono game reads the text file and creates collidable objects (class yet to be implemented), based on the external tool’s created document (see external tool documentation)

- Map scrolling which simulates player's movement implemented (use wasd to scroll the map in respective directions, indirectly moves the player)

- Player Projectile firing is completely implemented (click a space on the map to have a projectile fire from the player in the direction of the mouse click, moves until the recent projectile is offscreen)

- Spell switching: while in-game use keys fgh to switch between spell types (f for fire, g for water, h for earth), UI indication on the top screen indicates which spell the player is using

- Player Class nearly completed which includes: Class fields and properties, firing projectiles, switching between spells, GUI indication of active spell

- GUI: Main menu has a clickable buttons which will change the game's state based on which button clicked

- Projectile Class nearly completed which includes: class fields and properties, method for projectile moving based on a firing direction

- Placeholder StateChanges implemented, with directions to switch between states

- Abstract Character Class implemented and completed 

- General refactoring of many classes to accomplish some of the following above 


## Milestone 3
- External Tool: Mono game reads a text file named map.txt located in the monogame solution, creates collidable objects, and places the collidable object on the map, all based on the contents of the external tool

- Collidable object, enemies, and projectiles scroll based on player movement like the background map

- In addition to scrolling with the map, enemies move directly towards the player while they are alive

- Enemy Firing: While an enemy is alive it fires a projecting in a straight path directly towards where the player was when it was fired  

- Clumsiness Mechanic implemented: There is a random chance for the players projectile to not fire because our witch clumsy ;)

- Players and enemies take damage from projectiles. Enemies enrage, take more damage, or take default damage based on that type of enemy and the spell it was hit by (see documentation for more info about this)

- Enemy class and its methods: Implemented and completed, which include its constructor, taking damage, dying, and firing projectiles, and enraging

- Enemy Enraging: when an enemy is hit a certain spell it enrages, which means its projectiles are faster, the enemy shoots more often, and the enemies appearance changes

- Enemy Manager and its methods: which include spawning random enemies types on the screen at random locations (max 10 at a time), all of those enemies taking damage when necessary, all enemies firing projectiles and moving towards the player

- Necessary objects/fields are reset anytime the player starts a new game

- Options menu was changed to instructions menu and now gives a summary of the games objectives and controls 

- High scores are saved upon the players death in that round, and displayed in order in the high score menu 

- GUI : Current health of the player and their current scored is displayed on the in-game screen, and the death screen displays the score achieved that round

- General bug fixes and refactoring especially for the Character and Player class

- Know error: upon entering the game the player shoots a projectile to the upper left corner
