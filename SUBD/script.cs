using DB.Logic;
using DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DB
{
    class script
    {
        public double LabScriptGroup()
        {
                  var startTime = DateTime.Now;
            var clientGroups = OrderLogic
                .Read(new Order { Id = 0 })
                .Join(сontext.Client,
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
            Console.WriteLine("---Скрипт группировка выполнен");
            return (finishTime - startTime).TotalMilliseconds;
        }
    }

    public double LabScriptSershClien()
    {
        // отобразить клиентов, полученных за последние 30 дней
        var startTime = DateTime.Now;
        var clients = OrderLogic.Read(new Order { Id = 0 }).Join(context.Clients,
                t => t.clientId,
                d => d.Id)
            .Where(rec => rec.Order.Date > DateTime.Now.AddDays(-30))
                .ToList();
        var finishTime = DateTime.Now;
        foreach (var r in client)
        {
            Console.WriteLine($"{r.name} {r.number} ");
        }
        Console.WriteLine("---Скрипт LabScriptSearchClient выполнен");
        return (finishTime - startTime).TotalMilliseconds;
    }

    public double ScriptSerch_forPrice()
    {
        var product = new Product() ;       
        var startTime = DateTime.Now;
        var products = ProductLogic.Read(product).Where(rec => rec.Price < 2000);
        var finishTime = DateTime.Now;
        foreach (var s in products)
        {
            Console.WriteLine(s.Name + " " + s.Price);
        }
        Console.WriteLine("---Скрипт ScriptSerchOrderforPrice выполнен");
        return (finishTime - startTime).TotalMilliseconds;
    }
}
