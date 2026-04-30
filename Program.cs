// =================================================================================== SECTION 1: ( PRODUCT CLASS ) =================================================================================== //
using System;
using System.Xml;

class Product
{
    public int Id;
    public string Name;
    public double Price;
    public int RemainingStock;
    public string Category;    
    public void DisplayProduct()
    {
        Console.WriteLine(
            $"{Id,-3} | {Name,-65} | {Category,-20} | {Price,12:N0} | {RemainingStock,5}"
        );
        Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
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
        ///////////////////// Cart limit is based on TOTAL quantity of items ( Maximum of 10 Items Total ) /////////////////////
        /////////////////////    Example: 5 RAM + 5 PROCESSORS = FULL CART ( Makes it 10 Items Total )     /////////////////////

        string choice = "y";                //<............// [ A ] PROGRAM START
        Product[] cart = new Product[10];                  // The program begins here. All variables are prepared such as the cart,   
        int[] cartQty = new int[10];                       // total items, and the store products. This is the setup stage before any user interaction happens.
        int cartCount = 0;                   
        int totalItems = 0;
        int receiptCounter = 1;
        string[] orderHistory = new string[10];
        int orderCount = 0;

        Product[] store = new Product[13];          

        store[0] = new Product { Id = 1, Name = "[MONITOR] 27-inch Gaming Monitor (144Hz IPS Display)", Category = "Monitor / Display", Price = 12000, RemainingStock = 15 }; 

        store[1] = new Product { Id = 2, Name = "[PHONE] ASUS ROG Phone 8 (Gaming Smartphone)", Category = "Smartphone", Price = 45000, RemainingStock = 10 };

        store[2] = new Product { Id = 3, Name = "[PC CASE] ATX Gaming PC Case (Tempered Glass)", Category = "PC Case / Chassis", Price = 2800, RemainingStock = 18 };

        store[3] = new Product { Id = 4, Name = "[MOTHERBOARD] MSI B550M Motherboard", Category = "Motherboard", Price = 6500, RemainingStock = 15 };

        store[4] = new Product { Id = 5, Name = "[GPU] NVIDIA RTX 3060 12GB", Category = "GPU / Graphics Card", Price = 18000, RemainingStock = 8 };

        store[5] = new Product { Id = 6, Name = "[RAM] 16GB DDR4 RAM (8x2)", Category = "Memory (RAM)", Price = 3200, RemainingStock = 25 };

        store[6] = new Product { Id = 7, Name = "[PROCESSOR] AMD Ryzen 5 5600X", Category = "Processor (CPU)", Price = 9500, RemainingStock = 12 };

        store[7] = new Product { Id = 8, Name = "[STORAGE] 1TB NVMe SSD", Category = "Storage (SSD)", Price = 3500, RemainingStock = 20 };

        store[8] = new Product { Id = 9, Name = "[POWER SUPPLY] 650W 80+ Bronze PSU", Category = "Power Supply", Price = 2800, RemainingStock = 18 };

        store[9] = new Product { Id = 10, Name = "[MOUSE] RGB Gaming Mouse", Category = "Peripherals (Mouse)", Price = 1200, RemainingStock = 30 };

        store[10] = new Product { Id = 11, Name = "[KEYBOARD] Mechanical Gaming Keyboard", Category = "Peripherals (Keyboard)", Price = 1200, RemainingStock = 30 };

        store[11] = new Product { Id = 12, Name = "[HEADSET] 7.1 Gaming Headset", Category = "Audio / Headset", Price = 1000, RemainingStock = 18 };

        store[12] = new Product { Id = 13, Name = "[CONSOLE] Steam Machine", Category = "Gaming Console", Price = 45000, RemainingStock = 3 };

        while (choice == "y" || choice == "Y")  //<.............................. // [ B ] MAIN LOOP
        {                                                                         // This loop keeps the store running. As long as the user enters "y",
            Console.WriteLine("");                                                // the program will continue showing the menu and allowing purchases.
            Console.WriteLine("=========================================[ PC PARTS & ACCESSORIES STORE MENU ]=======================================");
            Console.WriteLine("");
            Console.WriteLine("ID  | Name                                                              | Category             | Price        | Stock");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");                
            for (int i = 0; i < store.Length; i++)
            {
                store[i].DisplayProduct();
            }

            // =================================================================================== SECTION 3: ( USER INPUT ) =================================================================================== //

            Console.WriteLine("");
            Console.WriteLine("==================================================[ CART MENU ]======================================================"); 
            Console.WriteLine("");
            Console.WriteLine("1. ADD ITEM");                                                             
            Console.WriteLine("2. VIEW CART");
            Console.WriteLine("3. REMOVE ITEM");
            Console.WriteLine("4. UPDATE QUANTITY");
            Console.WriteLine("5. CLEAR CART");
            Console.WriteLine("6. CHECKOUT");
            Console.WriteLine("7. SEARCH PRODUCT");      
            Console.WriteLine("8. VIEW ORDER HISTORY");  
            Console.WriteLine("");
            Console.WriteLine("=====================================================================================================================");
            Console.WriteLine("");
            Console.WriteLine("ENTER CHOICE: ");

            string menuChoice = Console.ReadLine();

            if (menuChoice == "1")     // =========================================================[ CHOICE 1 SECTION ] [ ADD ITEM ]======================================================= //                                
            {
                int productId = 0;
                bool isValidId = false;

                while (!isValidId || productId <= 0) //<..................// [ C ] ENTER PRODUCT ID
                {                                                         // The program asks the user to input a product ID.
                    Console.WriteLine("");                                // This starts the process of selecting an item from the store.
                    Console.WriteLine("Enter Product ID: ");
                    Console.WriteLine("");

                    string inputId = Console.ReadLine();

                    isValidId = int.TryParse(inputId, out productId);  //<........................................................................... // [ D ] VALID INPUT?
                                                                       // The system checks if the entered product ID is a valid number.
                    if (!isValidId || productId <= 0)  //<......................... //[ D ERROR ]                                                     // This prevents errors from non-numeric input.
                    {                                                               // If the input is not valid or less than or equal to zero,
                        Console.WriteLine("");                                      // the program informs the user and asks again until a correct input is given.
                        Console.WriteLine("Invalid Product ID Try Again");
                        Console.WriteLine("");

                    }
                }


                int quantity = 0;
                bool isValidQty = false;

                while (!isValidQty || quantity <= 0) //<........................// [ F ] ENTER QUANTITY
                {                                                               // After selecting a product, the user is asked how many items they want to buy.
                    Console.WriteLine("");
                    Console.WriteLine("Enter Quantity: ");
                    Console.WriteLine("");

                    string inputQty = Console.ReadLine();

                    isValidQty = int.TryParse(inputQty, out quantity);  //<.....................................// [ G ] VALID QUANTITY?
                                                                        // The program checks if the quantity entered is a valid number.
                    if (!isValidQty || quantity <= 0)   //<........................// [ G ERROR ]
                    {                                                              // If the quantity is invalid or zero or negative,
                        Console.WriteLine("");                                     // the program asks the user to input again.
                        Console.WriteLine("Invalid Quantity Try Again");
                        Console.WriteLine("");
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
                        Console.WriteLine("");                                                         // If the product is out of stock, the user is informed.
                    }                                                                                  // and cannot proceed with this item.
                    else                     
                    {
                        Console.WriteLine("");
                        Console.WriteLine($"Product Found: {selectedProduct.Name}");  //<............................// [ L ] PRODUCT FOUND
                        Console.WriteLine("");                                                                       // If everything is valid, the program confirms the product selection.
                    }                                                                                                // and displays its name to the user.
                }       


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
                        Console.WriteLine("");
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
                        continue;
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
            }

            

            else if (menuChoice == "2") // =========================================================[ CHOICE 2 SECTION ] [ VIEW CART ]======================================================= //
            {

                Console.WriteLine("");
                Console.WriteLine("================== VIEW CART ==================");      
                if (cartCount == 0)
                {
                    Console.WriteLine("Cart is Empty.");
                }
                else
                {
                    for (int i = 0; i < cartCount; i++)
                    {
                        double itemTotal = cart[i].GetItemtotal(cartQty[i]);

                        Console.WriteLine($"Product: {cart[i].Name}");
                        Console.WriteLine($"Category: {cart[i].Category}");       
                        Console.WriteLine($"Quantity: {cartQty[i]}");
                        Console.WriteLine($"Price: {cart[i].Price}");
                        Console.WriteLine($"Total: {itemTotal}");
                        Console.WriteLine("-------------------------------------------");
                    }
                }


            }

            else if (menuChoice == "3") // =========================================================[ CHOICE 3 SECTION ] [ REMOVE ITEM ]======================================================= //
            {
                Console.WriteLine("");
                Console.WriteLine("================== REMOVE ITEM ==================");

                if (cartCount == 0)                                            
                {
                    Console.WriteLine("Cart is Empty, There Isn't anything to remove.");
                }
                else
                {
                    for (int i = 0; i < cartCount; i++)
                    {
                        Console.WriteLine($"{i + 1}. {cart[i].Name} (Qty: {cartQty[i]})");
                    }

                    Console.WriteLine("");
                    Console.WriteLine("Enter item number to remove: ");

                    int removeIndex;
                    bool isValidRemove = int.TryParse(Console.ReadLine(), out removeIndex);

                    if (!isValidRemove || removeIndex <= 0 || removeIndex > cartCount)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Invalid Choice");
                        Console.WriteLine("");
                    }
                    else
                    {
                        removeIndex--;

                        cart[removeIndex].RemainingStock += cartQty[removeIndex];      //<......................... Item Goes back to the Stock.
                        
                        totalItems -= cartQty[removeIndex];                            //<......................... TotalItems Updates after Removal.

                        for (int i = removeIndex; i < cartCount - 1; i++)              //<......................... Item Removal Mechanism. 
                        {
                            cart[i] = cart[i + 1];
                            cartQty[i] = cartQty[i + 1];
                        }

                        cartCount--;
                        Console.WriteLine("");
                        Console.WriteLine("Item Removed");
                        Console.WriteLine("");
                    }

                }

                


            }
            // =========================================================[ CHOICE 4 SECTION ] [ UPDATE QUANTITY ] ( ! MAJOR UPDATED ! ) [ HARDEST PART ] ======================================================= //
            else if (menuChoice == "4")
            {
                Console.WriteLine("");
                Console.WriteLine("================== UPDATE QUANTITY =================="); 

                if (cartCount == 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Cart is Empty");
                    Console.WriteLine("");
                    continue;
                }

                for (int i = 0; i < cartCount; i++)
                {
                    Console.WriteLine($"{i + 1}. {cart[i].Name} (Qty: {cartQty[i]})");  //<...... (prints each product in the cart with its number and current quantity so the user can choose what to update.)
                }

                Console.WriteLine("");
                Console.WriteLine("Enter item number to Update: ");
                string input = Console.ReadLine();

                int index;
                bool isValid = int.TryParse(input, out index);          //<....................... (converts the user input into a number safely and checks if it is valid.)

                if (!isValid || index <= 0 || index > cartCount)        //<....................... (checks if the selected item number is invalid or outside the cart range.)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Invalid Choice");
                    Console.WriteLine("");
                    continue;
                }

                index--;                                                //<....................... (adjusts the user input from 1-based numbering to 0-based array indexing.)
                Console.WriteLine("");
                Console.WriteLine($"you selected: {cart[index].Name}");
                Console.WriteLine("");
                Console.WriteLine("Enter new quantity: ");
                string qtyInput = Console.ReadLine();

                int newQty;
                bool isValidQty = int.TryParse(qtyInput, out newQty);   //<....................... (converts the new quantity input into a number and checks if it is valid.)

                if (!isValidQty || newQty <= 0)                         //<....................... (checks if the new quantity is invalid or less than or equal to zero.)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Invalid Quantity");
                    Console.WriteLine("");
                    continue;
                }

