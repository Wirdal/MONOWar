using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MONOWar
{
    enum EUnitType
    {
        Infantry = 0,

    }
    enum EUnitColor
    {
        Red = 0
    }
    enum EWeaponType
    {
        MachineGun = 0,
    }
    enum EArmorType
    {
        None = 0,
    }
    enum ETraversalType
    {
        Foot = 0,
    }
    /// <summary>
    /// This class provides the skeleton that all unit types will derive from.
    /// </summary>
    abstract class Unit
    {
        public EUnitType type;
        public EUnitColor color;
        public EWeaponType weapon;
        public EArmorType armor;
        public ETraversalType traversalType;

        public int hitpoints;
        public int colplace, rowplace;

        public Tile currentTile;
        public Unit(EUnitColor color, Tile tile)
            // Maybe do a method for it.
        {
            this.color = color;
            this.colplace = tile.colplace;
            this.rowplace = tile.rowplace;
            currentTile = tile;
        }
        public virtual void Attack(Unit defender)
        {

        }
        public virtual void Defend(Unit attacker)
        {

        }
        public virtual void Move(Tile tile)
        {
            this.currentTile = tile;
            tile.currentUnit = this;
        }
        public abstract List<Tile> GetTraversableTiles(Tile[,] map);
    }
        // Need to have constant kinds of sprite sheets
        //

    class Infantry : Unit
    {
        public Infantry(EUnitColor color, Tile tile): base(color, tile)
        {
            type = EUnitType.Infantry;
            hitpoints = 100;
            weapon = EWeaponType.MachineGun;
        }
        public override void Attack(Unit defender)
        {
            defender.Defend(this);
        }

        public override void Defend(Unit attacker)
        {
            // Loose some amount of health based on the weapon
        }

        public override List<Tile> GetTraversableTiles(Tile[,] map)
        {
            throw new NotImplementedException();
        }
    }
}
