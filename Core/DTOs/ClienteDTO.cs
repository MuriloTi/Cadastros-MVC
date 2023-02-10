using Core.Entities;

namespace Core.DTOs
{
    public class ClienteDTO
    {
        public ClienteDTO(int id, string codigo, string nome, string endereco, string bairro, int cidadeId, string cidade, string uF, string cEP, string telefone)
        {
            Id = id;
            Codigo = codigo;
            Nome = nome;
            Endereco = endereco;
            Bairro = bairro;
            CidadeId = cidadeId;
            Cidade = cidade;
            UF = uF;
            CEP = cEP;
            Telefone = telefone;
        }
        public ClienteDTO(Cliente cliente, Cidade cidade)
        {
            Id = cliente.Id;
            Codigo = cliente.Codigo;
            Nome = cliente.Nome;
            Endereco = cliente.Endereco;
            Bairro = cliente.Bairro;
            CidadeId = cidade.Id;
            Cidade = cidade.Nome;
            UF = cidade.UF;
            CEP = cliente.CEP;
            Telefone = cliente.Telefone;
        }

        public int Id { get; private set; }
        public string Codigo { get; private set; }
        public string Nome { get; private set; }
        public string Endereco { get; private set; }
        public string Bairro { get; private set; }
        public int CidadeId { get; private set; }
        public string Cidade { get; private set; }
        public string UF { get; private set; }
        public string CEP { get; private set; }
        public string Telefone { get; private set; }

        public string GetEnderecoCompleto()
        {
            return CEP + ", " + Endereco + ", " + Bairro;
        }
    }
}
