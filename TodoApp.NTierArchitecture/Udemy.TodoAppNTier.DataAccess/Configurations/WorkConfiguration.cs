using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.TodoAppNTier.Entities.Domains;

namespace Udemy.TodoAppNTier.DataAccess.Configurations
{
    public class WorkConfiguration : IEntityTypeConfiguration<Work>
    {
        public void Configure(EntityTypeBuilder<Work> builder)
        {
            //Burada biz proportylerimizi veritabanındaymış gibi özellikler tanımlayacağız
            //Kısaca Configure edeceğiz

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Definition).HasMaxLength(300);
            builder.Property(x => x.Definition).IsRequired(true);

            builder.Property(x => x.IsCompleted).IsRequired(true);

            //Şimdi bu Confgiureleri ayarladıktan sonra TodoContext'ten yani context klasöründen
            //Bu tabloyu artık OnModelCreating'den ayarlıyoruz.
        }
    }
}
