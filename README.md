E-Commerce Website with Admin Panel

Project Overview
This documentation outlines the development of an e-commerce website that includes a comprehensive admin panel for site management. The website aims to offer a seamless shopping experience, enhanced by a robust backend system that allows administrators to manage products, categories, orders, and notifications effectively.

Project Goals
- User-Friendly Platform: Develop a platform that supports product browsing, selection, and purchasing.
- Secure Payment System: Integrate a secure payment system for processing transactions.
- Comprehensive Admin Panel: Implement an admin panel for managing website content and user activities.
- User Authentication: Enable user registration and login via Google and Facebook.
- Email Verification: Incorporate email verification for new user registrations.
- Responsive Design: Ensure the website provides an optimal viewing experience across various devices.

Key Features
- Admin Panel: Versatile backend interface for managing products, categories, and orders. Features include:
- Adding, deleting, and updating product information and categories.
- Reviewing and processing orders.
- Payment Integration: Secure processing of transactions with integration of a virtual POS system, supporting various payment methods.
- User Authentication: Option for users to register and log in using Google or Facebook accounts.
- Email Verification: System to verify email addresses of users upon registration.
- Responsive Design: Adjusts layout for optimal viewing on desktops, tablets, and smartphones.
- Search Functionality: In-site search box to facilitate easy access to products.
- Image Management: Admin panel allows addition, editing, and deletion of product images.
- Order Management: Capability to view, edit, and update the status of orders through the admin panel.

Technology Stack
Framework: ASP.NET MVC Core-5 for robust web application development.
Frontend: HTML, CSS, Bootstrap for responsive design, and JavaScript for interactive elements.
Backend: ASP.NET Core MVC for server-side logic and database management.
Database: SQL Server for storing product, user, and order data.
Authentication: OAuth for Google and Facebook login integration.
Payment Gateway: Integration with a virtual POS service - IYZICO for secure transaction processing.

Installation and Setup
1- Clone the Repository:
git clone https://github.com/selengecagin/e-commerce-website.git
cd e-commerce-website


2- Setup Database:
Configure your SQL Server database.
Update the connection string in the appsettings.json file.

3- Install Dependencies:
dotnet restore

4- Run Migrations:
dotnet ef database update

5- Run the Application
dotnet run

Contributing
We welcome contributions to enhance the functionality and features of this e-commerce website. Please follow these steps:

1. Fork the repository.
2. Create a new branch (git checkout -b feature-branch).
3. Commit your changes (git commit -m 'Add some feature').
4. Push to the branch (git push origin feature-branch).
5. Open a pull request.

Contact
For any inquiries or feedback, please contact the project maintainer at selengecagin@gmail.com.
