﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MONOWar
{

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class MONOWar : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public MONOWar()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
            // Set up gamestate manager with information
            GameStateManager.publicInstance.SetContent(Content);
            GameStateManager.publicInstance.gameInstance = this;
            GameStateManager.publicInstance.window = new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferWidth);

            // Let's create the main menu screen here
            IsMouseVisible = true;
            MainMenu mainScreen = new MainMenu(graphics.GraphicsDevice);
            GameStateManager.publicInstance.AddScreen(mainScreen);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            // TODO: use this.Content to load your game content here
            spriteBatch = new SpriteBatch(GraphicsDevice);
            MapManager.publicInstance.LoadContent(Content);
            UnitManager.publicInstance.LoadContent(Content);
            FontManager.publicInstance.LoadContent(Content);
            UIManager.publicInstance.LoadContent(Content);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            GameStateManager.publicInstance.UnloadContent();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            GameStateManager.publicInstance.Update(gameTime);
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

            // TODO: Add your drawing code here
            GameStateManager.publicInstance.Draw(spriteBatch);
            base.Draw(gameTime);
        }
    }
}
