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
        Console.WriteLine($"{Id,-3} | {Name,-55}| {Price,10}, | {RemainingStock,5}");
        Console.WriteLine("-----------------------------------------------------------------------------------");
    }

    public double GetItemtotal(int quantity)
    {
        return Price * quantity;        //<..........// Price gets Multiplied Per Quantity
    }

    public bool HasEnoughStock(int quantity)
    {
        if (RemainingStock >= quantity)
        {
            return true;         //<..........// enough stock available
        }
        else
        {
            return false;        //<..........// not enough stock available
        }
    }


    public void DeductStock(int quantity)
    {
        RemainingStock -= quantity; //<......// Stock Reduces after Purchase. 
    }

}
// =================================================================================== SECTION 2: ( STORE MENU ) =================================================================================== //
class Program
{

    static void Main(string[] args)
    {
        string choice = "y";                //<............// [ A ] PROGRAM START
        Product[] cart = new Product[10];                  // The program begins here. All variables are prepared such as the cart,   
        int[] cartQty = new int[10];                       // total items, and the store products. This is the setup stage before any user interaction happens.
        int cartCount = 0;                   
        int totalItems = 0; 

        Product[] store = new Product[13];

        store[0] = new Product { Id = 1, Name = "[MONITOR] 27-inch Gaming Monitor (144Hz IPS Display)", Price = 12000, RemainingStock = 15 }; 
        store[1] = new Product { Id = 2, Name = "[PHONE] ASUS ROG Phone 8 (Gaming Smartphone)", Price = 45000, RemainingStock = 10 };
        store[2] = new Product { Id = 3, Name = "[PC CASE] ATX Gaming PC Case (Tempered Glass)", Price = 2800, RemainingStock = 18 };
        store[3] = new Product { Id = 4, Name = "[MOTHERBOARD] MSI B550M Motherboard", Price = 6500, RemainingStock = 15 };
        store[4] = new Product { Id = 5, Name = "[GPU] NVIDIA RTX 3060 12GB", Price = 18000, RemainingStock = 8 };
        store[5] = new Product { Id = 6, Name = "[RAM] 16GB DDR4 RAM (8x2)", Price = 3200, RemainingStock = 25 };
        store[6] = new Product { Id = 7, Name = "[PROCESSOR] AMD Ryzen 5 5600X", Price = 9500, RemainingStock = 12 };
        store[7] = new Product { Id = 8, Name = "[STORAGE] 1TB NVMe SSD", Price = 3500, RemainingStock = 20 };
        store[8] = new Product { Id = 9, Name = "[POWER SUPPLY] 650W 80+ Bronze PSU", Price = 2800, RemainingStock = 18 };
        store[9] = new Product { Id = 10, Name = "[MOUSE] RGB Gaming Mouse", Price = 1200, RemainingStock = 30 };
        store[10] = new Product { Id = 11, Name = "[KEYBOARD] Mechanical Gaming Keyboard", Price = 1200, RemainingStock = 30 };
        store[11] = new Product { Id = 12, Name = "[HEADSET] 7.1 Gaming Headset", Price = 1000, RemainingStock = 18 };
        store[12] = new Product { Id = 13, Name = "[CONSOLE] Steam Machine", Price = 45000, RemainingStock = 3 };

        while (choice == "y" || choice == "Y")  //<.............................. // [ B ] MAIN LOOP
        {                                                                         // This loop keeps the store running. As long as the user enters "y",
            Console.WriteLine("");                                                // the program will continue showing the menu and allowing purchases.
            Console.WriteLine("=======================[ PC PARTS & ACCESSORIES STORE MENU ]=======================");
            Console.WriteLine("");
            Console.WriteLine("ID  | Name                                                   |     Price | Stock");                 
            Console.WriteLine("-----------------------------------------------------------------------------------");                
            for (int i = 0; i < store.Length; i++)
            {
                store[i].DisplayProduct();
            }

            // =================================================================================== SECTION 3: ( USER INPUT ) =================================================================================== //

            int productId = 0;
            bool isValidId = false;

            while (!isValidId || productId <= 0) //<..................// [ C ] ENTER PRODUCT ID
            {                                                         // The program asks the user to input a product ID.
                Console.WriteLine("");                                // This starts the process of selecting an item from the store.
                Console.WriteLine("Enter Product ID: ");

                string inputId = Console.ReadLine();

                isValidId = int.TryParse(inputId, out productId);  //<........................................................................... // [ D ] VALID INPUT?
                                                                                                                                                  // The system checks if the entered product ID is a valid number.
                if (!isValidId || productId <= 0)  //<......................... //[ D ERROR ]                                                     // This prevents errors from non-numeric input.
                {                                                               // If the input is not valid or less than or equal to zero,
                    Console.WriteLine("");                                      // the program informs the user and asks again until a correct input is given.
                    Console.WriteLine("Invalid Product ID Try Again");
                    

                }
            }


            int quantity = 0;
            bool isValidQty = false;

            while (!isValidQty || quantity <= 0) //<........................// [ F ] ENTER QUANTITY
            {                                                               // After selecting a product, the user is asked how many items they want to buy.
                Console.WriteLine("");
                Console.WriteLine("Enter Quantity: ");

                string inputQty = Console.ReadLine();

                isValidQty = int.TryParse(inputQty, out quantity);  //<.....................................// [ G ] VALID QUANTITY?
                                                                                                            // The program checks if the quantity entered is a valid number.
                if (!isValidQty || quantity <= 0)   //<........................// [ G ERROR ]
                {                                                              // If the quantity is invalid or zero or negative,
                    Console.WriteLine("");                                     // the program asks the user to input again.
                    Console.WriteLine("Invalid Quantity Try Again");  

                }
            }

            // =================================================================================== SECTION 4: ( PRODUCT SELECTION ) =================================================================================== //
            Product selectedProduct = null;

            for (int i = 0; i < store.Length; ++i)
            {
                if (store[i].Id == productId)     //<.......................// [ E ] DOES PRODUCT EXIST?
                {                                                           // The program searches the store list to find if the entered ID matches a product.
                    selectedProduct = store[i];
                    break;
                }

            }
            if (selectedProduct != null && totalItems + quantity <= 10) 
            {
                if (selectedProduct.RemainingStock == 0)         //<........................................................// [ I ] OUT OF STOCK?
                {                                                                                                           // The program checks if the selected product has zero stock remaining.
                    Console.WriteLine("");
                    Console.WriteLine("Sorry, This product is Out of Stock");   //<................// [ I ERROR ]
                }                                                                                  // If the product is out of stock, the user is informed
                else                                                                               // and cannot proceed with this item.
                {
                    Console.WriteLine("");
                    Console.WriteLine($"Product Found: {selectedProduct.Name}");  //<............................// [ L ] PRODUCT FOUND
                }                                                                                                // If everything is valid, the program confirms the product selection
            }                                                                                                    // and displays its name to the user.


            // =================================================================================== SECTION 5: ( STOCK CHECK and PROCESSING ) =================================================================================== //
            bool isTransactionValid = false;
            if (selectedProduct == null)      //<.....................// [ E ERROR ]
            {                                                         // If no matching product is found, the program displays an error
                Console.WriteLine("");                                // and restarts the process from the beginning.
                Console.WriteLine("Product not Found.");         
                Console.WriteLine("");
                continue;                                          
            }

            else if (!selectedProduct.HasEnoughStock(quantity))     //<........................................................// [ H ] ENOUGH STOCK?
            {                                                                                                                  // The program checks if the store has enough stock for the requested quantity.
                Console.WriteLine("");
                Console.WriteLine("Not enough stock Available");     //<.......................// [ H ERROR ]
                Console.WriteLine("");                                                         // If the stock is not enough, the program informs the user
                continue;                                                                      // and restarts the process.                          
            }

            else
            {
                double total = selectedProduct.GetItemtotal(quantity);
                

                isTransactionValid = true;

                if (totalItems + quantity <= 10)        //<.....................................................// [ J ] CART LIMIT CHECK
                {                                                                                               // The program checks if adding this quantity will exceed the cart limit of 10 items.
                    Console.WriteLine($"Added to cart! total Price of Specific Product Selected: {total}");
                    Console.WriteLine("");
                }

            }

            // =================================================================================== SECTION 6: ( CART DECLARATION and ADD TO CART [ HARDEST PART ] ) =================================================================================== //

            int availableSpace = 10 - totalItems;      //<........................// computes how many items can still fit in the cart (max is 10).
            int finalQuantity = quantity;         
            if (isTransactionValid && selectedProduct != null)   //<........................// continues only if product is valid and transaction passed all checks.
            {
                if (quantity > availableSpace)        
                {
                    finalQuantity = availableSpace;
                    Console.WriteLine("");
                    Console.WriteLine($"Only {availableSpace} items added due to CART MAX CAPACITY");    //<...............................// [ J1 and K1 ]
                    Console.WriteLine("");                                                                                                 // If the requested quantity is too large, only the allowed amount
                }                                                                                                                          // based on remaining cart space will be added.
                if (availableSpace <= 0)       //<.................................// [ K ] IS CART FULL?
                {                                                                  // The program checks if the cart has already reached its maximum capacity.
                    Console.WriteLine("");
                    Console.WriteLine("Cart is Full, Cannot ADD more items");     //<.............// [ K2 END ]
                    Console.WriteLine("");                                                        // If the cart is full, the program stops adding items and ends execution of the program.
                    return;
                }
                else
                {
                    selectedProduct.DeductStock(finalQuantity); 

                    int existingIndex = -1;    //<.................................// used to check if product already exists in cart.

                    for (int i = 0; i < cartCount; i++)
                    {
                        if (cart[i].Id == selectedProduct.Id)    //<....................// found same product already in cart
                        {
                            existingIndex = i;
                            break;
                        }
                    }
                    if (existingIndex != -1)
                    {
                        cartQty[existingIndex] += finalQuantity;  //<........................// update quantity if product already exists 
                    }
                    else
                    {
                        cart[cartCount] = selectedProduct;
                        cartQty[cartCount] = finalQuantity;
                        cartCount++;
                    }
                    totalItems += finalQuantity;   //<................// update total number of items in cart

                    Console.WriteLine("Product Added to Cart");  //<...............// [ M ] ADD TO CART
                    Console.WriteLine("");                                         // The selected product is added to the cart.
                }                                                                  // Stock is reduced, and cart values are updated accordingly.
            }

            // =================================================================================== SECTION 7: ( RECEIPT DISPLAY and STOCK UPDATE ) =================================================================================== //
            Console.WriteLine("");
            Console.WriteLine("==============================[ UPDATED STOCK AFTER CHECKOUT ]=============================");      //<................ // [ N ] UPDATED STOCK DISPLAY
                                                                                                                                                       // After adding the product, the program shows the updated stock of all items,   
            for (int i = 0; i < store.Length; i++)                                                                                                     // so the user can see the remaining availability.
            {
                Console.WriteLine($"{store[i].Name,-55} Remaining Stocks Available: {store[i].RemainingStock,3}");
                Console.WriteLine("------------------------------------------------------------------------------------------");
                 
            }
            Console.WriteLine("");

            Console.WriteLine("");
            Console.WriteLine("=====================================[ RECEIPT ]===================================");  //<....................................// [ Q ] RECEIPT DISPLAY
            Console.WriteLine("");                                                                                                                            // The program begins displaying the receipt for the user's purchases.
            Console.WriteLine($"Total Items In CART: {totalItems}");  //<...................................................// [ O and P1 ] TOTAL ITEMS
            if (totalItems == 10)                                                                                           // Shows the total number of items currently inside the cart.
            {                                                                                                               // Displays the total items count clearly to the user.
                Console.WriteLine("Cart Capacity has Reached its Limit");   //<..................// [ P2 ]
            }                                                                                    // If the cart has reached 10 items, the program informs the user
            Console.WriteLine("");                                                               // that the maximum capacity has been reached.

            for (int i = 0; i < cartCount; ++i)                     //<..........// [ Q ] ITEM DETAILS DISPLAY
            {                                                                    // Each product in the cart is listed along with quantity,
                double itemTotal = cart[i].GetItemtotal(cartQty[i]);             // individual price, and total cost for that item.

                Console.WriteLine($"Product: {cart[i].Name}, Qty: {cartQty[i]}, Price: {cart[i].Price}, Total: {itemTotal}");

            }

            // =================================================================================== SECTION 8: ( TOTAL COMPUTATION ) =================================================================================== //
            double finalTotal = 0;

            for (int i = 0; i < cartCount; i++)
            {
                double itemTotal = cart[i].GetItemtotal(cartQty[i]);
                finalTotal += itemTotal;
            }
            if (finalTotal < 5000)      //<......................................// [ R ] TOTAL COMPUTATION
            {                                                                    // The program calculates the total cost of all items in the cart.
                Console.WriteLine($"Total Amount to Pay: {finalTotal}");   //<.....................................// [ R1 ] NORMAL PURCHASE
            }                                                                                                      // If the total is less than 5000, the program simply shows the total amount.
            if (finalTotal >= 5000)
            {
                Console.WriteLine($"Origial Total Amount to Pay: {finalTotal}");                 
            }

            // =================================================================================== SECTION 9: ( DISCOUNT SYSTEM ) =================================================================================== //
            double discount = 0;
            double finalAmount = finalTotal;

            if (finalTotal >= 5000)  //<.................................// [ R2 ] DISCOUNT SYSTEM
            {                                                            // If the total is 5000 or more, a 10 percent discount is applied.
                discount = finalTotal * 0.10;                            // The final amount after discount is then displayed.
                finalAmount = finalTotal - discount;
                Console.WriteLine("");
                Console.WriteLine("Discount Applied: 10%");
                Console.WriteLine($"Final Amount to Pay With Discount: {finalAmount}");
            }

            // =================================================================================== SECTION 10: ( LOOP ) =================================================================================== //
            Console.WriteLine("");
            Console.WriteLine("Do you want to buy again? (y/n): ");   //<............................// [ S ] BUY AGAIN?
            Console.WriteLine("");                                                                   // The program asks the user if they want to continue shopping.
            choice = Console.ReadLine();

            while (choice != "y" && choice != "Y" && choice != "n" && choice != "N")    //<.............// [ T and T2 ]
            {                                                                                           // The program ensures the user only enters valid choices (y or n).
                Console.WriteLine("");                                                                  // This continues validation to make sure the loop decision is correct.
                Console.WriteLine("Invalid Choice. Enter only (Y/y) or (N/n): ");   //<.....// [ T1 ]
                Console.WriteLine("");                                                      // If the input is invalid, the user is asked again until a correct choice is given.
                choice = Console.ReadLine();
            }
            if (choice == "n" || choice == "N")    //<...................// [ U ] USER SELECTED NO
            {                                                            // If the user chooses not to continue, the loop will end.
                Console.WriteLine("");
                Console.WriteLine("Purchase complete! Time to upgrade your gaming experience");  //<.............// [ V ] PROGRAM END
                Console.WriteLine("");                                                                           // The program finishes and displays a final message confirming the purchase is complete.
            }

            // =================================================================================== DEAD END =================================================================================== //


        }
    }
}



