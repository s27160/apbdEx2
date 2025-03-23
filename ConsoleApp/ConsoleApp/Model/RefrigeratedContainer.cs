namespace ConsoleApp.Model;

public class RefrigeratedContainer(
    double height,
    double ownWeight,
    double depth,
    double maxCapacity,
    double requiredTemperature)
    : Container("C", height, ownWeight, depth, maxCapacity)
{
    private Product? SettedProduct { get; set; }
    private double Temperature { get; set; } = requiredTemperature;
    private double RequiredTemperature { get; } = requiredTemperature;

    public override void LoadCargo(double mass)
    {
        Console.WriteLine("Podaj identyfikator produktu:");
        Cache.Products.ForEach(product => Console.WriteLine($"{product.Id} - {product.Name} - Wymagana temperatura: {product.Temperature}C"));

        var productId = int.Parse(Console.ReadLine() ?? string.Empty);
        var settedProduct = Cache.Products.FirstOrDefault(p => p.Id == productId);

        if (settedProduct == null)
        {
            throw new Exception("Nieznany rodzaj produktu.");
        }
            
        if (Temperature < settedProduct.Temperature)
        {
            throw new Exception("Za niska temperatura dla tego typu produktu.");
        }

        if (SettedProduct != null && SettedProduct != settedProduct)
        {
            throw new Exception("W kontenerze może byc tylko jeden typ produktu. Żeby załadować nowy typ należy wyładować stary.");
        }
            
        SettedProduct = settedProduct;
        
        base.LoadCargo(mass);
    }
    
    public override void UnloadCargo()
    {
        SettedProduct = null;
        base.UnloadCargo();
    }

    public override string ToString()
    {
        return base.ToString() + $" (Produkt={SettedProduct?.Name ?? "Nie ustawiono"}, Temp={Temperature}°C, MinWymagana={RequiredTemperature}°C)";
    }
}