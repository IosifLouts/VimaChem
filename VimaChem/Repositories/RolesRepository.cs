using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VimaChem.Interfaces;
using VimaChem.models;

namespace VimaChem.Repositories
{
    public class RolesRepository : IRolesRepository
    {
        public RolesRepository()
        {

        }
        public void ShowRoles()
        {
            using (var db = new DataBaseContext())
            {
                var query = from b in db.Role
                            select b;
                foreach (var item in query)
                {
                    var text = String.Format("Role Name: {0}", item.Name);
                    Console.WriteLine(text);
                }
            }
        }
    }
}
