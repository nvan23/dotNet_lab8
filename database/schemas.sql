create database SinhVien
use SinhVien;

CREATE TABLE [Subject] (
  [id] nvarchar(5) PRIMARY KEY,
  [name] nvarchar(255)
)
GO

CREATE TABLE [Teacher] (
  [id] nvarchar(3) PRIMARY KEY,
  [name] nvarchar(255),
  [password] nvarchar(255)
)
GO

CREATE TABLE [Class] (
  [id] nvarchar(6) PRIMARY KEY,
  [name] nvarchar(255)
)
GO

CREATE TABLE [Student] (
  [id] nvarchar(6) PRIMARY KEY,
  [firstname] nvarchar(255),
  [lastname] nvarchar(255),
  [class_id] nvarchar(6)
)
GO

select * from [Student]

CREATE TABLE [Course] (
  [id] int IDENTITY(1,1) PRIMARY KEY,
  [teacher_id] nvarchar(3),
  [class_id] nvarchar(6),
  [subject_id] nvarchar(5),
  UNIQUE ([subject_id], [teacher_id], [class_id])
)
GO

CREATE TABLE [Point] (
  [id] int IDENTITY(1,1) PRIMARY KEY,
  [student_id] nvarchar(6),
  [course_id] integer,
  [value] float
)
GO

ALTER TABLE [Student] ADD FOREIGN KEY ([class_id]) REFERENCES [Class] ([id])
GO

ALTER TABLE [Course] ADD FOREIGN KEY ([teacher_id]) REFERENCES [Teacher] ([id])
GO

ALTER TABLE [Course] ADD FOREIGN KEY ([class_id]) REFERENCES [Class] ([id])
GO

ALTER TABLE [Course] ADD FOREIGN KEY ([subject_id]) REFERENCES [Subject] ([id])
GO

ALTER TABLE [Point] ADD FOREIGN KEY ([student_id]) REFERENCES [Student] ([id])
GO

ALTER TABLE [Point] ADD FOREIGN KEY ([course_id]) REFERENCES [Course] ([id])
GO

