using DB;

using DB.Logic;
using DB.Models;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Linq;
using System.Text;

namespace DB
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
                Console.WriteLine(add.CreateType("футболка"));
                Console.WriteLine(add.CreateClient("dmitriy", "845345433455"));
                Console.WriteLine(add.CreateProvider("oleg", "'865756757565"));
                Console.WriteLine(read.ReadClients("dmitriy"));
                Console.WriteLine(read.ReadClients2("8956565756546"));
                Console.WriteLine(upd.UpdateType("футболка'", "shouts"));
                Console.WriteLine(upd.UpdateProvider("Oleg", "Adidas"));
                Console.WriteLine(del.DeleteType("shuts"));
                Console.WriteLine(del.DeleteClient("dmitriy"));
                Console.WriteLine(del.DeleteProvider(5001));
                Console.WriteLine(sqr.LabScriptSershClien());
                Console.WriteLine(sqr.LabScriptGroup());
                Console.WriteLine(sqr.ScriptSerch_forPrice());




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
