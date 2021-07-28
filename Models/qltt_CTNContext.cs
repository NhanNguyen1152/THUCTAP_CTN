using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace thuctap_CTN.Models
{
    public partial class qltt_CTNContext : DbContext
    {
        public qltt_CTNContext()
        {
        }

        public qltt_CTNContext(DbContextOptions<qltt_CTNContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ad> Ad { get; set; }
        public virtual DbSet<Baigiang> Baigiang { get; set; }
        public virtual DbSet<Baigiangfile> Baigiangfile { get; set; }
        public virtual DbSet<Chitietbaigiang> Chitietbaigiang { get; set; }
        public virtual DbSet<Chitietlop> Chitietlop { get; set; }
        public virtual DbSet<Hocvien> Hocvien { get; set; }
        public virtual DbSet<Loaibaigiang> Loaibaigiang { get; set; }
        public virtual DbSet<Lop> Lop { get; set; }
        public virtual DbSet<Taikhoan> Taikhoan { get; set; }
        public virtual DbSet<Thoikhoabieu> Thoikhoabieu { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-BTNISNBQ;Database=qltt_CTN;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ad>(entity =>
            {
                entity.ToTable("AD");

                entity.Property(e => e.AdId)
                    .HasColumnName("AD_ID")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.AdPassword)
                    .HasColumnName("AD_PASSWORD")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.AdTen)
                    .HasColumnName("AD_TEN")
                    .HasMaxLength(50);

                entity.Property(e => e.AdUsername)
                    .HasColumnName("AD_USERNAME")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Baigiang>(entity =>
            {
                entity.HasKey(e => e.BgId)
                    .HasName("PK__BAIGIANG__1F3BF74CBD822F21");

                entity.ToTable("BAIGIANG");

                entity.Property(e => e.BgId)
                    .HasColumnName("BG_ID")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.BgTen)
                    .HasColumnName("BG_TEN")
                    .HasMaxLength(50);

                entity.Property(e => e.BgTrangthai)
                    .HasColumnName("BG_TRANGTHAI")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BgfId)
                    .HasColumnName("BGF_ID")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.LoaiId)
                    .HasColumnName("LOAI_ID")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.Bgf)
                    .WithMany(p => p.Baigiang)
                    .HasForeignKey(d => d.BgfId)
                    .HasConstraintName("FK_BAIGIANG_BAIGIANGFILE");

                entity.HasOne(d => d.Loai)
                    .WithMany(p => p.Baigiang)
                    .HasForeignKey(d => d.LoaiId)
                    .HasConstraintName("FK_BAIGIANG_LOAIBAIGIANG");
            });

            modelBuilder.Entity<Baigiangfile>(entity =>
            {
                entity.HasKey(e => e.BgfId)
                    .HasName("PK__BAIGIANG__B248032FF31CB171");

                entity.ToTable("BAIGIANGFILE");

                entity.Property(e => e.BgfId)
                    .HasColumnName("BGF_ID")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.BgfFile)
                    .HasColumnName("BGF_FILE")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.BgfTen)
                    .HasColumnName("BGF_TEN")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Chitietbaigiang>(entity =>
            {
                entity.HasKey(e => e.CtbgId)
                    .HasName("PK__CHITIETB__F3A7FDA879BCC627");

                entity.ToTable("CHITIETBAIGIANG");

                entity.Property(e => e.CtbgId)
                    .HasColumnName("CTBG_ID")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.BgId)
                    .HasColumnName("BG_ID")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.LId)
                    .HasColumnName("L_ID")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.Bg)
                    .WithMany(p => p.Chitietbaigiang)
                    .HasForeignKey(d => d.BgId)
                    .HasConstraintName("FK_CHITIETBAIGIANG_BAIGIANG");

                entity.HasOne(d => d.L)
                    .WithMany(p => p.Chitietbaigiang)
                    .HasForeignKey(d => d.LId)
                    .HasConstraintName("FK_CHITIETBAIGIANG_LOP");
            });

            modelBuilder.Entity<Chitietlop>(entity =>
            {
                entity.HasKey(e => e.CtlId)
                    .HasName("PK__CHITIETL__0AA6E7A1C6B19045");

                entity.ToTable("CHITIETLOP");

                entity.Property(e => e.CtlId)
                    .HasColumnName("CTL_ID")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.HvId)
                    .HasColumnName("HV_ID")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.LId)
                    .HasColumnName("L_ID")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.Hv)
                    .WithMany(p => p.Chitietlop)
                    .HasForeignKey(d => d.HvId)
                    .HasConstraintName("FK_CHITIETLOP_HOCVIEN");

                entity.HasOne(d => d.L)
                    .WithMany(p => p.Chitietlop)
                    .HasForeignKey(d => d.LId)
                    .HasConstraintName("FK_CHITIETLOP_LOP");
            });

            modelBuilder.Entity<Hocvien>(entity =>
            {
                entity.HasKey(e => e.HvId)
                    .HasName("PK__HOCVIEN__BB0F9415AE3879B8");

                entity.ToTable("HOCVIEN");

                entity.Property(e => e.HvId)
                    .HasColumnName("HV_ID")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.HvDiachi)
                    .HasColumnName("HV_DIACHI")
                    .HasMaxLength(100);

                entity.Property(e => e.HvEmail)
                    .HasColumnName("HV_EMAIL")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HvGioitinh)
                    .HasColumnName("HV_GIOITINH")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.HvHinhanh)
                    .HasColumnName("HV_HINHANH")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.HvNgaysinh)
                    .HasColumnName("HV_NGAYSINH")
                    .HasColumnType("date");

                entity.Property(e => e.HvNgayvao)
                    .HasColumnName("HV_NGAYVAO")
                    .HasColumnType("date");

                entity.Property(e => e.HvSdt)
                    .HasColumnName("HV_SDT")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Loaibaigiang>(entity =>
            {
                entity.HasKey(e => e.LoaiId)
                    .HasName("PK__LOAIBAIG__6D16F0B038D18990");

                entity.ToTable("LOAIBAIGIANG");

                entity.Property(e => e.LoaiId)
                    .HasColumnName("LOAI_ID")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.LoaiTen)
                    .HasColumnName("LOAI_TEN")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Lop>(entity =>
            {
                entity.HasKey(e => e.LId)
                    .HasName("PK__LOP__420BA09E61580FBD");

                entity.ToTable("LOP");

                entity.Property(e => e.LId)
                    .HasColumnName("L_ID")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.LKhoa)
                    .HasColumnName("L_KHOA")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LMota)
                    .HasColumnName("L_MOTA")
                    .HasMaxLength(200);

                entity.Property(e => e.LNgaybatdau)
                    .HasColumnName("L_NGAYBATDAU")
                    .HasColumnType("date");

                entity.Property(e => e.LNgayketthuc)
                    .HasColumnName("L_NGAYKETTHUC")
                    .HasColumnType("date");

                entity.Property(e => e.LTen)
                    .HasColumnName("L_TEN")
                    .HasMaxLength(50);

                entity.Property(e => e.LTrangthai)
                    .HasColumnName("L_TRANGTHAI")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Taikhoan>(entity =>
            {
                entity.HasKey(e => e.TkId)
                    .HasName("PK__TAIKHOAN__6416AA1EB3FE79C0");

                entity.ToTable("TAIKHOAN");

                entity.Property(e => e.TkId)
                    .HasColumnName("TK_ID")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.TkPw)
                    .HasColumnName("TK_PW")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TkUrn)
                    .HasColumnName("TK_URN")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Thoikhoabieu>(entity =>
            {
                entity.HasKey(e => e.TkbId)
                    .HasName("PK__THOIKHOA__C63105EB2EBCB39F");

                entity.ToTable("THOIKHOABIEU");

                entity.Property(e => e.TkbId)
                    .HasColumnName("TKB_ID")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.HvId)
                    .HasColumnName("HV_ID")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.LId)
                    .HasColumnName("L_ID")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.TkbKhunggio)
                    .HasColumnName("TKB_KHUNGGIO")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TkbLinkhoc)
                    .HasColumnName("TKB_LINKHOC")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TkbMonhoc)
                    .HasColumnName("TKB_MONHOC")
                    .HasMaxLength(50);

                entity.Property(e => e.TkbNgay)
                    .HasColumnName("TKB_NGAY")
                    .HasColumnType("date");

                entity.HasOne(d => d.Hv)
                    .WithMany(p => p.Thoikhoabieu)
                    .HasForeignKey(d => d.HvId)
                    .HasConstraintName("FK_THOIKHOABIEU_HOCVIEN");

                entity.HasOne(d => d.L)
                    .WithMany(p => p.Thoikhoabieu)
                    .HasForeignKey(d => d.LId)
                    .HasConstraintName("FK_THOIKHOABIEU_LOP");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
