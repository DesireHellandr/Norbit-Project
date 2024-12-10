namespace Norbit_Project.Models
{
    public class Role
    {
        private int id;
        private string name;
        private int permission;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Permission
        {
            get { return permission; }
            set { permission = value; }
        }
    }
}
