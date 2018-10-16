using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyRecycling.Models
{
    class DefaultClass : ICharacterClass
    {
        public AttackEffect Effect;
        public DefaultClass()
        {

        }
        public DefaultClass(AttackEffect effect)
        {
            Effect = effect;
        }
        /// <summary>
        /// DefaultClass ThrowBottle method
        /// </summary>
        public void ThrowBottle()
        {
            throw new NotImplementedException();
        }
    }
}
