using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        // Sample data
        Address address1 = new Address("123 Noneya Bidness Street", "Utah", "UT", "USA");
        Customer customer1 = new Customer("Kevin Noorda", address1);

        Product product1 = new Product("Water Bottle", "P001", 20.0, 2);
        Product product2 = new Product("Ice Pack", "P002", 15.0, 1);

        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Console.WriteLine("----- Packing Label -----");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("----- Shipping Label -----");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine("----- Total Cost -----");
        Console.WriteLine($"${order1.GetTotalCost()}");
    }
}


// Product Class

class Product
{
    public string Name { get; }
    public string ProductId { get; }
    public double Price { get; }
    public int Quantity { get; }

    public Product(string name, string productId, double price, int quantity)
    {
        Name = name;
        ProductId = productId;
        Price = price;
        Quantity = quantity;
    }

    public double GetTotalCost()
    {
        return Price * Quantity;
    }
}


// Address Class

class Address
{
    public string Street { get; }
    public string City { get; }
    public string StateOrProvince { get; }
    public string Country { get; }

    public Address(string street, string city, string stateOrProvince, string country)
    {
        Street = street;
        City = city;
        StateOrProvince = stateOrProvince;
        Country = country;
    }

    public bool IsInUSA()
    {
        return Country.Trim().ToUpper() == "USA";
    }

    public string GetFullAddress()
    {
        return $"{Street}\n{City}, {StateOrProvince}\n{Country}";
    }
}


// Customer Class

class Customer
{
    public string Name { get; }
    public Address Address { get; }

    public Customer(string name, Address address)
    {
        Name = name;
        Address = address;
    }

    public bool LivesInUSA()
    {
        return Address.IsInUSA();
    }
}


// Order Class

class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalCost()
    {
        double total = 0;

        foreach (var product in _products)
        {
            total += product.GetTotalCost();
        }

        double shipping = _customer.LivesInUSA() ? 5 : 35;
        return total + shipping;
    }

    public string GetPackingLabel()
    {
        StringBuilder label = new StringBuilder();
        foreach (var product in _products)
        {
            label.AppendLine($"{product.Name} (ID: {product.ProductId})");
        }
        return label.ToString();
    }

    public string GetShippingLabel()
    {
        return $"{_customer.Name}\n{_customer.Address.GetFullAddress()}";
    }
}