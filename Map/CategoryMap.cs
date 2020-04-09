using ControleFinanceiro.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFinanceiro.Map
{
    public class CategoryMap : IEntityTypeConfiguration<CategoryModel>
    {

        public void Configure(EntityTypeBuilder<CategoryModel> builder)
        {
            builder.ToTable("Categoria");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId);
        }
    }
}
