using System.Runtime.ConstrainedExecution;

namespace Core.Entities
{
    public class Cliente
    {
        public Cliente(string codigo, string nome, string endereco, string bairro, int cidadeId, string cEP, string telefone)
        {
            Codigo = codigo;
            Nome = nome;
            Endereco = endereco;
            Bairro = bairro;
            CidadeId = cidadeId;
            CEP = cEP;
            Telefone = telefone;
        }

        public int Id { get; private set; }
        public string Codigo { get; private set; }
        public string Nome { get; private set; }
        public string Endereco { get; private set; }
        public string Bairro { get; private set; }
        public int CidadeId { get; private set; }
        public string CEP { get; private set; }
        public string Telefone { get; private set; }

        public virtual Cidade Cidade { get; set; }

        public void Update(string codigo, string nome, string endereco, string bairro, int cidadeId, string cep, string telefone)
        {
            Codigo = codigo;
            Nome = nome;
            Endereco = endereco;
            Bairro = bairro;
            CidadeId = cidadeId;
            CEP = cep;
            Telefone = telefone;
        }
    }
}
