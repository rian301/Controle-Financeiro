using System;
using System.ComponentModel.DataAnnotations;

namespace ControleFinanceiro.DTO
{
    public class UserDTO
    {
        public Nullable<int> Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [EmailAddress]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail não é valido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Este camp,o é obrigatório")]
        [MaxLength(20, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        [RegularExpression(@"^\S*$", ErrorMessage = "Não é permitido espaços")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(8, ErrorMessage = "Este campo deve conter entre 6 e 8 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 6 e 8 caracteres")]
        [RegularExpression(@"^\S*$", ErrorMessage = "Não é permitido espaços")]
        public string Password { get; set; }

        public Nullable<float> Salary { get; set; }

    }
}
