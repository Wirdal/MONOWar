using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;



namespace MONOWar
{
    interface IManager
    {
        void Draw(SpriteBatch spriteBatch);
        void Update(GameTime gameTime);

    }
    class GameStateManager
    {
        private static GameStateManager SprivateInstance = null;
        // Going to store the game states within a stack
        private Stack<GameState> screens = new Stack<GameState>();
        private ContentManager content
        {
            get; set;
        }

        public Game gameInstance
        {
            get; set;
        }
        // Also a field, because I don't think I can pass it around too much
        public static GameStateManager publicInstance
        {
            get
            {
                if (SprivateInstance == null)
                {
                    SprivateInstance = new GameStateManager();
                }
                return SprivateInstance;
            }
        }
        public void SetContent(ContentManager content)
        {
            this.content = content;
        }
        public void AddScreen(GameState screen)
        {
            screens.Push(screen);
            screens.Peek().Initialize(); //Init ti too
            screens.Peek().LoadContent(content); //Pass it the content manager

        }
        public void RemoveScreen()
        {
            if (screens.Count() > 0)
            {
                screens.Pop();
            }
        }
        public void ClearScreens()
        {
            while (screens.Count() > 0)
            {
                screens.Pop();
            }
        }
        public void Update(GameTime gameTime)
        {
            if (screens.Count() > 0)
            {
                screens.Peek().Update(gameTime);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (screens.Count() > 0)
            {
                screens.Peek().Draw(spriteBatch);
            }
        }
        public void UnloadContent()
        {
            foreach (GameState screen in screens)
            {
                screen.UnloadContent();
            }
        }

    }
    class UIManager
    {
        private static UIManager SprivateInstance = null;
        public static UIManager publicInstance
        {
            get
            {
                if (SprivateInstance == null)
                {
                    SprivateInstance = new UIManager();
                }
                return SprivateInstance;
            }
        }

        public void DrawUI(SpriteBatch spriteBatch)
        {
            // Draw that UI, baby
        }
        public void Update(GameTime gameTime)
        {
            // Update data values within the UI

        }

    }
    class FontManager
    {
        private static FontManager SprivateInstance = null;

        public static FontManager publicInstance
        {
            get
            {
                if (SprivateInstance == null)
                {
                    SprivateInstance = new FontManager();
                }
                return SprivateInstance;
            }
        }


        public SpriteFont menuBold;


        public void LoadContent(ContentManager content)
        {
            menuBold = content.Load<SpriteFont>("Fonts/MenuBold");
        }

    }
    class MapManager
    {
        private static MapManager SprivateInstance;
        public static MapManager publicInstance
        {
            get
            {
                if (SprivateInstance == null)
                {
                    SprivateInstance = new MapManager();
                }
                return SprivateInstance;
            }
        }

        GraphicsDevice graphicsDevice;
        private Tile[,] map; //  The tiles we have

        // General Map information
        private bool evenq = false; // Is the map even-q? Default no, odd-q by default
        private int nooTiles;
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
        public static Tile SelectedTile = null;


        private List<Texture2D> tileSprites = new List<Texture2D>();

        // private Player[] Players; //  Want to know who is playing on the map

        //Textures;
        Texture2D orang;

        Texture2D grassTile;
        Texture2D dirtTile;
        Texture2D factoryTile;
        public MapManager()
        {
            graphicsDevice = GameStateManager.publicInstance.gameInstance.GraphicsDevice;
        }

