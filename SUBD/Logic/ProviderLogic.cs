using DB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DB.Logic
{
    static class ProviderLogic
    {
        static DatabaseContext context = Program.context;
        public static void Create(Provider model)
        {
            if (model.Number == null)
            {
                throw new Exception("Введён некорректный номер зачётной книжки");
            }
            if (model.Name == null)
            {
                throw new Exception("Введите фамилию");
            }
           
            context.Providers.Add(new Provider
            {
                Number = model.Number,
                Name = model.Name,
              
            });
            context.SaveChanges();
        }
        public static List<Provider> Read(Provider model, int pageSize = Program.pageSize, int currentPage = 0)
        {
            List<Provider> result = new List<Provider>();
            if (model.Number != null)
            {
                result = context.Providers
                   .Where(rec => rec.Name.Equals(model.Name))
                   .Skip(pageSize * currentPage)
                   .Take(pageSize)
                   .ToList();
            }
            else
            {
                result = context.Providers
                   .Skip(pageSize * currentPage)
                   .Take(pageSize)
                   .ToList();
            }
            return result;
        }
        public static void Update(Provider model)
        {
            Provider Provider = context.Providers.FirstOrDefault(rec => rec.Name.Equals(model.Name));
            Provider.Name = model.Name;
            Provider.Number = model.Number;

            context.SaveChanges();
        }
        public static void Delete(Provider model)
        {
            Models.Provider Provider = context.Providers.FirstOrDefault(rec => rec.Id == model.Id);
            context.Providers.Remove(Provider);
            context.SaveChanges();
        }
    }
}
