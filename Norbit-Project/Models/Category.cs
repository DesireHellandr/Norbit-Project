namespace Norbit_Project.Models
{
    public class Category
    {
        private int Id { get; set; }
        private string Name { get; set; }

        private string Description { get; set; }

        private int ParentCategoryId { get; set; }

        public Category(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
