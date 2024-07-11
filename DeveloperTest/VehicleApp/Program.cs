using VehicleApp.Models.Abstactions;
using VehicleApp.Services;

namespace VehicleApp;

public static class Program
{
    public static void Main()
    {
        var vehicles = InstanceService.GetInstances<Vehicle>();
        var vehicleTypes = vehicles.Select(v => v.GetType().Name);

        PrintHelpMessage();

        while (true)
        {
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input. Press any key to continue.");
                continue;
            }

            switch (choice)
            {
                case 0:
                    PrintHelpMessage();
                    break;
                case 1:
                    PrintVehicles(vehicleTypes);
                    break;
                case 2:
                    PrintVehicles(vehicleTypes, true);
                    break;
                case 3:
                    ProcessSearchCommand(vehicleTypes);
                    break;
                case 4:
                    TrySaveInstancesToFile(vehicles);
                    break;
                case 5:
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Press any key to continue.");
                    break;
            }
        }
    }

    private static void PrintHelpMessage()
    {
        Console.Clear();
        Console.WriteLine("0. Help\n" +
            "1. List vehicle types\n" +
            "2. List vehicle types in alphabetical order\n" +
            "3. Search for a type\n" +
            "4. Save instances to disk\n" +
            "5. Exit");
    }

    private static void PrintVehicles(
        IEnumerable<string> vehicleTypes,
        bool isInAlphabeticalOrder = false)
    {
        if (isInAlphabeticalOrder)
        {
            vehicleTypes = vehicleTypes.Order();
        }

        foreach (var vehicleType in vehicleTypes)
        {
            Console.WriteLine(vehicleType);
        }
    }

    private static void ProcessSearchCommand(IEnumerable<string> vehicleTypes)
    {
        Console.WriteLine("Enter name of type (or part of the name)");
        var searchTarget = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(searchTarget))
        {
            Console.WriteLine("Please, enter a non-empty name of type");
            return;
        }

        var foundTypes = vehicleTypes.Where(t =>
           t.Contains(searchTarget, StringComparison.OrdinalIgnoreCase));

        Console.WriteLine($"Search target - {searchTarget}\n" +
            "Result:");

        if (!foundTypes.Any())
        {
            Console.WriteLine("No matching types found.");
        }
        else
        {
            PrintVehicles(foundTypes);
        }
    }

    private static void TrySaveInstancesToFile(IEnumerable<Vehicle> vehicles)
    {
        try
        {
            using var writer = new StreamWriter("VehicleInstances.txt");

            foreach (var instance in vehicles)
            {
                writer.WriteLine(instance.ToString());
            }

            Console.WriteLine("Instances saved to disk.");
        }
        catch (Exception)
        {
            Console.WriteLine("Instances can't saved to disk.");
        }
    }
}
