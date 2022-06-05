using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VimaChem.Interfaces;
using VimaChem.models;

namespace VimaChem.Repositories
{
    public class BookCategoryRepository : IBookCategoryRepository
    {
        public BookCategoryRepository()
        {

        }

        public void DeleteCategory(string name)
        {
            using(var db = new DataBaseContext())
            {
                try
                {
                    // Search book category by name and remove the record
                    var bookCategory = (from b in db.BookCategory
                                        where b.Name == name
                                        select b).First();
                    
                    db.BookCategory.Remove(bookCategory);
                } 
                catch
                {
                    throw new Exception("Book category does not exists.");
                }             
            }
        }
    }
}
