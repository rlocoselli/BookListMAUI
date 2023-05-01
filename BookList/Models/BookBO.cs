using BookList.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookList.Models
{
    public class BookBO
    {
        public ObservableCollection<BookBase> GetNarratif()
        {
            ObservableCollection<BookBase> books = new ObservableCollection<BookBase>();
            books.Add(new BookBase("Livre 1",BookType.Narratif,1));
            books.Add(new BookBase("Livre 2", BookType.Narratif, 1));

            return books;
        }
    }
}
