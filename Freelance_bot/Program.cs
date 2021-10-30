using System;
using System.Collections.Generic;
using System.Linq;

namespace Freelance_bot
{
    class Program
    {
        static void Main()
        {
            ShowTable();
            AddOrder(200, 73450324, 52350324, "TEST_CATEGORY", "TEST_DESCRIPTION");
            AddOrder(201, 52350324, 73450324, "TEST_CATEGORY#2", "TEST_DESCRIPTION#2");
            Console.WriteLine("\nAdded 2 orders (200, 201)");
            ShowTable();
            UpdateOrderWorkerId(200, 13750324);
            Console.WriteLine("\nUpdated worker id at order 200");
            ShowTable();
            DeleteOrder(200);
            DeleteOrder(201);
            Console.WriteLine("\nDeleted 2 orders (200, 201)");
            ShowTable();
        }

        static void ShowTable()
        {
            using Freelance_botContext db = new();

            var lines = db.Orders.ToList();
            Console.WriteLine("Data from PostgresSQL:");
            if (lines.Count == 0)
            {
                Console.WriteLine("Table is empty!");
                return;
            }
            foreach (Order order in lines)
            {
                Console.WriteLine($"ID = {order.OrderId}, Category = {order.Category}, Description = {order.Description}, worker_id = {order.WorkerId}");
            }
        }

        static void AddOrder(Int64 order_id, Int64 creator_id, Int64 worker_id, string category, string description)
        {
            using Freelance_botContext db = new();
            Order new_order = new() { OrderId = order_id, CreatorId = creator_id, WorkerId = worker_id, Category = category, Description = description };

            db.Orders.Add(new_order);
            db.SaveChanges();
        }

        static void UpdateOrderWorkerId(Int64 order_id, Int64 worker_id)
        {
            using Freelance_botContext db = new();

            Order order = db.Orders.Find(order_id);
            if (order != null)
            {
                order.WorkerId = worker_id;

                db.Orders.Update(order);
                db.SaveChanges();
            }
        }

        static void DeleteOrder(Int64 order_id)
        {
            using Freelance_botContext db = new();

            Order order = db.Orders.Find(order_id);
            if (order != null)
            {
                _ = db.Orders.Remove(order);
                db.SaveChanges();
            }
        }
    }
}
