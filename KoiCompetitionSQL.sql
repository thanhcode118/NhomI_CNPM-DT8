-- Tạo cơ sở dữ liệu và sử dụng nó
CREATE DATABASE KoiCompetition;
go
USE KoiCompetition;
go
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
go
-- Thêm dữ liệu mẫu cho Users
INSERT INTO Users (name, email, password, role)
VALUES 
('John Doe', 'johndoe@example.com', 'password123', 'member'),
('Alice Smith', 'alice@example.com', 'password456', 'admin'),
('Bob Johnson', 'bob@example.com', 'password789', 'member');
GO

-- Tạo bảng KoiManagement
-- Tạo bảng KoiManagement với các thuộc tính mở rộng
CREATE TABLE KoiManagement (
    KoiID INT IDENTITY(1,1) NOT NULL PRIMARY KEY, -- ID Cá Koi tự động tăng
    Name NVARCHAR(50) NOT NULL,                  -- Tên Cá Koi
    Breed NVARCHAR(50) NOT NULL,                 -- Giống Cá Koi
    Size DECIMAL(5, 2) NOT NULL CHECK (Size > 0), -- Kích thước, phải lớn hơn 0
    Color NVARCHAR(50) NULL,                     -- Màu sắc
    DateOfEntry DATE NOT NULL DEFAULT GETDATE(), -- Ngày thêm vào, mặc định là ngày hiện tại
    Origin NVARCHAR(100) NULL,                   -- Nguồn gốc
    Price DECIMAL(10, 2) NULL CHECK (Price >= 0), -- Giá, phải không âm
    HealthStatus NVARCHAR(50) NULL CHECK (HealthStatus IN ('Healthy', 'Moderate', 'Excellent')), -- Tình trạng sức khỏe
    ContestCategory NVARCHAR(100) NULL,          -- Hạng mục tham gia cuộc thi
    ContestStatus NVARCHAR(50) DEFAULT 'Pending' NOT NULL, -- Trạng thái tham gia cuộc thi
    ContestDate DATE NULL,                       -- Ngày tham gia cuộc thi
    user_email NVARCHAR(255) NOT NULL,           -- Email người dùng
    GPA DECIMAL(3, 2) NOT NULL CHECK (GPA BETWEEN 0 AND 4), -- GPA trong khoảng 0-4
    id_user INT NULL,                            -- ID người dùng
    VoteCount INT DEFAULT 0 NOT NULL CHECK (VoteCount >= 0), -- Số lượt bình chọn
    CONSTRAINT FK_UserEmail FOREIGN KEY (user_email) REFERENCES Users(email) ON DELETE CASCADE,
    CONSTRAINT FK_UserID FOREIGN KEY (id_user) REFERENCES Users(user_id) ON DELETE NO ACTION
);

go

-- Thêm dữ liệu mẫu cho KoiManagement
INSERT INTO KoiManagement (Name, Breed, Size, Color, DateOfEntry, Origin, Price, HealthStatus, user_email, GPA, id_user, ContestCategory, ContestStatus, ContestDate)
VALUES 
-- Loại Kohaku
('Kohaku Shine', 'Kohaku', 19.40, 'White with Red & Black', '2024-11-01', 'Japan', 1550.00, 'Healthy', 'johndoe@example.com', 3.6, 1, 'Best Color', 'Pending', '2024-11-15'),
('Sanke Glow', 'Sanke', 19.50, 'Light Blue', '2024-11-05', 'China', 1450.00, 'Moderate', 'alice@example.com', 3.6, 2, 'Best Pattern', 'Pending', '2024-11-16'),
('Kohaku Grace', 'Kohaku', 20.00, 'White with Red & Black', '2024-11-03', 'Japan', 1600.00, 'Excellent', 'bob@example.com', 3.8, 3, 'Best Color', 'Pending', '2024-11-15'),

-- Loại Sanke
('Sanke Blue', 'Sanke', 21.80, 'Light Blue', '2024-11-04', 'China', 1400.00, 'Healthy', 'johndoe@example.com', 3.7, 1, 'Best Pattern', 'Pending', '2024-11-16'),
('Sanke Moon', 'Sanke', 12.10, 'Light Blue', '2024-11-06', 'China', 1500.00, 'Excellent', 'bob@example.com', 3.9, 3, 'Best Pattern', 'Pending', '2024-11-16'),
('Kohaku Spark', 'Kohaku', 18.50, 'White with Red & Black', '2024-11-02', 'Japan', 1500.00, 'Moderate', 'alice@example.com', 3.5, 2, 'Best Color', 'Pending', '2024-11-15'),

-- Loại Showa
('Showa Gold', 'Showa', 18.00, 'Golden', '2024-11-07', 'Vietnam', 1250.00, 'Healthy', 'johndoe@example.com', 3.4, 1, 'Best Overall', 'Pending', '2024-11-17'),
('Utsuri Radiance', 'Utsuri', 25.00, 'Black & Yellow', '2024-11-12', 'Thailand', 1700.00, 'Excellent', 'bob@example.com', 4.0, 3, 'Best Size', 'Pending', '2024-11-18'),
('Showa Pearl', 'Showa', 20.50, 'Golden', '2024-11-09', 'Vietnam', 1400.00, 'Excellent', 'bob@example.com', 3.7, 3, 'Best Overall', 'Pending', '2024-11-17'),

