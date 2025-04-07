
CREATE DATABASE EmployeeDb;
GO
USE EmployeeDb;
GO

-- Role Master
CREATE TABLE RoleMaster (
    Id INT PRIMARY KEY IDENTITY(1,1),
    RoleName NVARCHAR(100) NOT NULL
);

INSERT INTO RoleMaster (RoleName)
VALUES ('Employee'), ('Manager'), ('Admin');

-- Users
CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(100) NOT NULL,
    Password NVARCHAR(100) NOT NULL,
    RoleId INT NOT NULL,
    IsActive INT DEFAULT 1,
    IsDeleted INT DEFAULT 0,
    FOREIGN KEY (RoleId) REFERENCES RoleMaster(Id)
);

-- Leave Status Master
CREATE TABLE LeaveStatusMaster (
    Id INT PRIMARY KEY IDENTITY(1,1),
    StatusName NVARCHAR(50) NOT NULL
);

INSERT INTO LeaveStatusMaster (StatusName)
VALUES ('Pending'), ('Approved'), ('Rejected');

-- Notification Type Master
CREATE TABLE NotificationTypeMaster (
    Id INT PRIMARY KEY IDENTITY(1,1),
    TypeName NVARCHAR(50) NOT NULL
);

INSERT INTO NotificationTypeMaster (TypeName)
VALUES ('Email'), ('SMS');

-- Employee Leaves
CREATE TABLE EmployeeLeaves (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UserId INT NOT NULL,
    FromDate DATE NOT NULL,
    ToDate DATE NOT NULL,
    Reason NVARCHAR(MAX),
    LeaveStatusId INT NOT NULL,
    NotificationTypeId INT NOT NULL,
    FOREIGN KEY (UserId) REFERENCES Users(Id),
    FOREIGN KEY (LeaveStatusId) REFERENCES LeaveStatusMaster(Id),
    FOREIGN KEY (NotificationTypeId) REFERENCES NotificationTypeMaster(Id)
);
