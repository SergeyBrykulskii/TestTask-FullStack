using VehicleApp.Models.Abstactions;
using VehicleApp.Services;

namespace VehicleApp;

public static class Program
{
    public static void Main()
    {
        var vehicles = InstanceService.GetInstances<Vehicle>();

        foreach (var el in vehicles)
        {
            Console.WriteLine(el);
        }
    }
}
