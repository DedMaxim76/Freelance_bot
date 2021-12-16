using Npgsql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;

namespace Freelance_bot
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("--------------------------------------");
            GetOrdersSum();
            Console.WriteLine("--------------------------------------\n");


            GetOrderMax();
            Console.WriteLine("--------------------------------------\n");

            GetOrderMin();
            Console.WriteLine("--------------------------------------\n");

            crossJoin();
            Console.WriteLine("--------------------------------------\n");

            GetOrderUperThen(1, 123);
            Console.WriteLine("--------------------------------------\n");

            Orders_ASC();
            Console.WriteLine("--------------------------------------\n");

            Orders_Descend();
            Console.WriteLine("--------------------------------------\n");

            CountOrders();
            Console.WriteLine("--------------------------------------\n");

            GetOrders(1);
            Console.WriteLine("--------------------------------------\n");



            /*ShowTable();
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
            ShowTable();*/
        }


        static void GetOrdersSum()
        {
            using (Freelance_botContext db = new())
            {
                var sum = db.Orders.Sum(x => x.CostValue);
                Console.WriteLine("Orders sum: {0}", sum);
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        static void GetOrderMax()
        {
            using (Freelance_botContext db = new())
            {
                var max = db.Orders.Max(x => x.CostValue);
                Console.WriteLine("Orders max cost: {0}", max);
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        static void GetOrderMin()
        {
            using (Freelance_botContext db = new())
            {
                var min = db.Orders.Min(x => x.CostValue);
                Console.WriteLine("Orders min cost: {0}", min);
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        static void crossJoin()
        {
            using (Freelance_botContext db = new())
            {
                var join = db.Orders.Join(db.Users,
                       x => x.CreatorId,
                       y => y.UserId, (x, y) => new
                       {
                           OrderId = x.OrderId,
                           OrderCost = x.CostValue,
                           MediaMessageUrl = x.MediaMessageUrl,
                           UserId = y.UserId,
                           UserName = y.UserName
                       });
                foreach (var j in join)
                    Console.WriteLine("{0}  {1}  {2}  {3}  {4}", j.OrderId, j.OrderCost, j.MediaMessageUrl, j.UserId, j.UserName);
            }
            Console.WriteLine();
            Console.WriteLine();
        }


        static void GetOrderUperThen(float amount, int user_id)
        {
            using (Freelance_botContext db = new())
            {
                var tempOrders = db.Orders.Where(x => x.CostValue >= amount)
                                     .Where(x => x.CreatorId.Equals(user_id));
                foreach (var order in tempOrders)
                    Console.WriteLine("{0}  {1}  {2}  {3}  {4}  {5}", order.OrderId, order.CreatorId, order.WorkerId, order.CostValue, order.Category, order.Description);
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        static void Orders_ASC()
        {
            using (Freelance_botContext db = new())
            {
                var tempOrders = db.Orders.OrderBy(x => x.OrderId);
                foreach (var order in tempOrders)
                    Console.WriteLine("{0}  {1}  {2}  {3}  {4}  {5}", order.OrderId, order.CreatorId, order.WorkerId, order.CostValue, order.Category, order.Description);
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        static void Orders_Descend()
        {
            using (Freelance_botContext db = new())
            {
                var tempOrders = db.Orders.OrderByDescending(x => x.OrderId);
                foreach (var order in tempOrders)
                    Console.WriteLine("{0}  {1}  {2}", order.OrderId, order.CostValue, order.CreatorId);
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        static void CountOrders()
        {
            using (Freelance_botContext db = new Freelance_botContext())
            {
                var countOrders = db.Orders.Count();
                Console.WriteLine("Orders count - {0}", countOrders);
            }
            Console.WriteLine();
            Console.WriteLine();
        }


        static void GetOrders(int num)
        {
            using (Freelance_botContext db = new())
            {
                var tempOrders = db.Orders.Take(num);
                foreach (var order in tempOrders)
                    Console.WriteLine("{0}  {1}  {2}  {3}  {4}  {5}", order.OrderId, order.CreatorId, order.WorkerId, order.CostValue, order.Category, order.Description);
            }
            Console.WriteLine();
            Console.WriteLine();
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
