using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OgrenciDanismanTakip.Models;

public partial class OgrenciDanismanDbContext : DbContext
{
    public OgrenciDanismanDbContext()
    {
    }

    public OgrenciDanismanDbContext(DbContextOptions<OgrenciDanismanDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Danisman> Danismen { get; set; }

    public virtual DbSet<Ogrenci> Ogrencis { get; set; }

    public virtual DbSet<ProjeRaporu> ProjeRaporus { get; set; }

    public virtual DbSet<Randevu> Randevus { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=OgrenciDanismanDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Danisman>(entity =>
        {
            entity.HasKey(e => e.DanismanId).HasName("PK__Danisman__4DEC788E9CB4308D");

            entity.ToTable("Danisman");

            entity.Property(e => e.DanismanId)
                .ValueGeneratedNever()
                .HasColumnName("danisman_id");
            entity.Property(e => e.AdSoyad)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ad_soyad");
            entity.Property(e => e.Bolum)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("bolum");
            entity.Property(e => e.Unvan)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("unvan");
        });

        modelBuilder.Entity<Ogrenci>(entity =>
        {
            entity.HasKey(e => e.OgrenciId).HasName("PK__Ogrenci__8B48F2801ABBB017");

            entity.ToTable("Ogrenci");

            entity.HasIndex(e => e.Eposta, "UQ__Ogrenci__2549FEE62ACA39E5").IsUnique();

            entity.Property(e => e.OgrenciId)
                .ValueGeneratedNever()
                .HasColumnName("ogrenci_id");
            entity.Property(e => e.AdSoyad)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ad_soyad");
            entity.Property(e => e.DanismanId).HasColumnName("danisman_id");
            entity.Property(e => e.Eposta)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("eposta");

            entity.HasOne(d => d.Danisman).WithMany(p => p.Ogrencis)
                .HasForeignKey(d => d.DanismanId)
                .HasConstraintName("FK__Ogrenci__danisma__4D94879B");
        });

        modelBuilder.Entity<ProjeRaporu>(entity =>
        {
            entity.HasKey(e => e.RaporId).HasName("PK__ProjeRap__F920D2919781E16B");

            entity.ToTable("ProjeRaporu");

            entity.Property(e => e.RaporId)
                .ValueGeneratedNever()
                .HasColumnName("rapor_id");
            entity.Property(e => e.DanismanId).HasColumnName("danisman_id");
            entity.Property(e => e.DosyaYolu)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("dosya_yolu");
            entity.Property(e => e.Geribildirim)
                .HasColumnType("text")
                .HasColumnName("geribildirim");
            entity.Property(e => e.NotDegeri).HasColumnName("not_degeri");
            entity.Property(e => e.OgrenciId).HasColumnName("ogrenci_id");

            entity.HasOne(d => d.Danisman).WithMany(p => p.ProjeRaporus)
                .HasForeignKey(d => d.DanismanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProjeRapo__danis__5629CD9C");

            entity.HasOne(d => d.Ogrenci).WithMany(p => p.ProjeRaporus)
                .HasForeignKey(d => d.OgrenciId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProjeRapo__ogren__5535A963");
        });

        modelBuilder.Entity<Randevu>(entity =>
        {
            entity.HasKey(e => e.RandevuId).HasName("PK__Randevu__98699B29F739EB18");

            entity.ToTable("Randevu");

            entity.Property(e => e.RandevuId)
                .ValueGeneratedNever()
                .HasColumnName("randevu_id");
            entity.Property(e => e.DanismanId).HasColumnName("danisman_id");
            entity.Property(e => e.Durum)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Beklemede")
                .HasColumnName("durum");
            entity.Property(e => e.OgrenciId).HasColumnName("ogrenci_id");
            entity.Property(e => e.TarihSaat)
                .HasColumnType("datetime")
                .HasColumnName("tarih_saat");

            entity.HasOne(d => d.Danisman).WithMany(p => p.Randevus)
                .HasForeignKey(d => d.DanismanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Randevu__danisma__52593CB8");

            entity.HasOne(d => d.Ogrenci).WithMany(p => p.Randevus)
                .HasForeignKey(d => d.OgrenciId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Randevu__ogrenci__5165187F");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
