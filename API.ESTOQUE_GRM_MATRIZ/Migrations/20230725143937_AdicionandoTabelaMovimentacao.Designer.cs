﻿// <auto-generated />
using System;
using API.ESTOQUE_GRM_MATRIZ.ContextBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API.ESTOQUE_GRM_MATRIZ.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230725143937_AdicionandoTabelaMovimentacao")]
    partial class AdicionandoTabelaMovimentacao
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("API.ESTOQUE_GRM_MATRIZ.Models.Estoque.EstoqueModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Codigo")
                        .HasColumnType("text");

                    b.Property<DateTime>("DataHoraAlteracao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataHoraCadstro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Descricao")
                        .HasColumnType("text");

                    b.Property<Guid?>("LocalArmazenagemId")
                        .HasColumnType("uuid");

                    b.Property<double>("Quantidade")
                        .HasColumnType("double precision");

                    b.Property<Guid?>("TipoMaterialId")
                        .HasColumnType("uuid");

                    b.Property<string>("Unidade")
                        .HasColumnType("text");

                    b.Property<Guid>("UsuarioAlteracaoId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UsuarioCadastroId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("LocalArmazenagemId");

                    b.HasIndex("TipoMaterialId");

                    b.HasIndex("UsuarioAlteracaoId");

                    b.HasIndex("UsuarioCadastroId");

                    b.ToTable("tab_estoque");
                });

            modelBuilder.Entity("API.ESTOQUE_GRM_MATRIZ.Models.Estoque.LocalArmazenagemModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("DataHoraAlteracao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataHoraCadastro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Local")
                        .HasColumnType("text");

                    b.Property<Guid>("UsuarioAlteracaoId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UsuarioCadastroId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioAlteracaoId");

                    b.HasIndex("UsuarioCadastroId");

                    b.ToTable("tab_local_armazenagem");
                });

            modelBuilder.Entity("API.ESTOQUE_GRM_MATRIZ.Models.Estoque.MovimentacaoModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DataHoraMovimentacao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Destino")
                        .HasColumnType("text");

                    b.Property<Guid>("MaterialId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("MatetialId")
                        .HasColumnType("uuid");

                    b.Property<double>("NovaQuantidade")
                        .HasColumnType("double precision");

                    b.Property<double>("QuantidadeDestino")
                        .HasColumnType("double precision");

                    b.Property<double>("QuantidadeOrigem")
                        .HasColumnType("double precision");

                    b.Property<string>("TipoMovimentacao")
                        .HasColumnType("text");

                    b.Property<Guid>("UsuarioMovimentacaoId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("MatetialId");

                    b.HasIndex("UsuarioMovimentacaoId");

                    b.ToTable("tab_movimentacao");
                });

            modelBuilder.Entity("API.ESTOQUE_GRM_MATRIZ.Models.Substituto.SubstitutoModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DataHoraAlteracao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataHoraCadatro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("MaterialEstoqueId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SubstitutoId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UsuarioAlteracaoId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UsuarioCadatroId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("MaterialEstoqueId");

                    b.HasIndex("SubstitutoId");

                    b.HasIndex("UsuarioAlteracaoId");

                    b.HasIndex("UsuarioCadatroId");

                    b.ToTable("tab_substitutos");
                });

            modelBuilder.Entity("API.ESTOQUE_GRM_MATRIZ.Models.TipoMaterial.TipoMaterialModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DataTimeChange")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataTimeRegister")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("TipoMaterial")
                        .HasColumnType("text");

                    b.Property<Guid>("UserChangeId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserRegisterId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserChangeId");

                    b.HasIndex("UserRegisterId");

                    b.ToTable("tab_tipo_matetial");
                });

            modelBuilder.Entity("API.ESTOQUE_GRM_MATRIZ.Models.User.UserAuthModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Apelido")
                        .HasColumnType("text");

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("tab_user_auth");
                });

            modelBuilder.Entity("API.ESTOQUE_GRM_MATRIZ.Models.Estoque.EstoqueModel", b =>
                {
                    b.HasOne("API.ESTOQUE_GRM_MATRIZ.Models.Estoque.LocalArmazenagemModel", "LocalArmazenagem")
                        .WithMany()
                        .HasForeignKey("LocalArmazenagemId");

                    b.HasOne("API.ESTOQUE_GRM_MATRIZ.Models.TipoMaterial.TipoMaterialModel", "TipoMaterial")
                        .WithMany()
                        .HasForeignKey("TipoMaterialId");

                    b.HasOne("API.ESTOQUE_GRM_MATRIZ.Models.User.UserAuthModel", "UsuarioAlteracao")
                        .WithMany()
                        .HasForeignKey("UsuarioAlteracaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.ESTOQUE_GRM_MATRIZ.Models.User.UserAuthModel", "UsuarioCadastro")
                        .WithMany()
                        .HasForeignKey("UsuarioCadastroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LocalArmazenagem");

                    b.Navigation("TipoMaterial");

                    b.Navigation("UsuarioAlteracao");

                    b.Navigation("UsuarioCadastro");
                });

            modelBuilder.Entity("API.ESTOQUE_GRM_MATRIZ.Models.Estoque.LocalArmazenagemModel", b =>
                {
                    b.HasOne("API.ESTOQUE_GRM_MATRIZ.Models.User.UserAuthModel", "UsuarioAlteracao")
                        .WithMany()
                        .HasForeignKey("UsuarioAlteracaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.ESTOQUE_GRM_MATRIZ.Models.User.UserAuthModel", "UsuarioCadastro")
                        .WithMany()
                        .HasForeignKey("UsuarioCadastroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UsuarioAlteracao");

                    b.Navigation("UsuarioCadastro");
                });

            modelBuilder.Entity("API.ESTOQUE_GRM_MATRIZ.Models.Estoque.MovimentacaoModel", b =>
                {
                    b.HasOne("API.ESTOQUE_GRM_MATRIZ.Models.Estoque.EstoqueModel", "Matetial")
                        .WithMany()
                        .HasForeignKey("MatetialId");

                    b.HasOne("API.ESTOQUE_GRM_MATRIZ.Models.User.UserAuthModel", "UsuarioMovimentacao")
                        .WithMany()
                        .HasForeignKey("UsuarioMovimentacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Matetial");

                    b.Navigation("UsuarioMovimentacao");
                });

            modelBuilder.Entity("API.ESTOQUE_GRM_MATRIZ.Models.Substituto.SubstitutoModel", b =>
                {
                    b.HasOne("API.ESTOQUE_GRM_MATRIZ.Models.Estoque.EstoqueModel", "MaterialEstoque")
                        .WithMany("Substituos")
                        .HasForeignKey("MaterialEstoqueId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("API.ESTOQUE_GRM_MATRIZ.Models.Estoque.EstoqueModel", "Substituto")
                        .WithMany()
                        .HasForeignKey("SubstitutoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("API.ESTOQUE_GRM_MATRIZ.Models.User.UserAuthModel", "UsuarioAlteracao")
                        .WithMany()
                        .HasForeignKey("UsuarioAlteracaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.ESTOQUE_GRM_MATRIZ.Models.User.UserAuthModel", "UsuarioCadatro")
                        .WithMany()
                        .HasForeignKey("UsuarioCadatroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MaterialEstoque");

                    b.Navigation("Substituto");

                    b.Navigation("UsuarioAlteracao");

                    b.Navigation("UsuarioCadatro");
                });

            modelBuilder.Entity("API.ESTOQUE_GRM_MATRIZ.Models.TipoMaterial.TipoMaterialModel", b =>
                {
                    b.HasOne("API.ESTOQUE_GRM_MATRIZ.Models.User.UserAuthModel", "UserChange")
                        .WithMany()
                        .HasForeignKey("UserChangeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.ESTOQUE_GRM_MATRIZ.Models.User.UserAuthModel", "UserRegister")
                        .WithMany()
                        .HasForeignKey("UserRegisterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserChange");

                    b.Navigation("UserRegister");
                });

            modelBuilder.Entity("API.ESTOQUE_GRM_MATRIZ.Models.Estoque.EstoqueModel", b =>
                {
                    b.Navigation("Substituos");
                });
#pragma warning restore 612, 618
        }
    }
}
