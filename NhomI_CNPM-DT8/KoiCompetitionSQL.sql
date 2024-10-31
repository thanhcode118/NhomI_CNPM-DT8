-- Tạo cơ sở dữ liệu
CREATE DATABASE KoiCompetition;
GO

-- Sử dụng cơ sở dữ liệu vừa tạo
USE KoiCompetition;
GO

-- Tạo bảng Account
CREATE TABLE Account (
    id INT PRIMARY KEY IDENTITY(1,1),
    name NVARCHAR(100) NOT NULL,
    email NVARCHAR(100) NOT NULL UNIQUE,
    username NVARCHAR(50) NOT NULL UNIQUE,
    password NVARCHAR(255) NOT NULL,
    role NVARCHAR(50) NOT NULL
);
GO
