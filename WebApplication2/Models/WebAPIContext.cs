using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebApplication2.Models
{
    public partial class WebAPIContext : DbContext
    {
        public WebAPIContext()
        {
        }

        public WebAPIContext(DbContextOptions<WebAPIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
/*#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-54595IM;Database=WebAPI;Trusted_Connection=True;");*/
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(e => e.ItCode)
                    .HasName("PK__Item__E66AD380B27EB96E");

                entity.ToTable("Item");

                entity.Property(e => e.ItCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ItDesc)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.ItRate).HasColumnType("decimal(18, 3)");

                entity.HasOne(d => d.SuplNoNavigation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.SuplNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SuplNo");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.SuplNo)
                    .HasName("PK__Supplier__F18078990200BCF3");

                entity.ToTable("Supplier");

                entity.Property(e => e.SuplNo).ValueGeneratedNever();

                entity.Property(e => e.SuplAddr).IsUnicode(false);

                entity.Property(e => e.SuplName)
                    .IsRequired()
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
