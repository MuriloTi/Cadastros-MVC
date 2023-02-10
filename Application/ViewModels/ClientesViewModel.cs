using Core.DTOs;

namespace Cadastros.Application.ViewModels
{
    public class ClientesViewModel
    {
        public ClientesViewModel(List<ClienteDTO> clientes, List<CidadeDTO> cidades)
        {
            Clientes = clientes;
            Cidades = cidades;
        }

        public List<ClienteDTO> Clientes { get; set; }
        public List<CidadeDTO> Cidades { get; set; }

        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public int CidadeId { get; set; }
        public string CEP { get; set; }
        public string Telefone { get; set; }
    }
}
