using Core.DTOs;

namespace Cadastros.Application.ViewModels
{
    public class RelatorioClientesViewModel
    {
        public RelatorioClientesViewModel(List<CidadeItem> cidades)
        {
            Cidades = cidades;
        }

        public List<CidadeItem> Cidades { get; set; }

        public class CidadeItem
        {
            public string Cidade { get; set; }
            public string UF { get; set; }
            public List<ClienteDTO> Clientes { get; set; }
        }
    }
}
