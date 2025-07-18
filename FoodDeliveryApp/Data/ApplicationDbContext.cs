﻿using FoodDeliveryApp.Models; // Include the models for the food delivery application.  
using Microsoft.EntityFrameworkCore; // Include EF Core for database context features.  
using System;  

namespace FoodDeliveryApp.Data  
{  
    public class ApplicationDbContext : DbContext  
    {  
        // Constructor to initialize the application context with options passed.  
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }  

        // DbSets represent collections of entities in the database.  
        public DbSet<Admin> Admins { get; set; } // Collection of Admin entities.  
        public DbSet<Customer> Customers { get; set; } // Collection of Customer entities.  
        public DbSet<Item> Items { get; set; } // Collection of Item entities.  
        public DbSet<Order> Orders { get; set; } // Collection of Order entities.  
        public DbSet<OrderItem> OrderItems { get; set; } // Collection of OrderItem entities.  

        // Configures the model and database schema on model creation.  
        protected override void OnModelCreating(ModelBuilder modelBuilder)  
        {  
            base.OnModelCreating(modelBuilder); // Calls the base method to ensure the correct model is created.  

            // Seed data for the Admin table.  
            modelBuilder.Entity<Admin>().HasData(  
                new Admin { AdminId = 1, Name = "SuperAdmin", Email = "admin@example.com", Password = "admin@123", PhoneNumber = "1234567890", Role = "SuperAdmin" }  
            );  

            // Seed data for the Customers table.  
            modelBuilder.Entity<Customer>().HasData(  
                new Customer { CustomerId = 1, CustomerName = "John Doe", Email = "john@example.com", Password = "john@123", PhoneNumber = "9876543210", Address = "123 Main Street" },  
                new Customer { CustomerId = 2, CustomerName = "Jane Smith", Email = "jane@example.com", Password = "jane@123", PhoneNumber = "5554443322", Address = "456 South Avenue" }  
            );  

            // Seed data for the Items table.  
            modelBuilder.Entity<Item>().HasData(  
                new Item { ItemId = 1, ItemName = "Margherita Pizza", Description = "Classic cheese pizza", Price = 9.99m, IsAvailable = true },  
                new Item { ItemId = 2, ItemName = "Veggie Burger", Description = "Delicious burger with veggie patty", Price = 7.49m, IsAvailable = true },  
                new Item { ItemId = 3, ItemName = "Pepperoni Pizza", Description = "Pizza with pepperoni toppings", Price = 10.99m, IsAvailable = true },  
                new Item { ItemId = 4, ItemName = "Chicken Burger", Description = "Juicy chicken burger", Price = 8.49m, IsAvailable = true },  
                new Item { ItemId = 5, ItemName = "French Fries", Description = "Crispy golden fries", Price = 3.49m, IsAvailable = true }  
            );  

            // Seed data for the Orders table, including the relationship with Customers.  
            modelBuilder.Entity<Order>().HasData(  
                new Order { OrderId = 1, CustomerId = 1, OrderDateTime = DateTime.Today.AddMinutes(10), Status = OrderStatus.Pending, Price = 9.99m },  // Single item #1  
                new Order { OrderId = 2, CustomerId = 2, OrderDateTime = DateTime.Today.AddMinutes(25), Status = OrderStatus.Accepted, Price = 7.49m },  // Single item #2  
                new Order { OrderId = 3, CustomerId = 1, OrderDateTime = DateTime.Today.AddMinutes(32), Status = OrderStatus.Accepted, Price = 10.98m }, // Items #2, #5  
                new Order { OrderId = 4, CustomerId = 2, OrderDateTime = DateTime.Today.AddMinutes(45), Status = OrderStatus.Pending, Price = 10.99m },  // Single item #3  
                new Order { OrderId = 5, CustomerId = 2, OrderDateTime = DateTime.Today.AddMinutes(45), Status = OrderStatus.Rejected, Price = 10.98m }, // Items #2, #5  
                new Order { OrderId = 6, CustomerId = 1, OrderDateTime = DateTime.Today.AddMinutes(50), Status = OrderStatus.Rejected, Price = 10.99m }  // Single item #3  
            );  

            // Seed data for the OrderItems table, representing items within an order.  
            modelBuilder.Entity<OrderItem>().HasData(  
                new OrderItem { OrderItemId = 1, OrderId = 1, ItemId = 1, Quantity = 1, UnitPrice = 9.99m },  
                new OrderItem { OrderItemId = 2, OrderId = 2, ItemId = 2, Quantity = 1, UnitPrice = 7.49m },  
                new OrderItem { OrderItemId = 3, OrderId = 3, ItemId = 2, Quantity = 1, UnitPrice = 7.49m },  
                new OrderItem { OrderItemId = 4, OrderId = 3, ItemId = 5, Quantity = 1, UnitPrice = 3.49m },  
                new OrderItem { OrderItemId = 5, OrderId = 4, ItemId = 3, Quantity = 1, UnitPrice = 10.99m },  
                new OrderItem { OrderItemId = 6, OrderId = 5, ItemId = 2, Quantity = 1, UnitPrice = 7.49m },  
                new OrderItem { OrderItemId = 7, OrderId = 5, ItemId = 5, Quantity = 1, UnitPrice = 3.49m },  
                new OrderItem { OrderItemId = 8, OrderId = 6, ItemId = 3, Quantity = 1, UnitPrice = 10.99m }  
            );  
        }  
    }  
}  