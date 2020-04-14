using ControleFinanceiro.Data;
using ControleFinanceiro.DTO;
using ControleFinanceiro.Models;

namespace ControleFinanceiro.Model.Service
{
    public class UserCategoryService
    {
        private readonly DataContext _context;

        public UserCategoryService(DataContext context)
        {
            _context = context;
        }

        public UserCategoryModel CrateUserCategory(UserCategoryDTO dto)
        {
            UserCategoryModel newUserCategory = new UserCategoryModel(dto.UserId, dto.CategoryId);

            _context
                .UserCategory
                .Add(newUserCategory);
            
            _context.SaveChanges();

            return newUserCategory;
        }
    }
}
