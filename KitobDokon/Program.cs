using Infrostructure.Infrostructure;
using Npgsql;
using Prezentation.Prezentation;
using System.Security.Cryptography.X509Certificates;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KitobDokon
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
                new CreateDatabase().CreateBaseIfNot();
           
           
           
           
            Run();
            Console.ReadKey();
        }
        public static void Run()
        {

            Book_UI bookUI = new Book_UI();
            UI_Forum Filter = new UI_Forum();

            numKey:
            Console.WriteLine("1 CRUD");
            Console.WriteLine("2 Filter");
            if (!byte.TryParse(Console.ReadLine(), out byte num))
            {
                goto numKey;
            }
            switch (num)
            {
                case 1: bookUI.Run(); break;
                case 2: Filter.Run(); break;
                
                default: goto numKey;
            }
        }
    }
}