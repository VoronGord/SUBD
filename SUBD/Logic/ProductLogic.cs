using GoryaynovDB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoryaynovDB.Logic
{
    static class ProductLogic
    {
        static DatabaseContext context = Program.context;
        public static void Create(Product model)
        {
            if (model.Name == 0)
            {
                throw new Exception("Введите имя");
            }
            if (model.Count == 0)
            {
                throw new Exception("Введите количество");
            }

            if (model.Price== 0)
            {
                throw new Exception("Введите цену");
            }

            if (model.typeId == 0)
            {
                throw new Exception("Некорректный Id предмета");
            }
            if (model.ProviderId == 0)
            {
                throw new Exception("Некорректный Id продавца");
            }
            
            context.Products.Add(new Product
            {
                Name = model.Name,
                Count = model.Count,
               Price = model.Price,
                typeId = model.typeId,
                ProviderId = model.ProviderId              
            });
            context.SaveChanges();
        }
        public static List<Product> Read(Product model, int pageSize = Program.pageSize, int currentPage = 0)
        {
            List<Product> result = new List<Product>();
            if (model.Id != 0)
            {
                result = context.Products
                    .Where(rec => rec.Id == model.Id)
                    .Include(product => product.Type)
                    .Include(product => product.Provider)
                    .Skip(currentPage * pageSize)
                    .Take(pageSize)
                    .ToList();
            } 
            else
            {
                result = context.Products
                    .Include(product => product.Type)
                    .Include(product => product.Provider)
                    .Skip(currentPage * pageSize)
                    .Take(pageSize)
                    .ToList();
            }
            return result;
        }
        public static void Update(Product model)
        {
            Product product = context.Products.FirstOrDefault(rec => rec.Id == model.Id);
            product.Name = model.Name;
            product.Count = model.Count;
            product.Price = model.Price;
            product.typeId= model.typeId;
            product.ProviderId = model.ProviderId;
            context.SaveChanges();
        }
        public static void Delete(Product model)
        {
            Product product = context.Products.FirstOrDefault(rec => rec.Id == model.Id);
            context.Products.Remove(product);
            context.SaveChanges();
        }
    }
}
