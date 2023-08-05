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

CREATE TABLE [article] (
    [ArticleId] int NOT NULL IDENTITY,
    [Name] nvarchar(100) NULL,
    [Content] ntext NULL,
    CONSTRAINT [PK_article] PRIMARY KEY ([ArticleId])
);
GO

CREATE TABLE [tags] (
    [TagId] nvarchar(20) NOT NULL,
    [Content] ntext NULL,
    CONSTRAINT [PK_tags] PRIMARY KEY ([TagId])
);
GO

CREATE TABLE [articletag] (
    [ArticleTagId] int NOT NULL IDENTITY,
    [ArticleId] int NOT NULL,
    [TagId] nvarchar(20) NULL,
    CONSTRAINT [PK_articletag] PRIMARY KEY ([ArticleTagId]),
    CONSTRAINT [FK_articletag_article_ArticleId] FOREIGN KEY ([ArticleId]) REFERENCES [article] ([ArticleId]) ON DELETE CASCADE,
    CONSTRAINT [FK_articletag_tags_TagId] FOREIGN KEY ([TagId]) REFERENCES [tags] ([TagId]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_articletag_ArticleId] ON [articletag] ([ArticleId]);
GO

CREATE UNIQUE INDEX [IX_articletag_ArticleTagId_TagId] ON [articletag] ([ArticleTagId], [TagId]) WHERE [TagId] IS NOT NULL;
GO

CREATE INDEX [IX_articletag_TagId] ON [articletag] ([TagId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230805164711_v0', N'5.0.4');
GO

COMMIT;
GO

