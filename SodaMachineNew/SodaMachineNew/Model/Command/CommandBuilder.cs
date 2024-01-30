using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachineNew.Model.Command
{
    internal class CommandBuilder
    {
        public ICommand Build(string input)
        {
            if (input.StartsWith("insert"))
                return new InsertCommand();

            if (input.StartsWith("order"))
                return new OrderCommand();

            if (input.StartsWith("sms order"))
                return new SmsOrderCommand();

            if (input.Equals("recall"))
                return new RecallCommand();

            return null;
        }
    }
}
