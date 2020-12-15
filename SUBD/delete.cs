using DB.Logic;
using DB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DB
{
    class delete
    {
        public double DeleteClient(string names)
        {
            var client = new Client { Name = names };
            var startTime = DateTime.Now;
            ClientLogic.Delete(client);
            var finishTime = DateTime.Now;
            Console.WriteLine("---Скрипт Deleteclient выполнен");
            return (finishTime - startTime).TotalMilliseconds;
        }
        public double DeleteProvider(int id)
        {
            var provider = new Provider { Id = id };
            var startTime = DateTime.Now;
            ProviderLogic.Delete(provider);
            var finishTime = DateTime.Now;
            Console.WriteLine("---Скрипт Deleteprovider выполнен");
            return (finishTime - startTime).TotalMilliseconds;
        }
        public double DeleteType(string types)
        {
            var type = new Models.DType { Types = types };
            var startTime = DateTime.Now;
            TypeLogic.Delete(type);
            var finishTime = DateTime.Now;
            Console.WriteLine("---Скрипт DeleteType выполнен");
            return (finishTime - startTime).TotalMilliseconds;
        }
    }
}
