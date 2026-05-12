# Salgado_Alexander_ShoppingCartActivity ( UPDATED with PART 2 )

---

## Shopping Cart System Information:

### Description

This is an enhanced console-based shopping cart system made in C#.

The program allows users to browse products, manage a shopping cart, and complete a checkout process with payment validation and receipt generation.

It checks stock availability, calculates totals, applies discounts, and stores order history during program execution.

This project focuses on understanding program flow, object-oriented programming, validation, and real-world shopping system logic.

---

## Features

* Product display with category, price, and stock
* Product search by name
* Category field for product classification
* Input validation using `int.TryParse`
* Stock checking system
* Cart management system:

  * Add items
  * View cart
  * Remove items
  * Update quantity
  * Clear cart
  * Checkout
* Cart limit of 10 total items
* Duplicate item merging in cart
* Automatic total computation
* 10% discount if total is 5000 or more
* Payment validation system (must be numeric and sufficient)
* Change computation after payment
* Receipt generation with:

  * Receipt number
  * Date and time
  * Purchased items
  * Total amount
  * Discount
  * Final amount
  * Payment and change
* Order history storage (up to 10 transactions)
* Low stock alert system (stock ≤ 5)
* Continuous shopping loop system

---

## Code Structure

### Product Class

* Stores product information (ID, name, price, category, stock)
* Handles:

  * Item total computation
  * Stock validation
  * Stock deduction after purchase
* Displays product information in formatted layout

---

### Program Class

* Main entry point of the system
* Handles:

  * Store menu display
  * User input and validation
  * Cart system logic
  * Checkout process
  * Payment handling
  * Receipt generation
  * Order history storage
  * Program loop control

---

## Program Flow

* Program starts
* Product menu is displayed
* User selects action from cart menu
* User adds products with validation
* System checks stock and cart limit
* Items are added or updated in cart
* User can manage cart before checkout
* Checkout begins:

  * Receipt is generated
  * Total is calculated
  * Discount is applied (if applicable)
  * Payment is validated
  * Change is computed
* Low stock alert is displayed
* Order is saved in order history
* User chooses to continue or exit

---

## Files

* Program.cs
* ‎Salgado_Alexander_ShoppingCartActivity OUTPUT SAMPLES.txt
* README.md

---

## AI Usage

I used AI as a learning tool and guide while working on this project.

Because I have difficulty with reading comprehension, AI helped me understand complex instructions and break down the program into smaller, manageable steps.

I relied on AI to:

* Explain programming concepts in simple and clear terms
* Help me understand program flow and logic structure
* Guide me in building the cart system step by step
* Assist in debugging and improving code logic
* Help implement validation, stock handling, and receipt generation

### Additional AI Usage Details

Examples of prompts/questions I asked AI:

* How to build a cart management system step by step in C#
* How to use `int.TryParse` for input validation
* How to manage stock correctly when adding/removing items
* How to prevent cart overflow and enforce limits
* How to generate receipts with formatted output
* How to implement order history using arrays
* How to improve program logic and structure

### What I improved after using AI:

* Improved input validation for all user inputs
* Implemented full cart management system
* Fixed stock handling and deduction logic
* Added payment validation and change computation
* Added receipt system with complete transaction details
* Implemented order history storage with limits
* Improved overall program structure and readability
* Added detailed comments to understand program flow

Even though AI was used as a guide, all code was reviewed and understood step by step.

AI was used as a learning assistant, not just for generating code, but for understanding programming logic and improving problem-solving skills.

---

## Notes

* Products are hardcoded in the system.
* Console-based application only.
* Cart limit is 10 total items.
* Order history is limited to 10 records.
* Focus of this project is learning real-world program flow, validation, and system logic.
