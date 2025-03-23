namespace ConsoleApp.View;

public static class ShipView
{
    public static void Info()
    {
        Console.WriteLine("Podaj nazwę statku:");
        var name = Console.ReadLine();
        var ship = Cache.Ships.FirstOrDefault(s => s.Name == name);
        if (ship == null)
        {
            Console.WriteLine("Nie znaleziono statku!");
        }
        else
        {
            ship.PrintInfo();
        }

        Console.ReadKey();
    }
}