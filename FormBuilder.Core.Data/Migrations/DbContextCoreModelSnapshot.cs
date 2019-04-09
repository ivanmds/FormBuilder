﻿// <auto-generated />
using System;
using FormBuilder.Core.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FormBuilder.Core.Data.Migrations
{
    [DbContext(typeof(DbContextCore))]
    partial class DbContextCoreModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FormBuilder.Core.Domain.Models.Fields.BaseField", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int?>("FormBuildId");

                    b.Property<bool?>("IsRequired");

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.HasKey("Id");

                    b.HasIndex("FormBuildId");

                    b.ToTable("BaseField");

                    b.HasDiscriminator<string>("Discriminator").HasValue("BaseField");
                });

            modelBuilder.Entity("FormBuilder.Core.Domain.Models.Forms.FormBuild", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ExpiredIn");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("FormBuild");
                });

            modelBuilder.Entity("FormBuilder.Core.Domain.Models.Fields.Numbers.IntField", b =>
                {
                    b.HasBaseType("FormBuilder.Core.Domain.Models.Fields.BaseField");

                    b.Property<int?>("MaxValue");

                    b.Property<int?>("MinValue");

                    b.ToTable("IntField");

                    b.HasDiscriminator().HasValue("IntField");
                });

            modelBuilder.Entity("FormBuilder.Core.Domain.Models.Fields.Texts.TextField", b =>
                {
                    b.HasBaseType("FormBuilder.Core.Domain.Models.Fields.BaseField");

                    b.Property<int?>("MaxLength");

                    b.Property<int?>("MinLength");

                    b.Property<string>("Placeholder");

                    b.ToTable("TextField");

                    b.HasDiscriminator().HasValue("TextField");
                });

            modelBuilder.Entity("FormBuilder.Core.Domain.Models.Fields.BaseField", b =>
                {
                    b.HasOne("FormBuilder.Core.Domain.Models.Forms.FormBuild")
                        .WithMany("Fields")
                        .HasForeignKey("FormBuildId");
                });
#pragma warning restore 612, 618
        }
    }
}
