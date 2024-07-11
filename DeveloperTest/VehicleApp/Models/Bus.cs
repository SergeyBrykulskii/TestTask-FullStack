using VehicleApp.Models.Abstactions;

namespace VehicleApp.Models;

public class Bus : Vehicle
{
    public bool IsTourBus { get; set; }

    public Bus() : base(80, "MAZ", "Green")
    {
        IsTourBus = true;
    }
}