        public void LoadContent(ContentManager content)
        {
            grassTile = content.Load<Texture2D>("Sprites/Tiles/GrassTile");
            dirtTile = content.Load<Texture2D>("Sprites/Tiles/DirtTile");
            factoryTile = content.Load<Texture2D>("Sprites/Tiles/FactoryTile");
            orang = content.Load<Texture2D>("Orang");
            tileSprites.Add(grassTile);
            tileSprites.Add(dirtTile);
            tileSprites.Add(factoryTile);
            tileheight = grassTile.Height / 4;
            tilewidth = grassTile.Width / 4;
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
            for (int i = 0; i < map.GetLength(0); i++) //Col 
            {
                for (int j = 0; j < map.GetLength(1); j++) //Row 
                {
                    int tempx = (map[i, j].colplace * tilewidth * 3 / 4) + cameraX;
                    int tempy;
                    if (evenq)
                    {
                        if ((i) % 2 == 0)
                        {
                            tempy = map[i, j].rowplace * tileheight + tileheight / 2;
                        }
                        else
                        {
                            tempy = map[i, j].rowplace * tileheight;
                        }
                    }
                    else
                    {
                        if ((i - 1) % 2 == 0)
                        {
                            tempy = map[i, j].rowplace * tileheight + tileheight / 2;
                        }
                        else
                        {
                            tempy = map[i, j].rowplace * tileheight;
                        }
                    }
                    tempy += cameraY;
                    int tempwidth = tilewidth + 2;
                    int tempheight = tileheight + 2;
                    int tyletype = (int)map[i, j].type;
                    // Set up our variables here
                    // TODO 
                    // Make this 1000x better.
                    spriteBatch.Draw(
                        tileSprites[tyletype],
                        new Rectangle(tempx, tempy, tempwidth, tempheight),
                        Color.White);
                    map[i, j].xpos = tempx;
                    map[i, j].ypos = tempy;
                    map[i, j].height = tempheight;
                    map[i, j].width = tempwidth;
                    map[i, j].UpdateClickBox();
                    // Lets also check the click box location by drawing it
                    // spriteBatch.Draw(Orang, new Rectangle(Map[i, j].clickButton.xpos, Map[i, j].clickButton.ypos, Map[i, j].clickButton.width, Map[i, j].clickButton.height), Color.White);
                }
            }
            spriteBatch.End();
        }
        public Tile FindClickedTile(MouseState mouse)
        {
            Tile returntile = null;
            foreach (Tile tile in map)
            {
                if (tile.clickButton.CheckForHover(mouse))
                {
                    // System.Diagnostics.Debug.WriteLine("Tile found");
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
            string mapfile = File.ReadAllText("../../../../Maps/" + mapname + ".map");

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

                Int32.TryParse(TileMatch.Groups["val"].Value, out nooTiles);
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
            map = new Tile[rownum, colnum];

            foreach (Match i in MapMatch)
            {
                int currentcolnum = 0;
                int currentrownum = 0;
                // Iterate through all the matches
                Int32.TryParse(i.Groups["rownum"].Value, out currentrownum);
                string tilelist = i.Groups["tiles"].Value;
                foreach (int tiletype in tilelist)
                {
                    map[currentcolnum, currentrownum - 1] = new Tile((ETileType)tiletype - 48, currentcolnum, currentrownum - 1);
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
                returnlist.Add(map[tile.colplace + 1, tile.rowplace]);
            }

            if ((tile.colplace != colnum - 1) && (tile.rowplace != 0))
            {
                returnlist.Add(map[tile.colplace + 1, tile.rowplace - 1]);

            }

            if (tile.rowplace != 0)
            {
                returnlist.Add(map[tile.colplace, tile.rowplace - 1]);
            }

            if (tile.colplace != 0)
            {
                returnlist.Add(map[tile.colplace - 1, tile.rowplace]);
            }

            if ((tile.colplace != 0) && (tile.rowplace != rownum - 1))
            {
                returnlist.Add(map[tile.colplace - 1, tile.rowplace + 1]);
            }

            if (tile.rowplace != rownum - 1)
            {
                returnlist.Add(map[tile.colplace, tile.rowplace + 1]);
            }

            return returnlist;
        }
        public void Update(GameTime gameTime)
        {

        }
    }
    class UnitManager
    {
        private static UnitManager SprivateInstance;
        public static UnitManager publicInstance
        {
            get
            {
                if (SprivateInstance == null)
                {
                    SprivateInstance = new UnitManager();
                }
                return SprivateInstance;
            }
        }

        public static Point SheetSize1 { get => SheetSize; set => SheetSize = value; }

        // Holds all the units created
        List<Unit> units = new List<Unit>();

        // Lists for seperate unit colors
        // We add the sprites into the appropriate list when they are loaded.
        // 0 = Red
        // 1 = Blue
        // 2 = Green
        // 3 = Yellow
        // 4 = Purple
        // In addition, the units themselves are in order in the list,according to enum Unit Type. Defined in Unit.cs
        // 0 = Infantry
        List<Texture2D>[] unitsColored = new List<Texture2D>[5];

        public static Unit SelectedUnit = null;

        // Info for our sprite sheets
        static Point SframeSize = new Point(32, 32);
        static Point ScurrentFrame = new Point(0, 0);
        static Point SheetSize = new Point(2, 2);

        const int MillisecondsPerFrame = 120;
        int timeSinceLastFrame = 0;

        public void CreateUnit(EUnitType type, EUnitColor color, Tile tile)
        {
            switch (type)
            {
                case EUnitType.Infantry:
                    units.Add(new Infantry(color, tile));
                    break;
                default:
                    break;

            }
        }
        public void DrawUnits(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            foreach (Unit unit in units)
            {

                // Find out their texture and color? ^
                int unitType = (int)unit.type;
                int unitColor = (int)unit.color;
                spriteBatch.Draw(unitsColored[unitColor][unitType],
                    unit.currentTile.unitRectangle,
                    new Rectangle(ScurrentFrame.X * SframeSize.X, ScurrentFrame.Y * SframeSize.Y, SframeSize.X, SframeSize.Y),
                    Color.White);
            }
            spriteBatch.End();
        }
        public void LoadContent(ContentManager content)
        {
            // Load the red unit sprites and construct the list the will preside in.
            unitsColored[0] = new List<Texture2D>();
            unitsColored[0].Add(content.Load<Texture2D>("Sprites/Units/Red/Infantry"));
            // Load the blue
            // ...
        }
        public void ClearUnits()
        {
            units.Clear();
        }
        public void Update(GameTime gameTime)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > MillisecondsPerFrame)
            {
                timeSinceLastFrame -= MillisecondsPerFrame;
                ScurrentFrame.X++;
                if (ScurrentFrame.X >= SheetSize1.X)
                {
                    ScurrentFrame.X = 0;
                    ScurrentFrame.Y++;
                    if (ScurrentFrame.Y >= SheetSize1.Y)
                    {
                        ScurrentFrame.Y = 0;
                    }
                }
            }
        }
    }
}
