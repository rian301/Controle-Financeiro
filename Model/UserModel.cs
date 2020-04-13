using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ControleFinanceiro.Models
{
    public class UserModel
    {
        public UserModel(float balance)
        {
            Balance = balance;
        }

        public int Id { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public float Salary { get; set; }

        public float Balance { get; set; }

        public IList<UserCategoryModel> Categories { get; set; }

    }
}

