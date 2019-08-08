using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MONOWar
{
    class InGame : GameState
    {
        // Might make game states static, who knows. Might be too much work, though
        public InGame(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
            graphicsDevice.Clear(Color.Aquamarine);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            graphicsDevice.Clear(Color.Aquamarine); //  The background image placeholder
            MapManager.Instance.DrawMap(spriteBatch);
            UnitManager.Instance.DrawUnits(spriteBatch);
            // uiManager.Draw
        }

        public override void Initialize()
        {
            // Buttons will need to communicate with the map name, in the map manager
            MapManager.Instance.CreateMap("TestMap.map");
            // Starting a new map, so we probably should clear this thing out.
            UnitManager.Instance.ClearUnits();
            // UnitManager.Instance.CreateUnit(UnitType.Infantry, 0, 0, UnitColor.Red);
        }

        public override void LoadContent(ContentManager content)
        {
            MapManager.Instance.LoadContent(content);
            UnitManager.Instance.LoadContent(content);
        }

        public override void UnloadContent()
        {
        }

        public override void Update(GameTime gameTime)
        {
            MapManager.Instance.Update(gameTime);
            UnitManager.Instance.Update(gameTime);
        }
    }
}
