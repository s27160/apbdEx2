using ConsoleApp.Model;

namespace ConsoleApp.Controller;

public static class ShipController
{
    public static void Create()
    {
        Console.WriteLine("Podaj nazwę statku:");
        var name = Console.ReadLine() ?? string.Empty;

        Console.WriteLine("Podaj maksymalną prędkość (węzły):");
        var speed = double.Parse(Console.ReadLine() ?? string.Empty);

        Console.WriteLine("Podaj maksymalną liczbę kontenerów:");
        var maxNum = int.Parse(Console.ReadLine() ?? string.Empty);

        Console.WriteLine("Podaj maksymalny udźwig (w tonach):");
        var maxWeight = double.Parse(Console.ReadLine() ?? string.Empty);

        Cache.Ships.Add(new Ship(name, speed, maxNum, maxWeight));
        Console.WriteLine("Dodano statek!");
        Console.ReadKey();
    }

    public static void Delete()
    {
        Console.WriteLine("Podaj nazwę statku do usunięcia:");
        var name = Console.ReadLine();

        var ship = Cache.Ships.FirstOrDefault(s => s.Name == name);
        if (ship == null)
        {
            Console.WriteLine("Nie znaleziono statku o podanej nazwie!");
        }
        else
        {
            Cache.Ships.Remove(ship);
            Console.WriteLine("Usunięto statek!");
        }

        Console.ReadKey();
    }


    public static void LoadContainer()
    {
        Console.WriteLine("Podaj numer kontenera (SerialNumber) do załadowania:");
        var serial = Console.ReadLine();
        var container = Cache.Containers.FirstOrDefault(c => c.SerialNumber == serial);
        if (container == null)
        {
            Console.WriteLine("Nie znaleziono kontenera o podanym numerze!");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Podaj nazwę statku:");
        var name = Console.ReadLine();
        var ship = Cache.Ships.FirstOrDefault(s => s.Name == name);
        if (ship == null)
        {
            Console.WriteLine("Nie znaleziono statku o podanej nazwie!");
            Console.ReadKey();
            return;
        }

        try
        {
            ship.LoadContainer(container);
            Console.WriteLine("Załadowano kontener na statek!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Błąd: " + ex.Message);
        }

        Console.ReadKey();
    }

    public static void RemoveContainer()
    {
        Console.WriteLine("Podaj nazwę statku:");
        var name = Console.ReadLine();
        var ship = Cache.Ships.FirstOrDefault(s => s.Name == name);
        if (ship == null)
        {
            Console.WriteLine("Nie znaleziono statku!");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Podaj numer kontenera (SerialNumber) do usunięcia:");
        var serial = Console.ReadLine() ?? string.Empty;

        try
        {
            ship.RemoveContainer(serial);
            Console.WriteLine("Usunięto kontener ze statku!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Błąd: " + ex.Message);
        }

        Console.ReadKey();
    }
    
    public static void ReplaceContainer()
    {
        Console.WriteLine("Podaj nazwę statku:");
        var name = Console.ReadLine();
        var ship = Cache.Ships.FirstOrDefault(s => s.Name == name);
        if (ship == null)
        {
            Console.WriteLine("Nie znaleziono statku!");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Podaj numer kontenera (SerialNumber) do zastąpienia:");
        var oldSerial = Console.ReadLine() ?? string.Empty;

        Console.WriteLine("Podaj numer nowego kontenera (SerialNumber):");
        var newSerial = Console.ReadLine();
        var newContainer = Cache.Containers.FirstOrDefault(c => c.SerialNumber == newSerial);
        if (newContainer == null)
        {
            Console.WriteLine("Nie znaleziono nowego kontenera!");
            Console.ReadKey();
            return;
        }

        try
        {
            ship.ReplaceContainer(oldSerial, newContainer);
            Console.WriteLine("Zastąpiono kontener na statku!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Błąd: " + ex.Message);
        }

        Console.ReadKey();
    }
    
    public static void TransferContainerBetweenShips()
    {
        Console.WriteLine("Podaj nazwę statku źródłowego:");
        var sourceName = Console.ReadLine();
        var sourceShip = Cache.Ships.FirstOrDefault(s => s.Name == sourceName);
        if (sourceShip == null)
        {
            Console.WriteLine("Nie znaleziono statku źródłowego!");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Podaj nazwę statku docelowego:");
        var targetName = Console.ReadLine();
        var targetShip = Cache.Ships.FirstOrDefault(s => s.Name == targetName);
        if (targetShip == null)
        {
            Console.WriteLine("Nie znaleziono statku docelowego!");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Podaj numer kontenera do przeniesienia:");
        var serial = Console.ReadLine() ?? string.Empty;

        try
        {
            sourceShip.TransferContainer(serial, targetShip);
            Console.WriteLine("Przeniesiono kontener!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Błąd: " + ex.Message);
        }

        Console.ReadKey();
    }
}