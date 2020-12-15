using DB.Logic;
using DB.Models;
using System;

namespace DB
{
    public class add
    {
        public double CreateType(string types)
        {
            var type = new Models.DType
            {
                Types = types
            };
            var startTime = DateTime.Now;
            TypeLogic.Create(type);
            var finishTime = DateTime.Now;
            Console.WriteLine("---Скрипт CreateType выполнен");
            return (int)(finishTime - startTime).TotalMilliseconds;
        }
        public double CreateClient(string numbers, string names)
        {
            var client = new Client
            {
                Number = numbers,
                Name = names

            };
            var startTime = DateTime.Now;
            ClientLogic.Create(client);
            var finishTime = DateTime.Now;
            Console.WriteLine("---Скрипт CreateClient выполнен");
            return (finishTime - startTime).TotalMilliseconds;
        }
        public double CreateProvider(string numbers, string names)
        {
            var provider = new Provider
            {
                Name = names,
                Number = numbers
            };
            var startTime = DateTime.Now;
            ProviderLogic.Create(provider);
            var finishTime = DateTime.Now;
            Console.WriteLine("---Скрипт CreateProduct выполнен");
            return (finishTime - startTime).TotalMilliseconds;
        }
    }
}
