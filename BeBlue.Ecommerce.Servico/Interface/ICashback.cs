namespace BeBlue.Ecommerce.Servico.Interface
{
    public interface ICashback
    {
        decimal BuscarDesconto(string genero, int diaSemana);
    }
}
