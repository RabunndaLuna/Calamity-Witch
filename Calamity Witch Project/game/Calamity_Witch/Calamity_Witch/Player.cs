using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Calamity_Witch
{
    //The player character, what the player controls/interacts with
    class Player:Character
    {
        //Fields
        Texture2D fireSpell;
        Texture2D waterSpell;
        Texture2D earthSpell;
        MouseState prevMState;
        KeyboardState prevKBState;

        Random RNG;
        

        //Constructor
        public Player(int cHealth, float aSpeed, int mSpeed, Texture2D tex, Rectangle pos, Vector2 screenSize, Type spellType,
            Texture2D fireSpell, Texture2D waterSpell, Texture2D earthSpell)
            :base(cHealth, aSpeed, mSpeed, tex, pos, screenSize, spellType, fireSpell)
        {
            this.fireSpell = fireSpell;
            this.waterSpell = waterSpell;
            this.earthSpell = earthSpell;
            RNG = new Random();
            
        }

        // Change the type of a projectile according to the parameter, which would be the player's current spell
        public override void Attack(Type attackType)
        {
            int fizzle = RNG.Next(1, 11);

            if (fizzle <= 1)
            {
                //Spell fizzles, do nothing intentionally
            }
            else
            {
                characterProjectile.SpellType = attackType;
                switch (attackType)
                {
                    case Type.Fire:
                        characterProjectile.ProjectileTex = fireSpell;
                        break;

                    case Type.Nature:
                        characterProjectile.ProjectileTex = earthSpell;
                        break;

                    case Type.Water:
                        characterProjectile.ProjectileTex = waterSpell;
                        break;
                }
            }
           
        }

        // Process taking damage
        public override void TakeDamage(int damage, Type damageType)
        {
            health -= damage;
            if (health <= 0)
            {
                isAlive = false;
            }
        }

        public override void Update(GameTime gameTime)
        {
            //Get kb + m states to process in Game Actions, including Projectile firing
            KeyboardState kbState = Keyboard.GetState();
            MouseState mState = Mouse.GetState();

            if (prevMState != null)
            {
                // Convert to firespell
                if ((kbState.IsKeyDown(Keys.D1) && prevKBState.IsKeyUp(Keys.D1)) && characterProjectile.IsActive == false)
                {
                    characterType = Type.Fire;
                } 

                // Convert to water spell
                if ((kbState.IsKeyDown(Keys.D2) && prevKBState.IsKeyUp(Keys.D2)) && characterProjectile.IsActive == false)
                {
                    characterType = Type.Water;
                }

                // Convert to earthspell
                if ((kbState.IsKeyDown(Keys.D3) && prevKBState.IsKeyUp(Keys.D3)) && characterProjectile.IsActive == false)
                {
                    characterType = Type.Nature;
                }


                    // If the player pressed and released a the mouse but and if there is not a current projectile active, fire one
                if ((mState.LeftButton == ButtonState.Pressed && prevMState.LeftButton == ButtonState.Released)  
                    && characterProjectile.IsActive == false 
                    && mState.X < screenSize.X && mState.X > 0 && mState.Y < screenSize.Y && mState.Y > 0)
                {
                    // set the projectile to the play's position
                    characterProjectile.PositionVectorX = position.X + (characterProjectile.ProjectileTex.Width/64);
                    characterProjectile.PositionVectorY = position.Y + (characterProjectile.ProjectileTex.Height/64);

                    // Set the player's projectile to active
                    characterProjectile.IsActive = true;
                    
                    // Change the spell type if nessicary 
                    Attack(characterType);

                    // Fides the destination of the projectiles path and the angle which that path will take
                    projectileDirection = new Vector2(mState.X, mState.Y) - new Vector2(characterProjectile.PositionVectorX, characterProjectile.PositionVectorY);
                    projectileDirection.Normalize();
                    

                }
            }
            
            // While the player has a projectile active, move it
            if (characterProjectile.IsActive == true)
            {
                int screenX = (int)screenSize.X;
                int screenY = (int)screenSize.Y;
                characterProjectile.MoveProjectile(projectileDirection, new Rectangle(0,0, screenX, screenY));
            }
            prevMState = mState;
            prevKBState = kbState;
        }

        public override void Draw(SpriteBatch sb)
        {
            // Draws the character
            base.Draw(sb);

            // Draws GUI for spells on top middle of the screen
            Vector2 projectileUIPositions = new Vector2(position.X - (characterProjectile.ProjectileTex.Width / 4), (characterProjectile.ProjectileTex.Height / 64));

            // Draw the active spell on the top of the screen shaded in it's elemental color
            // Draw the non active spells shaded in black
            if (characterType == Type.Fire)
            {
                sb.Draw(fireSpell, new Vector2(projectileUIPositions.X - fireSpell.Width, projectileUIPositions.Y), Color.White);
            }
            else
            {
                sb.Draw(fireSpell, new Vector2(projectileUIPositions.X - fireSpell.Width, projectileUIPositions.Y), Color.Black);
            }


            if (characterType == Type.Water)
            {
                sb.Draw(waterSpell, new Vector2(projectileUIPositions.X, projectileUIPositions.Y), Color.White);
            }
            else
            {
                sb.Draw(waterSpell, new Vector2(projectileUIPositions.X, projectileUIPositions.Y), Color.Black);
            }

            if (characterType == Type.Nature)
            {
                sb.Draw(earthSpell, new Vector2(projectileUIPositions.X + earthSpell.Width, projectileUIPositions.Y), Color.YellowGreen);
            }
            else
            {
                sb.Draw(earthSpell, new Vector2(projectileUIPositions.X + earthSpell.Width, projectileUIPositions.Y), Color.Black);
            }
        }
    }
}
