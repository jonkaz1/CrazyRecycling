using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyRecycling.Controllers.PlayerControllerSubSystem
{
    class MovementController
    {
        public Point MoveUp(int x, int y)
        {
            y--;
            return new Point(x, y);
        }
        public Point MoveDown(int x, int y)
        {
            y++;
            return new Point(x, y);
        }
        public Point MoveLeft(int x, int y)
        {
            x--;
            return new Point(x, y);
        }
        public Point MoveRight(int x, int y)
        {
            x++;
            return new Point(x, y);
        }
    }


}
