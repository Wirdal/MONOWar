using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

//https://rareelementgames.wordpress.com/2017/04/21/game-state-management/
namespace MONOWar
{
    public class MainMenu : GameState
    {
        List<Button> Buttons = new List<Button>();

        Texture2D StartButtonTexture;
        Texture2D CurrentBackdrop;
        public MainMenu(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
            Buttons.Add(new MainMenuButton(GameStateManager.Instance.GameInstance, 150, 150));
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            // I think we're just going to draw all the buttons raw here
            spriteBatch.Begin();
            spriteBatch.Draw(CurrentBackdrop, new Rectangle(0, 0, graphicsDevice.PresentationParameters.BackBufferWidth, graphicsDevice.PresentationParameters.BackBufferHeight), Color.White);
            spriteBatch.End();
            // Draw the buttons afterwards
            foreach (Button button in Buttons)
            {
                button.Draw(spriteBatch);
            }
        }

        public override void Initialize()
        {
            //throw new System.NotImplementedException();
            // Read a config file, maybe?
            foreach (Button button in Buttons)
            {
                button.Initialize();
            }
        }

        public override void LoadContent(ContentManager content)
        {
            CurrentBackdrop = content.Load<Texture2D>("Backdrops/Test");
        }

        public override void UnloadContent()
        {
        //      throw new System.NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (Button button in Buttons)
            {
                button.Update(gameTime);
            }
        }
    }
}
