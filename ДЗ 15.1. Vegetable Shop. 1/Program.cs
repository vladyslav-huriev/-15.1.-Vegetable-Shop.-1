namespace ДЗ_15._1._Vegetable_Shop._1;

using System;
using System.Collections.Generic;
using System.Linq;
abstract class Product
{
    public string Name { get; }
    protected double BasePrice { get; }
    public virtual double Price => BasePrice;
    public Product(string name, double basePrice)
    {
        Name = name;
        BasePrice = basePrice;
    }
    public override string ToString() => $"Product: {Name}, Price: {Price}";
}
class Carrot : Product
{
    public Carrot(double basePrice) : base("Carrot", basePrice) { }
}
class Potato : Product
{
    public int Count { get; }
    public override double Price => BasePrice * Count;
    public Potato(double basePrice, int count) : base("Potato", basePrice)
    {
        Count = count;
    }
    public override string ToString() => base.ToString() + $", Count: {Count}, Total price: {Price}";
}
class Cucumber : Product
{
    public int Count { get; }
    public override double Price => BasePrice * Count;
    public Cucumber(double basePrice, int count) : base("Cucumber", basePrice)
    {
        Count = count;
    }
    public override string ToString() => base.ToString() + $", Count: {Count}, Total price: {Price}";
}
class Tomato : Product
{
    public Tomato(double basePrice) : base("Tomato", basePrice) { }
}
class VegetableShop
{
    private List<Product> _products = new List<Product>();
    public void AddProducts(IEnumerable<Product> products)
    {
        _products.AddRange(products);
    }
    public void PrintProductsInfo()
    {
        double totalPrice = 0;
        foreach (var product in _products)
        {
            Console.WriteLine(product);
            totalPrice += product.Price;
        }
        Console.WriteLine($"Total products price: {totalPrice}");
    }
}
class Program
{
    static void Main()
    {
        var products = new List<Product>
        {
            new Carrot(15),
            new Potato(20, 4),
            new Cucumber(14, 2),
            new Tomato(10)
        };
        VegetableShop shop = new VegetableShop();
        shop.AddProducts(products);
        shop.PrintProductsInfo();
    }
}
