namespace Entidades
{
    public class Endereco
    {
        public int Endereco_ID { get; set; }
        public string PrimeiroNome { get; set; } = string.Empty;
        public string UltimoNome { get; set; } = string.Empty;
        public string Rua { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public string Cep { get; set; } = string.Empty;
        public string Pais { get; set; } = string.Empty;
        public int Usuario_ID { get; set; }
    }
}