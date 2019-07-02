using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MONOWar
{
    interface IGameObject
    {
        void Draw(SpriteBatch spriteBatch);
        void Initialize();
        void Update(GameTime gameTime);
    }
    public abstract class GameObject : DrawableGameComponent, IGameObject
    {
        public GameObject(Game game) : base(game)
        {

        }

        public abstract void Draw(SpriteBatch spriteBatch);
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
            base.LoadContent();
        }

    }
}