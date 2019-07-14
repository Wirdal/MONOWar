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
    }
    class Tile
    {

        public TileType Type;
        // These are going to tell us where exactly the tile must be placed.
        // The values will be appropriatley created during the CreateMap call in the MapManager
        public int xpos;
        public int ypos;

        // These are their column/row values
        public int colplace;
        public int rowplace;

        public Unit CurrentUnit;
        public Tile(TileType type, int colplace, int rowplace)
        {
            Type = type;
            this.colplace = colplace;
            this.rowplace = rowplace;
        }
    }
}
