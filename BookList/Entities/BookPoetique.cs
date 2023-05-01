using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookList.Entities
{
    public class BookPoetique : BookBase
    {
        public BookPoetique(string bookName, BookType bookType, int id) : base(bookName, bookType, id)
        {
        }
    }
}
