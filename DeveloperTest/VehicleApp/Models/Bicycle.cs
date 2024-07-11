using VehicleApp.Models.Abstactions;

namespace VehicleApp.Models;

public class Bicycle : Vehicle
{
    public bool IsFixedGear { get; set; }

    public Bicycle() : base(25, "Trek", "Blue")
    {
        IsFixedGear = false;
    }
}
