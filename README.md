# 🛍️ Uniqlo Web Application

This repository contains the source code and resources for the **Uniqlo Web Application**, a dynamic e-commerce platform developed using **ASP.NET**. The application is designed to provide a seamless shopping experience, featuring functionalities such as product browsing, shopping cart management, user authentication, and payment processing.

## 📂 Repository Contents

- **Frontend Components:**
  - ASP.NET pages (ASPX) for various sections such as **Home**, **Product Details**, **Cart**, **Profile**, **Login**, and **Checkout**.
  - JavaScript files (JS) to handle dynamic content, user interactions, and data visualization (e.g., **ContactUs.js**, **lineChart.js**, **Login.js**).
  - CSS files for styling and enhancing the user interface.

- **Backend Components:**
  - C# source files implementing business logic, controllers, and services for managing user accounts, products, orders, and payments.
  - Database models defined using **Entity Framework (EDMX files)** to manage data access and manipulation.

- **Admin Management:**
  - Pages for managing various aspects of the application, such as **AdminLogin**, **AdminProfile**, **Dashboard**, **Product Management**, **Order Management**, and **Staff Management**.

- **Database Files:**
  - **Uniqlo.mdf** and **Uniqlo_log.ldf** for managing the application's data storage, including user information, product catalog, order history, and other relevant data.

## 🌟 Key Features

- **User Authentication:** Secure login and registration system with validation and password management.
- **Product Catalog:** Dynamic product listing with options to view details, filter, and search products.
- **Shopping Cart:** Users can add, update, or remove items from their cart and proceed to checkout.
- **Order Management:** Allows users to track their order status and view order history.
- **Admin Dashboard:** Comprehensive management tools for the admin to manage products, orders, discounts, and user accounts.
- **Responsive Design:** Optimized for various devices and screen sizes.

## 🚀 Getting Started

To run the application locally:

1. Clone the repository to your local machine.
2. Open the solution file (`Uniqlo.sln`) in **Visual Studio**.
3. Restore the necessary NuGet packages.
4. Configure the connection string in `Web.config` to match your SQL Server instance.
5. Build and run the application.

## 📊 Database Management

The database is managed using **SQL Server** with **Entity Framework** for object-relational mapping (ORM). The database files (**Uniqlo.mdf** and **Uniqlo_log.ldf**) contain all necessary tables and relationships to store user data, product information, order details, and more.

## 💡 Contribution

Feel free to fork the repository and submit pull requests if you'd like to contribute to improving the application.
