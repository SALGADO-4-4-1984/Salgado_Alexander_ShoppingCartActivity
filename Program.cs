//----------------------------------------------SECTION 1: ( PRODUCT CLASS )--------------------------------------------------------//
using System;

class Product
{
    public int Id;
    public string Name;
    public double Price;
    public int RemainingStock;

    public void DisplayProduct()
    {
        Console.WriteLine($"ID: {Id}, Name: {Name}, Price: {Price}, Stock: {RemainingStock}");
    }

    public double GetItemtotal(int quantity)
    {
        return Price * quantity;
    }

    public bool HasEnoughStock(int quantity)
    {
        if (RemainingStock >= quantity)
        {
            return true; // When stock is available
        }
        else
        {
            return false; // Not Enough Stock
        }
    }


    public void DeductStock(int quantity) // Reduce stock or -1 stock per purchase of product
    {
        RemainingStock -= quantity;
    }

}

//----------------------------------------------------------------DEAD END---------------------------------------------------------//
