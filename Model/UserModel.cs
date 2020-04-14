using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ControleFinanceiro.Models
{
    public class UserModel
    {
        public int Id { get; private set; }

        public string Email { get; private set; }

        public string UserName { get; private set; }

        public string Password { get; private set; }

        public float Salary { get; private set; }

        public IList<UserCategoryModel> Categories { get; set; }


        public UserModel(string email, string userName, string password, float salary)
        {
            Email = email;
            UserName = userName;
            Password = password;
            Salary = salary;

            Categories = new List<UserCategoryModel>();
        }

        public void Update(string email, string userName, string password, float? salary)
        {
            Email = email;
            UserName = userName;
            Password = password;
            Salary = salary == null? Salary : salary.Value;

        }
    }
}

