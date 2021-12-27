using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Data.SqlClient;
using System.Threading;
using System.Diagnostics;

namespace Freelance_bot.Tasks
{
    public class Task_4
    {
        static int count_of_orders = 1;
        static int count_of_users = 1;
        static object locker = new();

        public async Task<List<long>> GetFiveOrdersID()
        {
            using var context = new Freelance_botContext();
            List<long> list_id = new();
            var orders = await context.Orders.Take(5).ToListAsync();
            orders.ForEach(order => list_id.Add(order.OrderId));
            return list_id;
        }

        public async Task<List<long>> GetFiveOrderWorkerID()
        {
            using var context = new Freelance_botContext();
            List<long> WorkerIDs = new();
            var orders = await context.Orders.Take(5).ToListAsync();
            orders.ForEach(order => WorkerIDs.Add(order.WorkerId));
            return WorkerIDs;
        }
        public async Task<List<long>> GetHundredOrdersIDAsync()
        {
            using var context = new Freelance_botContext();
            List<long> list_id = new();
            var orders = await context.Orders.Take(100).ToListAsync();
            orders.ForEach(order => list_id.Add(order.OrderId));
            return list_id;
        }

        public async Task<List<long>> GetHundtedOrderWorkerIDAsync()
        {
            using var context = new Freelance_botContext();
            List<long> WorkerIDs = new();
            var orders = await context.Orders.Take(100).ToListAsync();
            orders.ForEach(order => WorkerIDs.Add(order.WorkerId));
            return WorkerIDs;
        }

        public async Task<List<long>> GetFiveOrdersIDAsync()
        {
            return await Task.Run(() => GetFiveOrdersID());
        }
        public async Task<List<long>> GetFiveOrderWorkerIDAsync()
        {
            return await Task.Run(() => GetFiveOrderWorkerID());
        }

        public async Task<List<long>> GetIDs()
        {
            List<long> IDs = new();

            var result_1 = GetFiveOrdersIDAsync();
            var result_2 = GetFiveOrderWorkerIDAsync();
            await Task.WhenAll(result_1, result_2);
            result_1.Result.ForEach(n => IDs.Add(n));
            result_2.Result.ForEach(n => IDs.Add(n));

            return IDs;
        }

        public async Task PrintAllIds()
        {
            var names = await GetIDs();
            names.ForEach(n => Console.WriteLine("ID: " + n.ToString()));
        }

        public void MultithreadedRecording()
        {
            Console.WriteLine("Recordig...");

            var t1 = new Thread(LoopRecording);
            var t2 = new Thread(LoopRecording);
            var t3 = new Thread(LoopRecording);
            var t4 = new Thread(LoopRecording);


            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();
        }

        public static void LoopRecording()
        {
            using var context = new Freelance_botContext();
            lock (locker)
            {
                for (int i = 0; i < 100; i++)
                {
                    context.Orders.AddAsync(new Order { OrderId = count_of_orders + i, Category = $"LoopRecording {i}", Description = $"LoopRecording {i}", CreatorId = 124, ChatId = 111 });
                    context.Users.AddAsync(new User { UserId = count_of_users + i, UserName = $"Peter {i}", Balance = 100, Rating = 0 });
                    context.SaveChanges();
                }
                count_of_orders += 1000;
                count_of_users += 1000;
                Console.WriteLine("Created 100 orders and users");
            }

        }
        public void Dif_Task_And_Thread()
        {
            Thread.Sleep(15000);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var result_1 = GetHundredOrdersIDAsync();
            var result_2 = GetHundtedOrderWorkerIDAsync();

            Task.WaitAll(result_1, result_2);
            stopwatch.Stop();
            Console.WriteLine("Async:" + stopwatch.ElapsedMilliseconds);


            Thread t1 = new Thread(ThreadMethodUsersId);
            Thread t2 = new Thread(ThreadMethodOrdersID);

            stopwatch.Start();
            t1.Start();
            t2.Start();
            stopwatch.Stop();
            Console.WriteLine("Thread:" + stopwatch.ElapsedMilliseconds);
        }
        public void ThreadMethodUsersId()
        {
            List<long> names = new();
            using var context = new Freelance_botContext();
            var drivers = context.Users.Take(100).ToList();
            drivers.ForEach(d => names.Add(d.UserId));
        }

        public void ThreadMethodOrdersID()
        {
            List<long> names = new List<long>();
            using var context = new Freelance_botContext();
            var customers = context.Orders.Take(100).ToList();
            customers.ForEach(c => names.Add(c.OrderId));
        }
    }
}
