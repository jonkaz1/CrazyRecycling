using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Helper.MessageInterpreter
{
    public abstract class ChatExpression
    {
        public void Interpret(ref MessageContext context)
        {
            if (CheckExpressionValidity(context))
            {
                MakeChanges(ref context);
            }
        }

        public abstract bool CheckExpressionValidity(MessageContext context);
        public abstract void MakeChanges(ref MessageContext context);
    }
}
