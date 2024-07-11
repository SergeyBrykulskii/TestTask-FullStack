using VehicleApp.Models.Abstactions;

namespace VehicleApp.Models;

public class Car : Vehicle
{
    public double EngineCapacity { get; set; }
    public int EnginePower { get; set; }

    public Car() : base(150, "Nissan", "White")
    {
        EngineCapacity = 3.8;
        EnginePower = 480;
    }
}
