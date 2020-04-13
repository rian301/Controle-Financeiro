using ControleFinanceiro.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFinanceiro.Map
{
    public class UserMap : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(x => x.Id);

            //builder.Ignore(x => x.ValidationResult);
            //builder.Ignore(x => x.CascadeMode);
        }
    }
}

