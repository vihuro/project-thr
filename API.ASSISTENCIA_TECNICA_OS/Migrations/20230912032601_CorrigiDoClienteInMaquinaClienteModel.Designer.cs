﻿// <auto-generated />
using System;
using System.Collections.Generic;
using API.ASSISTENCIA_TECNICA_OS.ContextBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API.ASSISTENCIA_TECNICA_OS.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230912032601_CorrigiDoClienteInMaquinaClienteModel")]
    partial class CorrigiDoClienteInMaquinaClienteModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("API.ASSISTENCIA_TECNICA_OS.Model.Client.ClientModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Cnpj")
                        .HasMaxLength(14)
                        .HasColumnType("character varying(14)");

                    b.Property<string>("CodigoRadar")
                        .HasColumnType("text");

                    b.Property<string>("ContatoTelefone")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<DateTime>("DataHoraAlteracao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataHoraCadastro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("NomeContatoClient")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<Guid>("UsuarioAlteracaoId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UsuarioCadastroId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioAlteracaoId");

                    b.HasIndex("UsuarioCadastroId");

                    b.ToTable("tab_client");
                });

            modelBuilder.Entity("API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.MaquinaClienteModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("MaquinaId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("MaquinaId")
                        .IsUnique();

                    b.ToTable("tab_maquina_cliente");
                });

            modelBuilder.Entity("API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.MaquinaModel", b =>
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

                    b.Property<string>("NumeroSerie")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("TipoMaquina")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<Guid>("UsuarioAlteracaoId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UsuarioCadastroId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioAlteracaoId");

                    b.HasIndex("UsuarioCadastroId");

                    b.ToTable("tab_maquina");
                });

            modelBuilder.Entity("API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.Pecas.PecasModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<List<string>>("EnderecoImagem")
                        .HasColumnType("text[]");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<double>("Preco")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("tab_pecas");
                });

            modelBuilder.Entity("API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.Pecas.PecasPorMaquinaEOrdemModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Conserto")
                        .HasColumnType("boolean");

                    b.Property<Guid>("MaquinaId")
                        .HasColumnType("uuid");

                    b.Property<int>("OrdemServicoId")
                        .HasColumnType("integer");

                    b.Property<Guid>("PecaId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Troca")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("MaquinaId");

                    b.HasIndex("OrdemServicoId");

                    b.HasIndex("PecaId");

                    b.ToTable("tab_pecas_por_maquina_ordem_servico");
                });

            modelBuilder.Entity("API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.Pecas.PecasPorMaquinaModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("MaquinaId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PecaId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("MaquinaId");

                    b.HasIndex("PecaId");

                    b.ToTable("tab_pecaPorMaquina");
                });

            modelBuilder.Entity("API.ASSISTENCIA_TECNICA_OS.Model.OrdemServico.OrdemServicoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("tab_ordemServico");
                });

            modelBuilder.Entity("API.ASSISTENCIA_TECNICA_OS.Model.User.UserModel", b =>
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

            modelBuilder.Entity("API.ASSISTENCIA_TECNICA_OS.Model.Client.ClientModel", b =>
                {
                    b.HasOne("API.ASSISTENCIA_TECNICA_OS.Model.User.UserModel", "UsuarioAlteracao")
                        .WithMany()
                        .HasForeignKey("UsuarioAlteracaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.ASSISTENCIA_TECNICA_OS.Model.User.UserModel", "UsuarioCadastro")
                        .WithMany()
                        .HasForeignKey("UsuarioCadastroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UsuarioAlteracao");

                    b.Navigation("UsuarioCadastro");
                });

            modelBuilder.Entity("API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.MaquinaClienteModel", b =>
                {
                    b.HasOne("API.ASSISTENCIA_TECNICA_OS.Model.Client.ClientModel", "Cliente")
                        .WithMany("Maquinas")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.MaquinaModel", "Maquina")
                        .WithOne("MaquinaCliente")
                        .HasForeignKey("API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.MaquinaClienteModel", "MaquinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Maquina");
                });

            modelBuilder.Entity("API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.MaquinaModel", b =>
                {
                    b.HasOne("API.ASSISTENCIA_TECNICA_OS.Model.User.UserModel", "UsuarioAlteracao")
                        .WithMany()
                        .HasForeignKey("UsuarioAlteracaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.ASSISTENCIA_TECNICA_OS.Model.User.UserModel", "UsuarioCadastro")
                        .WithMany()
                        .HasForeignKey("UsuarioCadastroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UsuarioAlteracao");

                    b.Navigation("UsuarioCadastro");
                });

            modelBuilder.Entity("API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.Pecas.PecasPorMaquinaEOrdemModel", b =>
                {
                    b.HasOne("API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.MaquinaModel", "Maquina")
                        .WithMany()
                        .HasForeignKey("MaquinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.ASSISTENCIA_TECNICA_OS.Model.OrdemServico.OrdemServicoModel", "OrdemServico")
                        .WithMany("MaquinaPorOs")
                        .HasForeignKey("OrdemServicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.Pecas.PecasModel", "Peca")
                        .WithMany()
                        .HasForeignKey("PecaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Maquina");

                    b.Navigation("OrdemServico");

                    b.Navigation("Peca");
                });

            modelBuilder.Entity("API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.Pecas.PecasPorMaquinaModel", b =>
                {
                    b.HasOne("API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.MaquinaModel", "Maquina")
                        .WithMany()
                        .HasForeignKey("MaquinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.Pecas.PecasModel", "Peca")
                        .WithMany()
                        .HasForeignKey("PecaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Maquina");

                    b.Navigation("Peca");
                });

            modelBuilder.Entity("API.ASSISTENCIA_TECNICA_OS.Model.Client.ClientModel", b =>
                {
                    b.Navigation("Maquinas");
                });

            modelBuilder.Entity("API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.MaquinaModel", b =>
                {
                    b.Navigation("MaquinaCliente");
                });

            modelBuilder.Entity("API.ASSISTENCIA_TECNICA_OS.Model.OrdemServico.OrdemServicoModel", b =>
                {
                    b.Navigation("MaquinaPorOs");
                });
#pragma warning restore 612, 618
        }
    }
}
