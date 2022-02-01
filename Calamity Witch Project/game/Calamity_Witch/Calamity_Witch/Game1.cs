using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace Calamity_Witch
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    /// 

    //Defines all possible game states
    enum GameState
    {
        MainMenu,
        InGame,
        HighScoreMenu,
        InstructionsMenu,
        GameLoss
    }

    enum Type
    {
        Fire,
        Water,
        Nature
    }

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Enemy Manager
        EnemyManager enemyManager;

        //Resolution variables
        int screenWidth;
        int screenHeight;

        //Main menu buttons
        Rectangle startGameButton;
        Rectangle highScoreButton;
        Rectangle optionsButton;
        Rectangle quitButton;

        // Vectors
        Vector2 defaultTextPosition;

        //Fonts
        SpriteFont buttonFont;
        SpriteFont scoreFont;
        SpriteFont placeholderFont;

        //Textures
        Texture2D playerSprite;
        Texture2D enemySprite;
        Texture2D fireEnemySprite;
        Texture2D waterEnemySprite;
        Texture2D earthEnemySprite;
        Texture2D backImage;
        Texture2D fireSpell;
        Texture2D natureSpell;
        Texture2D waterSpell;

        // Map Textures
        Texture2D waterMap;
        Texture2D fireMap;
        Texture2D boulderMap;
        Texture2D stumpMap;
        Texture2D treeMap;

        // Class objects
        // Player Character
        Player playerCharacter;
        Enemy placeHolderEnemy;

        // Array of map tiles
        CollidableObject[,] loadedMapTiles;


        //Background Image
        Rectangle background;
        Rectangle outOfBounds;

        // Field for the correctly loaded file
        bool correctlyLoadedFile;

        //Stored keyboard+mouse states
        KeyboardState prevKBState;
        MouseState prevMState;

        //Game fields
        GameState currentState;
        double gameSpeed;
        int moveSpeed = 1;

        List<int> highScores;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            highScores = new List<int>();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            IsMouseVisible = true;

            //Start the game on the main menu by default
            currentState = GameState.MainMenu;

            //default testing screen size
            // X : 800
            // Y : 480
            screenWidth = graphics.GraphicsDevice.Viewport.Width;
            screenHeight = graphics.GraphicsDevice.Viewport.Height;

            defaultTextPosition = new Vector2(screenWidth/4, screenHeight/2);

            // Initialize menu button rectangles
            // Needs better positions and sizes
            startGameButton = new Rectangle(new Point(50, 50), new Point(25, 50));
            highScoreButton = new Rectangle(new Point(100, 100), new Point(25, 50));
            optionsButton = new Rectangle(new Point(150,150), new Point(25, 50));
            quitButton = new Rectangle(new Point(200,200), new Point(25, 50));  

           


            graphics.ApplyChanges();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            // Royality Free Placeholder assets
            // Player and EnemySprites
            playerSprite = Content.Load<Texture2D>("CalamityWitch");
            enemySprite = Content.Load<Texture2D>("CalamityGrock");
            fireEnemySprite = Content.Load<Texture2D>("fireEnemy");
            waterEnemySprite = Content.Load<Texture2D>("waterEnemy");
            earthEnemySprite = Content.Load<Texture2D>("earthEnemy");
            
            // Background Image
            backImage = Content.Load<Texture2D>("Background");

            // Royality Free Spell Sprites
            fireSpell = Content.Load<Texture2D>("Fireball_Effect");
            natureSpell = Content.Load<Texture2D>("Arcane_Effect");
            waterSpell = Content.Load<Texture2D>("Water__Effect");

            // Royality Free Map Sprites
            fireMap = Content.Load<Texture2D>("fireTerrain");
            waterMap = Content.Load<Texture2D>("waterTerrain");
            boulderMap = Content.Load<Texture2D>("boulderTerrain");
            stumpMap = Content.Load<Texture2D>("stumpTerrain");
            treeMap = Content.Load<Texture2D>("treeTerrain");


            //Load the player
            playerCharacter = new Player(5, 12, 5, playerSprite, new Rectangle(((screenWidth/2) - playerSprite.Width/20),
                ((screenHeight/2) - playerSprite.Height/20),
                playerSprite.Width/10, playerSprite.Height/10),
                new Vector2(screenWidth,screenHeight),
                Type.Fire, fireSpell, waterSpell, natureSpell);

            //Initialize Enemy Manager
            enemyManager = enemyManager = new EnemyManager(2, 3, 3, fireEnemySprite, waterEnemySprite, earthEnemySprite, (float)3, new Rectangle(1, 1, 50, 50), fireSpell, waterSpell, natureSpell);


            //Initialize background
            background = new Rectangle(new Point((screenWidth - (backImage.Width * 2)), screenHeight - (backImage.Height * 2)), new Point(backImage.Width * 2, backImage.Height * 2));
            
            // Initialize the out of bounds area
            outOfBounds = new Rectangle(background.X - screenWidth, background.Y - screenHeight, background.Width + screenWidth, background.Height + screenHeight);

            correctlyLoadedFile = LoadNewMap();

            // Loading SpriteFonts
            placeholderFont = Content.Load<SpriteFont>("PlaceholderFont");

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            //Check and store mouse and keyboard states
            KeyboardState kbState = Keyboard.GetState();
            MouseState mState = Mouse.GetState();

            //Check gamestate and run the appropriate method
            switch (currentState)
            {
                case GameState.MainMenu:
                    ProcessMainMenu(gameTime, mState);
                    break;
                case GameState.HighScoreMenu:
                    ProcessHighScoreMenu(kbState);
                    break;
                case GameState.InstructionsMenu:
                    ProcessInstructionsMenu(kbState);
                    break;
                case GameState.InGame:
                    ProcessInGame(gameTime, kbState);
                    break;
                case GameState.GameLoss:
                    ProcessGameLoss(kbState);
                    break;
            }

            //Store kb+m states for processing
            prevKBState = kbState;
            prevMState = mState;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            Color defaultTextColor = Color.Black;
            // Begin SpriteBatch
            spriteBatch.Begin();
            spriteBatch.Draw(backImage, background, Color.White);
            switch (currentState)
            {
                case GameState.MainMenu:
                    // GUI Buttons and titles
                    spriteBatch.DrawString(placeholderFont, "Calamity Witch!", defaultTextPosition, defaultTextColor);
                    spriteBatch.DrawString(placeholderFont, "Click the top witch to enter MainGame", new Vector2 (defaultTextPosition.X, defaultTextPosition.Y + 25), defaultTextColor);
                    spriteBatch.DrawString(placeholderFont, "Click other witches to enter other menues", new Vector2(defaultTextPosition.X, defaultTextPosition.Y + 50), defaultTextColor);
                    // Displays if anything is inncorrect with the read map.txt file
                    if (!correctlyLoadedFile)
                    {
                        spriteBatch.DrawString(placeholderFont, "Incorrect file format: unable to load object onto map", new Vector2(defaultTextPosition.X, defaultTextPosition.Y + 100), defaultTextColor);
                    }
                    spriteBatch.Draw(playerSprite, startGameButton, Color.White);
                    spriteBatch.Draw(playerSprite, optionsButton, Color.White);
                    spriteBatch.Draw(playerSprite, highScoreButton, Color.White);
                    // spriteBatch.Draw(playerSprite, quitButton, Color.White);
                    break;

                // Highscore Menu
                case GameState.HighScoreMenu:
                    spriteBatch.DrawString(placeholderFont, "Highscore Menu", new Vector2(screenWidth/2, 30), defaultTextColor);
                    spriteBatch.DrawString(placeholderFont, "Press Backspeack to go to Main Menu", new Vector2(5, 5), defaultTextColor);
                    // Print the top ten highscores
                    if (highScores.Count >= 10)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            string highScore = String.Format( (i+1) +": {0}", highScores[i]); 
                            spriteBatch.DrawString(placeholderFont, highScore, new Vector2(screenWidth / 2, 75 + (25*i)), defaultTextColor);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < highScores.Count; i++)
                        {
                            string highScore = String.Format((i + 1) + ": {0}", highScores[i]);
                            spriteBatch.DrawString(placeholderFont, highScore, new Vector2(screenWidth / 2, 75 + (25 * i)), defaultTextColor);
                        }
                    }
                    break;

                // Instructions Menu
                case GameState.InstructionsMenu:
                    spriteBatch.DrawString(placeholderFont, "How to Play", defaultTextPosition, defaultTextColor);
                    spriteBatch.DrawString(placeholderFont, "Clear the forest of enemies", new Vector2(defaultTextPosition.X, defaultTextPosition.Y + 25), defaultTextColor);
                    spriteBatch.DrawString(placeholderFont, "using your three spells", new Vector2(defaultTextPosition.X, defaultTextPosition.Y + 50), defaultTextColor);
                    spriteBatch.DrawString(placeholderFont, "Fire, Water, and Nature.", new Vector2(defaultTextPosition.X, defaultTextPosition.Y + 75), defaultTextColor);
                    spriteBatch.DrawString(placeholderFont, "Move using WASD and click the mouse to fire spells", new Vector2(defaultTextPosition.X-150, defaultTextPosition.Y + 100), defaultTextColor);
                    spriteBatch.DrawString(placeholderFont, "Change your current spell by using 1,2,3 buttons", new Vector2(defaultTextPosition.X-150, defaultTextPosition.Y + 125), defaultTextColor);
                    spriteBatch.DrawString(placeholderFont, "Choose your spells carefully or enemies will get stronger", new Vector2(defaultTextPosition.X-150, defaultTextPosition.Y + 150), defaultTextColor);
                    spriteBatch.DrawString(placeholderFont, "Press Backspeack to go to Main Menu", new Vector2(defaultTextPosition.X, defaultTextPosition.Y + 175), defaultTextColor);
                    break;

                // In-game
                case GameState.InGame:

                    // Player character draw override
                    playerCharacter.Draw(spriteBatch);

                    // Draw the player's active projectile
                    if (playerCharacter.CurrentProjectile.IsActive == true)
                    {
                        playerCharacter.CurrentProjectile.Draw(spriteBatch);
                    }

                    // Draws all the alive enemies and their projectiles
                    foreach (Enemy e in enemyManager.AliveEnemies)
                    {
                        e.Draw(spriteBatch);
                        if (e.CurrentProjectile.IsActive)
                        {
                            e.CurrentProjectile.Draw(spriteBatch);
                        }
                    }

                    // Draw all the collidableObjects onto the map
                    if (correctlyLoadedFile)
                    {
                        foreach (CollidableObject c in loadedMapTiles)
                        {
                            if (c != null)
                            {
                                c.Draw(spriteBatch);
                            }
                        }
                    }

                    // In game GUI
                    spriteBatch.DrawString(placeholderFont, "Score: " + enemyManager.Score, new Vector2(0, 50), defaultTextColor);
                    spriteBatch.DrawString(placeholderFont, "Health: " + playerCharacter.Health, new Vector2(0, 75), defaultTextColor);
                    break;
                
                // Game Loss
                case GameState.GameLoss:
                    // Displays a death message and the score achived that round
                    spriteBatch.DrawString(placeholderFont, "Press Enter to go to Main Menu", new Vector2(defaultTextPosition.X, defaultTextPosition.Y + 25), defaultTextColor);
                    spriteBatch.DrawString(placeholderFont, "Score: " + enemyManager.Score, new Vector2(defaultTextPosition.X, defaultTextPosition.Y + 75), defaultTextColor);
                    break;
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        //GameState processing methods
        //Main Menu:
        //Shows options that the player can take to either start the game, check high scores, or change options.
        public void ProcessMainMenu(GameTime gameTime, MouseState mouseState)
        {

            //Get mouse position and check for intersect with any of the buttons
            Rectangle mouseIntersect;
            Point mousePosition;

            if (prevKBState != null)
            {
                if (mouseState.LeftButton == ButtonState.Pressed && prevMState.LeftButton == ButtonState.Released)
                {
                    mousePosition = new Point(mouseState.X, mouseState.Y);
                    mouseIntersect = new Rectangle(mousePosition, new Point(1, 1));

                    if (startGameButton.Intersects(mouseIntersect))
                    {
                        // Resets the nessicary objects/field for the start of the game
                        ResestGame();

                        currentState = GameState.InGame;

                    }

                    if (optionsButton.Intersects(mouseIntersect))
                    {
                        currentState = GameState.InstructionsMenu;
                    }

                    if (highScoreButton.Intersects(mouseIntersect))
                    {
                        highScores.Sort();
                        highScores.Reverse();
                        currentState = GameState.HighScoreMenu;
                    }
                }
            }

            
        }

        // Helper Method: Resets the nessicary objects/field for the start of the game
        public void ResestGame()
        {
            // Resets the player's position
            playerCharacter.Position = new Rectangle(((screenWidth / 2) - playerSprite.Width / 20),
                ((screenHeight / 2) - playerSprite.Height / 20),
                playerSprite.Width / 10, playerSprite.Height / 10);

            // Resets the background
            background = new Rectangle(new Point((screenWidth - (backImage.Width * 2)), screenHeight - (backImage.Height * 2)), new Point(backImage.Width * 2, backImage.Height * 2));

            // Resets the collidable ojects
            int XPosition = background.Width / 20;
            int YPosition = background.Height / 15;
            for (int i = 0; i < loadedMapTiles.GetLength(0); i++)
            {
                for (int j = 0; j < loadedMapTiles.GetLength(1); j++)
                {
                    if (loadedMapTiles[i, j] != null)
                    {
                        loadedMapTiles[i, j] = new CollidableObject(loadedMapTiles[i, j].ObjectTexture,
                    new Rectangle(background.X + (XPosition * j) - loadedMapTiles[i, j].ObjectTexture.Width, background.Y + (YPosition * i) - loadedMapTiles[i, j].ObjectTexture.Height,
                    (treeMap.Width * 2), (treeMap.Height * 2)));
                    }
                }
            }

            // Resets the player's health
            playerCharacter.Health = 5;
            playerCharacter.IsAlive = true;

            // Resets the score and clears the enemie manager
            enemyManager.ClearAllEnemies();
        }

        //High Score Menu:
        //Displays high scores.
        public void ProcessHighScoreMenu(KeyboardState kbState)
        {
            if (kbState.IsKeyDown(Keys.Back))
            {
                currentState = GameState.MainMenu;
            }
        }

        //Instructions Menu: - once options menu but changed
        //Displays instructions for players to know how to play.
        public void ProcessInstructionsMenu(KeyboardState kbState)
        {
            if (kbState.IsKeyDown(Keys.Back))
            {
                currentState = GameState.MainMenu;
            }
        }

        

        //Playing the actual game:
        // Takes the current keyboad state and gameTime
        public void ProcessInGame(GameTime gameTime, KeyboardState kbState)
        {
            //Get kb + m states to process

            //Basic check and adjust the the background image if out of bounds 
            OutOfBoundsCheck();

            // Buggy: Check and adjust is the player is intersecting with any of the map objects
            //PlayerMapCheck();

            //Basic wasd check for scrolling of the map
            if (kbState.IsKeyDown(Keys.W))
            {
                MoveMapUp();
            }
            if (kbState.IsKeyDown(Keys.A))
            {
                MoveMapLeft();
            }
            if (kbState.IsKeyDown(Keys.S))
            {
                MoveMapDown();
            }
            if (kbState.IsKeyDown(Keys.D))
            {
                MoveMapRight();
            }
            
            // Process in game player controll 
            // Player override for update
            playerCharacter.Update(gameTime);
          


            //Calculate enemy spawns using Enemy Manager's SpawnEnemies() method
            enemyManager.SpawnEnemies(gameTime, 3, screenWidth, screenHeight); //3 is placeholder till we get player leveling working
            enemyManager.MoveAllEnemies(gameTime, playerCharacter);
            enemyManager.AllEnemiesTakeDamage(playerCharacter.CharacterType, playerCharacter);
            enemyManager.ShootProjectiles(gameTime.ElapsedGameTime.TotalSeconds);

            //check if enemy projectiles intersect the player and kill if so
            foreach (Enemy e in enemyManager.AliveEnemies)
            {
                if (e.CurrentProjectile.IsActive == true && e.CurrentProjectile.HasCollided(playerCharacter.Position))
                {
                   e.CurrentProjectile.IsActive = false;
                    playerCharacter.TakeDamage(1, e.EnemyType);
                }
            }


            // IF the player has died go to the main menue
            if (playerCharacter.IsAlive == false || kbState.IsKeyDown(Keys.Q))
            {
                currentState = GameState.GameLoss;
            }
        }

        // Check all the sncenios if the background srolling goes out of bounds
        public void OutOfBoundsCheck()
        {
            if (background.X < 0)
            {
                if (outOfBounds.X + screenWidth >= background.X)
                {
                    MoveMapLeft();
                }
            }

            if (background.X > 0)
            {
                if (outOfBounds.X <= background.X)
                {
                    MoveMapRight();
                }
            }

            if (background.Y < 0)
            {
                if (outOfBounds.Y + screenHeight >= background.Y)
                {
                    MoveMapUp();
                }
            }

            if (background.Y > 0)
            {
                if (outOfBounds.Y <= background.Y)
                {
                    MoveMapDown();
                }
            }

        }

        // Buggy: Check and adjust is the player is intersecting with any of the map objects
        /*
        public void PlayerMapCheck()
        {
            foreach (CollidableObject c in loadedMapTiles)
            {
                if (c != null)
                {
                    
                    if (((playerCharacter.Position.Top > c.ObjectRectangle.Bottom) && (playerCharacter.Position.Top < c.ObjectRectangle.Top)) && (playerCharacter.Position.Intersects(c.ObjectRectangle)))
                    {
                        MoveMapDown();
                    }
                    if (playerCharacter.Position.Bottom == c.ObjectRectangle.Top && (c.ObjectRectangle.Intersects(playerCharacter.Position) == true))
                    {
                        MoveMapUp();
                    }
                    if (playerCharacter.Position.Left == c.ObjectRectangle.Right && (c.ObjectRectangle.Intersects(playerCharacter.Position) == true))
                    {
                        MoveMapRight();
                    }
                    if (playerCharacter.Position.Right == c.ObjectRectangle.Left && (c.ObjectRectangle.Intersects(playerCharacter.Position) == true))
                    {
                        MoveMapLeft();
                    }
                }
            }
        }
        */

        // Helper Method scroll everthing left
        public void MoveMapLeft()
        {
            background.X += playerCharacter.MovementSpeed;
            foreach (CollidableObject c in loadedMapTiles)
            {
                if (c != null)
                {
                    c.XLocation += playerCharacter.MovementSpeed;
                }
            }
            playerCharacter.CurrentProjectile.PositionVectorX += playerCharacter.MovementSpeed;

            foreach (Enemy e in enemyManager.AliveEnemies)
            {
                e.PositionX += playerCharacter.MovementSpeed;
                e.CurrentProjectile.PositionVectorX += playerCharacter.MovementSpeed;
            }
        }

        // Helper Method scroll everthing right
        public void MoveMapRight()
        {
            background.X -= playerCharacter.MovementSpeed;
            foreach (CollidableObject c in loadedMapTiles)
            {
                if (c != null)
                {
                    c.XLocation -= playerCharacter.MovementSpeed;
                }
            }

            playerCharacter.CurrentProjectile.PositionVectorX -= playerCharacter.MovementSpeed;
            
            foreach (Enemy e in enemyManager.AliveEnemies)
            {
                e.PositionX -= playerCharacter.MovementSpeed;
                e.CurrentProjectile.PositionVectorX -= playerCharacter.MovementSpeed;
            }
        }

        // Helper Method scroll everthing up
        public void MoveMapUp()
        {
            background.Y += playerCharacter.MovementSpeed;
            foreach (CollidableObject c in loadedMapTiles)
            {
                if (c != null)
                {
                    c.YLocation += playerCharacter.MovementSpeed;
                }
            }

            playerCharacter.CurrentProjectile.PositionVectorY += playerCharacter.MovementSpeed;

            foreach (Enemy e in enemyManager.AliveEnemies)
            {
                e.PositionY += playerCharacter.MovementSpeed;
                e.CurrentProjectile.PositionVectorY += playerCharacter.MovementSpeed;
            }
        }

        // Helper Method scroll everthing down
        public void MoveMapDown()
        {
            background.Y -= playerCharacter.MovementSpeed;
            foreach (CollidableObject c in loadedMapTiles)
            {
                if (c != null)
                {
                    c.YLocation -= playerCharacter.MovementSpeed;
                }
            }

            playerCharacter.CurrentProjectile.PositionVectorY -= playerCharacter.MovementSpeed;

            foreach (Enemy e in enemyManager.AliveEnemies)
            {
                e.PositionY -= playerCharacter.MovementSpeed;
                e.CurrentProjectile.PositionVectorY -= playerCharacter.MovementSpeed;
            }
        }

        // Loads the data necessary from the based on file created by the external tool
        public bool LoadNewMap()
        {
            StreamReader readMapPlacement = null;
            string mapLine = null;
            int rowsToRead = 15;
            int columnsToRead = 20;
            int XPosition = background.Width / 20;
            int YPosition = background.Height / 15;
            
            loadedMapTiles = new CollidableObject[rowsToRead, columnsToRead];
            try
            {
                readMapPlacement = new StreamReader("..\\..\\..\\..\\map.txt");

                for (int i = 0; i < rowsToRead; i++)
                {
                    mapLine = readMapPlacement.ReadLine();
                    //string[] dataLoaded = mapLine.Split('|');

                    for (int j = 0; j < mapLine.Length; j++)
                    {
                        char loadedCharacters = mapLine[j];

                        switch (loadedCharacters)
                        {
                            // Creates a blank tile
                            // Do nothing!
                            case 'x':
                                break;

                            // Creates a tree object
                            case 't':
                            loadedMapTiles[i, j] = new CollidableObject(treeMap, 
                                new Rectangle(background.X + (XPosition * j) - treeMap.Width, background.Y + (YPosition * i) - treeMap.Height, 
                                (treeMap.Width * 2), (treeMap.Height * 2)));
                                break;

                            // Creates a boulder object
                            case 'b':
                                loadedMapTiles[i, j] = new CollidableObject(boulderMap, 
                                    new Rectangle(background.X + (XPosition * j) + boulderMap.Width, background.Y + (YPosition * i) + boulderMap.Height,
                                    (boulderMap.Width * 2), (boulderMap.Height * 2)));
                                break;
                                
                            // Creates a fire object
                            case 'f':
                                loadedMapTiles[i, j] = new CollidableObject(fireMap, 
                                    new Rectangle(background.X + (XPosition * j) + fireMap.Width, background.Y + (YPosition * i) + fireMap.Height,
                                    (fireMap.Width * 2), (fireMap.Height * 2)));
                                break;

                            // Creates a water object
                            case 'w':
                                loadedMapTiles[i, j] = new CollidableObject(waterMap, 
                                    new Rectangle(background.X + (XPosition * j) + waterMap.Width, background.Y + (YPosition * i) + waterMap.Height,
                                    (waterMap.Width * 2), (waterMap.Height * 2)));
                                break;

                             // Creates a stump object
                             case 's':
                             loadedMapTiles[i, j] = new CollidableObject(stumpMap,
                                 new Rectangle(background.X + (XPosition * j) + stumpMap.Width, background.Y + (YPosition * i) + stumpMap.Height,
                                 (stumpMap.Width * 2), (stumpMap.Height * 2)));
                                    break;

                             // Incorrect file format
                             default:
                                return false;
                        }

                    }
                    
                }
            }
            catch
            {
                return false;
            }
            if(readMapPlacement != null)
            {
                readMapPlacement.Close();
            }


            return true;
        }

        //For when the game is lost
        public void ProcessGameLoss(KeyboardState kbState)
        {
            if (kbState.IsKeyDown(Keys.Enter))
            {
                highScores.Add(enemyManager.Score);
                currentState = GameState.MainMenu;
            }
        }
    }
}
