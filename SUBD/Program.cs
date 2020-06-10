using DB;
using GoryanovDB;
using GoryaynovDB.Logic;
using GoryaynovDB.Models;
using Microsoft.EntityFrameworkCore.Internal;
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
            var add = new add();
            var read = new read();
            var upd = new update();
            var del = new delete();
            var sqr = new script();

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            try
            {
                context = new DatabaseContext();
                Console.WriteLine(add.CreateType());
                Console.WriteLine(add.CreateClient());
                Console.WriteLine(add.CreateProvider());
                Console.WriteLine(read.ReadClients());
                Console.WriteLine(read.ReadClients2());
                Console.WriteLine(upd.UpdateType());
                Console.WriteLine(upd.UpdateProvider());
                Console.WriteLine(del.DeleteType());
                Console.WriteLine(del.DeleteClient());
                Console.WriteLine(del.DeleteProvider());
                Console.WriteLine(sqr.LabScript());
                Console.WriteLine(sqr.LabScript2());
                Console.WriteLine(sqr.Script3());




            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                Environment.Exit(-1);
            }            
        }
 
            

        /**/
           
    }
}
