namespace ConsoleApp.View;

public static class ContainerView
{
    public static void Info()
    {
        Console.WriteLine("Podaj numer kontenera (SerialNumber):");
        var serial = Console.ReadLine();
        var container = Cache.Containers.FirstOrDefault(c => c.SerialNumber == serial);
        Console.WriteLine(container == null ? "Nie znaleziono kontenera!" : container.ToString());

        Console.ReadKey();
    }
}