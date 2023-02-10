namespace Cadastros.Application.InputModels
{
    public class CreateClienteInputModel
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public int CidadeId { get; set; }
        public string CEP { get; set; }
        public string Telefone { get; set; }
    }
}
