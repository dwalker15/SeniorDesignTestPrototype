using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SeniorDesignTestPrototype.Models
{
    public partial class PrototypeDatabaseContext : DbContext
    {
        public PrototypeDatabaseContext()
        {
        }

        public PrototypeDatabaseContext(DbContextOptions<PrototypeDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TNotes> TNotes { get; set; }
        public virtual DbSet<TPrototype> TPrototype { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:prototypetestserver.database.windows.net,1433;Initial Catalog=Prototype Database;Persist Security Info=False;User ID=djw0017;Password=Djdwa35393696!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<TNotes>(entity =>
            {
                entity.HasKey(e => e.INoteId)
                    .HasName("PK__tNotes__FE4627EC7E87C02A");

                entity.ToTable("tNotes");

                entity.Property(e => e.INoteId)
                    .HasColumnName("iNoteID")
                    .ValueGeneratedNever();

                entity.Property(e => e.IPrototypeId).HasColumnName("iPrototypeID");

                entity.Property(e => e.VcNote)
                    .IsRequired()
                    .HasColumnName("vcNote")
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.HasOne(d => d.IPrototype)
                    .WithMany(p => p.TNotes)
                    .HasForeignKey(d => d.IPrototypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tNotes__iPrototy__4E88ABD4");
            });

            modelBuilder.Entity<TPrototype>(entity =>
            {
                entity.HasKey(e => e.IPrototypeId)
                    .HasName("PK__tPrototy__291448A866534164");

                entity.ToTable("tPrototype");

                entity.Property(e => e.IPrototypeId)
                    .HasColumnName("iPrototypeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.VcDataCollection)
                    .IsRequired()
                    .HasColumnName("vcDataCollection")
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.VcPosture)
                    .IsRequired()
                    .HasColumnName("vcPosture")
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.VcTorqueType)
                    .IsRequired()
                    .HasColumnName("vcTorqueType")
                    .HasMaxLength(1024)
                    .IsUnicode(false);
            });
        }
    }
}
