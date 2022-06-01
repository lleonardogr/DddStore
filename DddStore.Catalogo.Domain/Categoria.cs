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
            Validar();
        }

        public override string ToString()
        {
            return $"{Nome} - {Codigo}";
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo Nome não pode estar vazio");
            Validacoes.ValidarSeDiferente(Codigo, 0, "O campo Codigo não pode ser 0");
        }
    }
}
