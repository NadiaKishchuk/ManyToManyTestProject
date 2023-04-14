﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tests.PatrnersTestContext;

#nullable disable

namespace Tests.Migrations.ContextWihtEntityExplicitMigrations
{
    [DbContext(typeof(ContextWihtEntityExplicit))]
    [Migration("20230412144955_InitialForExplicit")]
    partial class InitialForExplicit
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Tests.PatrnersTestContext.Models.Partner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Partners");
                });

            modelBuilder.Entity("Tests.PatrnersTestContext.Models.Streetcode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Streetcodes");
                });

            modelBuilder.Entity("Tests.PatrnersTestContext.Models.StreetcodePartner", b =>
                {
                    b.Property<int>("PartnerId")
                        .HasColumnType("int");

                    b.Property<int>("StreetcodeId")
                        .HasColumnType("int");

                    b.HasKey("PartnerId", "StreetcodeId");

                    b.HasIndex("StreetcodeId");

                    b.ToTable("StreetcodePartner");
                });

            modelBuilder.Entity("Tests.PatrnersTestContext.Models.StreetcodePartner", b =>
                {
                    b.HasOne("Tests.PatrnersTestContext.Models.Partner", "Partner")
                        .WithMany()
                        .HasForeignKey("PartnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tests.PatrnersTestContext.Models.Streetcode", "Streetcode")
                        .WithMany()
                        .HasForeignKey("StreetcodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Partner");

                    b.Navigation("Streetcode");
                });
#pragma warning restore 612, 618
        }
    }
}
