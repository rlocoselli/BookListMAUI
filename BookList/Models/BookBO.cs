using BookList.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookList.Database;
using CommunityToolkit.Maui.Core.Extensions;

namespace BookList.Models
{
    public class BookBO
    {
        public ObservableCollection<BookBase> GetNarratif()
        {
            ObservableCollection<BookBase> books = new ObservableCollection<BookBase>();

            Repository repo = new Repository();

            books = repo.ListBook().ToObservableCollection();

            return books;
        }

        public void CreateNarratif(String book)
        {
            Repository repo = new Repository();
            
            BookBase bookbase = new BookBase(book, BookType.Narratif, 1);

            repo.CreateBook(bookbase);
        }


    }
}
