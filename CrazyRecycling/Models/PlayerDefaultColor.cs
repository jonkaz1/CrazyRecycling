using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyRecycling.Models
{
    public class PlayerDefaultColor
    {
        public ICharacterClass _characterClass;

        public PlayerDefaultColor(ICharacterClass characterClass)
        {
            _characterClass = characterClass;
        }

        public virtual Color GetColor()
        {
            return Color.Black;
        }
    }
}
