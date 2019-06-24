using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MONOWar
{
    public class MainMenuButton : DrawableGameComponent
    {
        Game game;
        SpriteBatch spriteBatch;
        Texture2D RedRect;
        int Xpos, Ypos;
        public MainMenuButton(Game game, SpriteBatch spriteBatch, int xpos, int ypos) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.game = game;
            this.Xpos = xpos;
            this.Ypos = ypos;
            game.Content.RootDirectory = "Content";
            LoadContent();
        }

        protected override void LoadContent()
        {
            RedRect = game.Content.Load<Texture2D>("RedBlock");
            base.LoadContent();
        }
        public override void Draw(GameTime gameTime)
        {
            System.Console.WriteLine("Test");
            spriteBatch.Draw(RedRect, new Vector2(Xpos, Ypos), Color.White);
            base.Draw(gameTime);
        }
        
    }
}
