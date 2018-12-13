using Server.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Helper.MessageInterpreter
{
    public class MessageInterpreter
    {
        private string Message { get; set; }

        public void ProcessMessage(ref MessageContext messageContext)
        {
            List<ChatExpression> expressions = new List<ChatExpression>();
            expressions.Add(new CheatExpression());
            expressions.Add(new SwearExpression());

            foreach(ChatExpression exp in expressions)
            {
                exp.Interpret(ref messageContext);
            }
        }
    }
}
