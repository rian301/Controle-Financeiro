using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ControleFinanceiro.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Title { get; set; }

        public UserModel User { get; set; }

        [JsonIgnore]
        public virtual IList<AccountModel> Accounts { get; set; }

        public CategoryModel()
        {
            Accounts = new List<AccountModel>();
        }
    }
}
