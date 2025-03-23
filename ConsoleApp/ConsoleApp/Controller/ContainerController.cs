using ConsoleApp.Model;

namespace ConsoleApp.Controller;

public static class ContainerController
{
    public static void Create()
    {
        Console.WriteLine("Wybierz rodzaj kontenera:");
        Console.WriteLine("1) Kontener na płyny");
        Console.WriteLine("2) Kontener na gaz");
        Console.WriteLine("3) Kontener chłodniczy");
        var typeChoice = Console.ReadLine();

        string[] choices = ["1", "2", "3"];
        var a = Array.Exists(choices, element => element == typeChoice);
        if (a == false)
        {
            Console.WriteLine("Nieznany rodzaj kontenera.");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Podaj wysokość (cm):");
        var height = double.Parse(Console.ReadLine() ?? string.Empty);

        Console.WriteLine("Podaj wagę własną (kg):");
        var ownWeight = double.Parse(Console.ReadLine() ?? string.Empty);

        Console.WriteLine("Podaj głębokość (cm):");
        var depth = double.Parse(Console.ReadLine() ?? string.Empty);

        Console.WriteLine("Podaj maksymalną ładowność (kg):");
        var maxCap = double.Parse(Console.ReadLine() ?? string.Empty);

        Container c;

        switch (typeChoice)
        {
            case "1":
                Console.WriteLine("Czy ładunek jest niebezpieczny? (t/n)");
                var dangerous = Console.ReadLine() ?? string.Empty;
                var isDangerous = (dangerous.Equals("t", StringComparison.CurrentCultureIgnoreCase));
                c = new LiquidContainer(height, ownWeight, depth, maxCap, isDangerous);
                break;
            case "2":
                Console.WriteLine("Podaj ciśnienie (atm):");
                var pressure = double.Parse(Console.ReadLine() ?? string.Empty);
                c = new GasContainer(height, ownWeight, depth, maxCap, pressure);
                break;
            case "3":
                Console.WriteLine("Podaj wymaganą temperaturę kontenera (°C):");
                var reqTemp = double.Parse(Console.ReadLine() ?? string.Empty);
                c = new RefrigeratedContainer(height, ownWeight, depth, maxCap, reqTemp);
                break;
            default:
                return;
        }

        Cache.Containers.Add(c);
        Console.WriteLine($"Dodano kontener: {c.SerialNumber}");
        Console.ReadKey();
    }

    public static void LoadCargo()
    {
        Console.WriteLine("Podaj numer kontenera (SerialNumber):");
        var serial = Console.ReadLine();
        var container = Cache.Containers.FirstOrDefault(c => c.SerialNumber == serial);
        if (container == null)
        {
            Console.WriteLine("Nie znaleziono kontenera!");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Podaj masę ładunku do załadowania (kg):");
        var mass = double.Parse(Console.ReadLine() ?? string.Empty);

        try
        {
            container.LoadCargo(mass);
            Console.WriteLine("Załadowano ładunek do kontenera!");
        }
        catch (OverfillException oe)
        {
            Console.WriteLine("Błąd przepełnienia: " + oe.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Błąd: " + ex.Message);
        }

        Console.ReadKey();
    }

    public static void UnloadContainer()
    {
        Console.WriteLine("Podaj numer kontenera (SerialNumber):");
        var serial = Console.ReadLine();
        var container = Cache.Containers.FirstOrDefault(c => c.SerialNumber == serial);
        if (container == null)
        {
            Console.WriteLine("Nie znaleziono kontenera!");
            Console.ReadKey();
            return;
        }

        container.UnloadCargo();
        Console.WriteLine("Kontener rozładowany!");
        Console.ReadKey();
    }
}