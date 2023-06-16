IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230304205017_Intial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230304205017_Intial', N'7.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230304232311_TheBase')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230304232311_TheBase')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230304232311_TheBase')
BEGIN
    CREATE TABLE [Hospitals] (
        [Id] int NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [Email] nvarchar(max) NOT NULL,
        [Website] nvarchar(max) NOT NULL,
        [Region] nvarchar(max) NOT NULL,
        [City] nvarchar(max) NOT NULL,
        [Phone1] nvarchar(max) NOT NULL,
        [Phone2] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Hospitals] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230304232311_TheBase')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230304232311_TheBase')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230304232311_TheBase')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230304232311_TheBase')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230304232311_TheBase')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230304232311_TheBase')
BEGIN
    CREATE TABLE [DialysisUnits] (
        [DialysisUnitId] int NOT NULL,
        [Name] nvarchar(50) NOT NULL,
        [HospitalId] int NOT NULL,
        CONSTRAINT [PK_DialysisUnits] PRIMARY KEY ([DialysisUnitId]),
        CONSTRAINT [FK_DialysisUnits_Hospitals_HospitalId] FOREIGN KEY ([HospitalId]) REFERENCES [Hospitals] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230304232311_TheBase')
BEGIN
    CREATE TABLE [Doctors] (
        [DoctorId] int NOT NULL,
        [Name] nvarchar(100) NOT NULL,
        [gender] int NOT NULL,
        [Position] nvarchar(max) NOT NULL,
        [dialysisunitId] int NOT NULL,
        CONSTRAINT [PK_Doctors] PRIMARY KEY ([DoctorId]),
        CONSTRAINT [FK_Doctors_DialysisUnits_dialysisunitId] FOREIGN KEY ([dialysisunitId]) REFERENCES [DialysisUnits] ([DialysisUnitId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230304232311_TheBase')
BEGIN
    CREATE TABLE [Nurses] (
        [NurseId] int NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [gender] int NOT NULL,
        [dialysisUnitId] int NOT NULL,
        CONSTRAINT [PK_Nurses] PRIMARY KEY ([NurseId]),
        CONSTRAINT [FK_Nurses_DialysisUnits_dialysisUnitId] FOREIGN KEY ([dialysisUnitId]) REFERENCES [DialysisUnits] ([DialysisUnitId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230304232311_TheBase')
BEGIN
    CREATE TABLE [Patients] (
        [PatientId] int NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [gender] int NOT NULL,
        [Country] nvarchar(max) NOT NULL,
        [City] nvarchar(max) NOT NULL,
        [Phone] int NOT NULL,
        [dialysisUnitId] int NOT NULL,
        CONSTRAINT [PK_Patients] PRIMARY KEY ([PatientId]),
        CONSTRAINT [FK_Patients_DialysisUnits_dialysisUnitId] FOREIGN KEY ([dialysisUnitId]) REFERENCES [DialysisUnits] ([DialysisUnitId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230304232311_TheBase')
BEGIN
    CREATE TABLE [Drugs] (
        [Code] int NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [Brand] nvarchar(max) NOT NULL,
        [Dosage] tinyint NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [DoctorId] int NOT NULL,
        CONSTRAINT [PK_Drugs] PRIMARY KEY ([Code]),
        CONSTRAINT [FK_Drugs_Doctors_DoctorId] FOREIGN KEY ([DoctorId]) REFERENCES [Doctors] ([DoctorId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230304232311_TheBase')
BEGIN
    CREATE TABLE [PatientDoctors] (
        [PatientId] int NOT NULL,
        [DoctorID] int NOT NULL,
        CONSTRAINT [PK_PatientDoctors] PRIMARY KEY ([PatientId], [DoctorID]),
        CONSTRAINT [FK_PatientDoctors_Doctors_DoctorID] FOREIGN KEY ([DoctorID]) REFERENCES [Doctors] ([DoctorId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_PatientDoctors_Patients_PatientId] FOREIGN KEY ([PatientId]) REFERENCES [Patients] ([PatientId]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230304232311_TheBase')
BEGIN
    CREATE TABLE [PatientNurses] (
        [PatientId] int NOT NULL,
        [NurseId] int NOT NULL,
        CONSTRAINT [PK_PatientNurses] PRIMARY KEY ([PatientId], [NurseId]),
        CONSTRAINT [FK_PatientNurses_Nurses_NurseId] FOREIGN KEY ([NurseId]) REFERENCES [Nurses] ([NurseId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_PatientNurses_Patients_PatientId] FOREIGN KEY ([PatientId]) REFERENCES [Patients] ([PatientId]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230304232311_TheBase')
BEGIN
    CREATE TABLE [PatientDrugs] (
        [PatientId] int NOT NULL,
        [DrugId] int NOT NULL,
        [NTimes] datetime2 NOT NULL,
        CONSTRAINT [PK_PatientDrugs] PRIMARY KEY ([PatientId], [DrugId]),
        CONSTRAINT [FK_PatientDrugs_Drugs_DrugId] FOREIGN KEY ([DrugId]) REFERENCES [Drugs] ([Code]) ON DELETE NO ACTION,
        CONSTRAINT [FK_PatientDrugs_Patients_PatientId] FOREIGN KEY ([PatientId]) REFERENCES [Patients] ([PatientId]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230304232311_TheBase')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230304232311_TheBase')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230304232311_TheBase')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230304232311_TheBase')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230304232311_TheBase')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230304232311_TheBase')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230304232311_TheBase')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230304232311_TheBase')
BEGIN
    CREATE INDEX [IX_DialysisUnits_HospitalId] ON [DialysisUnits] ([HospitalId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230304232311_TheBase')
BEGIN
    CREATE INDEX [IX_Doctors_dialysisunitId] ON [Doctors] ([dialysisunitId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230304232311_TheBase')
BEGIN
    CREATE INDEX [IX_Drugs_DoctorId] ON [Drugs] ([DoctorId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230304232311_TheBase')
BEGIN
    CREATE INDEX [IX_Nurses_dialysisUnitId] ON [Nurses] ([dialysisUnitId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230304232311_TheBase')
BEGIN
    CREATE INDEX [IX_PatientDoctors_DoctorID] ON [PatientDoctors] ([DoctorID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230304232311_TheBase')
BEGIN
    CREATE INDEX [IX_PatientDrugs_DrugId] ON [PatientDrugs] ([DrugId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230304232311_TheBase')
BEGIN
    CREATE INDEX [IX_PatientNurses_NurseId] ON [PatientNurses] ([NurseId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230304232311_TheBase')
BEGIN
    CREATE INDEX [IX_Patients_dialysisUnitId] ON [Patients] ([dialysisUnitId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230304232311_TheBase')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230304232311_TheBase', N'7.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230307163940_help')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230307163940_help', N'7.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230310235954_TheBase2')
BEGIN
    EXEC sp_rename N'[Hospitals].[Region]', N'Country', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230310235954_TheBase2')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Patients]') AND [c].[name] = N'Phone');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Patients] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Patients] ALTER COLUMN [Phone] nvarchar(max) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230310235954_TheBase2')
BEGIN
    ALTER TABLE [Patients] ADD [Email] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230310235954_TheBase2')
BEGIN
    ALTER TABLE [Nurses] ADD [Email] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230310235954_TheBase2')
BEGIN
    ALTER TABLE [Nurses] ADD [Phone] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230310235954_TheBase2')
BEGIN
    ALTER TABLE [Hospitals] ADD [Area] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230310235954_TheBase2')
BEGIN
    ALTER TABLE [Doctors] ADD [Email] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230310235954_TheBase2')
BEGIN
    ALTER TABLE [Doctors] ADD [Phone] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230310235954_TheBase2')
BEGIN
    ALTER TABLE [DialysisUnits] ADD [capacity] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230310235954_TheBase2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230310235954_TheBase2', N'7.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230311000413_Helper')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name', N'NormalizedName', N'ConcurrencyStamp') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
        SET IDENTITY_INSERT [AspNetRoles] ON;
    EXEC(N'INSERT INTO [AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp])
    VALUES (N''21b85ae2-fc20-494d-98a4-63a83de68fa7'', N''Admin'', N''ADMIN'', N''26121dd4-e592-43c6-96a0-44ab1c3bfd69'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name', N'NormalizedName', N'ConcurrencyStamp') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
        SET IDENTITY_INSERT [AspNetRoles] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230311000413_Helper')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name', N'NormalizedName', N'ConcurrencyStamp') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
        SET IDENTITY_INSERT [AspNetRoles] ON;
    EXEC(N'INSERT INTO [AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp])
    VALUES (N''9697f52b-c3af-4f80-9cfc-0a63ece6fec9'', N''Doctor'', N''DOCTOR'', N''dfab04d0-ffd7-4718-a3e6-92e70daabf1d'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name', N'NormalizedName', N'ConcurrencyStamp') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
        SET IDENTITY_INSERT [AspNetRoles] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230311000413_Helper')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name', N'NormalizedName', N'ConcurrencyStamp') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
        SET IDENTITY_INSERT [AspNetRoles] ON;
    EXEC(N'INSERT INTO [AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp])
    VALUES (N''c2b4d424-a543-4a0c-9f78-ce092ca49ad6'', N''Patient'', N''PATIENT'', N''d4f8b4c7-098a-46f8-aacb-2edc563b8e3f'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name', N'NormalizedName', N'ConcurrencyStamp') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
        SET IDENTITY_INSERT [AspNetRoles] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230311000413_Helper')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name', N'NormalizedName', N'ConcurrencyStamp') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
        SET IDENTITY_INSERT [AspNetRoles] ON;
    EXEC(N'INSERT INTO [AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp])
    VALUES (N''47631c6c-308b-4437-aeac-19bff053bb6e'', N''User'', N''USER'', N''5d1e52d9-20e3-46ca-9ab2-823e2633916a'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name', N'NormalizedName', N'ConcurrencyStamp') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
        SET IDENTITY_INSERT [AspNetRoles] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230311000413_Helper')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230311000413_Helper', N'7.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230312165028_NEWNEW')
BEGIN
    ALTER TABLE [Drugs] ADD [ReportId] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230312165028_NEWNEW')
BEGIN
    CREATE TABLE [Reports] (
        [ReportId] int NOT NULL IDENTITY,
        [Status] nvarchar(max) NOT NULL,
        [ReportName] nvarchar(max) NOT NULL,
        [ReportDescription] nvarchar(max) NOT NULL,
        [ReportType] nvarchar(max) NOT NULL,
        [DoctorId] int NOT NULL,
        [PatientId] int NOT NULL,
        CONSTRAINT [PK_Reports] PRIMARY KEY ([ReportId]),
        CONSTRAINT [FK_Reports_Doctors_DoctorId] FOREIGN KEY ([DoctorId]) REFERENCES [Doctors] ([DoctorId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Reports_Patients_PatientId] FOREIGN KEY ([PatientId]) REFERENCES [Patients] ([PatientId]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230312165028_NEWNEW')
BEGIN
    CREATE TABLE [Schedules] (
        [ScheduleId] int NOT NULL IDENTITY,
        [NumberOfTimes] int NOT NULL,
        [DateOfTreatment] datetime2 NOT NULL,
        [days] int NOT NULL,
        [PatientId] int NOT NULL,
        CONSTRAINT [PK_Schedules] PRIMARY KEY ([ScheduleId]),
        CONSTRAINT [FK_Schedules_Patients_PatientId] FOREIGN KEY ([PatientId]) REFERENCES [Patients] ([PatientId]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230312165028_NEWNEW')
BEGIN
    CREATE INDEX [IX_Drugs_ReportId] ON [Drugs] ([ReportId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230312165028_NEWNEW')
BEGIN
    CREATE INDEX [IX_Reports_DoctorId] ON [Reports] ([DoctorId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230312165028_NEWNEW')
BEGIN
    CREATE INDEX [IX_Reports_PatientId] ON [Reports] ([PatientId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230312165028_NEWNEW')
BEGIN
    CREATE INDEX [IX_Schedules_PatientId] ON [Schedules] ([PatientId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230312165028_NEWNEW')
BEGIN
    ALTER TABLE [Drugs] ADD CONSTRAINT [FK_Drugs_Reports_ReportId] FOREIGN KEY ([ReportId]) REFERENCES [Reports] ([ReportId]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230312165028_NEWNEW')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230312165028_NEWNEW', N'7.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230324213306_Final')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230324213306_Final', N'7.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230324225422_FinalKidney')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230324225422_FinalKidney', N'7.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230327194215_ssssss')
BEGIN
    ALTER TABLE [Schedules] DROP CONSTRAINT [FK_Schedules_Patients_PatientId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230327194215_ssssss')
BEGIN
    ALTER TABLE [Schedules] DROP CONSTRAINT [PK_Schedules];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230327194215_ssssss')
BEGIN
    EXEC sp_rename N'[Schedules]', N'Schedule';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230327194215_ssssss')
BEGIN
    EXEC sp_rename N'[Schedule].[IX_Schedules_PatientId]', N'IX_Schedule_PatientId', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230327194215_ssssss')
BEGIN
    ALTER TABLE [Schedule] ADD CONSTRAINT [PK_Schedule] PRIMARY KEY ([ScheduleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230327194215_ssssss')
BEGIN
    ALTER TABLE [Schedule] ADD CONSTRAINT [FK_Schedule_Patients_PatientId] FOREIGN KEY ([PatientId]) REFERENCES [Patients] ([PatientId]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230327194215_ssssss')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230327194215_ssssss', N'7.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230513180212_ReportFiles')
BEGIN
    ALTER TABLE [Drugs] ADD [Date] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230513180212_ReportFiles')
BEGIN
    ALTER TABLE [Drugs] ADD [History] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230513180212_ReportFiles')
BEGIN
    CREATE TABLE [ReportFiles] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [ReportsReportId] int NOT NULL,
        CONSTRAINT [PK_ReportFiles] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ReportFiles_Reports_ReportsReportId] FOREIGN KEY ([ReportsReportId]) REFERENCES [Reports] ([ReportId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230513180212_ReportFiles')
BEGIN
    CREATE INDEX [IX_ReportFiles_ReportsReportId] ON [ReportFiles] ([ReportsReportId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230513180212_ReportFiles')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230513180212_ReportFiles', N'7.0.0');
END;
GO

COMMIT;
GO

