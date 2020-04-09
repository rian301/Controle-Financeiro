namespace ControleFinanceiro.Models
{
    public class UserCategoryModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }

        public UserModel User { get; set; }
        public CategoryModel Category { get; set; }
    }
}
