namespace Norbit_Project.Models
{
    public class User
    {
        private int id;
        private string name;
        private string email;
        private string password;
        private int roleId;

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

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public int RoleId
        {
            get { return roleId; }
            set { roleId = value; }
        }
    }
}
