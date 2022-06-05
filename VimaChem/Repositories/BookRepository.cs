using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VimaChem.Interfaces;
using VimaChem.models;

namespace VimaChem.Repositories
{
    public class BookRepository : IBookRepository
    {
        public BookRepository()
        {

        }
        public void ShowBooks()
        {
            using (var db = new DataBaseContext())
            {
                //Fetching the books from DB

                var books = from b in db.Book
                           orderby b.Name
                           select b;

                if (books == null) throw new Exception("There are no books stored in the database.");
                //Display books
                foreach(var item in books)
                {
                    var text = String.Format("The book with title: {0} belong to category: {1}", item.Name, item.BookCategories);
                    Console.WriteLine(text);
                }
            }
        }
    }
}
