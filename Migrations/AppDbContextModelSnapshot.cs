﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using P2PChat;

#nullable disable

namespace P2PChat.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("P2PChat.Models.Message", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("Timestamp")
                        .HasColumnType("bigint");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("Timestamp");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("P2PChat.Models.Peer", b =>
                {
                    b.Property<string>("IPPort")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LastId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("IPPort");

                    b.ToTable("Peers");
                });
#pragma warning restore 612, 618
        }
    }
}
