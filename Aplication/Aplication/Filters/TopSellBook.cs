using Aplication.Aplication.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Aplication.Filters
{
    public class TopSellBook
    {
        BookHandler handler = new();

        public void TopSell()
        {
            var query = (from bok in handler.GetAll().Result
                        orderby bok.BookCount
                        select new
                        {
                            BookId = bok.BookId,
                            BookName = bok.BookName,
                            Author = bok.Author,
                            BookCount = bok.BookCount,
                            CameTimes = bok.CameTimes,
                            SelBookCount = bok.SelBookCount
                        }).Take(5);
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }
        
    }
}
