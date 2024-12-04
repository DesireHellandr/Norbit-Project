namespace Norbit_Project.Models
{
    public class Body
    {
        private int Id { get; set; }
        private string Name { get; set; }
        private string Description { get; set; }
        private string Img { get; set; }
        private string SchematicImg { get; set; }

        public Body (int id, string name, string description, string img, string schematicImg)
        {
            Id = id;
            Name = name;
            Description = description;
            Img = img;
            SchematicImg = schematicImg;
        }
    }
}
