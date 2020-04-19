using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BonsaiWebApp.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Bonsai> Bonsais { get; set; }


        /*
         * el metodo onModelCreating que nos va a permitir mapear 
         * nuestras entidades con la base de datos y le enviamos como
         * parametro un objeto que instancia la clase ModelBuilder
         */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region category
            modelBuilder.Entity<Category>(entity => {
                entity.ToTable("category");
                entity.HasKey(e => e.CategoryId);
                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.Name)
                .HasColumnName("name")
                .IsUnicode(false);

                entity.Property(e => e.Description)
                .HasColumnName("description")
                .IsUnicode(false);
                /* isUnicode(false): indica que la columna se almacenara cono varchar en lugar de nvarchar*/

                entity.Property(e => e.Status)
                .HasColumnName("status")
                .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDeleted)
                .HasColumnName("isDeleted")
                .HasDefaultValueSql("((0))");

                entity.Property(e => e.CreateAt)
                .HasColumnName("createAt")
                .HasColumnType("datetime2");

                entity.Property(e => e.UpdateAt)
                .HasColumnName("updateAt")
                .HasColumnType("datetime2");

                entity.Property(e => e.DeleteAt)
                .HasColumnName("deleteAt")
                .HasColumnType("datetime2");
            });
            #endregion

            #region bonsai
            modelBuilder.Entity<Bonsai>(entity => {
                entity.ToTable("bonsai");
                entity.HasKey(e => e.BonsaiId);
                entity.Property(e => e.BonsaiId).HasColumnName("bonsaiId");

                entity.Property(e => e.Name)
                .HasColumnName("name")
                .IsUnicode(false);

                entity.Property(e => e.Description)
                .HasColumnName("description")
                .IsUnicode(false);
                /* isUnicode(false): indica que la columna se almacenara cono varchar en lugar de nvarchar*/

                entity.Property(e => e.Code)
                .HasColumnName("code")
                .IsUnicode(false);

                entity.Property(e => e.IsDeleted)
                .HasColumnName("isDeleted")
                .HasDefaultValueSql("((0))");

                entity.Property(e => e.CreateAt)
                .HasColumnName("createAt")
                .HasColumnType("datetime2");

                entity.Property(e => e.UpdateAt)
                .HasColumnName("updateAt")
                .HasColumnType("datetime2");

                entity.Property(e => e.DeleteAt)
                .HasColumnName("deleteAt")
                .HasColumnType("datetime2");

                entity.HasOne(b => b.Category)
                .WithMany(c => c.Bonsais)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_bonsai_categoria");
            });
            #endregion
        }


    }
}
