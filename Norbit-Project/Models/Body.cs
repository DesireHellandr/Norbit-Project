namespace Norbit_Project.Models
{
    public class Body
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private string img;
        public string Img
        {
            get { return img; }
            set { img = value; }
        }

        private string schematicImg;
        public string SchematicImg
        {
            get { return schematicImg; }
            set { schematicImg = value; }
        }

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
