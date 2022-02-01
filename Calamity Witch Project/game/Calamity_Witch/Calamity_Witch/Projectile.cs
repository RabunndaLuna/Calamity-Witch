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
    // Class that handles projectile firing, collision, and drawing
    class Projectile
    {
        // Projectile Fields
        private float movementSpeed;
        private Texture2D projectileTex;
        private bool isActive;
        private int damage;
        private Type spellType;
        private Vector2 positionVector;
        private Vector2 screenSize;

        // Projectile Properties
        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        public float MovementSpeed
        {
            get { return movementSpeed; }
            set { movementSpeed = value; }
        }

        public float PositionVectorX
        {
            get { return positionVector.X ; }
            set { positionVector.X = value; }
        }

        public float PositionVectorY
        {
            get { return positionVector.Y; }
            set { positionVector.Y = value; }
        }


        public Vector2 PositionVector
        {
            get { return positionVector; }
            set { positionVector = value; }
        }

        public Texture2D ProjectileTex
        {
            get { return projectileTex; }
            set { projectileTex = value; }
            
        }

        public Type SpellType
        {
            get { return spellType; }
            set { spellType = value ; }
        }

        // Constructor
        public Projectile(float movementSpeed, Texture2D projectileTex, bool isActive, int damage, Type spellType, Vector2 screenSize, Vector2 positionVector)
        {
            this.movementSpeed = movementSpeed;
            this.projectileTex = projectileTex;
            this.isActive = isActive;
            this.damage = damage;
            this.spellType = spellType;
            this.screenSize = screenSize;
            this.positionVector = positionVector;
        }

        
        // Take a direction of a Projectile's motion and moves the projectile accordingly  
        public void MoveProjectile(Vector2 attackDirection, Rectangle attackRange)
        {
            // THe speed in which the projectile moves

            positionVector.X += attackDirection.X * movementSpeed;
            positionVector.Y += attackDirection.Y * movementSpeed;

            // If it goes past the boundaries of the screen set it to false
            if (positionVector.X > screenSize.X || positionVector.Y > screenSize.Y || positionVector.X < -projectileTex.Width || positionVector.Y < -projectileTex.Height)
            {
                isActive = false;
            }

            if (!attackRange.Contains(attackRange))
            {
                isActive = false;
            }

        }

        // Checks if a projectile has made collision with something
        
        public bool HasCollided(Rectangle checkCollision)
        {
            int projectileX = (int)PositionVector.X;
            int projectileY = (int)PositionVector.Y;
            Rectangle projectilePosition = new Rectangle(projectileX, projectileY, projectileTex.Width, projectileTex.Height);

            if (projectilePosition.Intersects(checkCollision))
            {

                isActive = false;
                return true;
            }
            return false;
        }
        

        // Draws a projectile
        // Stretch goal implementation: have the spell sprite rotait to the direction of it's fired path
        public virtual void Draw(SpriteBatch sb)
        {
            
            if (spellType == Type.Nature)
            {
                sb.Draw(
                projectileTex,
                positionVector,
                Color.GreenYellow);
            }
            else
            {
                sb.Draw(
                projectileTex,
                positionVector,
                Color.White);
            }
        }

    }
}
