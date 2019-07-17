using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MONOWar
{
    enum UnitType
    {
        Infantry = 0,

    }
    enum UnitColor
    {
        Red = 0
    }
    abstract class Unit
    {
        UnitType type;
        UnitColor color;

        int colplace, rowplace;
        Tile currentTile;
        public Unit(UnitType type, UnitColor color, int colplace, int rowplace, Tile tile)
        {
            this.type = type;
            this.color = color;
            this.colplace = colplace;
            this.rowplace = rowplace;
            currentTile = tile;
        }
        public abstract void Attack(Unit defender);
        public abstract void Defend(Unit Attacker);
        public virtual void Move(Tile tile)
        {
            this.currentTile = tile;
        }
        public abstract List<Tile> GetTraversableTiles(Tile[,] map);
    }
    class Infantry : Unit
    {
        public Infantry(UnitType type, UnitColor color, int colplace, int rowplace, Tile tile) : base(type, color, colplace, rowplace, tile)
        {
            //sPEEED
        }
        public override void Attack(Unit defender)
        {
            throw new NotImplementedException();
        }

        public override void Defend(Unit Attacker)
        {
            throw new NotImplementedException();
        }

        public override List<Tile> GetTraversableTiles(Tile[,] map)
        {
            throw new NotImplementedException();
        }
    }

}
