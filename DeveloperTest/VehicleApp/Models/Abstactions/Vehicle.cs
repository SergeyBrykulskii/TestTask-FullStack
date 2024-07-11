namespace VehicleApp.Models.Abstactions;

public abstract class Vehicle
{
    public int MaxSpeed { get; set; }
    public string Brand { get; set; }
    public string Color { get; set; }

    protected Vehicle(int maxSpeed, string brand, string color)
    {
        MaxSpeed = maxSpeed;
        Brand = brand;
        Color = color;
    }
}
