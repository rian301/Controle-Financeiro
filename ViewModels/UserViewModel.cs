using ControleFinanceiro.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ControleFinanceiro.ViewModels
{
    public class UserViewModel

    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public float Salary { get; set; }

        public float Balance { get; set; }

        public IList<UserCategoryModelViewModel> UserCategories { get; set; }


        public UserViewModel()
        {

        }

        public UserViewModel(int id, float balance, float salary)
        {
            Id = id;
            Balance = balance;
            Salary = salary;
        }

    }
}
