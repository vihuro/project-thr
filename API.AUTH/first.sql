CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230726141810_first') THEN
    CREATE TABLE tab_user (
        "Id" uuid NOT NULL,
        "Nome" text NULL,
        "Apelido" text NULL,
        "Senha" text NULL,
        "Ativo" boolean NOT NULL,
        "DataHoraCadastro" timestamp with time zone NOT NULL,
        "DataHoraAlteracao" timestamp with time zone NOT NULL,
        CONSTRAINT "PK_tab_user" PRIMARY KEY ("Id")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230726141810_first') THEN
    CREATE TABLE "tab_typeClaims" (
        "Id" uuid NOT NULL,
        "Name" text NULL,
        "Value" text NULL,
        "DataHoraCadatro" timestamp with time zone NOT NULL,
        "UsuarioCadastroId" uuid NOT NULL,
        "DataHoraAlteracao" timestamp with time zone NOT NULL,
        "UsuarioAlteracaoId" uuid NOT NULL,
        CONSTRAINT "PK_tab_typeClaims" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_tab_typeClaims_tab_user_UsuarioAlteracaoId" FOREIGN KEY ("UsuarioAlteracaoId") REFERENCES tab_user ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_tab_typeClaims_tab_user_UsuarioCadastroId" FOREIGN KEY ("UsuarioCadastroId") REFERENCES tab_user ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230726141810_first') THEN
    CREATE TABLE "tab_claimsForUser" (
        "Id" uuid NOT NULL,
        "TypeClaimsId" uuid NOT NULL,
        "UserClaimId" uuid NOT NULL,
        "UserRegisterId" uuid NOT NULL,
        "UserChangeId" uuid NOT NULL,
        CONSTRAINT "PK_tab_claimsForUser" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_tab_claimsForUser_tab_typeClaims_TypeClaimsId" FOREIGN KEY ("TypeClaimsId") REFERENCES "tab_typeClaims" ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_tab_claimsForUser_tab_user_UserChangeId" FOREIGN KEY ("UserChangeId") REFERENCES tab_user ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_tab_claimsForUser_tab_user_UserClaimId" FOREIGN KEY ("UserClaimId") REFERENCES tab_user ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_tab_claimsForUser_tab_user_UserRegisterId" FOREIGN KEY ("UserRegisterId") REFERENCES tab_user ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230726141810_first') THEN
    CREATE INDEX "IX_tab_claimsForUser_TypeClaimsId" ON "tab_claimsForUser" ("TypeClaimsId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230726141810_first') THEN
    CREATE INDEX "IX_tab_claimsForUser_UserChangeId" ON "tab_claimsForUser" ("UserChangeId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230726141810_first') THEN
    CREATE INDEX "IX_tab_claimsForUser_UserClaimId" ON "tab_claimsForUser" ("UserClaimId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230726141810_first') THEN
    CREATE INDEX "IX_tab_claimsForUser_UserRegisterId" ON "tab_claimsForUser" ("UserRegisterId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230726141810_first') THEN
    CREATE INDEX "IX_tab_typeClaims_UsuarioAlteracaoId" ON "tab_typeClaims" ("UsuarioAlteracaoId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230726141810_first') THEN
    CREATE INDEX "IX_tab_typeClaims_UsuarioCadastroId" ON "tab_typeClaims" ("UsuarioCadastroId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230726141810_first') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20230726141810_first', '7.0.5');
    END IF;
END $EF$;
COMMIT;

