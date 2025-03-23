namespace ConsoleApp.Model;

public class LiquidContainer(double height, double ownWeight, double depth, double maxCapacity, bool isDangerous) : Container("L", height, ownWeight, depth, maxCapacity), IHazardNotifier
{
    private bool IsDangerous { get; set; } = isDangerous;

    public override void LoadCargo(double mass)
    {
        var allowedCapacity = IsDangerous ? MaxCapacity * 0.5 : MaxCapacity * 0.9;

        if (CargoMass + mass > allowedCapacity)
        {
            NotifyHazard($"Próba załadowania zbyt dużej ilości " + (IsDangerous ? "niebezpiecznego " : "zwykłego ") + $"ładunku do kontenera {SerialNumber}.");
            throw new OverfillException(maxCapacity: allowedCapacity, serialNumber: SerialNumber);
        }

        base.LoadCargo(mass);
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"[HAZARD] {message}");
    }
}