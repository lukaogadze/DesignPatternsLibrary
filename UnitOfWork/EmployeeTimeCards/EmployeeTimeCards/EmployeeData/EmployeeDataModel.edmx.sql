
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 04/29/2010 17:42:55
-- Generated from EDMX file: C:\dev\bitmask\writing\msft\ef4poco\EmployeeTimeCards\EmployeeData\EmployeeDataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [pocoEdm];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Employees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max),
    [HireDate] datetime  NOT NULL
);
GO

-- Creating table 'TimeCards'
CREATE TABLE [dbo].[TimeCards] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Hours] int  NOT NULL,
    [EffectiveDate] datetime  NOT NULL,
    [EmployeeTimeCard_TimeCard_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TimeCards'
ALTER TABLE [dbo].[TimeCards]
ADD CONSTRAINT [PK_TimeCards]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [EmployeeTimeCard_TimeCard_Id] in table 'TimeCards'
ALTER TABLE [dbo].[TimeCards]
ADD CONSTRAINT [FK_EmployeeTimeCard]
    FOREIGN KEY ([EmployeeTimeCard_TimeCard_Id])
    REFERENCES [dbo].[Employees]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeTimeCard'
CREATE INDEX [IX_FK_EmployeeTimeCard]
ON [dbo].[TimeCards]
    ([EmployeeTimeCard_TimeCard_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------