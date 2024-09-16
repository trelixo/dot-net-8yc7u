using System;
using System.Collections.Generic;
using System.IO;

namespace OrderProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Order> orders = OrderRepository.LoadOrdersFromFile("orders.txt");

            ProcessOrders(orders);
        }

        static void ProcessOrders(List<Order> orders)
        {
            foreach (Order order in orders)
            {
                decimal totalPrice = CalculateTotalPrice(order);
                Console.WriteLine($"Order ID: {order.OrderID}, Total Price: {totalPrice}");
            }

            // Additional processing or reporting could go here...
        }

        static decimal CalculateTotalPrice(Order order)
        {
            decimal totalPrice = order.Quantity * order.UnitPrice;

            // Apply discounts (potentially buggy or inefficient)
            if (order.CustomerID == "VIP")
            {
                totalPrice *= 0.9m; // 10% discount for VIP customers
            }
            else if (order.Quantity > 5)
            {
                totalPrice *= 0.95m; // 5% discount for bulk orders
            }

            return totalPrice;
        }
    }

    class Order
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }

    class OrderRepository
    {
        public static List<Order> LoadOrdersFromFile(string filePath)
        {
            // Implementation to read orders from a file (could be improved)
            List<Order> orders = new List<Order>();

            // ... (Code to read and parse order data from file)
            return orders;
        }
    }
}