                int oldQty = cartQty[index];                            //<....................... (gets the current quantity of the selected item in the cart.)
                int difference = newQty - oldQty;                       //<....................... (calculates how much the quantity has increased or decreased.)


                if (difference == 0)                                    //<....................... (checks if the user did not change the quantity at all.)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Quantity remains unchanged...");
                    Console.WriteLine("");
                    continue;
                }

                
                if (difference > 0 && totalItems + difference > 10)     //<....................... (checks if increasing quantity will exceed cart limit of 10 items and prevents the update if it does.)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Cannot Update Quantity.");
                    Console.WriteLine("Cart Limit of 10 Items will be Exceeded.");
                    Console.WriteLine("");
                    continue;
                }

                
                if (difference > 0)                                      //<....................... (handles case when quantity is increased.)
                {
                    if (!cart[index].HasEnoughStock(difference))         //<....................... (if the store has enough stock to increase the quantity.)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Not Enough Stock to Increase Quantity");
                        Console.WriteLine("");
                        continue;
                    }

                    cart[index].DeductStock(difference);                 //<....................... (removes the added quantity from the product stock.)
                }
                else
                {
                    cart[index].RemainingStock += Math.Abs(difference);  //<....................... (returns the removed quantity back to the product stock.)
                }

                
                cartQty[index] = newQty;                                 //<....................... (updates the quantity of the selected item in the cart.)
                totalItems += difference;                                //<....................... (updates total cart item count by adding the difference from the quantity change.)

                Console.WriteLine("");
                Console.WriteLine("Quantity Updated Successfully...");
                Console.WriteLine("");
            }

            else if (menuChoice == "5") // =========================================================[ CHOICE 5 SECTION ] [ CLEAR CART ]======================================================= //
            {
                Console.WriteLine("");
                {
                    Console.WriteLine("");
                    Console.WriteLine("================== CLEAR CART ==================");

                    if (cartCount == 0)                                                                                          
                    {
                        Console.WriteLine("Cart is already empty...");
                    }
                    else
                    {
                        for (int i = 0; i < cartCount; i++)               
                        {
                            cart[i].RemainingStock += cartQty[i];                       //<......................... All Items returned to Stock all at ONCE.
                        }

                        cartCount = 0;
                        totalItems = 0;                                                 //<......................... all Items Removal.
                        Console.WriteLine("");
                        Console.WriteLine("Cart Cleared...");
                        Console.WriteLine("");
                    }
                }
            }

            else if (menuChoice == "6")  // ========================================================[ CHOICE 6 SECTION ] [ CHECKOUT ] ======================================================= //
            {

                


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
                Console.WriteLine($"Receipt No: {receiptCounter:D4}");    
                Console.WriteLine($"Date: {DateTime.Now}");
                Console.WriteLine("");
                Console.WriteLine($"Total Items In CART: {totalItems}");  //<...................................................// [ O and P1 ] TOTAL ITEMS
                if (totalItems == 10)                                                                                           // Shows the total number of items currently inside the cart.
                {                                                                                                               // Displays the total items count clearly to the user.
                    Console.WriteLine("Cart Capacity has Reached its Limit");   //<..................// [ P2 ]
                }                                                                                    // If the cart has reached 10 items, the program informs the user
                Console.WriteLine("");                                                               // that the maximum capacity has been reached.

                for (int i = 0; i < cartCount; ++i)                     //<..........// [ Q ] ITEM DETAILS DISPLAY
                {                                                                    // Each product in the cart is listed along with quantity,
                    double itemTotal = cart[i].GetItemtotal(cartQty[i]);             // individual price, and total cost for that item.

                    Console.WriteLine($"Product: {cart[i].Name}, Category: {cart[i].Category}, Qty: {cartQty[i]}, Price: {cart[i].Price}, Total: {itemTotal}");
                    Console.WriteLine("");
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
                    Console.WriteLine("");
                }

                // =================================================================================== SECTION 9: ( DISCOUNT SYSTEM )=================================================================================== //
                double discount = 0;
                double finalAmount = finalTotal;

                if (finalTotal >= 5000)  //<.................................// [ R2 ] DISCOUNT SYSTEM
                {                                                            // If the total is 5000 or more, a 10 percent discount is applied.
                    discount = finalTotal * 0.10;                            // The final amount after discount is then displayed.
                    finalAmount = finalTotal - discount;
                    Console.WriteLine("");
                    Console.WriteLine("Discount Applied: 10%");
                    Console.WriteLine($"Final Amount to Pay With Discount: {finalAmount}");
                    Console.WriteLine("");


                }

                // =================================================================================== SECTION 9.1 ( PAYMENT SYSTEM ) =================================================================================== //
                double payment = 0;
                bool isValidPayment = false;                            

                while (!isValidPayment || payment < finalAmount)
                {
                    Console.WriteLine("");
                    Console.WriteLine($"Final Total: {finalAmount}");
                    Console.WriteLine("Enter Payment: ");

                    string paymentInput = Console.ReadLine();

                    isValidPayment = double.TryParse(paymentInput, out payment);

                    if (!isValidPayment)
                    {
                        Console.WriteLine("Invalid Input. Please Enter a VALID Amount.");
                        Console.WriteLine("");
                        continue;
                    }

                    if (payment < finalAmount)
                    {
                        Console.WriteLine("Insufficient Payment. Please enter enough Amount.");
                        Console.WriteLine("");
                    }
                }

                double change = payment - finalAmount;

                Console.WriteLine($"Payment: {payment}");
                Console.WriteLine($"Change: {change}");

                // =================================================================================== SECTION 9.2 ( LOW STOCK NOTIFIER ) =================================================================================== //
                Console.WriteLine("");
                Console.WriteLine("LOW STOCK ALERT:");
                Console.WriteLine("");

                bool hasLowStock = false;
                for (int i = 0; i < store.Length; i++)
                {
                    if (store[i].RemainingStock <= 5)
                    {
                        Console.WriteLine($"{store[i].Name} has only {store[i].RemainingStock} stocks left.");
                        hasLowStock = true;
                    }
                }

                if (!hasLowStock)
                {
                    Console.WriteLine("All products have sufficient stock.");
                }
                // =================================================================================== SECTION 10 ( LOOP )  =================================================================================== //
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


                // =================================================================================== SECTION 10.1 ( ORDER HISTORY RECEIPT ) [ NEW ] =================================================================================== //
                string itemsList = "";

                for (int i = 0; i < cartCount; i++)   //////////////////////// [ RECENTLY UPDATED ] Added more Information and made it clear to read Order History of User per purchase //////////////////////////
                {
                    itemsList += $"{cart[i].Name} (x{cartQty[i]})\n";
                }

                receiptCounter++;
                orderHistory[orderCount] =
                     $"Receipt #{receiptCounter - 1:D4}\n" +
                     $"Date: {DateTime.Now}\n\n" +
                     $"Items:\n{itemsList}\n" +
                     $"Total: {finalAmount}\n" +
                     $"---------------------------";
                orderCount++;
                
            }

            else if (menuChoice == "7")  // ========================================================[ CHOICE 7 SECTION ] [ SEARCH PRODUCT ]======================================================= //
            {
                Console.WriteLine("");
                Console.WriteLine("================== SEARCH PRODUCT ==================");

                Console.WriteLine("Enter product name to search: ");
                string search = Console.ReadLine().ToLower();

                bool found = false;

                for (int i = 0; i < store.Length; i++)
                {
                    if (store[i].Name.ToLower().Contains(search))  
                    {
                        Console.WriteLine($"{store[i].Id}. {store[i].Name} | {store[i].Category} - PHP {store[i].Price} - Stock: {store[i].RemainingStock}");
                        found = true;
                    }
                }

                if (!found)
                {
                    Console.WriteLine("No matching product found.");
                    Console.WriteLine("");
                }
            }

            else if (menuChoice == "8") // ========================================================[ CHOICE 8 SECTION ] [ ORDER HISTORY ]======================================================= //
            {
                Console.WriteLine("");
                Console.WriteLine("================== ORDER HISTORY ==================");          

                if (orderCount == 0)
                {
                    Console.WriteLine("No completed transactions yet.");
                    Console.WriteLine("");
                }
                else
                {
                    for (int i = 0; i < orderCount; i++)
                    {
                        Console.WriteLine(orderHistory[i]);  //<.......................... Order History Display from "SECTION 10.1 ( ORDER HISTORY RECEIPT )"
                    }
                }
            }

            else
            {
                Console.WriteLine("Invalid menu Choice. try again.");
                Console.WriteLine("");
            }


            // =================================================================================== DEAD END =================================================================================== //


        }
    }
}



