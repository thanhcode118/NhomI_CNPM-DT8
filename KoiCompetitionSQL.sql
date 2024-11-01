CREATE DATABASE KoiCompetition;
USE KoiCompetition;

-- Xóa bảng nếu đã tồn tại
DROP TABLE IF EXISTS Users;

-- Bảng Users
CREATE TABLE Users (
    user_id INT PRIMARY KEY IDENTITY,
    name NVARCHAR(255) NOT NULL,
    email NVARCHAR(255) UNIQUE NOT NULL,
    password NVARCHAR(255) NOT NULL,
    role NVARCHAR(50) CHECK (role IN ('member', 'admin')) NOT NULL,
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE()
);


select * from Users