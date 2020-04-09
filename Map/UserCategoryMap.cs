using ControleFinanceiro.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFinanceiro.Map
{
    public class UserCategoryMap : IEntityTypeConfiguration<UserCategoryModel>
    {

        public void Configure(EntityTypeBuilder<UserCategoryModel> builder)
        {
            builder.ToTable("Usuario_Categoria");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.User).WithMany(y => y.Categories).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Category).WithMany().HasForeignKey(x => x.CategoryId);

        }
    }
}
