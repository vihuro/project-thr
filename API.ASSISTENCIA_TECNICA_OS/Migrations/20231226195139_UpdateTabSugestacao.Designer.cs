﻿// <auto-generated />
using System;
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
    [Migration("20231226195139_UpdateTabSugestacao")]
    partial class UpdateTabSugestacao
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("API.ASSISTENCIA_TECNICA_OS.Model.Client.ClientModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("character varying(14)");

                    b.Property<string>("CodigoRadar")
                        .HasColumnType("text");

                    b.Property<string>("Complemento")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("ContatoTelefone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.Property<DateTime>("DataHoraAlteracao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataHoraCadastro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("character varying(4)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("NomeContatoClient")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("NumeroEstabelecimento")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Regiao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

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

                    b.Property<int>("Status")
                        .HasColumnType("integer");

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

                    b.Property<bool>("Atribuida")
                        .HasColumnType("boolean");

                    b.Property<string>("CodigoMaquina")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DataHoraAlteracao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataHoraCadastro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DescricaoMaquina")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("NumeroSerie")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("Unidade")
                        .HasColumnType("text");

                    b.Property<Guid>("UsuarioAlteracaoId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UsuarioCadastroId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioAlteracaoId");

                    b.HasIndex("UsuarioCadastroId");

                    b.ToTable("tab_maquina");
                });

            modelBuilder.Entity("API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.Pecas.PecasMaquinaOrcamentoModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Conserto")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("DataHoraAlteracao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataHoraCadastro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("MaquinaId")
                        .HasColumnType("uuid");

                    b.Property<int>("OrcamentoId")
                        .HasColumnType("integer");

                    b.Property<Guid>("PecaId")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantidade")
                        .HasColumnType("integer");

                    b.Property<bool>("Reaproveitamento")
                        .HasColumnType("boolean");

                    b.Property<bool>("Troca")
                        .HasColumnType("boolean");

                    b.Property<Guid>("UsuarioAlteracaoId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UsuarioCadastroId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("MaquinaId");

                    b.HasIndex("OrcamentoId");

                    b.HasIndex("PecaId");

                    b.HasIndex("UsuarioAlteracaoId");

                    b.HasIndex("UsuarioCadastroId");

                    b.ToTable("tab_pecasMaquinaEOrcamento");
                });

            modelBuilder.Entity("API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.Pecas.PecasModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CodigoRadar")
                        .HasColumnType("text");

                    b.Property<DateTime>("DataHoraAlteracao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataHoraCadastro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Descricao")
                        .HasColumnType("text");

                    b.Property<string>("EnderecoImagem")
                        .HasColumnType("text");

                    b.Property<string>("Familia")
                        .HasColumnType("text");

                    b.Property<double>("Preco")
                        .HasColumnType("double precision");

                    b.Property<string>("Unidade")
                        .HasColumnType("text");

                    b.Property<Guid>("UsuarioAlteracaoId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UsuarioCadastroId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioAlteracaoId");

                    b.HasIndex("UsuarioCadastroId");

                    b.ToTable("tab_pecas");
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

            modelBuilder.Entity("API.ASSISTENCIA_TECNICA_OS.Model.Orcamento.DiarioOrcamentoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataHoraApontamento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Informacao")
                        .HasColumnType("text");

                    b.Property<int>("OrcamentoId")
                        .HasColumnType("integer");

                    b.Property<bool>("Privado")
                        .HasColumnType("boolean");

                    b.Property<string>("Tag")
                        .HasColumnType("text");

                    b.Property<Guid>("UsuarioApontamentoId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("OrcamentoId");

                    b.HasIndex("UsuarioApontamentoId");

                    b.ToTable("tab_diarioOrcamento");
                });

            modelBuilder.Entity("API.ASSISTENCIA_TECNICA_OS.Model.Orcamento.OrcamentoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataHoraAlteracao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataHoraCadastro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DescricaoServico")
                        .HasColumnType("text");

                    b.Property<bool>("Externo")
                        .HasColumnType("boolean");

                    b.Property<Guid>("MaquinaClienteId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("MaquinaId")
                        .HasColumnType("uuid");

                    b.Property<string>("Observacao")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("TempoEstimadoManutencao")
                        .HasColumnType("integer");

                    b.Property<int>("TempoEstimadoOrcamento")
                        .HasColumnType("integer");

                    b.Property<Guid>("UsuarioAlteracaoId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UsuarioCadastroId")
                        .HasColumnType("uuid");

                    b.Property<double>("ValorOrcamento")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("MaquinaClienteId");

                    b.HasIndex("MaquinaId");

                    b.HasIndex("UsuarioAlteracaoId");

                    b.HasIndex("UsuarioCadastroId");

                    b.ToTable("tab_orcamento");
                });

            modelBuilder.Entity("API.ASSISTENCIA_TECNICA_OS.Model.Orcamento.StatusModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("tab_status");
                });

            modelBuilder.Entity("API.ASSISTENCIA_TECNICA_OS.Model.Orcamento.StatusOrcamentoModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DataHoraFim")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataHoraInicio")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Observacao")
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)");

                    b.Property<int>("OrcamentoId")
                        .HasColumnType("integer");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OrcamentoId");

                    b.HasIndex("StatusId");

                    b.ToTable("tab_statusOrcamento");
                });

            modelBuilder.Entity("API.ASSISTENCIA_TECNICA_OS.Model.Orcamento.SugestacaoManutencaoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataCobranca")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataHoraSugestacao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("MaquinaId")
                        .HasColumnType("uuid");

                    b.Property<string>("StatusSugestacao")
                        .HasColumnType("text");

                    b.Property<int>("StatusSugestao")
                        .HasColumnType("integer");

                    b.Property<string>("SugestacaoManutencao")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<Guid>("UsuarioSugestacaoId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("MaquinaId");

                    b.HasIndex("UsuarioSugestacaoId");

                    b.ToTable("tab_sugestao");
                });

            modelBuilder.Entity("API.ASSISTENCIA_TECNICA_OS.Model.Orcamento.TecnicoManutencaoModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("OrcamentoId")
                        .HasColumnType("integer");

                    b.Property<Guid>("TecnicoId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("OrcamentoId")
                        .IsUnique();

                    b.HasIndex("TecnicoId");

                    b.ToTable("tab_tecnicoManutencao");
                });

            modelBuilder.Entity("API.ASSISTENCIA_TECNICA_OS.Model.Orcamento.TecnicoOrcamentoModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("OrcamentoId")
                        .HasColumnType("integer");

                    b.Property<Guid>("TecnicoId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("OrcamentoId")
                        .IsUnique();

                    b.HasIndex("TecnicoId");

                    b.ToTable("tab_tecnicoOrcamento");
                });

            modelBuilder.Entity("API.ASSISTENCIA_TECNICA_OS.Model.Orcamento.UsuarioApontamentoFimStatusModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("StatusOrcamentoId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UsuarioApontamentoFimId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("StatusOrcamentoId")
                        .IsUnique();

                    b.HasIndex("UsuarioApontamentoFimId");

                    b.ToTable("tab_usuarioApontamentoStatusFim");
                });

            modelBuilder.Entity("API.ASSISTENCIA_TECNICA_OS.Model.Orcamento.UsuarioApontamentoInicioStatusModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("StatusOrcamentoId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UsuarioApontamentoInicioId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("StatusOrcamentoId")
                        .IsUnique();

                    b.HasIndex("UsuarioApontamentoInicioId");

                    b.ToTable("tab_usuarioApontamentoStatusInicio");
                });

            modelBuilder.Entity("API.ASSISTENCIA_TECNICA_OS.Model.Tecnico.TecnicoModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("tab_tecnico");
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

            modelBuilder.Entity("API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.Pecas.PecasMaquinaOrcamentoModel", b =>
                {
                    b.HasOne("API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.MaquinaModel", "Maquina")
                        .WithMany()
                        .HasForeignKey("MaquinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.ASSISTENCIA_TECNICA_OS.Model.Orcamento.OrcamentoModel", "Orcamento")
                        .WithMany("Pecas")
                        .HasForeignKey("OrcamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.Pecas.PecasModel", "Peca")
                        .WithMany()
                        .HasForeignKey("PecaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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

                    b.Navigation("Maquina");

                    b.Navigation("Orcamento");

                    b.Navigation("Peca");

                    b.Navigation("UsuarioAlteracao");

                    b.Navigation("UsuarioCadastro");
                });

            modelBuilder.Entity("API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.Pecas.PecasModel", b =>
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

            modelBuilder.Entity("API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.Pecas.PecasPorMaquinaModel", b =>
                {
                    b.HasOne("API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.MaquinaModel", "Maquina")
                        .WithMany("Pecas")
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

            modelBuilder.Entity("API.ASSISTENCIA_TECNICA_OS.Model.Orcamento.DiarioOrcamentoModel", b =>
                {
                    b.HasOne("API.ASSISTENCIA_TECNICA_OS.Model.Orcamento.OrcamentoModel", "Orcamento")
                        .WithMany("Diario")
                        .HasForeignKey("OrcamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.ASSISTENCIA_TECNICA_OS.Model.User.UserModel", "UsuarioApontamento")
                        .WithMany()
                        .HasForeignKey("UsuarioApontamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Orcamento");

                    b.Navigation("UsuarioApontamento");
                });

            modelBuilder.Entity("API.ASSISTENCIA_TECNICA_OS.Model.Orcamento.OrcamentoModel", b =>
                {
                    b.HasOne("API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.MaquinaClienteModel", "MaquinaCliente")
                        .WithMany()
                        .HasForeignKey("MaquinaClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.MaquinaModel", "Maquina")
                        .WithMany()
                        .HasForeignKey("MaquinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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

                    b.Navigation("Maquina");

                    b.Navigation("MaquinaCliente");

                    b.Navigation("UsuarioAlteracao");

                    b.Navigation("UsuarioCadastro");
                });

            modelBuilder.Entity("API.ASSISTENCIA_TECNICA_OS.Model.Orcamento.StatusOrcamentoModel", b =>
                {
                    b.HasOne("API.ASSISTENCIA_TECNICA_OS.Model.Orcamento.OrcamentoModel", "Orcamento")
                        .WithMany("StatusOrcamento")
                        .HasForeignKey("OrcamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.ASSISTENCIA_TECNICA_OS.Model.Orcamento.StatusModel", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Orcamento");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("API.ASSISTENCIA_TECNICA_OS.Model.Orcamento.SugestacaoManutencaoModel", b =>
                {
                    b.HasOne("API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.MaquinaModel", "Maquina")
                        .WithMany()
                        .HasForeignKey("MaquinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.ASSISTENCIA_TECNICA_OS.Model.User.UserModel", "UsuarioSugestacao")
                        .WithMany()
                        .HasForeignKey("UsuarioSugestacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Maquina");

                    b.Navigation("UsuarioSugestacao");
                });

            modelBuilder.Entity("API.ASSISTENCIA_TECNICA_OS.Model.Orcamento.TecnicoManutencaoModel", b =>
                {
                    b.HasOne("API.ASSISTENCIA_TECNICA_OS.Model.Orcamento.OrcamentoModel", "Orcamento")
                        .WithOne("TecnicoManutenco")
                        .HasForeignKey("API.ASSISTENCIA_TECNICA_OS.Model.Orcamento.TecnicoManutencaoModel", "OrcamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.ASSISTENCIA_TECNICA_OS.Model.Tecnico.TecnicoModel", "Tecnico")
                        .WithMany()
                        .HasForeignKey("TecnicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Orcamento");

                    b.Navigation("Tecnico");
                });

            modelBuilder.Entity("API.ASSISTENCIA_TECNICA_OS.Model.Orcamento.TecnicoOrcamentoModel", b =>
                {
                    b.HasOne("API.ASSISTENCIA_TECNICA_OS.Model.Orcamento.OrcamentoModel", "Orcamento")
                        .WithOne("TecnicoOrcamento")
                        .HasForeignKey("API.ASSISTENCIA_TECNICA_OS.Model.Orcamento.TecnicoOrcamentoModel", "OrcamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.ASSISTENCIA_TECNICA_OS.Model.Tecnico.TecnicoModel", "Tecnico")
                        .WithMany()
                        .HasForeignKey("TecnicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Orcamento");

                    b.Navigation("Tecnico");
                });

            modelBuilder.Entity("API.ASSISTENCIA_TECNICA_OS.Model.Orcamento.UsuarioApontamentoFimStatusModel", b =>
                {
                    b.HasOne("API.ASSISTENCIA_TECNICA_OS.Model.Orcamento.StatusOrcamentoModel", "StatusOrcamento")
                        .WithOne("UsuarioApontamentFim")
                        .HasForeignKey("API.ASSISTENCIA_TECNICA_OS.Model.Orcamento.UsuarioApontamentoFimStatusModel", "StatusOrcamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.ASSISTENCIA_TECNICA_OS.Model.User.UserModel", "UsuarioApontamentoFim")
                        .WithMany()
                        .HasForeignKey("UsuarioApontamentoFimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StatusOrcamento");

                    b.Navigation("UsuarioApontamentoFim");
                });

            modelBuilder.Entity("API.ASSISTENCIA_TECNICA_OS.Model.Orcamento.UsuarioApontamentoInicioStatusModel", b =>
                {
                    b.HasOne("API.ASSISTENCIA_TECNICA_OS.Model.Orcamento.StatusOrcamentoModel", "StatusOrcamento")
                        .WithOne("UsuarioApontamentoInicio")
                        .HasForeignKey("API.ASSISTENCIA_TECNICA_OS.Model.Orcamento.UsuarioApontamentoInicioStatusModel", "StatusOrcamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.ASSISTENCIA_TECNICA_OS.Model.User.UserModel", "UsuarioApontamentoInicio")
                        .WithMany()
                        .HasForeignKey("UsuarioApontamentoInicioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StatusOrcamento");

                    b.Navigation("UsuarioApontamentoInicio");
                });

            modelBuilder.Entity("API.ASSISTENCIA_TECNICA_OS.Model.Tecnico.TecnicoModel", b =>
                {
                    b.HasOne("API.ASSISTENCIA_TECNICA_OS.Model.User.UserModel", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("API.ASSISTENCIA_TECNICA_OS.Model.Client.ClientModel", b =>
                {
                    b.Navigation("Maquinas");
                });

            modelBuilder.Entity("API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.MaquinaModel", b =>
                {
                    b.Navigation("MaquinaCliente");

                    b.Navigation("Pecas");
                });

            modelBuilder.Entity("API.ASSISTENCIA_TECNICA_OS.Model.Orcamento.OrcamentoModel", b =>
                {
                    b.Navigation("Diario");

                    b.Navigation("Pecas");

                    b.Navigation("StatusOrcamento");

                    b.Navigation("TecnicoManutenco");

                    b.Navigation("TecnicoOrcamento");
                });

            modelBuilder.Entity("API.ASSISTENCIA_TECNICA_OS.Model.Orcamento.StatusOrcamentoModel", b =>
                {
                    b.Navigation("UsuarioApontamentFim");

                    b.Navigation("UsuarioApontamentoInicio");
                });
#pragma warning restore 612, 618
        }
    }
}
