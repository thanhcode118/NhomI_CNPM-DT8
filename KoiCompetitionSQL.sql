-- Create Database and Use it
CREATE DATABASE KoiCompetition;
USE KoiCompetition;

-- Drop Users table if it exists
DROP TABLE IF EXISTS Users;

-- Create Users Table
CREATE TABLE Users (
    user_id INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(255) NOT NULL,
    email NVARCHAR(255) UNIQUE NOT NULL,
    password NVARCHAR(255) NOT NULL,
    role NVARCHAR(50) CHECK (role IN ('member', 'admin')) NOT NULL,
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE()
);

-- Drop KoiManagement table if it exists
DROP TABLE IF EXISTS KoiManagement;

-- Create KoiManagement Table
CREATE TABLE KoiManagement (
    KoiID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL,
    Breed NVARCHAR(50) NOT NULL,
    Size DECIMAL(5, 2) NOT NULL,
    Color NVARCHAR(50) NULL,
    DateOfEntry DATE NULL,
    Origin NVARCHAR(100) NULL,
    Price DECIMAL(10, 2) NULL,
    HealthStatus NVARCHAR(50) NULL,
    user_email NVARCHAR(255) NOT NULL,
    GPA DECIMAL(3, 2) NOT NULL,
    CONSTRAINT FK_UserEmail FOREIGN KEY (user_email) REFERENCES Users(email)
);

-- Select all records from Users table
SELECT * FROM Users;
