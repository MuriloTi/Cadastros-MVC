namespace Core.Entities
{
    public class Cidade
    {
        public Cidade(string codigo, string nome, string uF)
        {
            Codigo = codigo;
            Nome = nome;
            UF = uF;
        }

        public int Id { get; private set; }
        public string Codigo { get; private set; }
        public string Nome { get; private set; }
        public string UF { get; private set; }

        public virtual List<Cliente> Clientes { get; set; }

        public void Update(string codigo, string nome, string uf)
        {
            Codigo = codigo;
            Nome = nome;
            UF = uf;
        }
    }
}
