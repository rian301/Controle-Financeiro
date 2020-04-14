namespace ControleFinanceiro.Models
{
    public class UserCategoryModel
    {
        public int Id { get; private set; }

        public int UserId { get; private set; }

        public int CategoryId { get; private set; }

        public UserModel User { get; set; }
        public CategoryModel Category { get; set; }

        public UserCategoryModel()
        {

        }

        public UserCategoryModel(int idUser, int idCategory)
        {
            UserId = idUser;
            CategoryId = idCategory;
        }
    }
}
