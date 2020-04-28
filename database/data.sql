use SinhVien
select * from [Student];
select * from [Class];
select * from [Subject];
select * from [Teacher];
select * from [Course];
select * from [Point];

INSERT INTO [Student]
    ([id], [lastname], [firstname], [class_id])
VALUES
    ('B18001', N'Phạm Thị Bảo', N'Nhiên', 'K44-01'),
    ('B18002', N'Nguyễn Văn', N'An', 'K44-01'),
    ('B18003', N'Lê Hoài', N'Anh', 'K44-01'),
    ('B18004', N'Nguyễn Lâm Hoàng', N'Anh', 'K44-01'),
    ('B18005', N'Lê Minh', N'Bằng', 'K44-01'),
    ('B18006', N'Vương Thừa', N'Chấn', 'K44-02'),
    ('B18007', N'Cao Công', N'Danh', 'K44-02'),
    ('B18008', N'Trịnh Lê Long', N'Đức', 'K44-02'),
    ('B18009', N'Dương Lê Minh', N'Hậu', 'K44-02'),
    ('B18010', N'Nguyễn Vũ', N'Hoàng', 'K44-02'),
    ('B18011', N'Nguyễn Hoàng Thái', N'Học', 'K44-03'),
    ('B18012', N'Nguyễn Quốc', N'Huy', 'K44-03'),
    ('B18013', N'Võ Đoàn Gia', N'Huy', 'K44-03'),
    ('B18014', N'Vũ Thị Bích', N'Huyền', 'K44-03'),
    ('B18015', N'Hồ Việt', N'Hưng', 'K44-03')
GO

INSERT INTO [Class]
    ([id], [name])
VALUES
    ('K44-01', 'CNPM 01'),
    ('K44-02', 'CNPM 02'),
    ('K44-03', 'CNPM 03')
GO

INSERT INTO [Subject]
    ([id], [name])
VALUES
    ('CT101', N'Lập trình căn bản'),
    ('CT103', N'Cấu trúc dữ liệu'),
    ('CT251', N'Phát triển ứng dụng trên Windows')
GO

INSERT INTO [Teacher]
    ([id], [name], [password])
VALUES
    ('001', N'Nguyễn Văn Cường', '123'),
    ('002', N'Huỳnh Minh Phương', '123'),
    ('003', N'Thái Cẩm Nhung', '123')
GO

INSERT INTO [Course]
    ([teacher_id], [subject_id], [class_id])
VALUES
    ('001', 'CT101', 'K44-01'),
    ('001', 'CT101', 'K44-02'),
    ('001', 'CT103', 'K44-01'),
    ('001', 'CT103', 'K44-03'),
    ('002', 'CT101', 'K44-03'),
    ('002', 'CT103', 'K44-02'),
    ('003', 'CT251', 'K44-01'),
    ('003', 'CT251', 'K44-02'),
    ('003', 'CT251', 'K44-03')
GO
