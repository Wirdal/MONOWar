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
        int xpos
        {
            get; set;
        }
        int ypos
        {
            get; set;
        }

        public Tile(TileType type)
        {
            Type = type;
        }
    }
}
