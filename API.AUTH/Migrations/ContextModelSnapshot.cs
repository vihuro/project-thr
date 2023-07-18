﻿// <auto-generated />
using System;
using API.AUTH.ContextBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API.AUTH.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("API.AUTH.Models.Claims.ClaimsForUserModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClaimsId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("TypeClaimsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserClaimId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("UserClaimsId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TypeClaimsId");

                    b.HasIndex("UserClaimsId");

                    b.ToTable("tab_claimsForUser");
                });

            modelBuilder.Entity("API.AUTH.Models.Claims.TypeClaimsModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DataHoraAlteracao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataHoraCadatro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid>("UsuarioAlteracaoId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UsuarioCadastroId")
                        .HasColumnType("uuid");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioAlteracaoId");

                    b.HasIndex("UsuarioCadastroId");

                    b.ToTable("tab_typeClaims");
                });

            modelBuilder.Entity("API.AUTH.Models.User.UserModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Apelido")
                        .HasColumnType("text");

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("DataHoraAlteracao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataHoraCadastro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<string>("Senha")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("tab_user");
                });

            modelBuilder.Entity("API.AUTH.Models.Claims.ClaimsForUserModel", b =>
                {
                    b.HasOne("API.AUTH.Models.Claims.TypeClaimsModel", "TypeClaims")
                        .WithMany()
                        .HasForeignKey("TypeClaimsId");

                    b.HasOne("API.AUTH.Models.User.UserModel", "UserClaims")
                        .WithMany("ClaimsForUser")
                        .HasForeignKey("UserClaimsId");

                    b.Navigation("TypeClaims");

                    b.Navigation("UserClaims");
                });

            modelBuilder.Entity("API.AUTH.Models.Claims.TypeClaimsModel", b =>
                {
                    b.HasOne("API.AUTH.Models.User.UserModel", "UsuarioAlteracao")
                        .WithMany()
                        .HasForeignKey("UsuarioAlteracaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.AUTH.Models.User.UserModel", "UsuarioCadastro")
                        .WithMany()
                        .HasForeignKey("UsuarioCadastroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UsuarioAlteracao");

                    b.Navigation("UsuarioCadastro");
                });

            modelBuilder.Entity("API.AUTH.Models.User.UserModel", b =>
                {
                    b.Navigation("ClaimsForUser");
                });
#pragma warning restore 612, 618
        }
    }
}
