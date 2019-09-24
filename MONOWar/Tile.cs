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
        // They are also updated during the draw method, cause it hold the relevant details;
        public int xpos;
        public int ypos;
        public int height; // Long angle, as well.
        public int width;
        // The values will be appropriatley created during the CreateMap call in the MapManager
        // These are their column/row values
        public int colplace;
        public int rowplace;
        // Info for the click box
        // I am going to replace this stuff with a button instead.
        public int boxx;
        public int boxy;
        public int boxwidth;
        public int boxheight;
        public int center;

        // The unit currently on the tile
        public Unit CurrentUnit;
        public Tile(TileType type, int colplace, int rowplace)
        {
            Type = type;
            this.colplace = colplace;
            this.rowplace = rowplace;
            // Xpos and Ypos are assigned during draw
        }
        public void updateClickBox()
        {

            // Find the distance we need to go down
            // Update our x and y
            double d = 60.000D;
            double tempboxx = Math.Tan(d) * (Convert.ToDouble(height/2)); // This is how far we go into our hexagon to place the x boundaries on the click box
            boxx = Convert.ToInt32(tempboxx) + xpos + 14;
            // Top of our Y is just the ypos of the hexagon, plus a couple of pixels
            boxy = ypos + height/4;

            // Update the boxw
            boxwidth = width/2;
            boxheight = height/2 ;
            // I think we're done?
        }
        void OnClick()
        {
            // What happens when I click on the tile?
            // Will want to display information about the tile
            // As well as info about our unit
            MapManager.selectedTile = this;
            if (CurrentUnit != null)
            {
                // Also display info about the unit
            }
            // Display unit about the tile
        }
    }
}
