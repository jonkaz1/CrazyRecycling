using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrazyRecycling.Models.Bottles
{
    public abstract class Bottle : InventoryItem
    {
        public int BottleId { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public PictureBox Image { get; set; }
        Rectangle Box { get; set; } = new Rectangle(new Point(16, 16), new Size(16, 16));
        public Point ThrownDirection { get; set; } = new Point();
        public float TimeToDestroy { get; set; } = 0;
        public bool IsNewlySpawned { get; set; }
        public bool MarkedForDelete { get; set; }

        //start of Jonas Visitor code
        public int Damage;
        public int PointsCount;
        //end

        protected Bottle()
        {
            
        }

        public abstract string GetBottleInfo();

        public override InventoryItem GetItem()
        {
            return this;
        }

        public override void Add(InventoryItem item)
        {
            Console.WriteLine("Cannot add to bottle");
        }

        public override void Remove(InventoryItem item)
        {
            Console.WriteLine("Cannot remove to bottle");
        }


        //start of Jonas Visitor code
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
        //end
    }
}
