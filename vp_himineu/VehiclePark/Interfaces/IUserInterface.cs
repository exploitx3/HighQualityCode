namespace VehiclePark.Interfaces
{
    public interface IUserInterface
    {
        string ReadLine();

        void WriteLine(string format, params object[] args);
    }
}