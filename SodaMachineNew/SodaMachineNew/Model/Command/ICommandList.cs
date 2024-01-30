using System.Collections.Generic;

namespace SodaMachineNew.Model.Command
{
    /// <summary>
    /// Contains inventory functions
    /// </summary>
    public interface ICommandList
    {
        /// <summary>
        /// Initializes command list with initial/standard values
        /// </summary>
        void Initialize();

        /// <summary>
        /// Gets command list ordered by Id
        /// </summary>
        List<ICommand> GetOrderedCommandList();

        /// <summary>
        /// Gets command item by name, returns null if no such command exists
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        ICommand GetCommandByName(string name);
    }
}
