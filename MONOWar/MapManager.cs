using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
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
        public string mapname;
        private int colnum;
        private int rownum;

        // private Player[] Players; //  Want to know who is playing on the map

        Texture2D GrassTile;
        public MapManager(string mapname)
        {
            graphicsDevice = GameStateManager.Instance.GameInstance.GraphicsDevice;
            CreateMap(mapname);
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
                    spriteBatch.Draw(GrassTile, new Rectangle(Map[i,j].xpos*30, Map[i, j].ypos*30, 40, 40), Color.White);
                    spriteBatch.End();
                }
            }
        }
        private void CreateMap(string mapname)
        {
            this.mapname = mapname;
            // Open the map file
            // Lets read the map.
            string mapfile = File.ReadAllText("../../../../Maps/"+mapname);

            System.Diagnostics.Debug.WriteLine("Map");
            // Find the tile amt. Construct a regex
            Regex TileAMTRX = new Regex(@"^(?:tileamt)\s*=\s*(?<val>\d*)\s*$", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            Match TileMatch = TileAMTRX.Match(mapfile);
            if (!TileMatch.Success)
            {
                System.Diagnostics.Debug.WriteLine("No TileAMT found");
                // Throw an error for later

            }
            else
            {
                Int32.TryParse(TileMatch.Groups["val"].Value, out NooTiles);
            }
            // We're going to do Some other fields as well, which can just be found out through the variable names. So bite me
            Regex RowRX = new Regex(@"^(?:Rows)\s*=\s*(?<val>\d*)\s*$", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            Regex ColRx = new Regex(@"^(?:Cols)\s*=\s*(?<val>\d*)\s*$", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            Match RowMatch = RowRX.Match(mapfile);
            Match ColMatch = ColRx.Match(mapfile);
            if (!RowMatch.Success)
            {
                System.Diagnostics.Debug.WriteLine("No RowAmt found");
                // Throw an error for later

            }
            else
            {
                Int32.TryParse(RowMatch.Groups["val"].Value, out rownum);
            }
            if (!ColMatch.Success)
            {
                System.Diagnostics.Debug.WriteLine("No RowAmt found");
                // Throw an error for later

            }
            else
            {
                Int32.TryParse(ColMatch.Groups["val"].Value, out colnum);
            }
            // The regex we will use for matching the map
            // M\s*=\s*(\d*);\s*(\d*);\s*offset\s*=\s*(-?\d*)
            // Multiline, global, and case-insensitive
            Regex MapRX = new Regex(@"M\s*=\s*(?<rownum>\d*);\s*(?<tiles>\d*);\s*offset\s*=\s*(?<offset>-?\d*)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            MatchCollection MapMatch = MapRX.Matches(mapfile);
            Map = new Tile[rownum, colnum];

            foreach (Match i in MapMatch)
            {
                int currentcolnum = 0;
                int currentrownum = 0;
                // Iterate through all the matches
                Int32.TryParse(i.Groups["rownum"].Value, out currentrownum);
                string tilelist = i.Groups["tiles"].Value;
                foreach(int tiletype in tilelist)
                {
                    Map[currentrownum-1, currentcolnum] = new Tile((TileType)tiletype, currentrownum-1, currentcolnum);
                    currentcolnum++;
                }
            }
            System.Diagnostics.Debug.WriteLine("Xpos {0}, Ypos {1}, Type {2}", Map[2,2].xpos, Map[2, 2].ypos, Map[2, 2].Type);

            // Now we just need to iterate through it properly
        }
    }
}
