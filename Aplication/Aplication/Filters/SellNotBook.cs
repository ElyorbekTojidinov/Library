using Aplication.Aplication.Handlers;
using Domein.Domein;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Aplication.Filters
{
    public class SellNotBook
    {
        BookHandler handler = new();

        public void sellNotBook()
        {
            var query = from bok in handler.GetAll().Result
                        where bok.BookCount == 0 && bok.CameTimes < bok.CameTimes
                        select new 
                        {
                            BookId = bok.BookId,
                            BookName = bok.BookName,
                            Author = bok.Author,
                            BookCount = bok.BookCount,
                            CameTimes = bok.CameTimes,
                            SelBookCount = bok.SelBookCount
                        };
            foreach (var item in query)
            {
                Console.WriteLine();
            }
        }
    }
}
