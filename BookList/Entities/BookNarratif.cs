using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookList.Entities
{
    public class BookNarratif : BookBase
    {
        public BookNarratif(string bookName, BookType bookType, int id) : base(bookName, bookType, id)
        {
        }
    }
}
