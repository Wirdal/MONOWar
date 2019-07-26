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
    enum WeaponType
    {
        MachineGun = 0,
    }
    enum TraversalType
    {
        Foot = 0,
    }
    abstract class Unit
    {
        public UnitType type;
        public UnitColor color;
        public WeaponType weapon;
        
        public int hitpoints;
        public int colplace, rowplace;
        Tile currentTile;
        public Unit(UnitColor color, int colplace, int rowplace, Tile tile)
        {
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
        public Infantry( UnitColor color, int colplace, int rowplace, Tile tile) : base(color, colplace, rowplace, tile)
        {
            type = UnitType.Infantry;
            hitpoints = 100;
            weapon = WeaponType.MachineGun;
        }
        public override void Attack(Unit defender)
        {
            defender.Defend(this);
        }

        public override void Defend(Unit Attacker)
        {
            // Loose some amount of health based on the weapon
        }

        public override List<Tile> GetTraversableTiles(Tile[,] map)
        {
            throw new NotImplementedException();
        }
    }

}
