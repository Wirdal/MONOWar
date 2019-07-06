using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.IO;

namespace MONOWar
{
    // Both controls and creates the map
    // If we only need o ne, should I make it a singleton?
    class MapManager
    {
        GraphicsDevice graphicsDevice;
        private Tile[,] Map; //  The tiles we have
        private int NooTiles;
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
                    //Hardcore math time
                    spriteBatch.Draw(GrassTile, new Rectangle(Map[i,j].xpos, Map[i, j].ypos, 40, 40), Color.White);
                    spriteBatch.End();
                }
            }
        }
        private Tile[,] CreateMap(string mapname)
        {
            this.mapname = mapname;
            // Open the map file
            // Lets read the map.
            string mapfile = File.ReadAllText("../../../../Maps/"+mapname);

            System.Diagnostics.Debug.WriteLine("Map");
            // Find the tile amt. Construct a regex
            Regex tempRX = new Regex(@"^(?:tileamt)\s*=\s*(?<val>\d*)$", RegexOptions.IgnoreCase | RegexOptions.Multiline);

            Match matches = tempRX.Match(mapfile);
            System.Diagnostics.Debug.WriteLine(matches.Value);

            return new Tile[1, 1];
        }
    }
}
