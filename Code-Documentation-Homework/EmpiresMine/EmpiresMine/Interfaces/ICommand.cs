namespace EmpiresMine.Interfaces
{
    public interface ICommand
    {
        /// <summary>
        /// Returns the Name of the command.
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Executes the command
        /// </summary>
        void Execute();
    }
}