namespace Norbit_Project.Models
{
    public class Component
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

        private string note;
        public string Note
        {
            get { return note; }
            set { note = value; }
        }

        private double price;
        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        private string dateAudit;
        public string DateAudit
        {
            get { return dateAudit; }
            set { dateAudit = value; }
        }

        private string img;
        public string Img
        {
            get { return img; }
            set { img = value; }
        }

        private string pinoutImg;
        public string PinoutImg
        {
            get { return pinoutImg; }
            set { pinoutImg = value; }
        }

        private int placeId;
        public int PlaceId
        {
            get { return placeId; }
            set { placeId = value; }
        }

        private int bodyId;
        public int BodyId
        {
            get { return bodyId; }
            set { bodyId = value; }
        }

        private int? categoryId;
        public int? CategoryId
        {
            get { return categoryId; }
            set { categoryId = value; }
        }

        public Component(int id, string name, string note, double price, string dateAudit, string img, string pinoutImg, int placeId, int bodyId, int categoryId)
        {
            Id = id;
            Name = name;
            Note = note;
            Price = price;
            DateAudit = dateAudit;
            Img = img;
            PinoutImg = pinoutImg;
            PlaceId = placeId;
            BodyId = bodyId;
            CategoryId = categoryId;
        }

        public Component(string name, string note, double price, string dateAudit, string img, string pinoutImg, int placeId, int bodyId, int categoryId)
        {
            Id = 0;
            Name = name;
            Note = note;
            Price = price;
            DateAudit = dateAudit;
            Img = img;
            PinoutImg = pinoutImg;
            PlaceId = placeId;
            BodyId = bodyId;
            CategoryId = categoryId;
        }
        public Component() { }
    }
}
