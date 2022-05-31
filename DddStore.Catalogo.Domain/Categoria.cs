using DddStore.Core.DomainObjects;


namespace DddStore.Catalogo.Domain
{
    public class Categoria : Entity
    {
        public string? Nome { get; private set; }
        public string? Codigo { get; private set; }

        public Categoria(string nome, string codigo)
        {
            Nome = nome;
            Codigo = codigo;
        }

        public override string ToString()
        {
            return $"{Nome} - {Codigo}";
        }
    }
}
