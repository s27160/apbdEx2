namespace ConsoleApp.View;

public static class ProgramView
{
    public static void Screen()
    {
        Console.WriteLine("Lista statków:");
        if (Cache.Ships.Count == 0)
        {
            Console.WriteLine("   Brak");
        }
        else
        {
            foreach (var s in Cache.Ships)
            {
                Console.WriteLine($"   - {s.Name} (speed={s.MaxSpeed}, maxContainerNum={s.MaxContainerCount}, maxWeight={s.MaxWeightInTons} t)");
            }
        }

        Console.WriteLine("Lista kontenerów:");
        if (Cache.Containers.Count == 0)
        {
            Console.WriteLine("   Brak");
        }
        else
        {
            foreach (var c in Cache.Containers)
            {
                Console.WriteLine("   - " + c);
            }
        }

        Console.WriteLine();
    }
}