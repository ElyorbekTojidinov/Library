using Aplication.Aplication.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Prezentation.Prezentation
{
    public class UI_Forum
    {
        public void Run()
        {
        numKey:
            Console.WriteLine("1 Top Sell Books");
            Console.WriteLine("2 Sell Not Books");
            Console.WriteLine("3 Searching ");
            
            if (!byte.TryParse(Console.ReadLine(), out byte num))
            {
                goto numKey;
            }
            switch (num)
            {
                case 1: TopSellBooks(); break;
                case 2: SellNotBooks(); break;
                case 3: Search(); break;
               
                default: goto numKey;
            }
        }

        public void TopSellBooks() 
        {
            TopSellBook selbok = new TopSellBook();
            selbok.TopSell();
        }
        public void SellNotBooks()
        {
            SellNotBook book = new SellNotBook();
            book.sellNotBook();
        }
        public void Search()
        {
            testc:
            Console.WriteLine("Search: ");
            string txt = Console.ReadLine();
            if(txt == null)
            {
                goto testc;
            }
            SearchText text = new SearchText();
            text.Search(txt);
        }
    }
}
