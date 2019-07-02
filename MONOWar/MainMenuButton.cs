using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MONOWar
{
    enum MainMenuButtonTypes
    {
        settings=0,
        start=1,
        multiplayer=2,
        exit=3,
    }
    class MainMenuButton : GameObject
    {

        Texture2D testTexture;
        // Where the button will be placed
        int xpos, ypos;
        // How big the button is
        int width, height;
        // So we know what screen to send to.
        int buttonType;
        public MainMenuButton(Game game, int xpos, int ypos, int buttonType) : base(game)
        {
            this.xpos = xpos;
            this.ypos = ypos;
            this.buttonType = buttonType;
            // These values are hardcoded, because thats the dimensions of the actual image


        }

        public override void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Begin();
            spriteBatch.Draw(testTexture, new Rectangle(xpos, ypos, width, height), Color.White); // Draw it as a rectangle later, so it gets bigger when update is called
            spriteBatch.End();

        }

        public override void Initialize()
        {
            width = 75;
            height = 25;
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            // When the button is hovered over. EXPAND
            // If clicked on, we're gonna change gamestates, depending on the button that was pressed
            // Enum would probably be better, then.
            MouseState mouse = Mouse.GetState();
            if ((mouse.X > xpos) & (mouse.X < xpos + width)
               & (mouse.Y > ypos) & (mouse.Y < ypos + height))
            {
                width = 100;
                height = 50;
                // Are we also clicking. Right now, just checks if the mouse is down
                // Will have to change it later, to be more convenient.
                if(mouse.LeftButton == ButtonState.Pressed)
                {
                    System.Diagnostics.Debug.WriteLine("Button clicked");
                    OnClick();
                }
            }
            else
            {
                width = 75;
                height = 25;
            }
            base.Update(gameTime);
        }

        protected override void LoadContent()
        {
            // Could need to bring this out a level. Or just use an enum or something
            // Or just draw, with a tint levied
            testTexture = Game.Content.Load<Texture2D>("RedBlock");
            base.LoadContent();
        }
        private void OnClick()
        {
            GameStateManager.Instance.AddScreen(new InGame(GraphicsDevice)); // Will load the stuff we need
        }
    }
}
