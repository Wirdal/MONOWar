using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MONOWar
{
    public class MainMenu : DrawableGameComponent
    {
        SpriteFont Arial12;

        Game game;
        protected MainMenuButton SinglePlayerButton;
        protected MainMenuButton SettingsButton;
        protected MainMenuButton MultiplayerButton;
        public MainMenu(Game game) : base(game)
        {
            game.Content.RootDirectory = "Content";
            this.game = game;
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

        protected override void LoadContent()
        {
            Arial12 = game.Content.Load<SpriteFont>("Fonts/Test");
            base.LoadContent();
        }
    }
}
