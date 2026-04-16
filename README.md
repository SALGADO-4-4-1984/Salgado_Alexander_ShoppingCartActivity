# Salgado_Alexander_ShoppingCartActivity

---

## Shopping Cart System Information:

### Description

This is a simple console shopping system made in C#.
The program allows users to select products, enter quantity, and purchase items.
It checks stock, calculates total price, applies discount, and shows a receipt.

This project also focuses on understanding program flow using step by step logic.

---

### Features

* Product display with price and stock
* Input validation for product ID and quantity
* Stock checking system
* Cart system with limit of 10 items
* Prevents over purchasing
* Merges duplicate items in cart
* Automatic total calculation
* 10 percent discount if total is 5000 or more
* Receipt display with item details
* Stock update after purchase
* Loop system for continuous shopping

---

### Code Structure

Product Class

* Stores product details such as ID, name, price, and stock
* Handles item total calculation
* Checks stock availability
* Updates stock after purchase

Program Class

* Main entry point
* Handles user input and program flow
* Displays store menu
* Processes cart and checkout
* Controls loop for repeated transactions

---

### Program Flow

* Program starts
* Store menu is displayed
* User enters product ID
* System validates input
* User enters quantity
* System checks stock
* Product is added to cart
* Cart and stock are updated
* Receipt is displayed
* Total is calculated
* Discount is applied if qualified
* User chooses to continue or exit

---

### Files

* Program.cs
* OUTPUT_FLOWCHART.png
* README.md

---

### AI Usage

I used AI as a learning tool and guide while working on this project.
Because I have difficulty with reading comprehension, AI helped me understand the instructions and how to build the program step by step.

I relied on AI to:

* Explain programming concepts in simple terms
* Help structure the logic of the program
* Check errors and improve code
* Guide me in building the system step by step

Additional AI Usage Details

Examples of prompts/questions I asked AI:
* How to build a shopping cart system step by step in C#
* How to use int.TryParse for input validation
* How to check if a product has enough stock
* How to prevent duplicate items in the cart
* How to compute total and apply discount
* How to fix errors and improve my code logic

What I improved after using AI:
* Added proper input validation for product ID and quantity
* Improved stock checking and handling of out of stock products
* Fixed logic for adding items to cart and preventing duplicates
* Added cart limit system and validation
* Implemented discount system for total amount
* Improved overall structure and readability of the program
* Added detailed comments and alphabetical labeling to understand the flow

Even though I used AI a lot, I made sure to:

* Review the code carefully
* Add my own comments and explanations
* Understand how each part of the program works

I also created an alphabetical system (A, B, C and sub letters) that matches my flowchart and code.
This helped me follow the program flow in order and understand each part clearly.

AI was not just used to generate code, but to help me learn and understand the logic behind it.

---

### Notes

* Products are hardcoded
* Console based only
* Cart has a maximum limit of 10 items
* Focus of this project is learning program flow and logic
