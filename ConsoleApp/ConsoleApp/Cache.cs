using ConsoleApp.Model;

namespace ConsoleApp;

public static class Cache
{
    public static readonly List<Ship> Ships = [];
    public static readonly List<Container> Containers = [];
    public static readonly List<Product> Products = [
        new Product(1,"Bananas", 13.3),
        new Product(2,"Chocolate", 18),
        new Product(3,"Fish", 2),
        new Product(4,"Meat", -15),
        new Product(5,"Ice cream", -18),
        new Product(6,"Frozen pizza", -30),
        new Product(7,"Cheese", 7.2),
        new Product(8,"Sausages", 5),
        new Product(9,"Butter", 20.5),
        new Product(10,"Eggs", 19)
    ];
}