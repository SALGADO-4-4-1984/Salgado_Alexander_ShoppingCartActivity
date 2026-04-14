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
// =================================================================================== SECTION 2: ( STORE MENU [ ! UPDATED ! ] ) =================================================================================== //
class Program
{

    static void Main(string[] args)
    {
        string choice = "y";
        Product[] cart = new Product[10];      
        int[] cartQty = new int[10];          
        int cartCount = 0;                   
        int totalItems = 0; 

        Product[] store = new Product[12];

        store[0] = new Product { Id = 1, Name = "[MONITOR] 27-inch Gaming Monitor (144Hz IPS Display)", Price = 12000, RemainingStock = 15 };  //<.............. [ RECENTLY ADDED new products ]
        store[1] = new Product { Id = 2, Name = "[PHONE] ASUS ROG Phone 8 (Gaming Smartphone)", Price = 45000, RemainingStock = 10 };
        store[2] = new Product { Id = 3, Name = "[PC CASE] ATX Gaming PC Case (Tempered Glass)", Price = 2800, RemainingStock = 18 };
        store[3] = new Product { Id = 4, Name = "[MOTHERBOARD] MSI B550M Motherboard", Price = 6500, RemainingStock = 15 };
        store[4] = new Product { Id = 5, Name = "[GPU] NVIDIA RTX 3060 12GB", Price = 18000, RemainingStock = 8 };
        store[5] = new Product { Id = 6, Name = "[RAM] 16GB DDR4 RAM (8x2)", Price = 3200, RemainingStock = 25 };
        store[6] = new Product { Id = 7, Name = "[CPU] AMD Ryzen 5 5600X", Price = 9500, RemainingStock = 12 };
        store[7] = new Product { Id = 8, Name = "[STORAGE] 1TB NVMe SSD", Price = 3500, RemainingStock = 20 };
        store[8] = new Product { Id = 9, Name = "[POWER SUPPLY] 650W 80+ Bronze PSU", Price = 2800, RemainingStock = 18 };
        store[9] = new Product { Id = 10, Name = "[MOUSE] RGB Gaming Mouse", Price = 1200, RemainingStock = 30 };
        store[10] = new Product { Id = 11, Name = "[KEYBOARD] Mechanical Gaming Keyboard", Price = 1200, RemainingStock = 30 };
        store[11] = new Product { Id = 12, Name = "[HEADSET] 7.1 Gaming Headset", Price = 1000, RemainingStock = 18 };

        while (choice == "y" || choice == "Y")    //<.............. [ Moved store menu display inside the loop to refresh menu every time user buys again ]
        {
            Console.WriteLine("");
            Console.WriteLine("=======================[ PC PARTS & ACCESSORIES STORE MENU ]=======================");        //<.............. [ Changed the STORE MENU title ]
            Console.WriteLine("");
            for (int i = 0; i < store.Length; i++)
            {
                store[i].DisplayProduct();
            }

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
            if (selectedProduct != null && totalItems + quantity <= 10)   //<............................. [ UPDATED as OUTPUT Statement will not be shown when CART has reached greater than MAXIMUM of 10 items ]
            {
                if (selectedProduct.RemainingStock == 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Sorry, This product is Out of Stock");    //<.................. [ RECENTLY ADDED for OUTPUT STATEMENT if specific selectedProduct is out of stock ]
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine($"Product Found: {selectedProduct.Name}");   //<...................... [ Changed the Spelling Fouund to Found ]
                }
            }


            // =================================================================================== SECTION 5: ( STOCK CHECK and PROCESSING [ ! UPDATED ! ] ) =================================================================================== //
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

                if (totalItems + quantity <= 10)      //<............................. [ UPDATED as OUTPUT Statement will not be shown when CART has reached greater than MAXIMUM of 10 items ]
                {
                    Console.WriteLine($"Added to cart! total Price of Specific Product Selected: {total}");
                    Console.WriteLine("");
                }

            }

            // =================================================================================== SECTION 6: ( CART DECLARATION and ADD TO CART [ ! UPDATED ! ] ) =================================================================================== //

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
                    int existingIndex = -1;         //<...................... [ Changed the Spelling of variable Exisiting to Existing ]

                    for (int i = 0; i < cartCount; i++)
                    {
                        if (cart[i].Id == selectedProduct.Id)
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
                    totalItems += quantity;

                    Console.WriteLine("Product Added to Cart");
                    Console.WriteLine("");
                }
            }

            // =================================================================================== SECTION 7: ( RECEIPT DISPLAY  ) =================================================================================== //
            Console.WriteLine("");
            Console.WriteLine("=======================[ RECEIPT ]=======================");
            Console.WriteLine("");
            Console.WriteLine($"Total Items In CART: {totalItems}");
            if (totalItems == 10)
            {
                Console.WriteLine("Cart Capacity has Reached its Limit");
            }
            Console.WriteLine("");

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
            if (finalTotal < 5000)
            {
                Console.WriteLine($"Total Amount to Pay: {finalTotal}");
            }
            if (finalTotal >= 5000)
            {
                Console.WriteLine($"Origial Total Amount to Pay: {finalTotal}");
            }

            // =================================================================================== SECTION 9: ( DISCOUNT SYSTEM ) =================================================================================== //
            double discount = 0;
            double finalAmount = finalTotal;

            if (finalTotal >= 5000)
            {
                discount = finalTotal * 0.10;
                finalAmount = finalTotal - discount;
                Console.WriteLine("");
                Console.WriteLine("Discount Applied: 10%");
                Console.WriteLine($"Final Amount to Pay With Discount: {finalAmount}");
            }




            // =================================================================================== SECTION 10: ( LOOP [ ! UPDATED ! ] ) =================================================================================== //
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
                Console.WriteLine("Purchase complete! Time to upgrade your gaming experience");       //<.............. [ Changed the STORE MENU closing message ]
                Console.WriteLine("");
            }
            // =================================================================================== DEAD END=================================================================================== //


        }
    }
}



