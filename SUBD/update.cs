using GoryaynovDB.Logic;
using GoryaynovDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoryaynovDB
{
    class update
    {
        public double UpdateProvider()
        {
            var providerToUpd = ProviderLogic
                .Read(new Provider { Name = "Oleg" })
                .FirstOrDefault();
            var newProvider = new Provider
            {
                Id = providerToUpd.Id,
                Name = "Adidas",
                Number = providerToUpd.Number
            };
            var startTime = DateTime.Now;
            ProviderLogic.Update(newProvider);
            var finishTime = DateTime.Now;
            Console.WriteLine("---Скрипт UpdateOrder выполнен");
            return (finishTime - startTime).TotalMilliseconds;
        }

        public double UpdateType()
        {
            var typeToUpd = TypeLogic
                .Read(new DType { Types = "футболка" })
                .FirstOrDefault();
            var newType = new GoryaynovDB.Models.DType
            {
                Id = typeToUpd.Id,
                Types = "shots"

            };
            var startTime = DateTime.Now;
            TypeLogic.Update(newType);
            var finishTime = DateTime.Now;
            Console.WriteLine("---Скрипт UpdateType выполнен");
            return (finishTime - startTime).TotalMilliseconds;
        }
    }
}
