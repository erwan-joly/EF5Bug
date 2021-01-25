﻿// <auto-generated />

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using NodaTime;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace EF5.Migrations
{
    [DbContext(typeof(TestContext))]
    [Migration("20210125041845_First")]
    partial class First
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("EF3.TestObject", b =>
                {
                    b.Property<Guid>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Instant>("ADate");

                    b.HasKey("Key");

                    b.ToTable("TestObjects");
                });
#pragma warning restore 612, 618
        }
    }
}
