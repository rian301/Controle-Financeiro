using System.Collections.Generic;

namespace ControleFinanceiro.ViewModels
{
    public class UserCategoryModelViewModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int CategoryId { get; set; }

        public IList<CategoryViewModel> Categories { get; set; }

        public UserCategoryModelViewModel()
        {
            Categories = new List<CategoryViewModel>();
        }

    }
}
