using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Foundation2 World!");

        // Create addresses
        Address address1 = new Address("123 Main St", "Cityville", "Stateville", "USA");
        Address address2 = new Address("456 Elm St", "Townsville", "Stateton", "Canada");

        // Create customers
        Customer customer1 = new Customer("John Doe", address1);
        Customer customer2 = new Customer("Jane Smith", address2);

        // Create products
        Product product1 = new Product("Laptop", "ABC123", 999.99m, 2);
        Product product2 = new Product("Headphones", "DEF456", 49.99m, 3);
        Product product3 = new Product("Smartphone", "GHI789", 599.99m, 1);

        // Create orders
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product2);
        order2.AddProduct(product3);

        // Display results
        Console.WriteLine("Order 1:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.CalculateTotalCost()}");

        Console.WriteLine("\nOrder 2:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.CalculateTotalCost()}");
    }
}
// Address class
class Address
{
    // Private member variables
    private string street;
    private string city;
    private string state;
    private string country;

    // Constructor
    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    // Method to check if address is in the USA
    public bool IsInUSA()
    {
        return country.Equals("USA", StringComparison.OrdinalIgnoreCase);
    }

    // Method to return address details as a string
    public string GetAddressDetails()
    {
        return $"{street}\n{city}, {state}\n{country}";
    }
}

// Customer class
class Customer
{
    // Private member variables
    private string name;
    private Address address;

    // Constructor
    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    // Method to check if customer is in the USA
    public bool IsInUSA()
    {
        return address.IsInUSA();
    }

    // Method to return customer's name
    public string GetName()
    {
        return name;
    }

    // Method to return customer's address
    public string GetAddress()
    {
        return address.GetAddressDetails();
    }
}

// Product class
class Product
{
    // Private member variables
    private string name;
    private string productId;
    private decimal price;
    private int quantity;

    // Constructor
    public Product(string name, string productId, decimal price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    // Method to calculate total cost of product
    public decimal GetTotalCost()
    {
        return price * quantity;
    }

    // Method to return product details as a string
    public override string ToString()
    {
        return $"Name: {name}, Product ID: {productId}";
    }
}

// Order class
class Order
{
    // Private member variables
    private List<Product> products;
    private Customer customer;

    // Constructor
    public Order(Customer customer)
    {
        this.customer = customer;
        this.products = new List<Product>();
    }

    // Method to add product to order
    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    // Method to calculate total cost of order
    public decimal CalculateTotalCost()
    {
        decimal totalCost = 0;
        foreach (var product in products)
        {
            totalCost += product.GetTotalCost();
        }
        totalCost += customer.IsInUSA() ? 5 : 35; // Shipping cost
        return totalCost;
    }

    // Method to generate packing label
    public string GetPackingLabel()
    {
        string packingLabel = "Packing Label:\n";
        foreach (var product in products)
        {
            packingLabel += product.ToString() + "\n";
        }
        return packingLabel;
    }

    // Method to generate shipping label
    public string GetShippingLabel()
    {
        string shippingLabel = "Shipping Label:\n";
        shippingLabel += $"Customer: {customer.GetName()}\n";
        shippingLabel += $"Address:\n{customer.GetAddress()}";
        return shippingLabel;
    }
}
