using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ControleFinanceiro.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public IList<UserCategoryModel> Categories { get; set; }

    }
}




//using ControleFinanceiro.Model.Entity;
//using FluentValidation;
//using System.Collections.Generic;

//namespace ControleFinanceiro.Models
//{
//    public class Usuario : Entity<Usuario>
//    {
//        public int Id { get; set; }

//        public string NomeUsuario { get; set; }

//        public string Senha { get; set; }

//        public IList<UsuarioCategoria> Categorias { get; set; }

//        public override bool IsValid()
//        {
//            RuleFor(x => x.NomeUsuario)
//            .NotEmpty().WithMessage("O nome não pode ser nulo")
//            .MinimumLength(3).WithMessage("O nome não pode ser menor que 3 caracteres");

//            ValidationResult = Validate(this);
//            return ValidationResult.IsValid;
//        }
//    }
//}
