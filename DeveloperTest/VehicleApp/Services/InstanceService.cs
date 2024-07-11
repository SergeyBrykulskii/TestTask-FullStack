namespace VehicleApp.Services;

public static class InstanceService
{
    public static IEnumerable<T> GetInstances<T>() where T : class
    {
        var types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(type =>
                type is { IsClass: true, IsAbstract: false }
                && type.IsSubclassOf(typeof(T)))
            .Select(type => (T)Activator.CreateInstance(type));

        return types;
    }
}
