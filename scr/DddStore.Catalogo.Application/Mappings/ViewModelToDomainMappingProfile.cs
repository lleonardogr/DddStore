using AutoMapper;
using DddStore.Catalogo.Application.ViewModels;
using DddStore.Catalogo.Domain;


namespace DddStore.Catalogo.Application.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProdutoViewModel, Produto>()
                .ConstructUsing(p => new Produto(p.Nome, p.Descricao, p.Ativo,
                p.Valor, p.CategoriaId, p.DataCadastro,
                p.Imagem, new Dimensoes(p.Altura, p.Largura, p.Profundidade)));

            CreateMap<CategoriaViewModel, Categoria>()
                .ConvertUsing(c => new Categoria(c.Nome, c.Codigo));
        }
    }
}
