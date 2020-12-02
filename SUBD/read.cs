using DB.Logic;
using DB.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace DB
{
    class read
    {
        public double ReadClients()
        {
            var client = new Client
            {
                Name = "Dmitriy"
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
        public double ReadClients2()
        {
            var client = new Client { Number = "89865538567" };
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
