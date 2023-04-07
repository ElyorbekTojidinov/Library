using Aplication.Aplication.Handlers;
using Domein.Domein;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prezentation.Prezentation
{
    public class Book_UI
    {
        private BookHandler bookHandler = new();
        
        public  void Run()
        {
           
        numKey:
            Console.WriteLine("1 Add Books");
            Console.WriteLine("2 Read Books");
            Console.WriteLine("3 ReadById Books");
            Console.WriteLine("4 Update Books");
            Console.WriteLine("5 Delete Books");
            if (!byte.TryParse(Console.ReadLine(), out byte num))
            {
                goto numKey;
            }
            switch (num)
            {
                case 1: AddBook(); break;
                case 2: ReadAll(); break;
                case 3: ReadById(); break;
                case 4: Update(); break;
                case 5: DeleteBook(); break;

                default: goto numKey;
            }
        }

        public  async void AddBook()
        {
        namekey:
            Console.WriteLine("Book name: ");
            string name = Console.ReadLine();
            if (name == null)
            {
                goto namekey;
            }
        key:
            Console.WriteLine("Author: ");
            string author = Console.ReadLine();

            if (author == null)
            {
                goto key;
            }
        countkey:
            Console.WriteLine("Book count: ");
           
            if (!int.TryParse(Console.ReadLine(), out int count))
            {
                goto countkey;
            }
            countb:
            Console.WriteLine("Sell book count: ");

            if (!int.TryParse(Console.ReadLine(), out int bcount))
            {
                goto countb;
            }

            Books bok = new()
            {
                BookName = name,
                Author = author,
                BookCount = bcount,
                CameTimes = DateTime.Now,
                SelBookCount = bcount
            };


            bool res  = await bookHandler.Insert(bok);

            Methods.BoolMethod(res);
        }

        public async void ReadAll()
         {
            List<Books> books = await bookHandler.GetAll();
            foreach (Books book in books)
            {
                Console.WriteLine(book);
            }
        }

        public async void ReadById()
        {
        ret:
            Console.WriteLine("Id: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                goto ret;
            }
            else
            {
                Books std = await bookHandler.GetById(id);
                Console.WriteLine(std);
            }
        }

        public async void Update()
        {

        namekey:
            Console.WriteLine("Book name: ");
            string name = Console.ReadLine();
            if (name == null)
            {
                goto namekey;
            }
        key:
            Console.WriteLine("Author: ");
            string author = Console.ReadLine();

            if (author == null)
            {
                goto key;
            }
        countkey:
            Console.WriteLine("Book count: ");

            if (!int.TryParse(Console.ReadLine(), out int count))
            {
                goto countkey;
            }
        countb:
            Console.WriteLine("Sell book count: ");

            if (!int.TryParse(Console.ReadLine(), out int bcount))
            {
                goto countb;
            }
        ret:
            Console.WriteLine("Id: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                goto ret;
            }
           
            Books bok = new()
            {
                BookId = id,
                BookName = name,
                Author = author,
                BookCount = bcount,
                CameTimes = DateTime.Now,
                SelBookCount = bcount
            };


            bool res = await bookHandler.Update(bok);
            Methods.BoolMethod(res);


        }

        public async void DeleteBook()
        {
        Idkey:
            Console.WriteLine("Id: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                goto Idkey;
            }
            bool res = await bookHandler.DeleteById(id);

            Methods.BoolMethod(res);
        }
    }
}
