using System;

namespace ControleFinanceiro.DTO
{
    public class UserCategoryDTO
    {
        public Nullable<int> Id { get; set; }

        public int UserId { get; set; }

        public int CategoryId { get; set; }
    }
}
