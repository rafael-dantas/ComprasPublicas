namespace ComprasPublicas.API
{
    public class ErroResponse
    {
        public ErroResponse()
        {
            Mensagem = "Algo deu errado, favor tentar operação mais tarde";
        }
        public string Mensagem { get; }
    }
}
