namespace ControleFinanceiro.ViewModels
{
    public class AccountViewModel
    {

        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public float Value { get; set; }

        public CategoryViewModel Category { get; set; }
    }
}
