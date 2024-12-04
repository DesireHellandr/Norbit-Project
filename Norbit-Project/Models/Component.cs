namespace Norbit_Project.Models
{
    public class Component
    {
        private int Id { get; set; }

        private string Name { get; set; }
        private string Note { get; set; }

        private double Price { get; set; }

        private string DateAudit { get; set; }

        private string Img {  get; set; }

        private string PinoutImg { get; set; }

        private int PlaceId { get; set; }

        private int BodyId { get; set; } 

        private int CategoryId { get; set; }

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
    }
}
