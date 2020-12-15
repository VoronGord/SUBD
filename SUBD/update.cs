using DB.Logic;
using DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DB
{ 
    class update 
    {
        public double UpdateProvider(string NamePost, string NameNow)
        {
            var providerToUpd = ProviderLogic
                .Read(new Provider { Name = NamePost })
                .FirstOrDefault();
            var newProvider = new Provider
            {
                Id = providerToUpd.Id,
                Name = NameNow,
                Number = providerToUpd.Number
            };
            var startTime = DateTime.Now;
            ProviderLogic.Update(newProvider);
            var finishTime = DateTime.Now;
            Console.WriteLine("---Скрипт UpdateOrder выполнен");
            return (finishTime - startTime).TotalMilliseconds;
        }

        public double UpdateType(string TypePost, string TypeNow)
        {
            var typeToUpd = TypeLogic
                .Read(new DType { Types = TypePost })
                .FirstOrDefault();
            var newType = new GoryaynovDB.Models.DType
            {
                Id = typeToUpd.Id,
                Types = TypeNow

            };
            var startTime = DateTime.Now;
            TypeLogic.Update(newType);
            var finishTime = DateTime.Now;
            Console.WriteLine("---Скрипт UpdateType выполнен");
            return (finishTime - startTime).TotalMilliseconds;
        }
    }
}
