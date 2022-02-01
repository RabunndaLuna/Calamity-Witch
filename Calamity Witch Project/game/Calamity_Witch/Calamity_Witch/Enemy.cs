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
    class Enemy:Character
    {
        //Fields
        bool isEnraged;
        bool alreadyEnraged;
        float timeToAttack;
        float lastAttack;
        Rectangle attackRange;
        Vector2 directionToPlayer;
        Type enemyType;

        // Properties
        public bool IsEnraged
        {
            get { return isEnraged; }
            set { isEnraged = value; }
        }

        public Vector2 DirectionToPlayer
        {
            get { return directionToPlayer; }
            set { directionToPlayer = value; }
        }

        public int PositionX
        {
            get { return position.X; }
            set { position.X = value; }
        }
        public int PositionY
        {
            get { return position.Y; }
            set { position.Y = value; }
        }
        public Type EnemyType
        {
            get { return enemyType; }
        }

        //Constructor
        public Enemy(int cHealth, float aSpeed, int mSpeed, Texture2D tex, Rectangle pos, Vector2 visibleScreenSize, 
            bool isEnraged, Type eType, Texture2D projectileTex, Rectangle attackRange, float timeToAttack)
            : base(cHealth, aSpeed, mSpeed, tex, pos, visibleScreenSize, eType, projectileTex)
        {
            this.isEnraged = false;
            this.attackRange = attackRange;
            this.timeToAttack = timeToAttack;
            this.enemyType = eType;
            this.alreadyEnraged = false;
        }


        public override void Attack(Type attackType)
        {
            if (OnScreen())
            {
                // Set the projectile to the enemy's position
                characterProjectile.PositionVectorX = position.X + (characterProjectile.ProjectileTex.Width / 64);
                characterProjectile.PositionVectorY = position.Y + (characterProjectile.ProjectileTex.Height / 64);
                
                characterProjectile.IsActive = true;

                // Set path toward player
                projectileDirection = directionToPlayer - new Vector2(characterProjectile.PositionVectorX, characterProjectile.PositionVectorY);
                projectileDirection.Normalize();
            }
        }

        // Enemy's Health changes based on the spell damage and type
        // See documention about these details
        public override void TakeDamage(int damage, Type damageType)
        {
            switch (damageType)
            {
                // If an Enemy was hit by a fire spell
                case Type.Fire:
                    if (characterType == Type.Fire)
                    {
                        health -= damage;
                    }
                    else if(characterType == Type.Water)
                    {
                        isEnraged = true;
                    }
                    else if(characterType == Type.Nature)
                    {
                        health -= (2*damage);
                    }
                    break;
                // If an Enemy was hit by a water spell
                case Type.Water:
                    if (characterType == Type.Fire)
                    {
                        health -= (2 * damage);
                    }
                    else if (characterType == Type.Water)
                    {
                        health -= damage;
                    }
                    else if (characterType == Type.Nature)
                    {
                        isEnraged = true;
                    }
                    break;
                // If an Enemy was hit by a nature spell
                case Type.Nature:
                    if (characterType == Type.Fire)
                    {
                        isEnraged = true;
                    }
                    else if (characterType == Type.Water)
                    {
                        health -= (2 * damage);
                    }
                    else if (characterType == Type.Nature)
                    {
                        health -= damage;
                    }
                    break;
            }

            // Enraged enemies shoot projectiles more ofter and are often
            if (isEnraged && alreadyEnraged == false)
            {
                alreadyEnraged = true;
                characterProjectile.MovementSpeed *= 2;
                timeToAttack /= 2;
                int screenSizeX = (int)screenSize.X;
                int screenSizeY = (int)screenSize.Y;
                attackRange = new Rectangle(0, 0, screenSizeX, screenSizeY);
            }

            // Kill the enemy 
            if (health <= 0)
            {
                IsAlive = false;
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (health >= 0)
            {
                // Fire a projectile if it's not active
                lastAttack += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (CurrentProjectile.IsActive == false && lastAttack >= timeToAttack)
                {
                    Attack(characterType);
                    lastAttack = 0;
                }

                // Move the proejctile if it's active
                if (characterProjectile.IsActive == true)
                {
                    characterProjectile.MoveProjectile(projectileDirection, attackRange);
                    lastAttack -= (float)gameTime.ElapsedGameTime.TotalSeconds;

                }

            }
            else
            {
                //Despawn projectile if enemy dies
                this.characterProjectile.IsActive = false; 
            }
        }
        
        // Override of Draw to handle appernce changing from enraging 
        public override void Draw(SpriteBatch sb)
        {
            if (isEnraged && health >= 0 && characterType == Type.Fire)
            {
                sb.Draw(textures, position, Color.OrangeRed);
            }
            else if (isEnraged && health >= 0 && characterType == Type.Water)
            {
                sb.Draw(textures, position, Color.SteelBlue);
            }
            else if (isEnraged && health >= 0 && characterType == Type.Nature)
            {
                sb.Draw(textures, position, Color.ForestGreen);
            }
            else
            {
                base.Draw(sb);
            }
           
        }
    }
}
