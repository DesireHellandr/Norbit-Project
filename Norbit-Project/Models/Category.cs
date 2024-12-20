namespace Norbit_Project.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public int? ParentCategoryId { get; set; }

        public Category() { }

        public Category(int id, string name, string description, int? parentCategoryId = null)
        {
            Id = id;
            Name = name;
            Description = description;
            ParentCategoryId = parentCategoryId;
        }
    }
}
