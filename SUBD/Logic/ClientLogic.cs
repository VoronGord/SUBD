using DB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DB.Logic
{
    static class ClientLogic
    {
        static DatabaseContext context = Program.context;
        public static void Create(Client model)
        {
            if (model.Number == null)
            {
                throw new Exception("Введён некорректный номер паспорта");
            }
            if (model.Name == null)
            {
                throw new Exception("Введите фамилию");
            }
           
            context.Clients.Add(new Client
            {
                Number = model.Number,
                Name = model.Name,
               
            });
            context.SaveChanges();
        }
        
        public  List<Models.Client> Read(Models.Client model, int pageSize = Program.pageSize, int currentPage = 0)
        {
            List<Models.Client> result = new List<Models.Client>();
            if (model.Name != null)
            {
                result = context.Clients
                    .Where(rec => rec.Name.Equals(model.Name))
                    .Skip(pageSize * currentPage)
                    .Take(pageSize)
                    .ToList();
            }
            else
            {
                result = context.Clients
                    .Skip(pageSize * currentPage)
                    .Take(pageSize)
                    .ToList();
            }
            return result;
        }
        public void Update(Client model)
        {
            Client client = context.Clients.FirstOrDefault(rec => rec.Name.Equals(model.Name));
            client.Name = model.Name;
            client.Number = model.Number;
                 
            context.SaveChanges();
        }
        public void Delete(Client model)
        {
            Client client = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);
            context.Clients.Remove(client);
            context.SaveChanges();
        }
    }
}
