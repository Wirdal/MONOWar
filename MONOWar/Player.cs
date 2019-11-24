using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MONOWar
{
    class Player
    {
        public EUnitColor color;
        public List<Unit> units;
        public int money;
        public Commander currentCommander;

        Player(EUnitColor color)
        {
            this.color = color;
        }


    }
}
