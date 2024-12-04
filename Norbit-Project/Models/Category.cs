namespace Norbit_Project.Models
{
    public class Category
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

        private int parentCategoryId;
        public int ParentCategoryId
        {
            get { return parentCategoryId; }
            set { parentCategoryId = value; }
        }

        public Category(int _id, string _name, string _description)
        {
            id = _id;
            name = _name;
            description = _description;
        }
    }
}
