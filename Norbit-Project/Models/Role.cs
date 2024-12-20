namespace Norbit_Project.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public int Permission { get; set; }

        
    }
}
