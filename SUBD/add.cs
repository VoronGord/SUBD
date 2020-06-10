using DB.Logic;
using DB.Models;
using System;

namespace DB
{
    public class add
    {
        public double CreateType()
        {
            var type = new Models.DType
            {
                Types = "футболка"

            };
            var startTime = DateTime.Now;
            TypeLogic.Create(type);
            var finishTime = DateTime.Now;
            Console.WriteLine("---Скрипт CreateType выполнен");
            return (int)(finishTime - startTime).TotalMilliseconds;
        }
        public double CreateClient()
        {
            var client = new Client
            {
                Number = "89176265555",
                Name = "Dmitriy"

            };
            var startTime = DateTime.Now;
            ClientLogic.Create(client);
            var finishTime = DateTime.Now;
            Console.WriteLine("---Скрипт CreateClient выполнен");
            return (finishTime - startTime).TotalMilliseconds;
        }
        public double CreateProvider()
        {
            var provider = new Provider
            {
                Name = "Oleg",
                Number = "834985385439"
            };
            var startTime = DateTime.Now;
            ProviderLogic.Create(provider);
            var finishTime = DateTime.Now;
            Console.WriteLine("---Скрипт CreateProduct выполнен");
            return (finishTime - startTime).TotalMilliseconds;
        }
    }
}
