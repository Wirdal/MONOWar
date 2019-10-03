using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MONOWar
{
    enum ETileType
    {
        Grass = 0,
        Dirt = 1,
        Factory = 2,
    }
    class Tile
    {

        public ETileType type;
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
        public TileButton clickButton;



        // The unit currently on the tile
        public Unit currentUnit;
        // Where the unit should be drawn
        public Rectangle unitRectangle;
        public Tile(ETileType type, int colplace, int rowplace)
        {
            this.type = type;
            this.colplace = colplace;
            this.rowplace = rowplace;
            clickButton = new TileButton(GameStateManager.Instance.GameInstance, 0, 0); //Will update these values later
            // Xpos and Ypos are assigned during draw
        }
        public void UpdateClickBox()
        {

            // Find the distance we need to go down
            // Update our x and y
            double d = 60.000D;
            double tempboxx = Math.Tan(d) * (Convert.ToDouble(height/2)); // This is how far we go into our hexagon to place the x boundaries on the click box
            clickButton.xpos = Convert.ToInt32(tempboxx) + xpos + 14;
            // Top of our Y is just the ypos of the hexagon, plus a couple of pixels
            clickButton.ypos= ypos + height/4;

            // Update the boxw
            clickButton.width = width/2;
            clickButton.height = height/2 ;
            // I think we're done?
        }
        private void OnClick()
        {
            // What happens when I click on the tile?
            // Will want to display information about the tile
            // As well as info about our unit
            MapManager.selectedTile = this;
            if (currentUnit != null)
            {
                // Also display info about the unit
            }
            // Display unit about the tile
        }
        
    }
}
