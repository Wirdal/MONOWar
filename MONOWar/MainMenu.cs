using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

//https://rareelementgames.wordpress.com/2017/04/21/game-state-management/
namespace MONOWar
{
    public class MainMenu : GameState
    {
        MainMenuButton testButton;
        Texture2D CurrentBackdrop;
        public MainMenu(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
            testButton = new MainMenuButton(GameStateManager.Instance.gameInstance, 150, 150);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            // I think we're just going to draw all the buttons raw here
            spriteBatch.Begin();
            spriteBatch.Draw(CurrentBackdrop, new Rectangle(0, 0, graphicsDevice.PresentationParameters.BackBufferWidth, graphicsDevice.PresentationParameters.BackBufferHeight), Color.White);
            spriteBatch.End();
            // Draw the buttons afterwards
            testButton.Draw(spriteBatch);
        }

        public override void Initialize()
        {
         //   throw new System.NotImplementedException();
        }

        public override void LoadContent(ContentManager content)
        {
            GameStateManager.Instance.gameInstance.Components.Add(testButton);
            System.Diagnostics.Debug.WriteLine("Loading content");
            CurrentBackdrop = content.Load<Texture2D>(@"Backdrops//Test");
        }

        public override void UnloadContent()
        {
      //      throw new System.NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
         //   throw new System.NotImplementedException();
        }
    }
}
