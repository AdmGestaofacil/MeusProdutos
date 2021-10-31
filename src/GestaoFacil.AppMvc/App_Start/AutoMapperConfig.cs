using AutoMapper;
using GestaoFacil.AppMvc.ViewModels;
using GestaoFacil.Business.Models.Fornecedores;
using GestaoFacil.Business.Models.Produtos;
using System;
using System.Linq;
using System.Reflection;

namespace GestaoFacil.AppMvc
{
    public class AutoMapperConfig
    {
        /*configuração para ja fazer o mapeamento logo na iniciaçização da aplicação
         * obtendo os assembles do tipo profiles... no finalvamos ter uma coleção de classes do tipo
         * profiles..
         * .*/
        public static MapperConfiguration GetMapperConfiguration()
        {
            var profiles = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(x => typeof(Profile).IsAssignableFrom(x));


            return new MapperConfiguration(cfg =>
            {
                foreach (var profile in profiles)
                {
                    cfg.AddProfile(Activator.CreateInstance(profile) as Profile);
                }
            });
        }
    }

    public class AutoMapperProfile : Profile
    {
        //mapeando classes.
        public AutoMapperProfile()
        {

            /*
              mapeando de entidade para ViewModel
              .ReverseMap() => posso usar quando todos os campos são iguals de um lado para o outro...
              mas caso seja diferente eu separado ex:
              CreateMap<FornecedorViewModels, Fornecedor>();
             */
            CreateMap<Fornecedor, FornecedorViewModels>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModels>().ReverseMap();
            CreateMap<Produto, EnderecoViewModels>().ReverseMap();

            
        }
    }
}