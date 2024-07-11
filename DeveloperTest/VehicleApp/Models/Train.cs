using VehicleApp.Models.Abstactions;

namespace VehicleApp.Models;

public class Train : Vehicle
{
    public int NumberOfCars { get; set; }
    public Train() : base(150, "STRIZH", "grey")
    {
        NumberOfCars = 10;
    }
}
