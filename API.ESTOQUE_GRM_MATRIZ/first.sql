CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230905184927_firsMigration') THEN
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
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230905184927_firsMigration') THEN
    CREATE TABLE tab_local_armazenagem (
        "Id" uuid NOT NULL,
        "Local" text NULL,
        "Ativo" boolean NOT NULL,
        "DataHoraCadastro" timestamp with time zone NOT NULL,
        "UsuarioCadastroId" uuid NOT NULL,
        "DataHoraAlteracao" timestamp with time zone NOT NULL,
        "UsuarioAlteracaoId" uuid NOT NULL,
        CONSTRAINT "PK_tab_local_armazenagem" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_tab_local_armazenagem_tab_user_auth_UsuarioAlteracaoId" FOREIGN KEY ("UsuarioAlteracaoId") REFERENCES tab_user_auth ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_tab_local_armazenagem_tab_user_auth_UsuarioCadastroId" FOREIGN KEY ("UsuarioCadastroId") REFERENCES tab_user_auth ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230905184927_firsMigration') THEN
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
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230905184927_firsMigration') THEN
    CREATE TABLE tab_estoque (
        "Id" uuid NOT NULL,
        "Codigo" text NULL,
        "Descricao" text NULL,
        "Quantidade" double precision NOT NULL,
        "TipoMaterialId" uuid NULL,
        "Preco" double precision NOT NULL,
        "DataFabricacao" timestamp with time zone NOT NULL,
        "Ativo" boolean NOT NULL,
        "Unidade" text NULL,
        "LocalArmazenagemId" uuid NULL,
        "UsuarioCadastroId" uuid NOT NULL,
        "DataHoraCadastro" timestamp with time zone NOT NULL,
        "UsuarioAlteracaoId" uuid NOT NULL,
        "DataHoraAlteracao" timestamp with time zone NOT NULL,
        CONSTRAINT "PK_tab_estoque" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_tab_estoque_tab_local_armazenagem_LocalArmazenagemId" FOREIGN KEY ("LocalArmazenagemId") REFERENCES tab_local_armazenagem ("Id"),
        CONSTRAINT "FK_tab_estoque_tab_tipo_matetial_TipoMaterialId" FOREIGN KEY ("TipoMaterialId") REFERENCES tab_tipo_matetial ("Id"),
        CONSTRAINT "FK_tab_estoque_tab_user_auth_UsuarioAlteracaoId" FOREIGN KEY ("UsuarioAlteracaoId") REFERENCES tab_user_auth ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_tab_estoque_tab_user_auth_UsuarioCadastroId" FOREIGN KEY ("UsuarioCadastroId") REFERENCES tab_user_auth ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230905184927_firsMigration') THEN
    CREATE TABLE tab_movimentacao (
        "Id" uuid NOT NULL,
        "TipoMovimentacao" text NULL,
        "MaterialId" uuid NOT NULL,
        "QuantidadeOrigem" double precision NOT NULL,
        "QuantidadeDestino" double precision NOT NULL,
        "QuantidadeMovimentada" double precision NOT NULL,
        "Destino" text NULL,
        "DataHoraMovimentacao" timestamp with time zone NOT NULL,
        "UsuarioMovimentacaoId" uuid NOT NULL,
        CONSTRAINT "PK_tab_movimentacao" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_tab_movimentacao_tab_estoque_MaterialId" FOREIGN KEY ("MaterialId") REFERENCES tab_estoque ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_tab_movimentacao_tab_user_auth_UsuarioMovimentacaoId" FOREIGN KEY ("UsuarioMovimentacaoId") REFERENCES tab_user_auth ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230905184927_firsMigration') THEN
    CREATE TABLE tab_substitutos (
        "Id" uuid NOT NULL,
        "MaterialEstoqueId" uuid NOT NULL,
        "SubstitutoId" uuid NOT NULL,
        "UsuarioCadatroId" uuid NOT NULL,
        "DataHoraCadatro" timestamp with time zone NOT NULL,
        "UsuarioAlteracaoId" uuid NOT NULL,
        "DataHoraAlteracao" timestamp with time zone NOT NULL,
        CONSTRAINT "PK_tab_substitutos" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_tab_substitutos_tab_estoque_MaterialEstoqueId" FOREIGN KEY ("MaterialEstoqueId") REFERENCES tab_estoque ("Id") ON DELETE RESTRICT,
        CONSTRAINT "FK_tab_substitutos_tab_estoque_SubstitutoId" FOREIGN KEY ("SubstitutoId") REFERENCES tab_estoque ("Id") ON DELETE RESTRICT,
        CONSTRAINT "FK_tab_substitutos_tab_user_auth_UsuarioAlteracaoId" FOREIGN KEY ("UsuarioAlteracaoId") REFERENCES tab_user_auth ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_tab_substitutos_tab_user_auth_UsuarioCadatroId" FOREIGN KEY ("UsuarioCadatroId") REFERENCES tab_user_auth ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230905184927_firsMigration') THEN
    CREATE INDEX "IX_tab_estoque_LocalArmazenagemId" ON tab_estoque ("LocalArmazenagemId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230905184927_firsMigration') THEN
    CREATE INDEX "IX_tab_estoque_TipoMaterialId" ON tab_estoque ("TipoMaterialId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230905184927_firsMigration') THEN
    CREATE INDEX "IX_tab_estoque_UsuarioAlteracaoId" ON tab_estoque ("UsuarioAlteracaoId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230905184927_firsMigration') THEN
    CREATE INDEX "IX_tab_estoque_UsuarioCadastroId" ON tab_estoque ("UsuarioCadastroId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230905184927_firsMigration') THEN
    CREATE INDEX "IX_tab_local_armazenagem_UsuarioAlteracaoId" ON tab_local_armazenagem ("UsuarioAlteracaoId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230905184927_firsMigration') THEN
    CREATE INDEX "IX_tab_local_armazenagem_UsuarioCadastroId" ON tab_local_armazenagem ("UsuarioCadastroId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230905184927_firsMigration') THEN
    CREATE INDEX "IX_tab_movimentacao_MaterialId" ON tab_movimentacao ("MaterialId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230905184927_firsMigration') THEN
    CREATE INDEX "IX_tab_movimentacao_UsuarioMovimentacaoId" ON tab_movimentacao ("UsuarioMovimentacaoId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230905184927_firsMigration') THEN
    CREATE INDEX "IX_tab_substitutos_MaterialEstoqueId" ON tab_substitutos ("MaterialEstoqueId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230905184927_firsMigration') THEN
    CREATE INDEX "IX_tab_substitutos_SubstitutoId" ON tab_substitutos ("SubstitutoId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230905184927_firsMigration') THEN
    CREATE INDEX "IX_tab_substitutos_UsuarioAlteracaoId" ON tab_substitutos ("UsuarioAlteracaoId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230905184927_firsMigration') THEN
    CREATE INDEX "IX_tab_substitutos_UsuarioCadatroId" ON tab_substitutos ("UsuarioCadatroId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230905184927_firsMigration') THEN
    CREATE INDEX "IX_tab_tipo_matetial_UserChangeId" ON tab_tipo_matetial ("UserChangeId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230905184927_firsMigration') THEN
    CREATE INDEX "IX_tab_tipo_matetial_UserRegisterId" ON tab_tipo_matetial ("UserRegisterId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230905184927_firsMigration') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20230905184927_firsMigration', '7.0.5');
    END IF;
END $EF$;
COMMIT;

