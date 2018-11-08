using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyRecycling.Models
{
    public class ColorData
    {
        public Color GetColor(ICharacterClass characterClass)
        {
            switch (characterClass)
            {
                case Hoarder h:
                    return Color.LawnGreen;
                case Speedy s:
                    return Color.LightBlue;
                case Brute b:
                    return Color.DarkRed;
                case DefaultClass d:
                default:
                    return Color.Black;
            }
        }
    }
}
