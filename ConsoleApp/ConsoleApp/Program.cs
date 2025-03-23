using ConsoleApp.View;
using ConsoleApp.Controller;

namespace ConsoleApp;

using System;

public static class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            ProgramView.Screen();
            Console.WriteLine("Możliwe akcje:");
            Console.WriteLine("1. Dodaj statek");
            Console.WriteLine("2. Usuń statek");
            Console.WriteLine("3. Dodaj kontener");
            Console.WriteLine("4. Załaduj kontener na statek");
            Console.WriteLine("5. Usuń kontener ze statku");
            Console.WriteLine("6. Załaduj ładunek do kontenera");
            Console.WriteLine("7. Rozładuj kontener");
            Console.WriteLine("8. Zastąp kontener na statku");
            Console.WriteLine("9. Przenieś kontener między statkami");
            Console.WriteLine("10. Wypisz informacje o kontenerze");
            Console.WriteLine("11. Wypisz informacje o statku");
            Console.WriteLine("0. Wyjście");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    ShipController.Create();
                    break;
                case "2":
                    ShipController.Delete();
                    break;
                case "3":
                    ContainerController.Create();
                    break;
                case "4":
                    ShipController.LoadContainer();
                    break;
                case "5":
                    ShipController.RemoveContainer();
                    break;
                case "6":
                    ContainerController.LoadCargo();
                    break;
                case "7":
                    ContainerController.UnloadContainer();
                    break;
                case "8":
                    ShipController.ReplaceContainer();
                    break;
                case "9":
                    ShipController.TransferContainerBetweenShips();
                    break;
                case "10":
                    ContainerView.Info();
                    break;
                case "11":
                    ShipView.Info();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Nieznana opcja.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}