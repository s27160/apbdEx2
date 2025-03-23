namespace ConsoleApp;

public class OverfillException(double maxCapacity, string serialNumber) : Exception($"Przekroczono maksymalną ładowność {maxCapacity} kg dla kontenera {serialNumber}.");