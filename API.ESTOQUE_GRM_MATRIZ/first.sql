CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230723013517_firstMigration') THEN
    CREATE TABLE tab_user_auth (
        "Id" uuid NOT NULL,
        "Nome" text NULL,
        "Apelido" text NULL,
        "Ativo" boolean NOT NULL,
        CONSTRAINT "PK_tab_user_auth" PRIMARY KEY ("Id")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230723013517_firstMigration') THEN
    CREATE TABLE "LocalArmazenagemModel" (
        "Id" uuid NOT NULL,
        "Local" text NULL,
        "Ativo" boolean NOT NULL,
        "DataHoraCadastro" timestamp with time zone NOT NULL,
        "UsuarioCadastroId" uuid NOT NULL,
        "DataHoraAlteracao" timestamp with time zone NOT NULL,
        "UsuarioAlteracaoId" uuid NULL,
        CONSTRAINT "PK_LocalArmazenagemModel" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_LocalArmazenagemModel_tab_user_auth_UsuarioAlteracaoId" FOREIGN KEY ("UsuarioAlteracaoId") REFERENCES tab_user_auth ("Id"),
        CONSTRAINT "FK_LocalArmazenagemModel_tab_user_auth_UsuarioCadastroId" FOREIGN KEY ("UsuarioCadastroId") REFERENCES tab_user_auth ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230723013517_firstMigration') THEN
    CREATE TABLE tab_tipo_matetial (
        "Id" uuid NOT NULL,
        "TipoMaterial" text NULL,
        "UserRegisterId" uuid NOT NULL,
        "DataTimeRegister" timestamp with time zone NOT NULL,
        "UserChangeId" uuid NOT NULL,
        "DataTimeChange" timestamp with time zone NOT NULL,
        CONSTRAINT "PK_tab_tipo_matetial" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_tab_tipo_matetial_tab_user_auth_UserChangeId" FOREIGN KEY ("UserChangeId") REFERENCES tab_user_auth ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_tab_tipo_matetial_tab_user_auth_UserRegisterId" FOREIGN KEY ("UserRegisterId") REFERENCES tab_user_auth ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230723013517_firstMigration') THEN
    CREATE TABLE tab_estoque (
        "Id" uuid NOT NULL,
        "Codigo" text NULL,
        "Descricao" text NULL,
        "Quantidade" double precision NOT NULL,
        "TipoMaterialId" uuid NULL,
        "Unidade" text NULL,
        "LocalArmazenagemId" uuid NULL,
        "UsuarioCadastroId" uuid NOT NULL,
        "DataHoraCadstro" timestamp with time zone NOT NULL,
        "UsuarioAlteracaoId" uuid NOT NULL,
        "DataHoraAlteracao" timestamp with time zone NOT NULL,
        CONSTRAINT "PK_tab_estoque" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_tab_estoque_LocalArmazenagemModel_LocalArmazenagemId" FOREIGN KEY ("LocalArmazenagemId") REFERENCES "LocalArmazenagemModel" ("Id"),
        CONSTRAINT "FK_tab_estoque_tab_tipo_matetial_TipoMaterialId" FOREIGN KEY ("TipoMaterialId") REFERENCES tab_tipo_matetial ("Id"),
        CONSTRAINT "FK_tab_estoque_tab_user_auth_UsuarioAlteracaoId" FOREIGN KEY ("UsuarioAlteracaoId") REFERENCES tab_user_auth ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_tab_estoque_tab_user_auth_UsuarioCadastroId" FOREIGN KEY ("UsuarioCadastroId") REFERENCES tab_user_auth ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230723013517_firstMigration') THEN
    CREATE TABLE tab_substitutos (
        "Id" uuid NOT NULL,
        "MaterialEstoqueId" uuid NOT NULL,
        "SubstitutoId" uuid NOT NULL,
        "UsuarioCadatroId" uuid NOT NULL,
        "DataHoraCadatro" timestamp with time zone NOT NULL,
        "UsuarioAlteracaoId" uuid NOT NULL,
        "DataHoraAlteracao" timestamp with time zone NOT NULL,
        CONSTRAINT "PK_tab_substitutos" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_tab_substitutos_tab_estoque_MaterialEstoqueId" FOREIGN KEY ("MaterialEstoqueId") REFERENCES tab_estoque ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_tab_substitutos_tab_estoque_SubstitutoId" FOREIGN KEY ("SubstitutoId") REFERENCES tab_estoque ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_tab_substitutos_tab_user_auth_UsuarioAlteracaoId" FOREIGN KEY ("UsuarioAlteracaoId") REFERENCES tab_user_auth ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_tab_substitutos_tab_user_auth_UsuarioCadatroId" FOREIGN KEY ("UsuarioCadatroId") REFERENCES tab_user_auth ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230723013517_firstMigration') THEN
    CREATE INDEX "IX_LocalArmazenagemModel_UsuarioAlteracaoId" ON "LocalArmazenagemModel" ("UsuarioAlteracaoId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230723013517_firstMigration') THEN
    CREATE INDEX "IX_LocalArmazenagemModel_UsuarioCadastroId" ON "LocalArmazenagemModel" ("UsuarioCadastroId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230723013517_firstMigration') THEN
    CREATE INDEX "IX_tab_estoque_LocalArmazenagemId" ON tab_estoque ("LocalArmazenagemId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230723013517_firstMigration') THEN
    CREATE INDEX "IX_tab_estoque_TipoMaterialId" ON tab_estoque ("TipoMaterialId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230723013517_firstMigration') THEN
    CREATE INDEX "IX_tab_estoque_UsuarioAlteracaoId" ON tab_estoque ("UsuarioAlteracaoId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230723013517_firstMigration') THEN
    CREATE INDEX "IX_tab_estoque_UsuarioCadastroId" ON tab_estoque ("UsuarioCadastroId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230723013517_firstMigration') THEN
    CREATE INDEX "IX_tab_substitutos_MaterialEstoqueId" ON tab_substitutos ("MaterialEstoqueId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230723013517_firstMigration') THEN
    CREATE INDEX "IX_tab_substitutos_SubstitutoId" ON tab_substitutos ("SubstitutoId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230723013517_firstMigration') THEN
    CREATE INDEX "IX_tab_substitutos_UsuarioAlteracaoId" ON tab_substitutos ("UsuarioAlteracaoId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230723013517_firstMigration') THEN
    CREATE INDEX "IX_tab_substitutos_UsuarioCadatroId" ON tab_substitutos ("UsuarioCadatroId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230723013517_firstMigration') THEN
    CREATE INDEX "IX_tab_tipo_matetial_UserChangeId" ON tab_tipo_matetial ("UserChangeId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230723013517_firstMigration') THEN
    CREATE INDEX "IX_tab_tipo_matetial_UserRegisterId" ON tab_tipo_matetial ("UserRegisterId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230723013517_firstMigration') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20230723013517_firstMigration', '7.0.5');
    END IF;
END $EF$;
COMMIT;

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230723022046_secondMigration') THEN
    ALTER TABLE "LocalArmazenagemModel" DROP CONSTRAINT "FK_LocalArmazenagemModel_tab_user_auth_UsuarioAlteracaoId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230723022046_secondMigration') THEN
    ALTER TABLE "LocalArmazenagemModel" DROP CONSTRAINT "FK_LocalArmazenagemModel_tab_user_auth_UsuarioCadastroId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230723022046_secondMigration') THEN
    ALTER TABLE tab_estoque DROP CONSTRAINT "FK_tab_estoque_LocalArmazenagemModel_LocalArmazenagemId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230723022046_secondMigration') THEN
    ALTER TABLE "LocalArmazenagemModel" DROP CONSTRAINT "PK_LocalArmazenagemModel";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230723022046_secondMigration') THEN
    ALTER TABLE "LocalArmazenagemModel" RENAME TO "Local";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230723022046_secondMigration') THEN
    ALTER INDEX "IX_LocalArmazenagemModel_UsuarioCadastroId" RENAME TO "IX_Local_UsuarioCadastroId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230723022046_secondMigration') THEN
    ALTER INDEX "IX_LocalArmazenagemModel_UsuarioAlteracaoId" RENAME TO "IX_Local_UsuarioAlteracaoId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230723022046_secondMigration') THEN
    ALTER TABLE "Local" ADD CONSTRAINT "PK_Local" PRIMARY KEY ("Id");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230723022046_secondMigration') THEN
    ALTER TABLE "Local" ADD CONSTRAINT "FK_Local_tab_user_auth_UsuarioAlteracaoId" FOREIGN KEY ("UsuarioAlteracaoId") REFERENCES tab_user_auth ("Id");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230723022046_secondMigration') THEN
    ALTER TABLE "Local" ADD CONSTRAINT "FK_Local_tab_user_auth_UsuarioCadastroId" FOREIGN KEY ("UsuarioCadastroId") REFERENCES tab_user_auth ("Id") ON DELETE CASCADE;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230723022046_secondMigration') THEN
    ALTER TABLE tab_estoque ADD CONSTRAINT "FK_tab_estoque_Local_LocalArmazenagemId" FOREIGN KEY ("LocalArmazenagemId") REFERENCES "Local" ("Id");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230723022046_secondMigration') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20230723022046_secondMigration', '7.0.5');
    END IF;
END $EF$;
COMMIT;

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230724132844_teste') THEN
    ALTER TABLE "Local" DROP CONSTRAINT "FK_Local_tab_user_auth_UsuarioAlteracaoId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230724132844_teste') THEN
    UPDATE "Local" SET "UsuarioAlteracaoId" = '00000000-0000-0000-0000-000000000000' WHERE "UsuarioAlteracaoId" IS NULL;
    ALTER TABLE "Local" ALTER COLUMN "UsuarioAlteracaoId" SET NOT NULL;
    ALTER TABLE "Local" ALTER COLUMN "UsuarioAlteracaoId" SET DEFAULT '00000000-0000-0000-0000-000000000000';
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230724132844_teste') THEN
    ALTER TABLE "Local" ADD CONSTRAINT "FK_Local_tab_user_auth_UsuarioAlteracaoId" FOREIGN KEY ("UsuarioAlteracaoId") REFERENCES tab_user_auth ("Id") ON DELETE CASCADE;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230724132844_teste') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20230724132844_teste', '7.0.5');
    END IF;
END $EF$;
COMMIT;

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230724133046_teste2') THEN
    ALTER TABLE "Local" DROP CONSTRAINT "FK_Local_tab_user_auth_UsuarioAlteracaoId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230724133046_teste2') THEN
    ALTER TABLE "Local" DROP CONSTRAINT "FK_Local_tab_user_auth_UsuarioCadastroId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230724133046_teste2') THEN
    ALTER TABLE tab_estoque DROP CONSTRAINT "FK_tab_estoque_Local_LocalArmazenagemId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230724133046_teste2') THEN
    ALTER TABLE "Local" DROP CONSTRAINT "PK_Local";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230724133046_teste2') THEN
    ALTER TABLE "Local" RENAME TO tab_local_armazenagem;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230724133046_teste2') THEN
    ALTER INDEX "IX_Local_UsuarioCadastroId" RENAME TO "IX_tab_local_armazenagem_UsuarioCadastroId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230724133046_teste2') THEN
    ALTER INDEX "IX_Local_UsuarioAlteracaoId" RENAME TO "IX_tab_local_armazenagem_UsuarioAlteracaoId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230724133046_teste2') THEN
    ALTER TABLE tab_local_armazenagem ADD CONSTRAINT "PK_tab_local_armazenagem" PRIMARY KEY ("Id");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230724133046_teste2') THEN
    ALTER TABLE tab_estoque ADD CONSTRAINT "FK_tab_estoque_tab_local_armazenagem_LocalArmazenagemId" FOREIGN KEY ("LocalArmazenagemId") REFERENCES tab_local_armazenagem ("Id");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230724133046_teste2') THEN
    ALTER TABLE tab_local_armazenagem ADD CONSTRAINT "FK_tab_local_armazenagem_tab_user_auth_UsuarioAlteracaoId" FOREIGN KEY ("UsuarioAlteracaoId") REFERENCES tab_user_auth ("Id") ON DELETE CASCADE;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230724133046_teste2') THEN
    ALTER TABLE tab_local_armazenagem ADD CONSTRAINT "FK_tab_local_armazenagem_tab_user_auth_UsuarioCadastroId" FOREIGN KEY ("UsuarioCadastroId") REFERENCES tab_user_auth ("Id") ON DELETE CASCADE;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230724133046_teste2') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20230724133046_teste2', '7.0.5');
    END IF;
END $EF$;
COMMIT;

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230724154116_testeMigrations2') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20230724154116_testeMigrations2', '7.0.5');
    END IF;
END $EF$;
COMMIT;

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230725143937_AdicionandoTabelaMovimentacao') THEN
    ALTER TABLE tab_substitutos DROP CONSTRAINT "FK_tab_substitutos_tab_estoque_MaterialEstoqueId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230725143937_AdicionandoTabelaMovimentacao') THEN
    ALTER TABLE tab_substitutos DROP CONSTRAINT "FK_tab_substitutos_tab_estoque_SubstitutoId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230725143937_AdicionandoTabelaMovimentacao') THEN
    CREATE TABLE tab_movimentacao (
        "Id" uuid NOT NULL,
        "TipoMovimentacao" text NULL,
        "MaterialId" uuid NOT NULL,
        "MatetialId" uuid NULL,
        "QuantidadeOrigem" double precision NOT NULL,
        "QuantidadeDestino" double precision NOT NULL,
        "NovaQuantidade" double precision NOT NULL,
        "Destino" text NULL,
        "DataHoraMovimentacao" timestamp with time zone NOT NULL,
        "UsuarioMovimentacaoId" uuid NOT NULL,
        CONSTRAINT "PK_tab_movimentacao" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_tab_movimentacao_tab_estoque_MatetialId" FOREIGN KEY ("MatetialId") REFERENCES tab_estoque ("Id"),
        CONSTRAINT "FK_tab_movimentacao_tab_user_auth_UsuarioMovimentacaoId" FOREIGN KEY ("UsuarioMovimentacaoId") REFERENCES tab_user_auth ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230725143937_AdicionandoTabelaMovimentacao') THEN
    CREATE INDEX "IX_tab_movimentacao_MatetialId" ON tab_movimentacao ("MatetialId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230725143937_AdicionandoTabelaMovimentacao') THEN
    CREATE INDEX "IX_tab_movimentacao_UsuarioMovimentacaoId" ON tab_movimentacao ("UsuarioMovimentacaoId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230725143937_AdicionandoTabelaMovimentacao') THEN
    ALTER TABLE tab_substitutos ADD CONSTRAINT "FK_tab_substitutos_tab_estoque_MaterialEstoqueId" FOREIGN KEY ("MaterialEstoqueId") REFERENCES tab_estoque ("Id") ON DELETE RESTRICT;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230725143937_AdicionandoTabelaMovimentacao') THEN
    ALTER TABLE tab_substitutos ADD CONSTRAINT "FK_tab_substitutos_tab_estoque_SubstitutoId" FOREIGN KEY ("SubstitutoId") REFERENCES tab_estoque ("Id") ON DELETE RESTRICT;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230725143937_AdicionandoTabelaMovimentacao') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20230725143937_AdicionandoTabelaMovimentacao', '7.0.5');
    END IF;
END $EF$;
COMMIT;

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230725174900_adicionado_coluna_tabela_movimentacao') THEN
    ALTER TABLE tab_movimentacao DROP CONSTRAINT "FK_tab_movimentacao_tab_estoque_MatetialId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230725174900_adicionado_coluna_tabela_movimentacao') THEN
    DROP INDEX "IX_tab_movimentacao_MatetialId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230725174900_adicionado_coluna_tabela_movimentacao') THEN
    ALTER TABLE tab_movimentacao DROP COLUMN "MatetialId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230725174900_adicionado_coluna_tabela_movimentacao') THEN
    ALTER TABLE tab_movimentacao RENAME COLUMN "NovaQuantidade" TO "QuantidadeMovimentada";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230725174900_adicionado_coluna_tabela_movimentacao') THEN
    CREATE INDEX "IX_tab_movimentacao_MaterialId" ON tab_movimentacao ("MaterialId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230725174900_adicionado_coluna_tabela_movimentacao') THEN
    ALTER TABLE tab_movimentacao ADD CONSTRAINT "FK_tab_movimentacao_tab_estoque_MaterialId" FOREIGN KEY ("MaterialId") REFERENCES tab_estoque ("Id") ON DELETE CASCADE;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230725174900_adicionado_coluna_tabela_movimentacao') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20230725174900_adicionado_coluna_tabela_movimentacao', '7.0.5');
    END IF;
END $EF$;
COMMIT;

