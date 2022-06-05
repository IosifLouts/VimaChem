using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VimaChem.Interfaces;
using VimaChem.models;

namespace VimaChem.Repositories
{
    public class UserRepository : IUserRepository
    {

        public UserRepository()
        {

        }

        public void AddANewUser()
        {
            //Insert User Data from the console

            Console.WriteLine("Adding a new User...");
            Console.WriteLine("Provide Name:");
            var name = Console.ReadLine();
            Console.WriteLine("Provide Surname:");
            var surname = Console.ReadLine();
            Console.WriteLine("Press 1 for an Admin user or anything else for a Simple user:");
            var role = Console.ReadLine();
            int roleId = 1; //Default admin
            if(role != "1") //If not admin then simple
            {
                roleId = 2;
            }
            using (DataBaseContext db = new DataBaseContext())
            {
                var user = new User
                {
                    Id = 0,
                    Name = name,
                    Surname = surname,
                    RoleId = roleId
                };

                //Check if user's name already exist in the DB
                var NameAlreadyExists = from b in db.User
                                        where b.Name == user.Name
                                        select b.Name;

                //Check if user's surname already exist in the DB
                var SurnameAlreadyExists = from b in db.User
                                           where b.Surname == user.Surname
                                           select b.Surname;

                if (NameAlreadyExists != null && SurnameAlreadyExists != null) // if both already exist, prevent the user from being added.
                {
                    string text = String.Format("The user with the Name: {0} and the Surname: {1}",NameAlreadyExists, SurnameAlreadyExists);
                    Console.WriteLine(text);
                }
                else
                {
                    db.User.Add(user);
                    db.SaveChanges();
                }     
            }    
        }

        public void UpdateUserRole(int id)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                // return the RoleId of the specific user

                var user = (from b in db.User
                           where b.Id == id
                           select b).FirstOrDefault();

                if (user == null) throw new Exception("The user does not exist"); // throw an exception if the user does not exist

                if (user.RoleId == 1) //If it is already in admin role, then inform the user
                {
                    Console.WriteLine("This user is already an admin user. As a result the role cannot be updated.");
                }
                else // if it is a simple user, then changes its RoleId to 1 ans inform the user
                {
                    user.RoleId = 1;
                    db.SaveChanges();
                    Console.WriteLine("The user has been successfully updated!");
                }
                             
            }
        }

    }
}
