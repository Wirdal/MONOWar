﻿using System;
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
        private ContentManager content;
        Texture2D TestSprite;
        // Holds all the units created
        List<Unit> units = new List<Unit>();

        List<Texture2D> unitSprites = new List<Texture2D>();
        //Lists for seperate unit colors
        List<List<Texture2D>> unitsColored = new List<List<Texture2D>>();

        //Assuming that our spritesheet is a perfect square

        Point frameSize = new Point(19, 19);
        Point currentFrame = new Point(0, 0);
        Point sheetSize = new Point(2, 2);

        public void CreateUnit(UnitType type, int colnum, int rownum, UnitColor color)
        {
           units.Add(new Infantry(UnitColor.Red, colnum, rownum, null));
        }
        public void DrawUnits(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            foreach (Unit unit in units)
            {
                // Find out their texture and color? ^
                spriteBatch.Draw(TestSprite,
                                 new Rectangle(150, 150, TestSprite.Width / 2, TestSprite.Height / 2),
                                 new Rectangle(currentFrame.X * frameSize.X, currentFrame.Y * frameSize.Y, frameSize.X, frameSize.Y),
                                 Color.White);
            }
            spriteBatch.End();
        }
        public void LoadContent(ContentManager content)
        {
            this.content = content;

            TestSprite = content.Load<Texture2D>("Sprites/Units/TestSprite");
            unitSprites.Add(TestSprite);
        }
        public void ClearUnits()
        {
            units.Clear();
        }
        public void Update(GameTime gameTime)
        {
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
