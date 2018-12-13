using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Helper.MessageInterpreter
{
    public class SwearExpression : ChatExpression
    {
        public override bool CheckExpressionValidity(MessageContext context)
        {
            if(context.Message.Length>0 && ContainsSwearWord(context.Message))
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
            context.Message = context.Message.Replace("lol", "haha");
        }
        private bool ContainsSwearWord(string message)
        {
            if (message.Contains("lol")){
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
