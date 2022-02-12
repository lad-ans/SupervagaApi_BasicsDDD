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

CREATE TABLE [tb_document] (
    [id] uniqueidentifier NOT NULL,
    [file_name] nvarchar(500) NULL,
    [FileUrl] nvarchar(max) NULL,
    [content_type] nvarchar(max) NULL,
    [file_size] bigint NULL,
    CONSTRAINT [PK_tb_document] PRIMARY KEY ([id])
);
GO

CREATE TABLE [tb_user] (
    [id] uniqueidentifier NOT NULL,
    [avatar] nvarchar(max) NULL,
    [name] nvarchar(450) NOT NULL,
    [password] nvarchar(max) NULL,
    [phone] nvarchar(max) NULL,
    [address] nvarchar(max) NULL,
    [biography] nvarchar(max) NULL,
    [email] nvarchar(450) NOT NULL,
    [type] nvarchar(max) NULL,
    [gender] nvarchar(max) NULL,
    [provider] nvarchar(max) NULL,
    [cv] nvarchar(max) NULL,
    [tag] nvarchar(max) NULL,
    [role] nvarchar(max) NULL,
    CONSTRAINT [PK_tb_user] PRIMARY KEY ([id])
);
GO

CREATE TABLE [tb_ad] (
    [id] uniqueidentifier NOT NULL,
    [title] nvarchar(450) NULL,
    [category] nvarchar(450) NULL,
    [description] nvarchar(450) NULL,
    [address] nvarchar(max) NULL,
    [audience_gender] nvarchar(max) NULL,
    [created_at] datetime2 NOT NULL DEFAULT '2022-02-12T07:28:26.1289740+02:00',
    [expires_at] datetime2 NOT NULL,
    [is_freelance] bit NOT NULL DEFAULT CAST(0 AS bit),
    [salary_offer] real NULL,
    [user_id] uniqueidentifier NOT NULL,
    [application_id] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_tb_ad] PRIMARY KEY ([id]),
    CONSTRAINT [FK_tb_user_user_id] FOREIGN KEY ([user_id]) REFERENCES [tb_user] ([id]) ON DELETE CASCADE
);
GO

CREATE TABLE [tb_advantage] (
    [id] uniqueidentifier NOT NULL,
    [ad_id] uniqueidentifier NOT NULL,
    [title] nvarchar(450) NULL,
    CONSTRAINT [PK_tb_advantage] PRIMARY KEY ([id]),
    CONSTRAINT [FK_tb_advantage_tb_ad_ad_id] FOREIGN KEY ([ad_id]) REFERENCES [tb_ad] ([id]) ON DELETE CASCADE
);
GO

CREATE TABLE [tb_application] (
    [id] uniqueidentifier NOT NULL,
    [created_at] datetime2 NOT NULL,
    [expires_at] datetime2 NOT NULL,
    [ad_id] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_tb_application] PRIMARY KEY ([id]),
    CONSTRAINT [FK_tb_application_ad_id_ad] FOREIGN KEY ([ad_id]) REFERENCES [tb_ad] ([id]) ON DELETE CASCADE
);
GO

CREATE TABLE [tb_requirement] (
    [id] uniqueidentifier NOT NULL,
    [ad_id] uniqueidentifier NOT NULL,
    [title] nvarchar(450) NULL,
    CONSTRAINT [PK_tb_requirement] PRIMARY KEY ([id]),
    CONSTRAINT [FK_tb_requirement_tb_ad_ad_id] FOREIGN KEY ([ad_id]) REFERENCES [tb_ad] ([id]) ON DELETE CASCADE
);
GO

CREATE TABLE [tb_candidate] (
    [id] uniqueidentifier NOT NULL,
    [application_id] uniqueidentifier NOT NULL,
    [id_ad] uniqueidentifier NOT NULL,
    [id_user] uniqueidentifier NOT NULL,
    [status] nvarchar(max) NOT NULL,
    [created_at] datetime2 NOT NULL,
    [is_cv] bit NOT NULL,
    CONSTRAINT [PK_tb_candidate] PRIMARY KEY ([id]),
    CONSTRAINT [FK_tb_candidate_tb_application_application_id] FOREIGN KEY ([application_id]) REFERENCES [tb_application] ([id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_tb_ad_category] ON [tb_ad] ([category]);
GO

CREATE INDEX [IX_tb_ad_description] ON [tb_ad] ([description]);
GO

CREATE INDEX [IX_tb_ad_id] ON [tb_ad] ([id]);
GO

CREATE INDEX [IX_tb_ad_title] ON [tb_ad] ([title]);
GO

CREATE INDEX [IX_tb_ad_user_id] ON [tb_ad] ([user_id]);
GO

CREATE INDEX [IX_tb_advantage_ad_id] ON [tb_advantage] ([ad_id]);
GO

CREATE INDEX [IX_tb_advantage_id] ON [tb_advantage] ([id]);
GO

CREATE INDEX [IX_tb_advantage_title] ON [tb_advantage] ([title]);
GO

CREATE UNIQUE INDEX [IX_tb_application_ad_id] ON [tb_application] ([ad_id]);
GO

CREATE INDEX [IX_tb_application_id] ON [tb_application] ([id]);
GO

CREATE INDEX [IX_tb_candidate_application_id] ON [tb_candidate] ([application_id]);
GO

CREATE INDEX [IX_tb_candidate_id] ON [tb_candidate] ([id]);
GO

CREATE INDEX [IX_tb_candidate_id_user] ON [tb_candidate] ([id_user]);
GO

CREATE INDEX [IX_tb_document_file_name] ON [tb_document] ([file_name]);
GO

CREATE INDEX [IX_tb_document_id] ON [tb_document] ([id]);
GO

CREATE INDEX [IX_tb_requirement_ad_id] ON [tb_requirement] ([ad_id]);
GO

CREATE INDEX [IX_tb_requirement_id] ON [tb_requirement] ([id]);
GO

CREATE INDEX [IX_tb_requirement_title] ON [tb_requirement] ([title]);
GO

CREATE INDEX [IX_tb_user_email] ON [tb_user] ([email]);
GO

CREATE INDEX [IX_tb_user_id] ON [tb_user] ([id]);
GO

CREATE INDEX [IX_tb_user_name] ON [tb_user] ([name]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220212052826_initial', N'6.0.1');
GO

COMMIT;
GO

