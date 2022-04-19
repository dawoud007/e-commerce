using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bulkey.Models
{
   public class CoverType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [Display (Name ="cover type")]

        public string Name { get; set; }
    }
}
