Create Database CarShopDb
use CarShopDb



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

CREATE TABLE [Brands] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Brands] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Valutes] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Valutes] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Cars] (
    [Id] int NOT NULL IDENTITY,
    [BrandId] int NOT NULL,
    [ValuteId] int NOT NULL,
    [Age] int NOT NULL,
    [Price] float NOT NULL,
    [Description] nvarchar(max) NULL,
    [Picture] nvarchar(max) NULL,
    [ABS] bit NOT NULL,
    [ElectricGlassOpener] bit NOT NULL,
    [Hatch] bit NOT NULL,
    [Bluetooth] bit NOT NULL,
    [Alarms] bit NOT NULL,
    [ParkingControl] bit NOT NULL,
    [Navigation] bit NOT NULL,
    [OnBoardComputer] bit NOT NULL,
    [MultiSteering] bit NOT NULL,
    CONSTRAINT [PK_Cars] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Cars_Brands_BrandId] FOREIGN KEY ([BrandId]) REFERENCES [Brands] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Cars_Valutes_ValuteId] FOREIGN KEY ([ValuteId]) REFERENCES [Valutes] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Cars_BrandId] ON [Cars] ([BrandId]);
GO

CREATE INDEX [IX_Cars_ValuteId] ON [Cars] ([ValuteId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220316103504_init', N'5.0.15');
GO

INSERT INTO [Valutes] ([Name])
VALUES ('GEL'), ('USD'), ('EUR')
GO

COMMIT;
GO

