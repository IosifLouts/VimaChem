using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VimaChem.Interfaces
{
    public interface IUserRepository
    {
        public void AddANewUser(); //Create a new user
        public void UpdateUserRole(int id); //Update user role (from simple to admin)
    }
}
