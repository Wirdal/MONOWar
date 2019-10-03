using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MONOWar
{

    class UnitManager
    {
        private static UnitManager instance;
        public static UnitManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UnitManager();
                }
                return instance;
            }
        }
        // Holds all the units created1
        List<Unit> units = new List<Unit>();

        //Lists for seperate unit colors
        // We add the sprites into the appropriate list when they are loaded.
        // 0 = Red
        // 1 = Blue
        // 2 = Green
        // 3 = Yellow
        // 4 = Purple
        // In addition, the units themselves are in order in the list, according to enum Unit Type. Defined in Unit.cs
        // 0 = Infantry
        List<Texture2D>[] unitsColored = new List<Texture2D>[5];

        public static Unit SelectedUnit = null;
        //Assuming that our spritesheet is a perfect square

        Point frameSize = new Point(32, 32);
        Point currentFrame = new Point(0, 0);
        Point sheetSize = new Point(2, 2);

        const int MillisecondsPerFrame = 120;
        int timeSinceLastFrame = 0;

        public void CreateUnit(EUnitType type, int colnum, int rownum, EUnitColor color, Tile tile)
        {
            switch (type)
            {
                case EUnitType.Infantry:
                    units.Add(new Infantry(color, colnum, rownum, tile));
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
                spriteBatch.Draw(unitsColored[unitColor][unitType], unit.currentTile.unitRectangle, new Rectangle(currentFrame.X, currentFrame.Y, frameSize.X, frameSize.Y), Color.White);
            }
            spriteBatch.End();
        }
        public void LoadContent(ContentManager content)
        {
            // Load the red unit sprites.
            unitsColored[0].Add(content.Load<Texture2D>("Sprites/Units/Red/Infantry"));
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
                currentFrame.X++;
                if (currentFrame.X >= sheetSize.X)
                {
                    currentFrame.X = 0;
                    currentFrame.Y++;
                    if (currentFrame.Y >= sheetSize.Y)
                    {
                        currentFrame.Y = 0;
                    }
                }
            }
        }
    }
}
