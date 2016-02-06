namespace EmpiresMine.Interfaces
{
    public interface IEngine
    {
        /// <summary>
        /// Returns the Databse
        /// </summary>
        IDatabase Database { get; }
        /// <summary>
        /// Returns the Command Dispacher
        /// </summary>
        ICommandDispacher CommandDispacher { get; }
        /// <summary>
        /// Runs the Engine
        /// </summary>
        void Run();
    }
}