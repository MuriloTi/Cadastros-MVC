using Core.DTOs;

namespace Cadastros.Application.ViewModels
{
    public class CidadesViewModel
    {
        public CidadesViewModel(List<CidadeDTO> cidades)
        {
            Cidades = cidades;
        }

        public List<CidadeDTO> Cidades { get; set; }

        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string UF { get; set; }
    }
}
