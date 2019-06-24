using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MONOWar
{
    // Enumerate the game states, so we know exactly what we're doing, and so we know what to update
    enum GameStates
    {
        InitialLoading = 0,
        MainMenu,

    }
    class GameStateManager : GameComponent
    {
        public GameStateManager(Game game) : base(game)
        {
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
