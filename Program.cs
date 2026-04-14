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
// =================================================================================== SECTION 2: ( STORE MENU ) =================================================================================== //
class Program
{

    static void Main(string[] args)
    {
        string choice = "y";
        Product[] cart = new Product[10];      
        int[] cartQty = new int[10];          
        int cartCount = 0;                   
        int totalItems = 0; 

        Product[] store = new Product[3];

        store[0] = new Product { Id = 1, Name = "Laptop", Price = 60000, RemainingStock = 10 };
        store[1] = new Product { Id = 2, Name = "Mouse", Price = 2000, RemainingStock = 10 };
        store[2] = new Product { Id = 3, Name = "Keyboard", Price = 4000, RemainingStock = 10 };

        Console.WriteLine("");
        Console.WriteLine("======================= STORE MENU =======================");
        Console.WriteLine("");
        for (int i = 0; i < store.Length; i++)
        {
            store[i].DisplayProduct();
        }
        while (choice == "y" || choice == "Y")
        {
            // =================================================================================== SECTION 3: ( USER INPUT ) =================================================================================== //

            int productId = 0;
            bool isValidId = false;

            while (!isValidId || productId <= 0)
            {
                Console.WriteLine("");
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
                Console.WriteLine("");
                Console.WriteLine("Enter Quantity: ");
                
                string inputQty = Console.ReadLine();

                isValidQty = int.TryParse(inputQty, out quantity);

                if (!isValidQty || quantity <= 0)
                {
                    
                    Console.WriteLine("Invalid Quantity Try Again");
                    
                }
            }

            // =================================================================================== SECTION 4: ( PRODUCT SELECTION [ ! UPDATED ! ] ) =================================================================================== //
            Product selectedProduct = null;

            for (int i = 0; i < store.Length; ++i)
            {
                if (store[i].Id == productId)
                {
                    selectedProduct = store[i];
                    break;
                }

            }
            if (selectedProduct != null)
            {
                Console.WriteLine("");
                Console.WriteLine($"Product Fouund: {selectedProduct.Name}");   //<...................... [ RECENTLY ADDED for {PRODUCT SELECTION identifying PRODUCT NAME selected by user ]
                
            }


            // =================================================================================== SECTION 5: ( STOCK CHECK and PROCESSING ) =================================================================================== //
            bool isTransactionValid = false; 
            if (selectedProduct == null)
            {
                Console.WriteLine("");
                Console.WriteLine("Product not Found.");
                Console.WriteLine("");
            }

            else if (!selectedProduct.HasEnoughStock(quantity))
            {
                Console.WriteLine("");
                Console.WriteLine("Not enough stock Available");
                Console.WriteLine("");
            }

            else
            {
                double total = selectedProduct.GetItemtotal(quantity);
                selectedProduct.DeductStock(quantity);

                isTransactionValid = true;
                
                Console.WriteLine($"Added to cart! total Price of Specific Product Selected: {total}");
                Console.WriteLine("");
            }

            // =================================================================================== SECTION 6: ( CART DECLARATION and ADD TO CART ) =================================================================================== //
             
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
                    Console.WriteLine("");
                }
            }

            // =================================================================================== SECTION 7: ( RECEIPT DISPLAY [ ! UPDATED ! ]  ) =================================================================================== //
            Console.WriteLine("");
            Console.WriteLine("======================= RECEIPT =======================");
            Console.WriteLine("");
            Console.WriteLine($"Total Items In CART: {totalItems}");                      //<...................... [ RECENTLY ADDED FOR Counting total items in CART ]
            if (totalItems == 10)
            {
                Console.WriteLine("Cart Capacity has Reached its Limit");     //<...................... [ RECENTLY ADDED for Output Statement IF the CART has reached capacity of 10 items in Maximum ]
            }
            Console.WriteLine("");

            for (int i = 0; i < cartCount; ++i)
            {
                double itemTotal = cart[i].GetItemtotal(cartQty[i]);
                
                Console.WriteLine($"Product: {cart[i].Name}, Qty: {cartQty[i]}, Price: {cart[i].Price}, Total: {itemTotal}");
                
            }

            // =================================================================================== SECTION 8: ( TOTAL COMPUTATION [ ! UPDATED ! ] ) =================================================================================== //
            double finalTotal = 0;

            for (int i = 0; i < cartCount; i++)
            {
                double itemTotal = cart[i].GetItemtotal(cartQty[i]);
                finalTotal += itemTotal;
            }
            if (finalTotal < 5000)                    
            {
                Console.WriteLine($"Total Amount to Pay: {finalTotal}");           //<...................... [ RECENTLY ADDDED MAIN OUTPUT STATEMENT if finalTotal price is Less than 5000 ]
            }
            if (finalTotal >= 5000)
            {
                Console.WriteLine($"Origial Total Amount to Pay: {finalTotal}");         //<...................... [ RECENTLY ADDDED ALTERNATE OUTPUT STATEMENT if finalTotal price is Greater than 5000 for discount ]
            }
            
            // =================================================================================== SECTION 9: ( DISCOUNT SYSTEM [ ! UPDATED ! ] ) =================================================================================== //
            double discount = 0;
            double finalAmount = finalTotal;

            if (finalTotal >= 5000)
            {
                discount = finalTotal * 0.10;
                finalAmount = finalTotal - discount;
                Console.WriteLine("");
                Console.WriteLine("Discount Applied: 10%");                           
                Console.WriteLine($"Final Amount to Pay With Discount: {finalAmount}");   //<...................... [ Moved inside if statement bracket if Discount is applied and finalTotal price is greater than 5000 ]
            }
            
            
            

            // =================================================================================== SECTION 10: ( LOOP ) =================================================================================== //
            Console.WriteLine("");
            Console.WriteLine("Do you want to buy again? (y/n): ");
            Console.WriteLine("");
            choice = Console.ReadLine();

            while (choice != "y" && choice != "Y" && choice != "n" && choice != "N")
            {
                Console.WriteLine("");
                Console.WriteLine("Invalid Choice. Enter only (Y/y) or (N/n)");
                Console.WriteLine("");
                choice = Console.ReadLine();
            }
            if (choice == "n" || choice == "N")
            {
                Console.WriteLine("");
                Console.WriteLine("Thank you for Shopping!");
                Console.WriteLine("");
            }
            // =================================================================================== DEAD END=================================================================================== //


        }
    }
}



