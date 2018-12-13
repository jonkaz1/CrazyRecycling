using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Helper.MessageInterpreter
{
    public class CheatExpression : ChatExpression
    {
        public override bool CheckExpressionValidity(MessageContext context)
        {
            if (context.Player != null && context.Message.Length > 0 && context.Message.Contains("/cheat/"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void MakeChanges(ref MessageContext context)
        {
            context.Player.HealthPoints += 1000;
        }
    }
}
