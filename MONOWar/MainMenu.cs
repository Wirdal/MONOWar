using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

//https://rareelementgames.wordpress.com/2017/04/21/game-state-management/
namespace MONOWar
{
    public class MainMenu : GameState
    {
        MainMenuButton startButton;
        Texture2D CurrentBackdrop;
        public MainMenu(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
            startButton = new MainMenuButton(GameStateManager.Instance.GameInstance, 150, 150, 1);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            // I think we're just going to draw all the buttons raw here
            spriteBatch.Begin();
            spriteBatch.Draw(CurrentBackdrop, new Rectangle(0, 0, graphicsDevice.PresentationParameters.BackBufferWidth, graphicsDevice.PresentationParameters.BackBufferHeight), Color.White);
            spriteBatch.End();
            // Draw the buttons afterwards
            startButton.Draw(spriteBatch);
        }

        public override void Initialize()
        {
         //   throw new System.NotImplementedException();
        }

        public override void LoadContent(ContentManager content)
        {
            GameStateManager.Instance.GameInstance.Components.Add(startButton);
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
