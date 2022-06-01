using DddStore.Core.DomainObjects;


namespace DddStore.Catalogo.Domain
{
    public class Produto : Entity
    {
        public string? Nome { get; private set; }
        public string? Descricao { get; private set; }
        public bool Ativo { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public string? Imagem { get; private set; }
        public int QuantidadeEstoque { get; private set; }
        public Dimensoes Dimensoes { get; private set; }
        public Guid CategoriaId { get; set; }
        public Categoria? Categoria { get; private set; }

        public Produto(string nome, string descricao, bool ativo, decimal valor, Guid categoriaId, DateTime dataCadastro, string imagem, Dimensoes dimensoes)
        {
            CategoriaId = categoriaId;
            Nome = nome;
            Descricao = descricao;
            Ativo = ativo;
            Valor = valor;
            DataCadastro = dataCadastro;
            Imagem = imagem;
            Dimensoes = dimensoes;

            Validar();
        }

        public void Ativar() => Ativo = true;
        public void Desativar() => Ativo = false;
        public void AlterarCategoria(Categoria categoria)
        { 
            Categoria = categoria;
            CategoriaId = categoria.Id;
        }
        public void AlterarDescricao(string descricao)
        {
            Validacoes.ValidarSeVazio(descricao, "O campo Descricao não pode estar vazio");
            Descricao = descricao;
        }
        public void DebitarEstoque(int quantidade)
        {
            if (QuantidadeEstoque < 0) quantidade *= -1;
            if (PossuiEstoque(quantidade)) throw new DomainException("Estoque insuficiente");

            QuantidadeEstoque -= quantidade;
        }
        public void ReporEstoque(int quantidade)
        {
            QuantidadeEstoque += quantidade;
        }
        public bool PossuiEstoque(int quantidade)
        {
            return QuantidadeEstoque >= quantidade;
        }
        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O Campo Nome não pode estar vazio");
            Validacoes.ValidarSeVazio(Descricao, "O Campo Descricao não pode estar vazio");
            Validacoes.ValidarSeVazio(Imagem, "O Campo Imagem não pode estar vazio");
            Validacoes.ValidarSeDiferente(CategoriaId,Guid.Empty, "O Campo CategoriaId tem que ser diferente de zero");
            Validacoes.ValidarSeMenorIgualMinimo(Valor,0, "O Campo Valor não pode ser menor ou igual a zero");
        }
    }
}
