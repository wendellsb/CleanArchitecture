using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // informa que id vai ser a chave primaria da tabela
            builder.HasKey(t => t.Id); 

            // minha propriedade  vai ter o tamanho maximo de 100 caracteres e vai ser obrigatoria
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
        }
    }
}
