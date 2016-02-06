namespace VehiclePark.Interfaces
{
    public interface ILayout
    {
        int PlacesPerSector { get; set; }

        int Sectors { get; set; }
    }
}