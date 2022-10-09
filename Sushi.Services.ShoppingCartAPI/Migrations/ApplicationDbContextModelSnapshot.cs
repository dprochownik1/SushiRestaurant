﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sushi.Services.ShoppingCartAPI.Models.DbContexts;

#nullable disable

namespace Sushi.Services.ShoppingCartAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Sushi.Services.ShoppingCartAPI.Models.CartDetails", b =>
                {
                    b.Property<int>("CartDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartDetailsId"), 1L, 1);

                    b.Property<int>("CartHeaderId")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("DishId")
                        .HasColumnType("int");

                    b.HasKey("CartDetailsId");

                    b.HasIndex("CartHeaderId");

                    b.HasIndex("DishId");

                    b.ToTable("CartDetails");
                });

            modelBuilder.Entity("Sushi.Services.ShoppingCartAPI.Models.CartHeader", b =>
                {
                    b.Property<int>("CartHeaderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartHeaderId"), 1L, 1);

                    b.Property<string>("CouponCode")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("UserId")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("CartHeaderId");

                    b.ToTable("CartHeaders");
                });

            modelBuilder.Entity("Sushi.Services.ShoppingCartAPI.Models.Dish", b =>
                {
                    b.Property<int>("DishId")
                        .HasColumnType("int");

                    b.Property<string>("CategoryName")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Description")
                        .HasMaxLength(700)
                        .HasColumnType("nvarchar(700)");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("DishId");

                    b.ToTable("Dishes");
                });

            modelBuilder.Entity("Sushi.Services.ShoppingCartAPI.Models.CartDetails", b =>
                {
                    b.HasOne("Sushi.Services.ShoppingCartAPI.Models.CartHeader", "CartHeader")
                        .WithMany()
                        .HasForeignKey("CartHeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sushi.Services.ShoppingCartAPI.Models.Dish", "Dish")
                        .WithMany()
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CartHeader");

                    b.Navigation("Dish");
                });
#pragma warning restore 612, 618
        }
    }
}
