using DddStore.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DddStore.Catalogo.Domain
{
    public class Dimensoes
    {
        public decimal Altura { get; private set; }
        public decimal Largura { get; private set; }
        public decimal Profundidade { get; private set; }

        private Dimensoes()
        {

        }

        public Dimensoes(decimal altura, decimal largura, decimal profundidade)
        {
            Validacoes.ValidarSeMenorQue(altura, 1, "O campo altura precisa ser maior que 1");
            Validacoes.ValidarSeMenorQue(largura, 1, "O campo largura precisa ser maior que 1");
            Validacoes.ValidarSeMenorQue(profundidade, 1, "O campo profundidade precisa ser maior que 1");

            Altura = altura;
            Largura = largura;
            Profundidade = profundidade;
        }

        public string DescricaoFormatada()
        {
            return $"LxAxP: {Largura} x {Altura} x {Profundidade}";
        }

        public override string ToString()
        {
            return DescricaoFormatada();
        }
    }
}
