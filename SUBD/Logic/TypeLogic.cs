using DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DB.Logic
{
    static class TypeLogic
    {
        static DatabaseContext context = Program.context;
        public  void Create(Models.DType model)
        {
            if (model.Types == null)
            {
                throw new Exception("Введите название типа продукта");
            }
            
            context.Types.Add(new Models.DType
            {
                Types = model.Types,
              
            });
            context.SaveChanges();
        }
        public  List<Models.DType> Read(Models.DType model, int pageSize = Program.pageSize, int currentPage = 0)
        {
            List<Models.DType> result = new List<Models.DType>();
            if (model.Types != null)
            {
                result = context.Types
                    .Where(rec => rec.Types.Equals(model.Types))
                    .Skip(pageSize * currentPage)
                    .Take(pageSize)
                    .ToList();
            }
            else
            {
                result = context.Types
                    .Skip(pageSize * currentPage)
                    .Take(pageSize)
                    .ToList();
            }
            return result;
        }
        public  void Update(Models.DType model)
        {
            Models.DType type = context.Types.FirstOrDefault(rec => rec.Types.Equals(model.Types));
            type.Types = model.Types;
            context.SaveChanges();
        }
        public  void Delete(Models.DType model)
        {
            Models.DType type = context.Types.FirstOrDefault(rec => rec.Id == model.Id);
            context.Types.Remove(type);
            context.SaveChanges();
        }
    }
}
