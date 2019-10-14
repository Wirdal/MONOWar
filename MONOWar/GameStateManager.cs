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
        private static GameStateManager PrivateInstance;
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
        public static GameStateManager publicInstance
        {
            get
            {
                if (PrivateInstance == null)
                {
                    PrivateInstance = new GameStateManager();
                }
                return PrivateInstance;
            }
        }
        public void SetContent(ContentManager content)
        {
            this.content = content;
        }
        public void AddScreen(GameState screen)
        {
            screens.Push(screen);
            screens.Peek().Initialize(); //Init ti too
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
