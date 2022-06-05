using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VimaChem.models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        //Foreign Key
        [Required]
        [Display(Name = "Role")]
        public virtual int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public virtual Role Roles { get; set; }
    }
}
