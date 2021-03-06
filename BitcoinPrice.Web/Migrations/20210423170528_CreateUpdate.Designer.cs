// <auto-generated />
using System;
using BitcoinPrice.Library;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BitcoinPrice.Web.Migrations
{
    [DbContext(typeof(BitCoinContext))]
    [Migration("20210423170528_CreateUpdate")]
    partial class CreateUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BitcoinPrice.Library.BitCoinPrice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BpiId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TimeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("chartName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("disclaimer")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BpiId");

                    b.HasIndex("TimeId");

                    b.ToTable("BitCoinPrice");
                });

            modelBuilder.Entity("BitcoinPrice.Library.Bpi", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("EURId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("GBPId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("USDId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EURId");

                    b.HasIndex("GBPId");

                    b.HasIndex("USDId");

                    b.ToTable("Bpi");
                });

            modelBuilder.Entity("BitcoinPrice.Library.EUR", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("rate_float")
                        .HasColumnType("float");

                    b.Property<string>("symbol")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EUR");
                });

            modelBuilder.Entity("BitcoinPrice.Library.GBP", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("rate_float")
                        .HasColumnType("float");

                    b.Property<string>("symbol")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GBP");
                });

            modelBuilder.Entity("BitcoinPrice.Library.Time", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("updated")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("updatedISO")
                        .HasColumnType("datetime2");

                    b.Property<string>("updateduk")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Time");
                });

            modelBuilder.Entity("BitcoinPrice.Library.USD", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("rate_float")
                        .HasColumnType("float");

                    b.Property<string>("symbol")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("USD");
                });

            modelBuilder.Entity("BitcoinPrice.Library.BitCoinPrice", b =>
                {
                    b.HasOne("BitcoinPrice.Library.Bpi", "bpi")
                        .WithMany()
                        .HasForeignKey("BpiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BitcoinPrice.Library.Time", "time")
                        .WithMany()
                        .HasForeignKey("TimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BitcoinPrice.Library.Bpi", b =>
                {
                    b.HasOne("BitcoinPrice.Library.EUR", "EUR")
                        .WithMany()
                        .HasForeignKey("EURId");

                    b.HasOne("BitcoinPrice.Library.GBP", "GBP")
                        .WithMany()
                        .HasForeignKey("GBPId");

                    b.HasOne("BitcoinPrice.Library.USD", "USD")
                        .WithMany()
                        .HasForeignKey("USDId");
                });
#pragma warning restore 612, 618
        }
    }
}
