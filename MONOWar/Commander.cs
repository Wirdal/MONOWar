using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MONOWar
{
    enum ECommanders
    {
        Chad = 0,
        Threde = 1,
    }
    abstract class Commander
    {
        // What commander are we
        public ECommanders commander;

        public abstract void PassiveAbility(Player player);
        public abstract void ActiveAbility(Player player);
    }
}
