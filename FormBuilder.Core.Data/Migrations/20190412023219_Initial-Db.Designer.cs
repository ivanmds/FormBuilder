﻿// <auto-generated />
using System;
using FormBuilder.Core.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FormBuilder.Core.Data.Migrations
{
    [DbContext(typeof(DbContextCore))]
    [Migration("20190412023219_Initial-Db")]
    partial class InitialDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FormBuilder.Core.Domain.Models.Fields.Builder.BaseFieldBuilder", b =>
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

                    b.ToTable("BaseFieldBuilder");

                    b.HasDiscriminator<string>("Discriminator").HasValue("BaseFieldBuilder");
                });

            modelBuilder.Entity("FormBuilder.Core.Domain.Models.Fields.Response.BaseFieldResponse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int?>("FieldBuildId");

                    b.Property<int?>("FormResponseId");

                    b.HasKey("Id");

                    b.HasIndex("FieldBuildId");

                    b.HasIndex("FormResponseId");

                    b.ToTable("BaseFieldResponse");

                    b.HasDiscriminator<string>("Discriminator").HasValue("BaseFieldResponse");
                });

            modelBuilder.Entity("FormBuilder.Core.Domain.Models.Forms.FormBuild", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ExpiredIn");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("FormBuild");
                });

            modelBuilder.Entity("FormBuilder.Core.Domain.Models.Forms.Response.FormResponse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FormBuildId");

                    b.HasKey("Id");

                    b.HasIndex("FormBuildId");

                    b.ToTable("FormResponse");
                });

            modelBuilder.Entity("FormBuilder.Core.Domain.Models.Fields.Builder.Numbers.IntFieldBuilder", b =>
                {
                    b.HasBaseType("FormBuilder.Core.Domain.Models.Fields.Builder.BaseFieldBuilder");

                    b.Property<int?>("MaxValue");

                    b.Property<int?>("MinValue");

                    b.ToTable("IntField");

                    b.HasDiscriminator().HasValue("IntFieldBuilder");
                });

            modelBuilder.Entity("FormBuilder.Core.Domain.Models.Fields.Builder.Texts.TextFieldBuilder", b =>
                {
                    b.HasBaseType("FormBuilder.Core.Domain.Models.Fields.Builder.BaseFieldBuilder");

                    b.Property<int?>("MaxLength");

                    b.Property<int?>("MinLength");

                    b.Property<string>("Placeholder");

                    b.ToTable("TextField");

                    b.HasDiscriminator().HasValue("TextFieldBuilder");
                });

            modelBuilder.Entity("FormBuilder.Core.Domain.Models.Fields.Response.Numbers.IntFieldResponse", b =>
                {
                    b.HasBaseType("FormBuilder.Core.Domain.Models.Fields.Response.BaseFieldResponse");

                    b.Property<int?>("Value")
                        .IsRequired()
                        .HasColumnName("IntFieldValue");

                    b.ToTable("IntFieldResponse");

                    b.HasDiscriminator().HasValue("IntFieldResponse");
                });

            modelBuilder.Entity("FormBuilder.Core.Domain.Models.Fields.Response.Texts.TextFieldResponse", b =>
                {
                    b.HasBaseType("FormBuilder.Core.Domain.Models.Fields.Response.BaseFieldResponse");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnName("TextFieldValue");

                    b.ToTable("TextFieldResponse");

                    b.HasDiscriminator().HasValue("TextFieldResponse");
                });

            modelBuilder.Entity("FormBuilder.Core.Domain.Models.Fields.Builder.BaseFieldBuilder", b =>
                {
                    b.HasOne("FormBuilder.Core.Domain.Models.Forms.FormBuild")
                        .WithMany("Fields")
                        .HasForeignKey("FormBuildId");
                });

            modelBuilder.Entity("FormBuilder.Core.Domain.Models.Fields.Response.BaseFieldResponse", b =>
                {
                    b.HasOne("FormBuilder.Core.Domain.Models.Fields.Builder.BaseFieldBuilder", "FieldBuild")
                        .WithMany()
                        .HasForeignKey("FieldBuildId");

                    b.HasOne("FormBuilder.Core.Domain.Models.Forms.Response.FormResponse", "FormResponse")
                        .WithMany("Fields")
                        .HasForeignKey("FormResponseId");
                });

            modelBuilder.Entity("FormBuilder.Core.Domain.Models.Forms.Response.FormResponse", b =>
                {
                    b.HasOne("FormBuilder.Core.Domain.Models.Forms.FormBuild", "FormBuild")
                        .WithMany()
                        .HasForeignKey("FormBuildId");
                });
#pragma warning restore 612, 618
        }
    }
}
