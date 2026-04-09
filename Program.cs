//---------------------------------------------------------------------SECTION 1: ( PRODUCT CLASS )-----------------------------------------------------------------------//
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
            return true; // <------------- When stock is available
        }
        else
        {
            return false; // <------------- Not Enough Stock
        }
    }


    public void DeductStock(int quantity) // <------------- Reduce stock or -1 stock per purchase of product
    {
        RemainingStock -= quantity;
    }

}
//---------------------------------------------------------------------SECTION 2: ( STORE MENU )-----------------------------------------------------------------------//
class Program
{

    static void Main(string[] args)
    {
        Product[] store = new Product[3];

        store[0] = new Product { Id = 1, Name = "Laptop", Price = 60000, RemainingStock = 10 };
        store[1] = new Product { Id = 2, Name = "Mouse", Price = 2000, RemainingStock = 10 };
        store[2] = new Product { Id = 3, Name = "Keyboard", Price = 4000, RemainingStock = 10 };

        Console.WriteLine("============== STORE MENU =============");
        for (int i = 0; i < store.Length; i++)
        {
            store[i].DisplayProduct();
        }
        //----------------------------------------------------------------------SECTION 3: ( USER INPUT )------------------------------------------------------------------------//

        Console.WriteLine("Enter Product ID: "); // <------------- where USER interacts by input product ID
        string inputId = Console.ReadLine();

        int productId;
        bool isValidId = int.TryParse(inputId, out productId);

        Console.WriteLine("Enter Quantity: "); // <------------- where USER interacts by input Quantity
        string inputQty = Console.ReadLine();

        int quantity;
        bool isValidQty = int.TryParse(inputQty, out quantity);

        

        if (!isValidId) // <------------- Checks if ID is Valid Number according to USER's Input
        {
            Console.WriteLine("Invalid Product ID. Please enter a Number.");
        }
        else if (productId <= 0)
        {
            Console.WriteLine("Product ID must not be greater than 0.");
        }
        if (!isValidQty) // <------------- Checks if ID is Valid Number according to USER's Input
        {
            Console.WriteLine("Invalid Quantity. Please enter a Number.");
        }
        else if (quantity <= 0)
        {
            Console.WriteLine("Quantity must not be greater than 0.");
        }
        else
        {
            Console.WriteLine($"You selected Product ID: {productId}, Quantity: {quantity}");
        } 


        //----------------------------------------------------------------------------------DEAD END-----------------------------------------------------------------------------//



    }
}




