using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MONOWar
{
    enum TileType
    {
        Grass = 0,
        Dirt = 1,
        Factory = 2,
    }
    class Tile
    {

        public TileType Type;
        // These are going to tell us where exactly the tile must be placed.
        // The values will be appropriatley created during the CreateMap call in the MapManager
        // They are also updated during the draw method, cause it hold the relevant details;
        public int xpos;
        public int ypos;
        public int size; // What was this for again?



        // These are their column/row values
        public int colplace;
        public int rowplace;

        // The unit currently on the tile
        public Unit CurrentUnit;
        public Tile(TileType type, int colplace, int rowplace)
        {
            Type = type;
            this.colplace = colplace;
            this.rowplace = rowplace;
        }
        void OnClick()
        {
            // What happens when I click on the tile?
            // Will want to display information about the tile
            // As well as info about our unit
            if (CurrentUnit != null)
            {
                // Also display info about the unit
            }
            // Display unit about the tile
        }
    }
}
