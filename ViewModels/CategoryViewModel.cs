using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ControleFinanceiro.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string User { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(20, ErrorMessage = "Este campo deve conter entre 3 e 20 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 20 caracteres")]
        public string Title { get; set; }

        public virtual IList<AccountViewModel> Contas { get; set; }
    }
}
