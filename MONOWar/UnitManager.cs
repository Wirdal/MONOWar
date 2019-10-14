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
        private static UnitManager PrivateInstance;
        public static UnitManager publicInstance
        {
            get
            {
                if (PrivateInstance == null)
                {
                    PrivateInstance = new UnitManager();
                }
                return PrivateInstance;
            }
        }

        // Holds all the units created
        List<Unit> units = new List<Unit>();

        //Lists for seperate unit colors
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
        //Assuming that our spritesheet is a perfect square

        static Point FrameSize = new Point(32, 32);
        static Point CurrentFrame = new Point(0, 0);
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
                spriteBatch.Draw(unitsColored[unitColor][unitType], unit.currentTile.unitRectangle, new Rectangle(CurrentFrame.X * FrameSize.X, CurrentFrame.Y * FrameSize.Y, FrameSize.X, FrameSize.Y), Color.White);
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
                CurrentFrame.X++;
                if (CurrentFrame.X >= SheetSize.X)
                {
                    CurrentFrame.X = 0;
                    CurrentFrame.Y++;
                    if (CurrentFrame.Y >= SheetSize.Y)
                    {
                        CurrentFrame.Y = 0;
                    }
                }
            }
        }
    }
}
