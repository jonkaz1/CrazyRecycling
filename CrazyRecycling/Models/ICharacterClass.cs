using CrazyRecycling.Models.Bottles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyRecycling.Models
{
    public interface ICharacterClass
    {
        Bottle ThrowBottle(int X, int Y);
        PlayerStats GetStats();
    }
}
