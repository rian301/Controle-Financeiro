using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ControleFinanceiro.Models
{
    public class CategoryModel
    {
        public int Id { get; private set; }

        public string Title { get; private set; }

        [JsonIgnore]
        public virtual IList<AccountModel> Accounts { get; set; }

        public CategoryModel()
        {
            Accounts = new List<AccountModel>();
        }

        public void SetTitle(string title)
        {
            Title = title;
        }
    }
}
