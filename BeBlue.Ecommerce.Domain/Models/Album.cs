namespace BeBlue.Ecommerce.Domain.Models
{
    public class Album :BaseEntity
    {
        public string KeyDisc { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Genre { get; set; }
    }
}
