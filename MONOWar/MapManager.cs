using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MONOWar
{
    // Both controls and creates the map
    // If we only need o ne, should I make it a singleton?
    class MapManager
    {
        GraphicsDevice graphicsDevice;
        private Tile[,] Map; //  The tiles we have
        // private Player[] Players; //  Want to know who is playing on the map
        public string mapname;

        Texture2D GrassTile;
        public MapManager(string mapname)
        {
            graphicsDevice = GameStateManager.Instance.GameInstance.GraphicsDevice;
            Map = CreateMap(mapname);
        }

        public void LoadContent(ContentManager content)
        {
            // We will want to load all of the tile content. Don't want to try and optimize
            GrassTile = content.Load<Texture2D>("Sprites/Tiles/GrassTile");
        }
        public void UnloadContent()
        {

        }
        public void DrawMap(SpriteBatch spriteBatch)
        {
            // We want to just draw the tiles.
            for (int i = 0; i < Map.GetLength(0); i++)
            {
                for (int j = 0; j < Map.GetLength(1); j++)
                {
                    spriteBatch.Begin();
                    spriteBatch.Draw(GrassTile, new Vector2(50, 50), Color.White);
                    spriteBatch.End();
                }
            }
        }
        private Tile[,] CreateMap(string mapname)
        {
            Tile[,] tempmap = new Tile[2, 2];

            // Iterare through the dimensions
            for (int i=0; i < tempmap.GetLength(0); i++)
            {
                for (int j=0; j< tempmap.GetLength(1); j++)
                {
                    tempmap[i, j] = new Tile(TileType.GrassTile);
                }
            }
            return tempmap;
        }
    }
}