-- Loại Utsuri
('Utsuri Flame', 'Utsuri', 23.10, 'Black & Yellow', '2024-11-10', 'Thailand', 1600.00, 'Healthy', 'johndoe@example.com', 3.9, 1, 'Best Size', 'Pending', '2024-11-18'),
('Asagi Sky', 'Asagi', 17.75, 'Gray Blue', '2024-11-13', 'Japan', 1300.00, 'Healthy', 'johndoe@example.com', 3.5, 1, 'Best Color', 'Pending', '2024-11-19'),
('Utsuri Shadow', 'Utsuri', 11.30, 'Black & Yellow', '2024-11-11', 'Thailand', 1550.00, 'Moderate', 'alice@example.com', 3.8, 2, 'Best Size', 'Pending', '2024-11-18'),

-- Loại Asagi
('Showa Star', 'Showa', 18.80, 'Golden', '2024-11-08', 'Vietnam', 1300.00, 'Moderate', 'alice@example.com', 3.5, 2, 'Best Overall', 'Pending', '2024-11-17'),
('Asagi Cloud', 'Asagi', 16.50, 'Gray Blue', '2024-11-14', 'Japan', 1250.00, 'Moderate', 'alice@example.com', 3.4, 2, 'Best Color', 'Pending', '2024-11-19'),
('Asagi Dream', 'Asagi', 18.00, 'Gray Blue', '2024-11-15', 'Japan', 1350.00, 'Excellent', 'bob@example.com', 3.6, 3, 'Best Color', 'Pending', '2024-11-19');
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

CREATE PROCEDURE ClassifyKoi
AS
BEGIN
    SELECT 
        KoiID,
        Name,
        Breed,
        Size,
        Color,
        Origin,
        Price,
        HealthStatus,
        ContestCategory,
        ContestStatus,
        ContestDate,
        CASE 
            WHEN Size < 15 THEN 'Small'
            WHEN Size BETWEEN 15 AND 20 THEN 'Medium'
            ELSE 'Large'
        END AS SizeCategory,
        HealthStatus AS HealthCategory
    FROM KoiManagement
    ORDER BY SizeCategory, HealthCategory;
END;
GO

CREATE TABLE KoiCheckIn (
    CheckInID INT PRIMARY KEY IDENTITY(1,1),
    KoiID INT NOT NULL, -- ID của cá Koi
    CheckInTime DATETIME DEFAULT GETDATE(), -- Thời gian check-in
    HealthStatus NVARCHAR(50) NOT NULL CHECK (HealthStatus IN ('Healthy', 'Moderate', 'Excellent')), -- Tình trạng sức khỏe
    Notes NVARCHAR(255), -- Ghi chú
    FOREIGN KEY (KoiID) REFERENCES KoiManagement(KoiID) ON DELETE CASCADE
);
GO
CREATE PROCEDURE CheckInKoi
    @KoiID INT,
    @HealthStatus NVARCHAR(50),
    @Notes NVARCHAR(255)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Kiểm tra nếu KoiID tồn tại
        IF EXISTS (SELECT 1 FROM KoiManagement WHERE KoiID = @KoiID)
        BEGIN
            -- Thêm dữ liệu check-in
            INSERT INTO KoiCheckIn (KoiID, HealthStatus, Notes)
            VALUES (@KoiID, @HealthStatus, @Notes);

            PRINT 'Check-in thành công!';
        END
        ELSE
        BEGIN
            PRINT 'KoiID không tồn tại.';
        END

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        PRINT 'Lỗi xảy ra: ' + ERROR_MESSAGE();
    END CATCH
END;
GO

select * from KoiManagement
INSERT INTO KoiCheckIn (KoiID, HealthStatus, Notes)
VALUES
(1, 'Healthy', 'Cá khỏe mạnh, không có vấn đề gì'),
(2, 'Moderate', 'Có dấu hiệu stress nhẹ, cần theo dõi'),
(3, 'Excellent', 'Cá ở trạng thái hoàn hảo'),
(1, 'Healthy', 'Không có dấu hiệu bệnh lý'),
(2, 'Moderate', 'Cần kiểm tra vây cá do có trầy xước'),
(3, 'Excellent', 'Hình thể đẹp, không có khiếm khuyết'),
(1, 'Healthy', 'Màu sắc tươi sáng, cá ăn uống bình thường'),
(2, 'Moderate', 'Cần điều chỉnh môi trường nước'),
(3, 'Excellent', 'Đạt tiêu chuẩn xuất sắc để thi đấu'),
(1, 'Healthy', 'Cá bơi linh hoạt, không có vấn đề gì'),
(2, 'Moderate', 'Quan sát thấy cá có dấu hiệu stress nhẹ'),
(3, 'Excellent', 'Sức khỏe hoàn hảo, tiếp tục duy trì'),
(1, 'Healthy', 'Không có dấu hiệu bệnh lý, kiểm tra định kỳ OK'),
(2, 'Moderate', 'Cần giảm độ pH của nước hồ nuôi'),
(3, 'Excellent', 'Tình trạng hoàn hảo cho cuộc thi');


EXEC CheckInKoi 
    @KoiID = 1, 
    @HealthStatus = 'Healthy', 
    @Notes = 'Cá khỏe mạnh, không có vấn đề gì';

GO

