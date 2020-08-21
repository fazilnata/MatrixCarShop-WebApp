using System;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Car.Models
{
    public partial class CarShopContext : DbContext
    {
        public CarShopContext()
        {
        }

        public CarShopContext(DbContextOptions<CarShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AllAds> AllAds { get; set; }
        public virtual DbSet<Brands> Brands { get; set; }
        public virtual DbSet<GeneralInfo> GeneralInfo { get; set; }
        public virtual DbSet<GeneralType> GeneralType { get; set; }
        public virtual DbSet<ImgAds> ImgAds { get; set; }
        public virtual DbSet<Models1> Models1 { get; set; }
     

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=CarShop;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AllAds>(entity =>
            {
                entity.ToTable("All_Ads");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AlloyWheels).HasColumnName("Alloy_Wheels");

                entity.Property(e => e.BodyTypeId).HasColumnName("Body_Type_ID");

                entity.Property(e => e.BrandId).HasColumnName("Brand_ID");

                entity.Property(e => e.CentralClosure).HasColumnName("Central_Closure");

                entity.Property(e => e.CityId).HasColumnName("City_ID");

                entity.Property(e => e.ColorId).HasColumnName("Color_ID");

                entity.Property(e => e.Contact)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.CurrencyId).HasColumnName("Currency_ID");

                entity.Property(e => e.EngineVolumeId).HasColumnName("Engine_Volume_ID");

                entity.Property(e => e.FuelTypeId).HasColumnName("Fuel_Type_ID");

                entity.Property(e => e.GearboxId).HasColumnName("Gearbox_ID");

                entity.Property(e => e.Hp).HasColumnName("HP");

                entity.Property(e => e.LeatherSalon).HasColumnName("Leather_Salon");

                entity.Property(e => e.ModelId).HasColumnName("Model_ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Note).HasMaxLength(300);

                entity.Property(e => e.ParkingRadar).HasColumnName("Parking_Radar");

                entity.Property(e => e.RainSensor).HasColumnName("Rain_Sensor");

                entity.Property(e => e.RearCamera).HasColumnName("Rear_Camera");

                entity.Property(e => e.SeatHeating).HasColumnName("Seat_Heating");

                entity.Property(e => e.SeatVentilation).HasColumnName("Seat_Ventilation");

                entity.Property(e => e.SideCurtains).HasColumnName("Side_Curtains");

                entity.Property(e => e.TransmissionId).HasColumnName("Transmission_ID");

                entity.Property(e => e.Usa).HasColumnName("USA");

                entity.HasOne(d => d.BodyType)
                    .WithMany(p => p.AllAdsBodyType)
                    .HasForeignKey(d => d.BodyTypeId)
                    .HasConstraintName("FK_TB_ADS_Body_TB_ADS");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.AllAds)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK_All_Ads_Brands");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.AllAdsCity)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TB_ADS_City_General_Type1");

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.AllAdsColor)
                    .HasForeignKey(d => d.ColorId)
                    .HasConstraintName("FK_TB_ADS_Color_General_Type");

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.AllAdsCurrency)
                    .HasForeignKey(d => d.CurrencyId)
                    .HasConstraintName("FK_TB_ADS_Currency");

                entity.HasOne(d => d.EngineVolume)
                    .WithMany(p => p.AllAdsEngineVolume)
                    .HasForeignKey(d => d.EngineVolumeId)
                    .HasConstraintName("FK_TB_ADS_Engine_General_Type1");

                entity.HasOne(d => d.FuelType)
                    .WithMany(p => p.AllAdsFuelType)
                    .HasForeignKey(d => d.FuelTypeId)
                    .HasConstraintName("FK_TB_ADS_Fuel_General_Type");

                entity.HasOne(d => d.Gearbox)
                    .WithMany(p => p.AllAdsGearbox)
                    .HasForeignKey(d => d.GearboxId)
                    .HasConstraintName("FK_TB_ADS_Gearbox_General_Type");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.AllAds)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("FK_TB_ADS_Model_Car_Models");

                entity.HasOne(d => d.Transmission)
                    .WithMany(p => p.AllAdsTransmission)
                    .HasForeignKey(d => d.TransmissionId)
                    .HasConstraintName("FK_TB_ADS_Transmission_General_Type");
            });

            modelBuilder.Entity<Brands>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BrandName)
                    .IsRequired()
                    .HasColumnName("Brand_Name")
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<GeneralInfo>(entity =>
            {
                entity.ToTable("General_Info");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.TypeId).HasColumnName("Type_ID");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.GeneralInfo)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_Gen_Name_General_Type");
            });

            modelBuilder.Entity<GeneralType>(entity =>
            {
                entity.ToTable("General_Type");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<ImgAds>(entity =>
            {
                entity.ToTable("Img_Ads");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AdsId).HasColumnName("ADS_ID");

                entity.Property(e => e.Image).HasMaxLength(300);

                entity.HasOne(d => d.Ads)
                    .WithMany(p => p.ImgAds)
                    .HasForeignKey(d => d.AdsId)
                    .HasConstraintName("FK_Car_Images_ADS");
            });

            modelBuilder.Entity<Models1>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BrandId)
                    .HasColumnName("Brand_ID")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(125)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ModelName)
                    .IsRequired()
                    .HasColumnName("Model_Name")
                    .HasMaxLength(125)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
