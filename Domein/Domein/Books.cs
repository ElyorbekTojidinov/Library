using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domein.Domein
{
    public class Books
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public int BookCount { get; set; }
        public DateTime CameTimes { get; set; }
        public int SelBookCount { get; set; }
        public override string ToString()
        {
            return $"BookId: {BookId}, BookName: {BookName}, Author: {Author},  BookCount: {BookCount},  CameTimes: {CameTimes}, SelBookCount: {SelBookCount}";
        }
    }
}
