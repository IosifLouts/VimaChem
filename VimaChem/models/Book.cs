using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VimaChem.models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "BookCategory")]
        public virtual int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual BookCategory BookCategories { get; set; }
    }
}
