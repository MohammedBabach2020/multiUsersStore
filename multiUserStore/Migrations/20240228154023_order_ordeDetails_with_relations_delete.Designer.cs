﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using multiUserStore.Data;

#nullable disable

namespace multiUserStore.Migrations
{
    [DbContext(typeof(GlobalDbContext))]
    [Migration("20240228154023_order_ordeDetails_with_relations_delete")]
    partial class order_ordeDetails_with_relations_delete
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("multiUserStore.Models.Account.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("StoreId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("StoreId")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("multiUserStore.Models.Categories.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("multiUserStore.Models.Orders.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("city")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("client_id")
                        .HasColumnType("integer");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("shippingAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("state")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("storeId")
                        .HasColumnType("integer");

                    b.Property<int>("store_id")
                        .HasColumnType("integer");

                    b.Property<float>("total_amount")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("client_id");

                    b.HasIndex("storeId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("multiUserStore.Models.Orders.OrderDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<float>("Quantity")
                        .HasColumnType("real");

                    b.Property<float>("amount")
                        .HasColumnType("real");

                    b.Property<int>("order_id")
                        .HasColumnType("integer");

                    b.Property<string>("prod_name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("prod_price")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("order_id");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("multiUserStore.Models.Product.Products", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("StoreId")
                        .HasColumnType("integer");

                    b.Property<float>("ammount_promotion")
                        .HasColumnType("real");

                    b.Property<float>("byuing_price")
                        .HasColumnType("real");

                    b.Property<bool>("has_promotion")
                        .HasColumnType("boolean");

                    b.Property<float>("selling_price")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("StoreId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("multiUserStore.Models.Store.CategoryToStore", b =>
                {
                    b.Property<int>("StoreId")
                        .HasColumnType("integer");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.HasKey("StoreId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("CategoryToStore");
                });

            modelBuilder.Entity("multiUserStore.Models.Store.StoreModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("OwnerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Store");
                });

            modelBuilder.Entity("multiUserStore.Models.Account.User", b =>
                {
                    b.HasOne("multiUserStore.Models.Store.StoreModel", "Store")
                        .WithOne("Owner")
                        .HasForeignKey("multiUserStore.Models.Account.User", "StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Store");
                });

            modelBuilder.Entity("multiUserStore.Models.Orders.Order", b =>
                {
                    b.HasOne("multiUserStore.Models.Account.User", "client")
                        .WithMany("Order")
                        .HasForeignKey("client_id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("multiUserStore.Models.Store.StoreModel", "store")
                        .WithMany()
                        .HasForeignKey("storeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("client");

                    b.Navigation("store");
                });

            modelBuilder.Entity("multiUserStore.Models.Orders.OrderDetails", b =>
                {
                    b.HasOne("multiUserStore.Models.Orders.Order", "order")
                        .WithMany("Details")
                        .HasForeignKey("order_id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("order");
                });

            modelBuilder.Entity("multiUserStore.Models.Product.Products", b =>
                {
                    b.HasOne("multiUserStore.Models.Store.StoreModel", "Store")
                        .WithMany("Products")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Store");
                });

            modelBuilder.Entity("multiUserStore.Models.Store.CategoryToStore", b =>
                {
                    b.HasOne("multiUserStore.Models.Categories.Category", "Category")
                        .WithMany("Stores")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("multiUserStore.Models.Store.StoreModel", "store")
                        .WithMany("Categories")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("store");
                });

            modelBuilder.Entity("multiUserStore.Models.Account.User", b =>
                {
                    b.Navigation("Order");
                });

            modelBuilder.Entity("multiUserStore.Models.Categories.Category", b =>
                {
                    b.Navigation("Stores");
                });

            modelBuilder.Entity("multiUserStore.Models.Orders.Order", b =>
                {
                    b.Navigation("Details");
                });

            modelBuilder.Entity("multiUserStore.Models.Store.StoreModel", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("Owner")
                        .IsRequired();

                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
