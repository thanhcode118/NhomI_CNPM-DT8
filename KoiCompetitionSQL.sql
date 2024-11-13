-- Tạo cơ sở dữ liệu và sử dụng nó
CREATE DATABASE KoiCompetition;
USE KoiCompetition;

-- Xóa Stored Procedure nếu đã tồn tại
IF OBJECT_ID('AddVote', 'P') IS NOT NULL
    DROP PROCEDURE AddVote;
GO

-- Xóa bảng nếu đã tồn tại
IF OBJECT_ID('Votes', 'U') IS NOT NULL
    DROP TABLE Votes;
IF OBJECT_ID('KoiManagement', 'U') IS NOT NULL
    DROP TABLE KoiManagement;
IF OBJECT_ID('Users', 'U') IS NOT NULL
    DROP TABLE Users;
GO

-- Tạo bảng Users
CREATE TABLE Users (
    user_id INT PRIMARY KEY IDENTITY,
    name NVARCHAR(255) NOT NULL,
    email NVARCHAR(255) UNIQUE NOT NULL,
    password NVARCHAR(255) NOT NULL,
    role NVARCHAR(50) CHECK (role IN ('member', 'admin')) NOT NULL,
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE()
);

-- Thêm dữ liệu mẫu cho Users
INSERT INTO Users (name, email, password, role)
VALUES 
('John Doe', 'johndoe@example.com', 'password123', 'member'),
('Alice Smith', 'alice@example.com', 'password456', 'admin'),
('Bob Johnson', 'bob@example.com', 'password789', 'member');
GO

-- Tạo bảng KoiManagement
CREATE TABLE KoiManagement (
    KoiID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
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
    id_user INT NULL,
    VoteCount INT DEFAULT 0 NOT NULL,
    CONSTRAINT FK_UserEmail FOREIGN KEY (user_email) REFERENCES Users(email),
    CONSTRAINT FK_UserID FOREIGN KEY (id_user) REFERENCES Users(user_id)
);

-- Thêm dữ liệu mẫu cho KoiManagement
INSERT INTO KoiManagement (Name, Breed, Size, Color, DateOfEntry, Origin, Price, HealthStatus, user_email, GPA, id_user)
VALUES 
('Kohaku', 'Taisho Sanke', 19.40, 'White with Red & Black', '2024-11-04', 'Japan', 1550.00, 'Healthy', 'johndoe@example.com', 3.6, 1),
('Sanke', 'Shusui', 21.80, 'Light Blue', '2024-11-05', 'China', 1400.00, 'Moderate', 'alice@example.com', 3.8, 2),
('Showa', 'Ogon', 18.00, 'Golden', '2024-11-06', 'Vietnam', 1250.00, 'Healthy', 'bob@example.com', 3.4, NULL),
('Utsuri', 'Utsuri', 23.10, 'Black & Yellow', '2024-11-07', 'Thailand', 1600.00, 'Excellent', 'johndoe@example.com', 3.9, 1),
('Asagi', 'Asagi', 17.75, 'Gray Blue', '2024-11-08', 'Japan', 1300.00, 'Healthy', 'alice@example.com', 3.5, 2);
GO

-- Tạo bảng Votes
CREATE TABLE Votes (
    VoteID INT PRIMARY KEY IDENTITY,
    KoiID INT NOT NULL,
    VoterEmail NVARCHAR(255) NOT NULL,
    VoteDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (KoiID) REFERENCES KoiManagement(KoiID),
    FOREIGN KEY (VoterEmail) REFERENCES Users(email)
);
GO

-- Tạo Stored Procedure AddVote
CREATE PROCEDURE AddVote
    @KoiID INT,
    @VoterEmail NVARCHAR(255)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Kiểm tra nếu KoiID tồn tại trong bảng KoiManagement
        IF EXISTS (SELECT 1 FROM KoiManagement WHERE KoiID = @KoiID)
        BEGIN
            -- Kiểm tra nếu đã tồn tại bình chọn
            IF NOT EXISTS (SELECT 1 FROM Votes WHERE KoiID = @KoiID AND VoterEmail = @VoterEmail)
            BEGIN
                -- Thêm bình chọn vào bảng Votes
                INSERT INTO Votes (KoiID, VoterEmail)
                VALUES (@KoiID, @VoterEmail);

                -- Cập nhật VoteCount trong bảng KoiManagement
                UPDATE KoiManagement
                SET VoteCount = VoteCount + 1
                WHERE KoiID = @KoiID;

                PRINT 'Bình chọn thành công!';
            END
            ELSE
            BEGIN
                PRINT 'Người dùng đã bình chọn cho cá này rồi.';
            END
        END
        ELSE
        BEGIN
            PRINT 'KoiID không tồn tại.';
        END

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        PRINT 'Đã xảy ra lỗi: ' + ERROR_MESSAGE();
    END CATCH
END;
GO

-- Kiểm tra dữ liệu
SELECT * FROM KoiManagement;
SELECT * FROM Votes;

-- Thực thi Stored Procedure AddVote
EXEC AddVote @KoiID = 1, @VoterEmail = 'johndoe@example.com';
EXEC AddVote @KoiID = 2, @VoterEmail = 'alice@example.com';
EXEC AddVote @KoiID = 3, @VoterEmail = 'bob@example.com';
GO
