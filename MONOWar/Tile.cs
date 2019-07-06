using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MONOWar
{
    enum TileType
    {
        GrassTile = 0,
    }
    class Tile
    {
        TileType Type;
        // These are going to tell us where exactly the tile must be placed.
        // The values will be appropriatley created during the CreateMap call in the MapManager
        public int xpos;
        public int ypos;

        // These are their column/row values
        public int colplace;
        public int rowplace;
        public Tile(TileType type, int xpos, int ypos)
        {
            Type = type;
            this.xpos = xpos;
            this.ypos = ypos;
        }
    }
}
