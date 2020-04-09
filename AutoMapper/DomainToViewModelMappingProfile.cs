using AutoMapper;
using ControleFinanceiro.Models;
using ControleFinanceiro.ViewModels;

namespace ControleFinanceiro.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<CategoryModel, CategoryViewModel>().ReverseMap();
            CreateMap<AccountModel, AccountViewModel>().ReverseMap();
        }
    }
}
