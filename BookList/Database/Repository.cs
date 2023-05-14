using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookList.Constants;
using BookList.Entities;

namespace BookList.Database
{
    class Repository
    {
        private readonly SQLiteConnection _database;

        public Repository()
        {
            _database = new SQLiteConnection(Constants.Constants.DatabasePath);
            _database.CreateTable<BookBase>();
        }

        public List<BookBase> ListBook()
        {
            return _database.Table<BookBase>().ToList();
        }

        public int CreateBook(BookBase book)
        {
            return _database.Insert(book);
        }

        public int UpdateBook(BookBase book)
        {
            return _database.Update(book);
        }
    }
}
