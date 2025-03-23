namespace ConsoleApp.Model;

public class Ship(string name, double maxSpeed, int maxContainerCount, double maxWeightInTons)
{
    public string Name { get; set; } = name;
    public double MaxSpeed { get; set; } = maxSpeed;
    public int MaxContainerCount { get; set; } = maxContainerCount;
    public double MaxWeightInTons { get; set; } = maxWeightInTons;

    private readonly List<Container> _containers = [];

    public void LoadContainer(Container container)
    {
        if (_containers.Count >= MaxContainerCount)
        {
            throw new Exception($"Statek {Name} nie może załadować więcej kontenerów (limit: {MaxContainerCount}).");
        }

        var currentWeight = _containers.Sum(c => c.OwnWeight + c.CargoMass);
        var newWeight = currentWeight + container.OwnWeight + container.CargoMass;

        if (newWeight / 1000.0 > MaxWeightInTons)
        {
            throw new Exception($"Statek {Name} przekroczy maksymalny udźwig {MaxWeightInTons} ton.");
        }

        _containers.Add(container);
    }

    public void RemoveContainer(string serialNumber)
    {
        var container = _containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container == null)
        {
            throw new Exception($"Nie znaleziono kontenera {serialNumber} na statku {Name}!");
        }

        _containers.Remove(container);
    }

    public void ReplaceContainer(string oldSerialNumber, Container newContainer)
    {
        RemoveContainer(oldSerialNumber);
        LoadContainer(newContainer);
    }

    public void TransferContainer(string serialNumber, Ship targetShip)
    {
        var container = _containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container == null)
        {
            throw new Exception($"Nie znaleziono kontenera {serialNumber} na statku {Name}!");
        }

        targetShip.LoadContainer(container);

        _containers.Remove(container);
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Statek: {Name} (MaxSpeed={MaxSpeed} węzłów, MaxContainers={MaxContainerCount}, MaxWeight={MaxWeightInTons} ton)");
        Console.WriteLine("Kontenery na pokładzie:");
        if (_containers.Count == 0)
        {
            Console.WriteLine("   Brak kontenerów.");
        }
        else
        {
            foreach (var c in _containers)
            {
                Console.WriteLine("   " + c.ToString());
            }
        }
    }
}