// <auto-generated />
using CarShop.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarShop.Infrastructure.Migrations
{
    [DbContext(typeof(CarShopDbContext))]
    partial class CarShopDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarShop.Domain.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("CarShop.Domain.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ABS")
                        .HasColumnType("bit");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<bool>("Alarms")
                        .HasColumnType("bit");

                    b.Property<bool>("Bluetooth")
                        .HasColumnType("bit");

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ElectricGlassOpener")
                        .HasColumnType("bit");

                    b.Property<bool>("Hatch")
                        .HasColumnType("bit");

                    b.Property<bool>("MultiSteering")
                        .HasColumnType("bit");

                    b.Property<bool>("Navigation")
                        .HasColumnType("bit");

                    b.Property<bool>("OnBoardComputer")
                        .HasColumnType("bit");

                    b.Property<bool>("ParkingControl")
                        .HasColumnType("bit");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("ValuteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("ValuteId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CarShop.Domain.Models.Valute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Valutes");
                });

            modelBuilder.Entity("CarShop.Domain.Models.Car", b =>
                {
                    b.HasOne("CarShop.Domain.Models.Brand", "Brand")
                        .WithMany("Cars")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarShop.Domain.Models.Valute", "Valute")
                        .WithMany("Cars")
                        .HasForeignKey("ValuteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Valute");
                });

            modelBuilder.Entity("CarShop.Domain.Models.Brand", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("CarShop.Domain.Models.Valute", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
