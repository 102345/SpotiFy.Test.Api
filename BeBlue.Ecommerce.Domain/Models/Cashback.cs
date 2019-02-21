namespace BeBlue.Ecommerce.Domain.Models
{
    public class Cashback : BaseEntity
    {
        public string Genero { get; set; }
        public int DiaSemana { get; set; }
        public int Percentual { get; set; }
    }
}
