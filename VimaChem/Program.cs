using System;
using VimaChem.models;
using VimaChem.Interfaces;
using VimaChem.Repositories;

namespace VimaChem
{
   public class Program
   {
        private IRolesRepository iRolesRepository;
        private IUserRepository iUserRepository;
        private IBookCategoryRepository iBookCategoryRepository;
        private IBookRepository iBookRepository;

        public Program(IRolesRepository rolesRepository, IUserRepository userRepository, IBookCategoryRepository iBookCategoryRepository, IBookRepository iBookRepository)
        {
            this.iRolesRepository = rolesRepository;
            this.iUserRepository = userRepository;
            this.iBookCategoryRepository = iBookCategoryRepository;
            this.iBookRepository = iBookRepository;
        }
        static void Main(string[] args)
        {           
            Program program = new Program(new RolesRepository(), new UserRepository(), new BookCategoryRepository(), new BookRepository());
            program.GetDefaultData();
            program.getBooks();
            
        }

        public void getBooks()
        {
            iBookRepository.ShowBooks();
        }


        
        public void GetDefaultData()
        {
            Console.WriteLine("Adding Default Data to the DB...");
            using (var db = new DataBaseContext())
            {
                //Adding users

                var user1 = new User
                {
                    Id = 1,
                    Name = "Iosif",
                    Surname = "Louts",
                    RoleId = 1
                };
                db.User.Add(user1);

                var user2 = new User
                {
                    Id = 2,
                    Name = "Dimosthenis",
                    Surname = "Ioannou",
                    RoleId = 2
                };
                db.User.Add(user2);

                var user3 = new User
                {
                    Id = 3,
                    Name = "Giorgos",
                    Surname = "Kefaloglou",
                    RoleId = 2
                };
                db.User.Add(user3);

                //Adding user roles

                var role1 = new Role
                {
                    RoleId = 1,
                    Name = "Admin"
                };
                db.Role.Add(role1);

                var role2 = new Role
                {
                    RoleId = 2,
                    Name = "Simple"
                };
                db.Role.Add(role2);

                //Adding books

                var book1 = new Book
                {
                    Id = 1,
                    Name = "The name of the Rose",
                    CategoryId = 1
                };
                db.Book.Add(book1);

                var book2 = new Book
                {
                    Id = 2,
                    Name = "Communist Manifesto",
                    CategoryId = 2
                };
                db.Book.Add(book2);

                var book3 = new Book
                {
                    Id = 3,
                    Name = "Night Terror",
                    CategoryId = 3
                };
                db.Book.Add(book3);

                var book4 = new Book
                {
                    Id = 4,
                    Name = "Fluid Physics",
                    CategoryId = 4
                };
                db.Book.Add(book4);

                //Adding Book Categories

                var category1 = new BookCategory
                {
                    CategoryId = 1,
                    Name = "Drama"
                };
                db.BookCategory.Add(category1);

                var category2 = new BookCategory
                {
                    CategoryId = 2,
                    Name = "Politics/Political science"
                };
                db.BookCategory.Add(category2);

                var category3 = new BookCategory
                {
                    CategoryId = 3,
                    Name = "Thriller/Terror"
                };
                db.BookCategory.Add(category3);

                var category4 = new BookCategory
                {
                    CategoryId = 4,
                    Name = "Science"
                };
                db.BookCategory.Add(category4);

                //Save default data to the database

                db.SaveChanges();
                Console.WriteLine("Saving changes...");
            }
        }
   }

   
}