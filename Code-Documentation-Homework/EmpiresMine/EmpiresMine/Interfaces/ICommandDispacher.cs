namespace EmpiresMine.Interfaces
{
    public interface ICommandDispacher
    {
    /// <summary>
    /// Dispatches the command by it's parameters
    /// </summary>
    /// <param name="parameters">The parameters of the command</param>
        void DispatchCommand(string[] parameters);


    }
}