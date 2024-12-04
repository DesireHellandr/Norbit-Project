namespace Norbit_Project.Models
{
    public class Place
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

        private string location;
        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        public Place(int id, string name, string location)
        {
            Id = id;
            Name = name;
            Location = location;
        }
    }
}
