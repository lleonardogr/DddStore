using DddStore.Core.DomainObjects;
using System;
using Xunit;

namespace DddStore.Catalogo.Domain.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Produto_Validar_ValidacoesDevemRetornarExceptions()
        {
            var ex = Assert.Throws<DomainException>(() =>
                new Produto(string.Empty, "Descricao", false, 100,
                Guid.NewGuid(), DateTime.Now, "Imagem", new Dimensoes(1, 1, 1)));

            Assert.Equal("O campo Nome não pode estar vazio", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Produto("Produto", String.Empty, false, 100,
                Guid.NewGuid(), DateTime.Now, "Imagem", new Dimensoes(1, 1, 1)));

            Assert.Equal("O campo Descrição não pode estar vazio", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Produto("Produto", "Descrição", false, 0,
                Guid.NewGuid(), DateTime.Now, "Imagem", new Dimensoes(1, 1, 1)));

            Assert.Equal("O campo Valor não pode ser menor ou igual a zero", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Produto("Produto", "Descrição", false, 100,
                Guid.Empty, DateTime.Now, "Imagem", new Dimensoes(1, 1, 1)));

            Assert.Equal("O campo CategoriaId não pode estar vazio", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Produto("Produto", "Descrição", false, 100,
                Guid.NewGuid(), DateTime.Now, String.Empty, new Dimensoes(1, 1, 1)));

            Assert.Equal("O campo Imagem não pode estar vazio", ex.Message);
        }
    }
}