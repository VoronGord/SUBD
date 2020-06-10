using GoryaynovDB.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoryaynovDB.Logic
{
    static class OrderLogic
    {
        static DatabaseContext context = Program.context;
        public static void Create(Order model)
        {
            if (model.Date.CompareTo(new DateTime(1900, 1, 1)) < 0)
            {
                throw new Exception("Введите дату");
            }
            if (model.clientId == 0)
            {
                throw new Exception("Некорректный Id предмета");
            }
            if (model.ProductId == 0)
            {
                throw new Exception("Некорректный Id продавца");
            }
            context.Orders.Add(new Order
            {
                Date = model.Date,
                clientId = model.clientId,
                ProductId = model.ProductId
            });
            context.SaveChanges();
        }
        public static List<Order> Read(Order model, int pageSize = Program.pageSize, int currentPage = 0)
        {
            List<Order> result = new List<Order>();
            if (model.Date != null)
            {
                result = context.Orders
                    .Where(rec => rec.Date.Equals(model.Date))
                    .Skip(pageSize * currentPage)
                    .Take(pageSize)
                    .ToList();
            }
            else
            {
                result = context.Orders
                    .Skip(pageSize * currentPage)
                    .Take(pageSize)
                    .ToList();
            }
            return result;
        }
        public static void Update(Order model)
        {
            Order order = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            order.Date = model.Date;
              order.clientId = model.clientId;
              order.ProductId = model.ProductId;
            context.SaveChanges();
        }
        public static void Delete(Order model)
        {
            Order order = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            context.Orders.Remove(order);
            context.SaveChanges();
        }
    }
}
