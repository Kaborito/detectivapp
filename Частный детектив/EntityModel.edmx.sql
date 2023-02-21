
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/03/2023 19:00:10
-- Generated from EDMX file: C:\Users\1234\Desktop\Частный детектив модель первая\Частный детектив\EntityModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [C:\Users\1234\Desktop\Частный детектив модель первая\teatr.mdf];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_PostanovSpectak]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Spektaks] DROP CONSTRAINT [FK_PostanovSpectak];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Kassirs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Kassirs];
GO
IF OBJECT_ID(N'[dbo].[Bilets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bilets];
GO
IF OBJECT_ID(N'[dbo].[Spektaks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Spektaks];
GO
IF OBJECT_ID(N'[dbo].[Postanovs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Postanovs];
GO
IF OBJECT_ID(N'[dbo].[Clients]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clients];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Kassirs'
CREATE TABLE [dbo].[Kassirs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Mail] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Number] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Bilets'
CREATE TABLE [dbo].[Bilets] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Date] nvarchar(max)  NOT NULL,
    [Oplata] nvarchar(max)  NOT NULL,
    [ClientId] int  NOT NULL,
    [id_Client] nvarchar(max)  NOT NULL,
    [id_Spektak] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Spektaks'
CREATE TABLE [dbo].[Spektaks] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Price] nvarchar(max)  NOT NULL,
    [Date] nvarchar(max)  NOT NULL,
    [Actors] nvarchar(max)  NOT NULL,
    [Photo] int  NOT NULL,
    [Actual] nvarchar(max)  NOT NULL,
    [PostanovId] int  NOT NULL
);
GO

-- Creating table 'Postanovs'
CREATE TABLE [dbo].[Postanovs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Mail] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Number] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Clients'
CREATE TABLE [dbo].[Clients] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Mail] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Number] nvarchar(max)  NOT NULL,
    [Skidka] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Kassirs'
ALTER TABLE [dbo].[Kassirs]
ADD CONSTRAINT [PK_Kassirs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Bilets'
ALTER TABLE [dbo].[Bilets]
ADD CONSTRAINT [PK_Bilets]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Spektaks'
ALTER TABLE [dbo].[Spektaks]
ADD CONSTRAINT [PK_Spektaks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Postanovs'
ALTER TABLE [dbo].[Postanovs]
ADD CONSTRAINT [PK_Postanovs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Clients'
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [PK_Clients]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PostanovId] in table 'Spektaks'
ALTER TABLE [dbo].[Spektaks]
ADD CONSTRAINT [FK_PostanovSpectak]
    FOREIGN KEY ([PostanovId])
    REFERENCES [dbo].[Postanovs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PostanovSpectak'
CREATE INDEX [IX_FK_PostanovSpectak]
ON [dbo].[Spektaks]
    ([PostanovId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------