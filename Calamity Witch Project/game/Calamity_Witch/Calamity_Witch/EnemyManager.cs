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
    //Spawns enemies, Moves Enemies, Makes Enemies attack, etc
    class EnemyManager
    {
        // Fields 
        // List of all alive enemies
        private List<Enemy> aliveEnemies;

        Random RNG;

        // Textures of the Different Enemies
        Texture2D fireEnemyTex;
        Texture2D waterEnemyTex;
        Texture2D earthEnemyTex;

        Texture2D enragedFireTex;
        Texture2D enragedWaterTex;
        Texture2D enragedEarthTex;

        // Textures of the enemey
        Texture2D fireSpellTex;
        Texture2D waterSpellTex;
        Texture2D earthSpellTex;

        // BaseStats for enemies
        // All will be passed into the individual enemies
        int baseHealth;
        double baseAttackSpeed;
        int baseMoveSpeed;
        Rectangle baseAttackRange;
        
        // How long inbetween spawns to spawn an enemy
        float timeToSpawn;
        float lastSpawn;

        //Enemies killed tracker
        int score;

        // Gets the current list of AliveEnemies
        public List<Enemy> AliveEnemies
        {
            get { return aliveEnemies; }
        }

        public int Score
        {
            get { return score; }
        }

        // Initizes the list, Takes all the base stats and Textures
        public EnemyManager(int baseHealth, double baseAttackSpeed, int baseMoveSpeed,
            Texture2D fireEnemieTex, Texture2D waterEnemieTex, Texture2D earthEnemieTex,
            float timeToSpawn, Rectangle baseAttackRange, Texture2D fireSpellTex,
            Texture2D waterSpellTex, Texture2D earthSpellTex)
        {
            this.baseHealth = baseHealth;
            this.baseAttackSpeed = baseAttackSpeed;
            this.baseMoveSpeed = baseMoveSpeed;
            this.fireEnemyTex = fireEnemieTex;
            this.waterEnemyTex = waterEnemieTex;
            this.earthEnemyTex = earthEnemieTex;
            this.timeToSpawn = timeToSpawn;
            this.baseAttackRange = baseAttackRange;
            this.fireSpellTex = fireSpellTex;
            this.waterSpellTex = waterSpellTex;
            this.earthSpellTex = earthSpellTex;
            aliveEnemies = new List<Enemy>();
            RNG = new Random();
            this.timeToSpawn = timeToSpawn;
            this.lastSpawn = 0;
            score = 0;
        }

        public void ShootProjectiles(double gameTime)
        {
            //Shoot by default every 3 secs, shooting based on enemy type
            if (gameTime % 5 == 0)
            {
                foreach (Enemy e in aliveEnemies)
                {
                    e.Attack(e.EnemyType);
                }
            }
        }

        public void MoveAllEnemies(GameTime gameTime, Player playerCharacter)
        {
            foreach (Enemy e in aliveEnemies)
            {
                if (e.CurrentProjectile.IsActive == false)
                {
                    e.DirectionToPlayer = new Vector2(playerCharacter.Position.X, playerCharacter.Position.Y);
                }

                e.Update(gameTime);

                //Actually move the enemies based on player position
                //Check X position
                if (e.Position.X < playerCharacter.Position.X)
                {
                    e.PositionX++;
                }
                else
                {
                    e.PositionX--;
                }
                //Check Y position
                if (e.Position.Y < playerCharacter.Position.Y)
                {
                    e.PositionY++;
                }
                else
                {
                    e.PositionY--;
                }
            }

            //Clean up dead enemies from the list
            for (int i = 0; i < aliveEnemies.Count; i++)
            {

                if (aliveEnemies[i].IsAlive == false)
                {
                    aliveEnemies[i].CurrentProjectile.IsActive = false;
                    if (aliveEnemies[i].IsEnraged)
                    {
                        score = score + 2;
                    }
                    else
                    {
                        score++;
                    }
                    aliveEnemies.RemoveAt(i);
                    i--;
                    
                    
                }
            }
        }

        // If the player's projectile intersects with an enemy it takes damage
        public void AllEnemiesTakeDamage(Type damageType, Player currentPlayer)
        {
            //damage will always be base of 1
            foreach (Enemy e in aliveEnemies)
            {
                if (currentPlayer.CurrentProjectile.IsActive && currentPlayer.CurrentProjectile.HasCollided(e.Position))
                {
                    e.TakeDamage(currentPlayer.DamageAmount, damageType);
                }
            }
        }

        // Clear the manager
        public void ClearAllEnemies()
        {
            aliveEnemies.Clear();
            score = 0;
        }

        public void SpawnEnemies(GameTime gameTime, int playerLevel, int screenWidth, int screenHeight)
        {
            //Spawn enemies based on gametime and a cap based on player level
            //RNG element to spawn enemy of random type
            int enemyRandomizer = RNG.Next(1, 4);

            //Nature only for now, should make random enemy type
            lastSpawn += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (lastSpawn >= timeToSpawn)
            {
                if (aliveEnemies.Count <= 10) //Hard enemy cap until playerlevel is implemented
                {
                    switch (enemyRandomizer)
                    {
                        case 1:
                            {
                                //Spawn fire enemy
                                aliveEnemies.Add(new Enemy(2, 2, 2, fireEnemyTex, new Rectangle(RNG.Next(screenWidth), RNG.Next(screenHeight), fireEnemyTex.Height, fireEnemyTex.Width),
                        new Vector2(screenWidth, screenHeight), false, Type.Fire, fireSpellTex,
                        new Rectangle(0, 0, screenWidth, screenHeight), 2.0f));
                                lastSpawn = 0;
                                break;
                            }
                        case 2:
                            {
                                //Spawn water enemy
                                aliveEnemies.Add(new Enemy(2, 2, 2, waterEnemyTex, new Rectangle(RNG.Next(screenWidth), RNG.Next(screenHeight), waterEnemyTex.Height, waterEnemyTex.Width),
                        new Vector2(screenWidth, screenHeight), false, Type.Water, waterSpellTex,
                        new Rectangle(0, 0, screenWidth, screenHeight), 2.0f));
                                lastSpawn = 0;
                                break;
                            }
                        case 3:
                            {
                                //Spawn nature enemy
                                aliveEnemies.Add(new Enemy(2, 2, 2, earthEnemyTex, new Rectangle(RNG.Next(screenWidth), RNG.Next(screenHeight), earthEnemyTex.Height, earthEnemyTex.Width),
                        new Vector2(screenWidth, screenHeight), false, Type.Nature, earthSpellTex,
                        new Rectangle(0, 0, screenWidth, screenHeight), 2.0f));
                                lastSpawn = 0;
                                break;
                            }


                    }
                    
                }
                
            }
        }
       
    }
}
