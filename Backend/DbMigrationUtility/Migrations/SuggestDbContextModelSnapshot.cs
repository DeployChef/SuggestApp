﻿// <auto-generated />
using DbMigrationUtility.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DbMigrationUtility.Migrations
{
    [DbContext(typeof(SuggestDbContext))]
    partial class SuggestDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("SuggestService.Entities.SuggestEntity", b =>
                {
                    b.Property<string>("Suggestion")
                        .HasColumnName("suggestion")
                        .HasColumnType("text");

                    b.Property<string>("Nn")
                        .HasColumnName("nn")
                        .HasColumnType("text");

                    b.HasKey("Suggestion");

                    b.ToTable("suggest");
                });
#pragma warning restore 612, 618
        }
    }
}
