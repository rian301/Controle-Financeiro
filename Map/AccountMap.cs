using ControleFinanceiro.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFinanceiro.Map
{
    public class AccountMap : IEntityTypeConfiguration<AccountModel>
    {

        public void Configure(EntityTypeBuilder<AccountModel> builder)
        {
            builder.ToTable("Conta");

            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Category).WithMany(y => y.Accounts).HasForeignKey(x => x.CategoryId);
        }
    }
}
