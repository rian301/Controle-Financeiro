using AutoMapper;
using ControleFinanceiro.DTO;
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
            CreateMap<UserModel, UserViewModel>().ReverseMap();
            CreateMap<UserCategoryModel, UserCategoryModelViewModel>().ReverseMap();
            CreateMap<UserDTO, UserModel>().ReverseMap();
        }
    }
}
