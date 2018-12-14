using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyRecycling.Models.Iterator
{
    class ConcreteIterator : Iterator
    {
        private ConcreteAggregate aggregate;
        private int currentObjectNumber = 0;

        // Constructor

        public ConcreteIterator(ConcreteAggregate aggregate)
        {
            this.aggregate = aggregate;
        }

        // Gets first iteration item

        public override object First()
        {
            return aggregate[0];
        }

        // Gets next iteration item

        public override object Next()
        {
            object item = null;
            if (currentObjectNumber < aggregate.Count() - 1)
            {
                item = aggregate[++currentObjectNumber];
            }

            return item;
        }
        public override object Previous()
        {
            object item = null;
            if (currentObjectNumber > 0)
            {
                item = aggregate[--currentObjectNumber];
            }

            return item;
        }
        // Gets current iteration item

        public override object CurrentItem()
        {
            return aggregate[currentObjectNumber];
        }

        // Gets whether iterations are complete

        public override bool IsDone()
        {
            return currentObjectNumber >= aggregate.Count();
        }
    }
}
