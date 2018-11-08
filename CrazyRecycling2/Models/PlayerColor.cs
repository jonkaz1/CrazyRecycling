using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyRecycling.Models
{
    public class PlayerColor : PlayerDefaultColor
    {
        private ColorData _colorData;

        public PlayerColor(ICharacterClass characterClass) : base(characterClass)
        {
            _colorData = new ColorData();
        }

        public override Color GetColor()
        {
            return _colorData.GetColor(_characterClass);
        }
    }
}
