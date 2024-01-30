using System.Collections.Generic;
using System.Linq;

namespace SodaMachineNew.Model.Command
{
    internal class CommandList : ICommandList
    {
        readonly List<ICommand> commandList = new List<ICommand>() { };

        public void Initialize()
        {
            commandList.Add(new InsertCommand());
            commandList.Add(new OrderCommand());
            commandList.Add(new SmsOrderCommand());
            commandList.Add(new RecallCommand());
        }
        
        public List<ICommand> GetOrderedCommandList()
        { 
            return commandList.OrderBy(x => x.Id).ToList();
        }

        public ICommand GetCommandByName(string input)
        {
            return commandList.FirstOrDefault(x => input.StartsWith(x.Name));
        }
    }
}
