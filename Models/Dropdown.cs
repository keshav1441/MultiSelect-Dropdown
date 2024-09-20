using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task_5.Models
{
    public class Dropdown
    {
        [Key]
        public int Id { get; set; } 

        [Required]
        [StringLength(100)] 
        public string Skill { get; set; } = string.Empty;
    }
}
