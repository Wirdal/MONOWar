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
        private ContentManager content;
        // Holds all the units created
        List<Unit> units = new List<Unit>();

        List<Texture2D> unitSprites = new List<Texture2D>();
        List<List<Texture2D>> unitsColored = new List<List<Texture2D>>();


        public void CreateUnit(UnitType type, int colnum, int rownum, UnitColor color)
        {
           // units.Add(new Unit(colnum, rownum, color));
        }
        public void DrawUnits(SpriteBatch spriteBatch)
        {
            foreach (Unit unit in units)
            {
                // Find out their texture and color?
            }
        }
        public void LoadContent(ContentManager content)
        {
            this.content = content;
        }
        public void ClearUnits()
        {
            units.Clear();
        }
    }
}
