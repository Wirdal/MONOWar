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
        private Tile[,] Map; //  The tiles we have
        private Player[] Players; //  Want to know who is playing on the map
        public string mapname;
        public MapManager(string mapname)
        {
            Map = CreateMap(mapname);
        }

        public void LoadContent(ContentManager content)
        {
            // We will want to load all of the tile content. Don't want to try and optimize
        }
        public void UnloadContent()
        {

        }
        public void DrawMap(SpriteBatch spriteBatch)
        {

        }
        private Tile[,] CreateMap(string mapname)
        {
            return new Tile[1,2];
        }
    }
}
