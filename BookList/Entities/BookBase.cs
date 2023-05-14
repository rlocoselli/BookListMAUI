namespace BookList.Entities
{
    public class BookBase
    {
        public BookBase(string bookName, BookType bookType, int id)
        {
            BookName = bookName;
            BookType = bookType;
            Id = id;
        }
        public BookBase()
        {

        }

        public String BookName { get; set; }
        public BookType BookType { get; set; }
        public int Id { get; set; }
    }
}