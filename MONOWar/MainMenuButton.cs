using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MONOWar
{
    class MainMenuButton : DrawableGameComponent
    {
        Texture2D testTexture;

        int xpos, ypos;
        public MainMenuButton(Game game, int xpos, int ypos) : base(game)
        {
            this.xpos = xpos;
            this.ypos = ypos;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Begin();
            spriteBatch.Draw(testTexture, new Vector2(xpos, ypos), Color.White); // Draw it as a rectangle, so it gets bigger when update is called
            spriteBatch.End();
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void LoadContent()
        {
            // Could need to bring this out a level. Or just use an enum or something
            testTexture = Game.Content.Load<Texture2D>("RedBlock");
            base.LoadContent();
        }
    }
}
