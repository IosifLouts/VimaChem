using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VimaChem.Interfaces
{
    public interface IBookCategoryRepository
    {
        public void DeleteCategory(string name);
    }
}
