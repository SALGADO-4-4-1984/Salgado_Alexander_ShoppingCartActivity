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
        return Price * quantity;   // <------------- Per quantity multiplies the price of the product the user chose
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

        Console.WriteLine("======================= STORE MENU =======================");
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
        if (!isValidQty) // <------------- Checks if Quantity is Valid Number according to USER's Input
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

        //---------------------------------------------------------------------SECTION 4: ( PRODUCT SELECTION )-------------------------------------------------------------//
        Product selectedProduct = null;

        for (int i = 0; i < store.Length; ++i)
        {
            if (store[i].Id == productId)
            {
                selectedProduct = store[i];
                break;
            }

        }

        //------------------------------------------------------------SECTION 5: ( STOCK CHECK and PROCESSING  )-------------------------------------------------------------//

        if (selectedProduct == null)
        {
            Console.WriteLine("Product not Found.");
        }

        else if (!selectedProduct.HasEnoughStock(quantity))
        {
            Console.WriteLine("Not enough stock Available");
        }

        else
        {
            double total = selectedProduct.GetItemtotal(quantity);
            selectedProduct.DeductStock(quantity);

            Console.WriteLine($"Added to cart! total: {total}");
        }

        //----------------------------------------------------------SECTION 6: ( CART DECLARATION and ADD TO CART )------------------------------------------------------------//
        Product[] cart = new Product[10];
        int[] cartQty = new int[10];
        int cartCount = 0;

        int existingIndex = -1;

        for (int i = 0; i < cartCount; ++i)
        {
            if(cart[i].Id == selectedProduct.Id)
            {
                existingIndex = i;
                break;
            }
        }

        if (existingIndex != -1)
        {
            cartQty[existingIndex] += quantity;
        }
        else
        {
            cart[cartCount] = selectedProduct;
            cartQty[cartCount] = quantity;
            cartCount++;
        }
        
        Console.WriteLine("Product Added to Cart.");

        //----------------------------------------------------------SECTION 7: ( RECEIPT DISPLAY )------------------------------------------------------------//
        Console.WriteLine("======================= RECEIPT =======================");
        for (int i = 0; i < cartCount; ++i)
        {
            double itemTotal = cart[i].GetItemtotal(cartQty[i]);

            Console.WriteLine($"Product: {cart[i].Name}, Qty: {cartQty[i]}, Price: {cart[i].Price}, Total: {itemTotal}");
        }

        //----------------------------------------------------------SECTION 8: ( TOTAL COMPUTATION )------------------------------------------------------------//
        double finalTotal = 0;

        for(int i = 0; i < cartCount; i++)
        {
            double itemTotal = cart[i].GetItemtotal(cartQty[i]);
            finalTotal += itemTotal;
        }

        Console.WriteLine($"Total Amount: {finalTotal}");

        //----------------------------------------------------------SECTION 9: ( DISCOUNT SYSTEM )------------------------------------------------------------//
        double discount = 0;
        double finalAmount = finalTotal;

        if (finalTotal >= 5000)
        {
            discount = finalTotal * 0.10;
            finalAmount = finalTotal - discount;

            Console.WriteLine("Discount Applied: 10%");
        }

        Console.WriteLine($"Final Amount to Pay: {finalAmount}");

        //----------------------------------------------------------SECTION 10: ( LOOP [ WORK IN PROGRESS ] )------------------------------------------------------------//
        Console.WriteLine("Do you want to buy again? (y/n): ");
        string choice = Console.ReadLine();

        if (choice == "Y" || choice == "y")
        {
            Console.WriteLine("Restarting...");
        }
        else if (choice == "N" || choice == "n")
        {
            Console.WriteLine("Thank you for Shopping!"); 
        }

        //----------------------------------------------------------------------------------DEAD END-----------------------------------------------------------------------------//



    }
}




