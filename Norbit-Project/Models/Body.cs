namespace Norbit_Project.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Body
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(255)]
        public string Img { get; set; }

        [StringLength(255)]
        public string SchematicImg { get; set; }

        public Body() { }

        public Body(int id, string name, string description, string img, string schematicImg)
        {
            Id = id;
            Name = name;
            Description = description;
            Img = img;
            SchematicImg = schematicImg;
        }
    }
}
