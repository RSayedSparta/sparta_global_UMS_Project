--DROP DATABASE User_ManagementDB;
--CREATE DATABASE User_ManagementDB;
--USE User_ManagementDB; 

DROP TABLE Trainer, Users, Cohorts,Stream,Roles;

CREATE TABLE Roles(
    roleID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    roleName VARCHAR(50),
    roleDescription VARCHAR(MAX)
    )

CREATE TABLE Streams(
    streamID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    streamName VARCHAR(50),
    specialization VARCHAR(50),
    duration VARCHAR(MAX),
    curriculum VARCHAR(MAX)
    )

CREATE TABLE Cohorts(
    cohortID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    cohortName VARCHAR(MAX),
    startDate DATETIME,
    endDate DATETIME,
    hasTA BIT,
    clocation VARCHAR(MAX),
    maximumSeats INT,
    minimumSeats INT,
    streamID INT NOT NULL FOREIGN KEY (streamID)REFERENCES Streams
)

CREATE TABLE Users(
    userID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    firstName VARCHAR(50),
    lastName VARCHAR(50),
    age INT,
    gender VARCHAR(50),
    email VARCHAR(MAX),
    upassword VARCHAR(MAX),
    passwordSalt VARCHAR(MAX),
    passwordHash VARCHAR(MAX),
    roleID INT NOT NULL FOREIGN KEY (roleID)REFERENCES Roles,
    cohortID INT NOT NULL FOREIGN KEY (cohortID)REFERENCES Cohorts
)


CREATE TABLE Trainers(
    trainerID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    trainerName VARCHAR(MAX),
    userID INT NOT NULL FOREIGN KEY (userID)REFERENCES Users,
    cohortID INT NOT NULL FOREIGN KEY (cohortID)REFERENCES Cohorts
)
