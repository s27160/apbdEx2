namespace ConsoleApp.Model;

public abstract class Container
{
    private static int _globalCounter = 1;

    public string SerialNumber { get; }

    public double CargoMass { get; protected set; }

    public double Height { get; set; }

    public double OwnWeight { get; set; }

    public double Depth { get; set; }

    protected double MaxCapacity { get; set; }

    protected Container(string typeCode, double height, double ownWeight, double depth, double maxCapacity)
    {
        SerialNumber = $"KON-{typeCode}-{_globalCounter++}";
        Height = height;
        OwnWeight = ownWeight;
        Depth = depth;
        MaxCapacity = maxCapacity;
        CargoMass = 0;
    }

    public virtual void LoadCargo(double mass)
    {
        if (CargoMass + mass > MaxCapacity)
        {
            throw new OverfillException(MaxCapacity, SerialNumber);
        }

        CargoMass += mass;
    }

    public virtual void UnloadCargo()
    {
        CargoMass = 0;
    }

    public override string ToString()
    {
        return $"{SerialNumber} (CargoMass={CargoMass} kg, OwnWeight={OwnWeight} kg, MaxCapacity={MaxCapacity} kg)";
    }
}