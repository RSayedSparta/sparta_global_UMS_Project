
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
<<<<<<< HEAD
-- Date Created: 03/26/2019 09:48:25
-- Generated from EDMX file: C:\Users\tech-w100a\Desktop\Engineering26\week10\sparta_global_UMS_Project\UMS_Project\UMS_Project\UMModel.edmx
=======
-- Date Created: 03/26/2019 14:07:59
-- Generated from EDMX file: C:\Users\tech-w94a\Engineering26\Week11\sparta_global_UMS_Project\UMS_Project\UMS_Project\UMModel.edmx
>>>>>>> 68d0b4dd81efab4b657501137fed4a4c4cc085f0
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

<<<<<<< HEAD
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
=======
IF OBJECT_ID(N'[dbo].[FK__Cohort__streamID__3A81B327]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cohort] DROP CONSTRAINT [FK__Cohort__streamID__3A81B327];
GO
IF OBJECT_ID(N'[dbo].[FK__Trainer__cohortI__4222D4EF]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Trainer] DROP CONSTRAINT [FK__Trainer__cohortI__4222D4EF];
GO
IF OBJECT_ID(N'[dbo].[FK__Trainer__userID__412EB0B6]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Trainer] DROP CONSTRAINT [FK__Trainer__userID__412EB0B6];
GO
IF OBJECT_ID(N'[dbo].[FK__Users__cohortID__3E52440B]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK__Users__cohortID__3E52440B];
GO
IF OBJECT_ID(N'[dbo].[FK__Users__roleID__3D5E1FD2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK__Users__roleID__3D5E1FD2];
>>>>>>> 68d0b4dd81efab4b657501137fed4a4c4cc085f0
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
<<<<<<< HEAD
=======
IF OBJECT_ID(N'[dbo].[Trainer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Trainer];
GO
>>>>>>> 68d0b4dd81efab4b657501137fed4a4c4cc085f0
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
<<<<<<< HEAD
    [trainerName] int  NULL,
=======
    [clocation] varchar(max)  NULL,
    [maximumSeats] int  NULL,
    [minimumSeats] int  NULL,
>>>>>>> 68d0b4dd81efab4b657501137fed4a4c4cc085f0
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

<<<<<<< HEAD
=======
-- Creating table 'Trainers'
CREATE TABLE [dbo].[Trainers] (
    [trainerID] int IDENTITY(1,1) NOT NULL,
    [trainerName] varchar(max)  NULL,
    [userID] int  NOT NULL,
    [cohortID] int  NOT NULL
);
GO

>>>>>>> 68d0b4dd81efab4b657501137fed4a4c4cc085f0
-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [userID] int IDENTITY(1,1) NOT NULL,
    [firstName] varchar(50)  NULL,
    [lastName] varchar(50)  NULL,
    [age] int  NULL,
    [gender] varchar(50)  NULL,
    [email] varchar(max)  NULL,
<<<<<<< HEAD
    [roleID] int  NOT NULL,
    [cohortID] int  NULL
=======
    [upassword] varchar(max)  NULL,
    [passwordSalt] varchar(max)  NULL,
    [passwordHash] varchar(max)  NULL,
    [roleID] int  NOT NULL,
    [cohortID] int  NOT NULL
>>>>>>> 68d0b4dd81efab4b657501137fed4a4c4cc085f0
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

<<<<<<< HEAD
=======
-- Creating primary key on [trainerID] in table 'Trainers'
ALTER TABLE [dbo].[Trainers]
ADD CONSTRAINT [PK_Trainers]
    PRIMARY KEY CLUSTERED ([trainerID] ASC);
GO

>>>>>>> 68d0b4dd81efab4b657501137fed4a4c4cc085f0
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
<<<<<<< HEAD
ADD CONSTRAINT [FK__Cohort__streamID__1A14E395]
=======
ADD CONSTRAINT [FK__Cohort__streamID__3A81B327]
>>>>>>> 68d0b4dd81efab4b657501137fed4a4c4cc085f0
    FOREIGN KEY ([streamID])
    REFERENCES [dbo].[Streams]
        ([streamID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

<<<<<<< HEAD
-- Creating non-clustered index for FOREIGN KEY 'FK__Cohort__streamID__1A14E395'
CREATE INDEX [IX_FK__Cohort__streamID__1A14E395]
=======
-- Creating non-clustered index for FOREIGN KEY 'FK__Cohort__streamID__3A81B327'
CREATE INDEX [IX_FK__Cohort__streamID__3A81B327]
>>>>>>> 68d0b4dd81efab4b657501137fed4a4c4cc085f0
ON [dbo].[Cohorts]
    ([streamID]);
GO

<<<<<<< HEAD
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
=======
-- Creating foreign key on [cohortID] in table 'Trainers'
ALTER TABLE [dbo].[Trainers]
ADD CONSTRAINT [FK__Trainer__cohortI__4222D4EF]
    FOREIGN KEY ([cohortID])
    REFERENCES [dbo].[Cohorts]
        ([cohortID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Trainer__cohortI__4222D4EF'
CREATE INDEX [IX_FK__Trainer__cohortI__4222D4EF]
ON [dbo].[Trainers]
    ([cohortID]);
>>>>>>> 68d0b4dd81efab4b657501137fed4a4c4cc085f0
GO

-- Creating foreign key on [cohortID] in table 'Users'
ALTER TABLE [dbo].[Users]
<<<<<<< HEAD
ADD CONSTRAINT [FK_Users_Cohort]
=======
ADD CONSTRAINT [FK__Users__cohortID__3E52440B]
>>>>>>> 68d0b4dd81efab4b657501137fed4a4c4cc085f0
    FOREIGN KEY ([cohortID])
    REFERENCES [dbo].[Cohorts]
        ([cohortID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

<<<<<<< HEAD
-- Creating non-clustered index for FOREIGN KEY 'FK_Users_Cohort'
CREATE INDEX [IX_FK_Users_Cohort]
=======
-- Creating non-clustered index for FOREIGN KEY 'FK__Users__cohortID__3E52440B'
CREATE INDEX [IX_FK__Users__cohortID__3E52440B]
>>>>>>> 68d0b4dd81efab4b657501137fed4a4c4cc085f0
ON [dbo].[Users]
    ([cohortID]);
GO

-- Creating foreign key on [roleID] in table 'Users'
ALTER TABLE [dbo].[Users]
<<<<<<< HEAD
ADD CONSTRAINT [FK__Users__roleID__173876EA]
=======
ADD CONSTRAINT [FK__Users__roleID__3D5E1FD2]
>>>>>>> 68d0b4dd81efab4b657501137fed4a4c4cc085f0
    FOREIGN KEY ([roleID])
    REFERENCES [dbo].[Roles]
        ([roleID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

<<<<<<< HEAD
-- Creating non-clustered index for FOREIGN KEY 'FK__Users__roleID__173876EA'
CREATE INDEX [IX_FK__Users__roleID__173876EA]
=======
-- Creating non-clustered index for FOREIGN KEY 'FK__Users__roleID__3D5E1FD2'
CREATE INDEX [IX_FK__Users__roleID__3D5E1FD2]
>>>>>>> 68d0b4dd81efab4b657501137fed4a4c4cc085f0
ON [dbo].[Users]
    ([roleID]);
GO

<<<<<<< HEAD
=======
-- Creating foreign key on [userID] in table 'Trainers'
ALTER TABLE [dbo].[Trainers]
ADD CONSTRAINT [FK__Trainer__userID__412EB0B6]
    FOREIGN KEY ([userID])
    REFERENCES [dbo].[Users]
        ([userID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Trainer__userID__412EB0B6'
CREATE INDEX [IX_FK__Trainer__userID__412EB0B6]
ON [dbo].[Trainers]
    ([userID]);
GO

>>>>>>> 68d0b4dd81efab4b657501137fed4a4c4cc085f0
-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------