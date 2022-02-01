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
    //Overarching charater class, defines traits all onscreen characters have
    abstract class Character
    {
        //Fields
        protected int health;
        protected float attackSpeed;
        protected int movementSpeed;
        protected Texture2D textures;
        protected bool isAlive;
        protected Rectangle position;
        protected Vector2 screenSize;
        protected Vector2 projectileDirection;
        protected int damageAmount;

        protected Projectile characterProjectile;
        protected Texture2D projectileTex;
        protected Type characterType;

        //Constructor
        protected Character(int cHealth, float aSpeed, int mSpeed, Texture2D tex, Rectangle pos, 
            Vector2 screenSize, Type characterType, Texture2D projectileTex)
        {
            health = cHealth;
            attackSpeed = aSpeed;
            movementSpeed = mSpeed;
            textures = tex;
            position = pos;
            isAlive = true;
            this.screenSize = screenSize;
            this.projectileTex = projectileTex;
            this.characterType = characterType;
            characterProjectile = new Projectile(aSpeed, projectileTex, false, 1, characterType, screenSize, new Vector2 (pos.X, pos.Y));
            damageAmount = 1;
        }

        //Properties
        public Vector2 ScreenSize
        {
            get { return screenSize; }
        }

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public Texture2D Textures
        {
            get { return textures; }
            set { textures = value; }
        }

        public int DamageAmount
        {
            get { return damageAmount; }
            set { damageAmount = value; }
        }

        public double AttackSpeed
        {
            get { return attackSpeed; }
        }
        public int MovementSpeed
        {
            get { return movementSpeed; }
        }
        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }
        public Rectangle Position
        {
            get { return position; }
            set { position = value; }
        }

        public Type CharacterType
        {
            get { return characterType; }
        }

        public Projectile CurrentProjectile
        {
            get
            {
                if (characterProjectile != null)
                {
                    return characterProjectile;
                }
                return null;
            }
        }

        //Abstract Methods
        //Attack method, overriden by enemy and player to allow different attacks for each
        public abstract void Attack(Type attackType);

        //Take damage, overridden by player and enemy to allow for enemy power up
        public abstract void TakeDamage(int damage, Type attackType);

        //Game logic pertaining to the character happens here
        public abstract void Update(GameTime gameTime);

        // Returns wether or not the character is on screen
        public virtual bool OnScreen()
        {
            if (position.X > screenSize.X)
            {
                return false;
            }
            if (position.Y > screenSize.Y)
            {
                return false;
            }
            if (position.X < -textures.Width)
            {
                return false;
            }
            if (position.Y < -textures.Height)
            {
                return false;
            }
            return true;
        }

        // Virtual Method for drawing the character
        public virtual void Draw(SpriteBatch sb)
        {
            if (health >= 0)
            {
                sb.Draw(textures, position, Color.White);
            }
            
        }

        
    }
}
