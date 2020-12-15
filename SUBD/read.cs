using DB.Logic;
using DB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DB
{
    class read
    {
        public double ReadClients(string names)
        {
            var client = new Client
            {
                Name = names
            };
            var startTime = DateTime.Now;
            var clients = ClientLogic.Read(client);
            var finishTime = DateTime.Now;
            foreach (var s in clients)
            {
                Console.WriteLine(s.Name + " " + s.Number);
            }
            Console.WriteLine("---Скрипт ReadClient выполнен");
            return (finishTime - startTime).TotalMilliseconds;
        }
        public double ReadClients2(string nimbers)
        {
            var client = new Client { Number = nimbers };
            var startTime = DateTime.Now;
            var clients = ClientLogic.Read(client);
            var finishTime = DateTime.Now;
            foreach (var s in clients)
            {
                Console.WriteLine(s.Name + " " + s.Number);
            }
            Console.WriteLine("---Скрипт ReadClients2 выполнен");
            return (finishTime - startTime).TotalMilliseconds;
        }
    }
}
