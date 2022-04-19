using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace bulkey.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }    
        [DisplayName ("Display Order")]
        public int DisplayOrder { get; set; }
        public DateTime CreateDateTime { get; set; }=DateTime.Now;



    }
}
