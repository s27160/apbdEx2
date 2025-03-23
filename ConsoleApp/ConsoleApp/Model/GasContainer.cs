namespace ConsoleApp.Model;

public class GasContainer(double height, double ownWeight, double depth, double maxCapacity, double pressure) : Container("G", height, ownWeight, depth, maxCapacity), IHazardNotifier
{
    public double Pressure { get; set; } = pressure;

    public override void LoadCargo(double mass)
    {
        if (CargoMass + mass > MaxCapacity)
        {
            NotifyHazard($"Próba załadowania {mass} kg do kontenera {SerialNumber} przekracza pojemność!");
            throw new OverfillException(MaxCapacity, SerialNumber);
        }

        base.LoadCargo(mass);
    }

    public override void UnloadCargo()
    {
        CargoMass *= 0.05;
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"[HAZARD] {message}");
    }
}