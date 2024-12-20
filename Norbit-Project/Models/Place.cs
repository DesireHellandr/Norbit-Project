namespace Norbit_Project.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Place
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Location { get; set; }


        public Place() { }

        public Place(int id, string name, string location)
        {
            Id = id;
            Name = name;
            Location = location;
        }
    }
}
