using Aplication.Aplication.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Aplication.Aplication.Filters
{
    public class SearchText
    {
        BookHandler bookHandler = new();

        public void Search(string text)
        {
            string pattern = $@"%{text}%";
            var query = (from book in bookHandler.GetAll().Result
                         where Regex.IsMatch(book.BookName, pattern)
                         select new
                         {
                             BookId = book.BookId,
                             BookName = book.BookName,
                             Author = book.Author,
                             BookCount = book.BookCount,
                             CameTimes = book.CameTimes,
                             SelBookCount = book.SelBookCount

                         });

            foreach (var item in query)
            {
                Console.WriteLine(item.BookName);
            }
        }

    }

}
