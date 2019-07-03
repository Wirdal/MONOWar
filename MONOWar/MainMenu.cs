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
            GameStateManager.Instance.GameInstance.Components.Add(startButton);
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
            System.Diagnostics.Debug.WriteLine("Init");
            //throw new System.NotImplementedException();
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
            startButton.Enabled = true; // Force it to be true, if this screen is active
         // throw new System.NotImplementedException();
         // The main menu does not need to update, nor does it need to call on its buttons to update
         // Because they are game components that can be drawn
        }
    }
}
