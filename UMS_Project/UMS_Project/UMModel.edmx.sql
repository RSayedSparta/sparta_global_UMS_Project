
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/26/2019 09:48:25
-- Generated from EDMX file: C:\Users\tech-w100a\Desktop\Engineering26\week10\sparta_global_UMS_Project\UMS_Project\UMS_Project\UMModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [User_ManagementDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Cohort__streamID__1A14E395]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cohort] DROP CONSTRAINT [FK__Cohort__streamID__1A14E395];
GO
IF OBJECT_ID(N'[dbo].[FK__Users__roleID__173876EA]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK__Users__roleID__173876EA];
GO
IF OBJECT_ID(N'[dbo].[FK_Trainer_Cohort]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cohort] DROP CONSTRAINT [FK_Trainer_Cohort];
GO
IF OBJECT_ID(N'[dbo].[FK_Users_Cohort]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_Users_Cohort];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Cohort]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cohort];
GO
IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
GO
IF OBJECT_ID(N'[dbo].[Stream]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Stream];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Cohorts'
CREATE TABLE [dbo].[Cohorts] (
    [cohortID] int IDENTITY(1,1) NOT NULL,
    [cohortName] varchar(max)  NULL,
    [startDate] datetime  NULL,
    [endDate] datetime  NULL,
    [hasTA] bit  NULL,
    [trainerName] int  NULL,
    [streamID] int  NOT NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [roleID] int IDENTITY(1,1) NOT NULL,
    [roleName] varchar(50)  NULL,
    [roleDescription] varchar(max)  NULL
);
GO

-- Creating table 'Streams'
CREATE TABLE [dbo].[Streams] (
    [streamID] int IDENTITY(1,1) NOT NULL,
    [streamName] varchar(50)  NULL,
    [specialization] varchar(50)  NULL,
    [duration] varchar(max)  NULL,
    [curriculum] varchar(max)  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [userID] int IDENTITY(1,1) NOT NULL,
    [firstName] varchar(50)  NULL,
    [lastName] varchar(50)  NULL,
    [age] int  NULL,
    [gender] varchar(50)  NULL,
    [email] varchar(max)  NULL,
    [roleID] int  NOT NULL,
    [cohortID] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [cohortID] in table 'Cohorts'
ALTER TABLE [dbo].[Cohorts]
ADD CONSTRAINT [PK_Cohorts]
    PRIMARY KEY CLUSTERED ([cohortID] ASC);
GO

-- Creating primary key on [roleID] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([roleID] ASC);
GO

-- Creating primary key on [streamID] in table 'Streams'
ALTER TABLE [dbo].[Streams]
ADD CONSTRAINT [PK_Streams]
    PRIMARY KEY CLUSTERED ([streamID] ASC);
GO

-- Creating primary key on [userID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([userID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [streamID] in table 'Cohorts'
ALTER TABLE [dbo].[Cohorts]
ADD CONSTRAINT [FK__Cohort__streamID__1A14E395]
    FOREIGN KEY ([streamID])
    REFERENCES [dbo].[Streams]
        ([streamID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Cohort__streamID__1A14E395'
CREATE INDEX [IX_FK__Cohort__streamID__1A14E395]
ON [dbo].[Cohorts]
    ([streamID]);
GO

-- Creating foreign key on [trainerName] in table 'Cohorts'
ALTER TABLE [dbo].[Cohorts]
ADD CONSTRAINT [FK_Trainer_Cohort]
    FOREIGN KEY ([trainerName])
    REFERENCES [dbo].[Users]
        ([userID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Trainer_Cohort'
CREATE INDEX [IX_FK_Trainer_Cohort]
ON [dbo].[Cohorts]
    ([trainerName]);
GO

-- Creating foreign key on [cohortID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_Users_Cohort]
    FOREIGN KEY ([cohortID])
    REFERENCES [dbo].[Cohorts]
        ([cohortID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Users_Cohort'
CREATE INDEX [IX_FK_Users_Cohort]
ON [dbo].[Users]
    ([cohortID]);
GO

-- Creating foreign key on [roleID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK__Users__roleID__173876EA]
    FOREIGN KEY ([roleID])
    REFERENCES [dbo].[Roles]
        ([roleID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Users__roleID__173876EA'
CREATE INDEX [IX_FK__Users__roleID__173876EA]
ON [dbo].[Users]
    ([roleID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------