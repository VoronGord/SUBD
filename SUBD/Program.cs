using GoryaynovDB.Logic;
using GoryaynovDB.Models;
using System;
using System.Linq;
using System.Text;

namespace GoryaynovDB
{
    class Program
    {
        public static DatabaseContext context = null;
        public const int pageSize = 100;
        static void Main(string[] args) 
        { 
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            try
            {
                context = new DatabaseContext();
                Console.WriteLine(CreateType());
                Console.WriteLine(CreateClient());
                Console.WriteLine(CreateProvider());
                Console.WriteLine(ReadClients());
                Console.WriteLine(ReadClients2());
                Console.WriteLine(UpdateType());
                Console.WriteLine(UpdateProvider());
                Console.WriteLine(DeleteType());
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                Environment.Exit(-1);
            }            
        }
        static double CreateType()
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
        static double CreateClient()
        {
            var client = new Client
            {
                Number ="89176265555",
                Name = "Dmitriy"
               
            };
            var startTime = DateTime.Now;
            ClientLogic.Create(client);
            var finishTime = DateTime.Now;
            Console.WriteLine("---Скрипт CreateClient выполнен");
            return (finishTime - startTime).TotalMilliseconds;
        }
        static double CreateProvider()
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
        static double ReadClients()
        {
            var client = new Client
            {
                Name = "Dmitriy"
            };
            var startTime = DateTime.Now;
            var clients = ClientLogic.Read(client);
            var finishTime = DateTime.Now;
            foreach (var s in clients)
            {
                Console.WriteLine(s.Name + " " + s.Number);
            }                
            Console.WriteLine("---Скрипт ReadSubjects выполнен");
            return (finishTime - startTime).TotalMilliseconds;
        }
        static double ReadClients2()
        {
            var client = new Client { Number = "89865538567" };
            var startTime = DateTime.Now;
            var clients = ClientLogic.Read(client);
            var finishTime = DateTime.Now;
            foreach (var s in clients)
            {
                Console.WriteLine(s.Name + " " + s.Number);
            }
            Console.WriteLine("---Скрипт ReadStudents выполнен");
            return (finishTime - startTime).TotalMilliseconds;
        }
       
        static double UpdateProvider()
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
        
        static double UpdateType()
        {
            var typeToUpd = TypeLogic
                .Read(new DType { Types = "футболка" })
                .FirstOrDefault();
            var newType = new Models.DType
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
        static double DeleteClient()
        {
            var client = new Client { Name = "dmitriy" };
            var startTime = DateTime.Now;
            ClientLogic.Delete(client);
            var finishTime = DateTime.Now;
            Console.WriteLine("---Скрипт Deleteclient выполнен");
            return (finishTime - startTime).TotalMilliseconds;
        }
        static double DeleteProvider()
        {
            var provider = new Provider { Id = 5001 };
            var startTime = DateTime.Now;
            ProviderLogic.Delete(provider);
            var finishTime = DateTime.Now;
            Console.WriteLine("---Скрипт Deleteprovider выполнен");
            return (finishTime - startTime).TotalMilliseconds;
        }
        static double DeleteType()
        {
            var type = new Models.DType { Types = "shots"};
            var startTime = DateTime.Now;
            TypeLogic.Delete(type);
            var finishTime = DateTime.Now;
            Console.WriteLine("---Скрипт DeleteType выполнен");
            return (finishTime - startTime).TotalMilliseconds;
        }
   
      
    }
}
