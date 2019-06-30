using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MONOWar
{
    //NO exception handling here. May need to add them for later
    class GameStateManager
    {
        // Singleton pattern
        private static GameStateManager instance;
        public GameTime gameTime;
        // Going to store the game states within a stack
        private Stack<GameState> screens = new Stack<GameState>();
        private  ContentManager content
        {
            get; set;
        }

        public Game gameInstance
        {
            get; set;
        }
        // Also a field, because I don't think I can pass it around too much
        public static GameStateManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameStateManager();
                }
                return instance;
            }
        }
        public void SetContent(ContentManager content)
        {
            this.content = content;
        }
        public void AddScreen(GameState screen)
        {
            screens.Push(screen); // I didn't do the initializing and loading of the gamestate here like the tutorial did. might need it
            screens.Peek().LoadContent(content); //Pass it the content manager
        }
        public void RemoveScreen()
        {
            if (screens.Count() > 0)
            {
                screens.Pop();
            }
        }
        public void ClearScreens()
        {
            while (screens.Count() > 0)
            {
                screens.Pop();
            }
        }

        // Update top screen
        public void Update(GameTime gameTime)
        {
            if (screens.Count() > 0)
            {
                screens.Peek().Update(gameTime);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (screens.Count() > 0)
            {
                screens.Peek().Draw(spriteBatch);
            }
        }
        public void UnloadContent()
        {
            foreach(GameState screen in screens)
            {
                screen.UnloadContent();
            }
        }

    }
}
