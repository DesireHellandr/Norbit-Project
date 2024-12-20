namespace Norbit_Project.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Component
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Note { get; set; }

        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        [StringLength(50)]
        public string DateAudit { get; set; }

        [StringLength(255)]
        public string Img { get; set; }

        [StringLength(255)]
        public string PinoutImg { get; set; }

        public int PlaceId { get; set; }
        public int BodyId { get; set; }

        public int? CategoryId { get; set; }

        public Component(int id, string name, string note, double price, string dateAudit, string img, string pinoutImg, int placeId, int bodyId, int? categoryId)
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

        public Component(string name, string note, double price, string dateAudit, string img, string pinoutImg, int placeId, int bodyId, int? categoryId)
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
