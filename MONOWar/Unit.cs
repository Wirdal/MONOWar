using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MONOWar
{
    enum UnitType
    {
        Infantry = 0,
    }
    class Unit : DrawableGameComponent
    {
        // Current drawable position within the map
        int xpos, ypos;
        // Current location within the map
        int colplace, rowplace;
        // What kind of unit it is.
        UnitType type;
        public Unit(Game game) : base(game)
        {

        }
    }
}
