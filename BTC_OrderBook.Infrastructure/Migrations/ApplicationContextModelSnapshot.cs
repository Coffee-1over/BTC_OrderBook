﻿// <auto-generated />
using System;
using BTC_OrderBook.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BTC_OrderBook.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BTC_OrderBook.Domain.Entities.OrderBookEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ID_ORDER_BOOK");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("Timestamp")
                        .HasColumnType("bigint")
                        .HasColumnName("TIMESTAMP");

                    b.HasKey("Id");

                    b.ToTable("ORDER_BOOKS");
                });

            modelBuilder.Entity("BTC_OrderBook.Domain.Entities.TradeOrderEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ID_TRADE_ORDER");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("AMOUNT");

                    b.Property<bool>("IsBuy")
                        .HasColumnType("bit")
                        .HasColumnName("IS_BUY");

                    b.Property<long?>("OrderBookEntityId")
                        .HasColumnType("bigint");

                    b.Property<long?>("OrderBookEntityId1")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("PRICE");

                    b.HasKey("Id");

                    b.HasIndex("OrderBookEntityId");

                    b.HasIndex("OrderBookEntityId1");

                    b.ToTable("TRADE_ORDERS");
                });

            modelBuilder.Entity("BTC_OrderBook.Domain.Entities.TradeOrderEntity", b =>
                {
                    b.HasOne("BTC_OrderBook.Domain.Entities.OrderBookEntity", null)
                        .WithMany("Asks")
                        .HasForeignKey("OrderBookEntityId");

                    b.HasOne("BTC_OrderBook.Domain.Entities.OrderBookEntity", null)
                        .WithMany("Bids")
                        .HasForeignKey("OrderBookEntityId1");
                });

            modelBuilder.Entity("BTC_OrderBook.Domain.Entities.OrderBookEntity", b =>
                {
                    b.Navigation("Asks");

                    b.Navigation("Bids");
                });
#pragma warning restore 612, 618
        }
    }
}