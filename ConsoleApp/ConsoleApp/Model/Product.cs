namespace ConsoleApp.Model;

public class Product(int id, string name, double temperature)
{
    public int Id { get;} = id;
    public string Name { get; } = name;
    public double Temperature { get; } = temperature;
}