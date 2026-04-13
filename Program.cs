// =================================================================================== SECTION 1: ( PRODUCT CLASS ) =================================================================================== //
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
            return true;
        }
        else
        {
            return false;
        }
    }


    public void DeductStock(int quantity)
    {
        RemainingStock -= quantity;
    }

}
// =================================================================================== SECTION 2: ( STORE MENU  [ !! UPDATED SECTION !! ] ) =================================================================================== //
class Program
{

    static void Main(string[] args)
    {
        string choice = "y";
        Product[] cart = new Product[10];      //
        int[] cartQty = new int[10];          //<.............................  [ Was prevously on section 6  but moved to section 2 to fic the cart system ]
        int cartCount = 0;                   //
        int totalItems = 0;  //<..............................[ Recently added for CART SYSTEM ]

        Product[] store = new Product[3];

        store[0] = new Product { Id = 1, Name = "Laptop", Price = 60000, RemainingStock = 10 };
        store[1] = new Product { Id = 2, Name = "Mouse", Price = 2000, RemainingStock = 10 };
        store[2] = new Product { Id = 3, Name = "Keyboard", Price = 4000, RemainingStock = 10 };

        Console.WriteLine("======================= STORE MENU =======================");
        for (int i = 0; i < store.Length; i++)
        {
            store[i].DisplayProduct();
        }
        while (choice == "y" || choice == "Y")
        {
            // =================================================================================== SECTION 3: ( USER INPUT [ !! UPDATED SECTION !! ] ) =================================================================================== //

            int productId = 0;
            bool isValidId = false;

            while (!isValidId || productId <= 0)
            {
                Console.WriteLine("Enter Product ID: ");
                string inputId = Console.ReadLine();

                isValidId = int.TryParse(inputId, out productId);

                if (!isValidId || productId <= 0)
                {
                    Console.WriteLine("Invalid Product ID Try Again");
                }
            }


            int quantity = 0;
            bool isValidQty = false;

            while (!isValidQty || quantity <= 0)
            {
                Console.WriteLine("Enter Quantity: ");
                string inputQty = Console.ReadLine();

                isValidQty = int.TryParse(inputQty, out quantity);

                if (!isValidQty || quantity <= 0)
                {
                    Console.WriteLine("Invalid Quantity Try Again");
                }
            }

            // =================================================================================== SECTION 4: ( PRODUCT SELECTION ) =================================================================================== //
            Product selectedProduct = null;

            for (int i = 0; i < store.Length; ++i)
            {
                if (store[i].Id == productId)
                {
                    selectedProduct = store[i];
                    break;
                }

            }

            // =================================================================================== SECTION 5: ( STOCK CHECK and PROCESSING [ !! UPDATED SECTION !! ]  ) =================================================================================== //
            bool isTransactionValid = false;  //<........................ [ RECENTLY ADDED for CART SYSTEM UPDATE ]
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

                isTransactionValid = true;     //<........................ [ RECENTLY ADDED for CART SYSTEM UPDATE ]

                Console.WriteLine($"Added to cart! total: {total}");
            }

            // =================================================================================== SECTION 6: ( CART DECLARATION and ADD TO CART [ !! UPDATED SECTION !! ] ) =================================================================================== //
             
            if (isTransactionValid && selectedProduct != null)
            {
                if (totalItems + quantity > 10)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Cart is Full. Cannot ADD more items");
                    Console.WriteLine("");
                }
                else
                {
                    int exisitingIndex = -1;

                    for (int i = 0; i < cartCount; i++)
                    {
                        if (cart[i].Id == selectedProduct.Id)
                        {
                            exisitingIndex = i;
                            break;
                        }
                    }
                    if (exisitingIndex != -1)
                    {
                        cartQty[exisitingIndex] += quantity;
                    }
                    else
                    {
                        cart[cartCount] = selectedProduct;
                        cartQty[cartCount] = quantity;
                        cartCount++;
                    }
                    totalItems += quantity;

                    Console.WriteLine("Product Added to Cart");
                }
            }

            // =================================================================================== SECTION 7: ( RECEIPT DISPLAY ) =================================================================================== //
            Console.WriteLine("======================= RECEIPT =======================");
            for (int i = 0; i < cartCount; ++i)
            {
                double itemTotal = cart[i].GetItemtotal(cartQty[i]);

                Console.WriteLine($"Product: {cart[i].Name}, Qty: {cartQty[i]}, Price: {cart[i].Price}, Total: {itemTotal}");
            }

            // =================================================================================== SECTION 8: ( TOTAL COMPUTATION ) =================================================================================== //
            double finalTotal = 0;

            for (int i = 0; i < cartCount; i++)
            {
                double itemTotal = cart[i].GetItemtotal(cartQty[i]);
                finalTotal += itemTotal;
            } 

            Console.WriteLine($"Total Amount: {finalTotal}");

            // =================================================================================== SECTION 9: ( DISCOUNT SYSTEM ) =================================================================================== //
            double discount = 0;
            double finalAmount = finalTotal;

            if (finalTotal >= 5000)
            {
                discount = finalTotal * 0.10;
                finalAmount = finalTotal - discount;

                Console.WriteLine("Discount Applied: 10%");
            }

            Console.WriteLine($"Final Amount to Pay: {finalAmount}");

            // =================================================================================== SECTION 10: ( LOOP ) =================================================================================== //
            Console.WriteLine("");
            Console.WriteLine("Do you want to buy again? (y/n): ");
            choice = Console.ReadLine();

            while (choice != "y" && choice != "Y" && choice != "n" && choice != "N")
            {
                Console.WriteLine("Invalid Choice. Enter only (Y/y) or (N/n)");
                choice = Console.ReadLine();
            }
            if (choice == "n" || choice == "N")
            {
                Console.WriteLine("Thank you for Shopping!");
            }
            // =================================================================================== DEAD END=================================================================================== //


        }
    }
}



