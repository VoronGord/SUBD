using GoryaynovDB.Logic;
using GoryaynovDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoryanovDB
{
    class script
    {
        public double LabScript()
        {
            // вывести число преподавателей по кафедрам
            var startTime = DateTime.Now;
            var clientGroups = OrderLogic
                .Read(new Order { Id = 0 })
                .Join(context.Client,
                    t => t.clientId,
                    d => d.Id,
                    (t, d) => new
                    {
                        Name = t.Name,
                        Date = d.Date
                    })
                .GroupBy(rec => rec.Date)
                .ToList();
            var finishTime = DateTime.Now;
            foreach (var group in clientGroups)
            {
                Console.WriteLine(group.Key + " " + group.Date());
            }
            Console.WriteLine("---Скрипт LabScript выполнен");
            return (finishTime - startTime).TotalMilliseconds;
        }
    }

    public double LabScript2()
    {
        // отобразить клиентов, полученных за последние 100 дней
        var startTime = DateTime.Now;
        var clients = OrderLogic.Read(new Order { Id = 0 }).Join(context.Clients,
                t => t.clientId,
                d => d.Id)
            .Where(rec => rec.Order.Date > DateTime.Now.AddDays(-100))
                .ToList();
        var finishTime = DateTime.Now;
        foreach (var r in client)
        {
            Console.WriteLine($"{r.name} {r.number} ");
        }
        Console.WriteLine("---Скрипт LabScript2 выполнен");
        return (finishTime - startTime).TotalMilliseconds;
    }

    public double Script3()
    {
        var product = new Product;
       
        var startTime = DateTime.Now;
        var products = ProductLogic.Read(product).Where(rec => rec.Price < 2000);
        var finishTime = DateTime.Now;
        foreach (var s in products)
        {
            Console.WriteLine(s.Name + " " + s.Price);
        }
        Console.WriteLine("---Скрипт scrip3 выполнен");
        return (finishTime - startTime).TotalMilliseconds;
    }
}
