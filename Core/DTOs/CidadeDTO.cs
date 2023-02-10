using Core.Entities;

namespace Core.DTOs
{
    public class CidadeDTO
    {
        public CidadeDTO(int id, string codigo, string nome, string uF)
        {
            Id = id;
            Codigo = codigo;
            Nome = nome;
            UF = uF;
        }

        public CidadeDTO(Cidade cidade)
        {
            Id = cidade.Id;
            Codigo = cidade.Codigo;
            Nome = cidade.Nome;
            UF = cidade.UF;
            Clientes = new List<ClienteDTO>();
            foreach (var cliente in cidade.Clientes)
            {
                Clientes.Add(new ClienteDTO(cliente, cidade));
            }
        }

        public int Id { get; private set; }
        public string Codigo { get; private set; }
        public string Nome { get; private set; }
        public string UF { get; private set; }

        public List<ClienteDTO> Clientes { get; set; }
    }
}
