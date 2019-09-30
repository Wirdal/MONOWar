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
    // Setting up
    class MapManager
    {
        private static MapManager instance;
        public static MapManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MapManager();
                }
                return instance;
            }
        }

        GraphicsDevice graphicsDevice;
        private Tile[,] Map; //  The tiles we have

        // General Map information
        private bool evenq = false; // Is the map even-q? Default no, odd-q by default
        private int NooTiles;
        public string mapname;

        // Map details;
        private int colnum;
        private int rownum;
        private int tileheight, tilewidth;

        // Navigation variables
        public int zoomLevel = 10;
        public int cameraX = 0;
        public int cameraY = 0;

        // Selection variable
        public static Tile selectedTile = null;


        private List<Texture2D> tileSprites = new List<Texture2D>();

        // private Player[] Players; //  Want to know who is playing on the map

        //Textures;
        Texture2D Orang;

        Texture2D GrassTile;
        Texture2D DirtTile;
        Texture2D FactoryTile;
        public MapManager()
        {
            graphicsDevice = GameStateManager.Instance.GameInstance.GraphicsDevice;
        }

        public void LoadContent(ContentManager content)
        {
            GrassTile = content.Load<Texture2D>("Sprites/Tiles/GrassTile");
            DirtTile = content.Load<Texture2D>("Sprites/Tiles/DirtTile");
            FactoryTile = content.Load<Texture2D>("Sprites/Tiles/FactoryTile");
            Orang = content.Load<Texture2D>("Orang");
            tileSprites.Add(GrassTile);
            tileSprites.Add(DirtTile);
            tileSprites.Add(FactoryTile);
            tileheight = GrassTile.Height / 4;
            tilewidth = GrassTile.Width / 4;
        }
        public void UnloadContent()
        {

        }
        public void DrawMap(SpriteBatch spriteBatch)
        {
            // We want to just draw the tiles.
            // We are keeping them "flat"
            // Also, will need to take into account eve
            // Figure out the scale from our zoomlevel.
            // Possibly do that in update

            spriteBatch.Begin();
            for (int i = 0; i < Map.GetLength(0); i++) //Col 
            {
                for (int j = 0; j < Map.GetLength(1); j++) //Row 
                {
                    int tempx = (Map[i, j].colplace * tilewidth * 3 / 4) + cameraX;
                    int tempy;
                    if (evenq)
                    {
                        if ((i) % 2 == 0)
                        {
                            tempy = Map[i, j].rowplace * tileheight + tileheight / 2;
                        }
                        else
                        {
                            tempy = Map[i, j].rowplace * tileheight;
                        }
                    }
                    else
                    {
                        if ((i - 1) % 2 == 0)
                        {
                            tempy = Map[i, j].rowplace * tileheight + tileheight / 2;
                        }
                        else
                        {
                            tempy = Map[i, j].rowplace * tileheight;
                        }
                    }
                    tempy += cameraY;
                    int tempwidth = tilewidth + 2;
                    int tempheight = tileheight + 2;
                    int tyletype = (int)Map[i, j].Type;
                    // Set up our variables here
                    // TODO 
                    // Make this 1000x better.
                    spriteBatch.Draw(
                        tileSprites[tyletype],
                        new Rectangle(tempx, tempy, tempwidth, tempheight),
                        Color.White);
                    Map[i, j].xpos = tempx;
                    Map[i, j].ypos = tempy;
                    Map[i, j].height = tempheight;
                    Map[i, j].width = tempwidth;
                    Map[i, j].updateClickBox();
                    // Lets also check the click box location by drawing it
                    spriteBatch.Draw(Orang, new Rectangle(Map[i, j].clickButton.xpos, Map[i, j].clickButton.ypos, Map[i, j].clickButton.width, Map[i, j].clickButton.height), Color.White);
                }
            }
            spriteBatch.End();
        }
        public Tile FindClickedTile(MouseState mouse)
        {
            Tile returntile = null;
            foreach(Tile tile in Map)
            {
                if (tile.clickButton.CheckForHover(mouse))
                {
                    System.Diagnostics.Debug.WriteLine("Tile found");
                    returntile = tile;
                }
            }
            return returntile;

        }
        public void CreateMap(string mapname)
        {
            this.mapname = mapname;
            // Open the map file
            // Lets read the map.
            System.Diagnostics.Debug.WriteLine(mapname);
            string mapfile = File.ReadAllText("../../../../Maps/"+mapname+".map");

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
                    Map[currentcolnum, currentrownum-1] = new Tile((TileType)tiletype - 48, currentcolnum, currentrownum-1);
                    currentcolnum++;
                    // System.Diagnostics.Debug.WriteLine("Tile type: {0}, Coords, {1}, {2}", tiletype - 48, currentcolnum - 1 , currentrownum -1);
                }
            }
            Regex EvenqRX = new Regex(@"^(?<true>(evenq))", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            Match EvenqMatch = EvenqRX.Match(mapfile);
            if (EvenqMatch.Success)
            {
                evenq = true;
            }
        }
        public List<Tile> GetNeighbors(Tile tile)
        {
            List<Tile> returnlist = new List<Tile>();
            // +1,0; +1, -1; 0, -1;
            // -1,0; -1, +1; 0, +1;
            // Tiles are indexed at 0
            // Subtract the 
            if (tile.colplace != colnum - 1)
            {
                returnlist.Add(Map[tile.colplace + 1, tile.rowplace]);
            }

            if ((tile.colplace != colnum - 1) && (tile.rowplace != 0))
            {
                returnlist.Add(Map[tile.colplace + 1, tile.rowplace - 1]);

            }

            if (tile.rowplace != 0)
            {
                returnlist.Add(Map[tile.colplace, tile.rowplace - 1]);
            }

            if (tile.colplace != 0)
            {
                returnlist.Add(Map[tile.colplace - 1, tile.rowplace]);
            }

            if ((tile.colplace != 0) && (tile.rowplace != rownum -1))
            {
                returnlist.Add(Map[tile.colplace - 1, tile.rowplace + 1]);
            }

            if (tile.rowplace != rownum - 1)
            {
                returnlist.Add(Map[tile.colplace, tile.rowplace + 1]);
            }

            return returnlist;
        }
        public void Update(GameTime gameTime)
        {

        }
    }
}
