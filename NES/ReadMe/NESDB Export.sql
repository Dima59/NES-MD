-- ----------------------------
-- Table structure for Department
-- ----------------------------
CREATE TABLE [Department] (
[DepartmentID] int NOT NULL IDENTITY(1,1) ,
[DepartmentName] nvarchar(100) NOT NULL 
)


GO
DBCC CHECKIDENT(N'[Department]', RESEED, 12)
GO

-- ----------------------------
-- Records of Department
-- ----------------------------
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [Department] ON
GO
INSERT INTO [Department] ([DepartmentID], [DepartmentName]) VALUES (N'3', N'Finance'), (N'4', N'Human Resources'), (N'1', N'Information Technologies'), (N'6', N'Marketing'), (N'2', N'Production'), (N'7', N'Public Relations'), (N'5', N'Sales')
GO
GO
SET IDENTITY_INSERT [Department] OFF
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for Department_Position
-- ----------------------------
CREATE TABLE [Department_Position] (
[DepartmentID] int NOT NULL ,
[PositionID] int NOT NULL ,
[DepPosID] int NOT NULL IDENTITY(1,1) 
)


GO
DBCC CHECKIDENT(N'[Department_Position]', RESEED, 15)
GO

-- ----------------------------
-- Records of Department_Position
-- ----------------------------
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [Department_Position] ON
GO
INSERT INTO [Department_Position] ([DepartmentID], [PositionID], [DepPosID]) VALUES (N'1', N'1', N'1'), (N'1', N'2', N'2'), (N'1', N'3', N'3'), (N'1', N'4', N'4'), (N'1', N'5', N'5'), (N'1', N'7', N'6'), (N'2', N'8', N'7'), (N'2', N'14', N'8'), (N'3', N'9', N'9'), (N'4', N'10', N'10'), (N'5', N'11', N'11'), (N'6', N'12', N'12'), (N'7', N'13', N'15')
GO
GO
SET IDENTITY_INSERT [Department_Position] OFF
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for OrgUnit
-- ----------------------------
CREATE TABLE [OrgUnit] (
[OrgUnitID] int NOT NULL IDENTITY(1,1) ,
[OrgUnitName] nvarchar(100) NOT NULL 
)


GO
DBCC CHECKIDENT(N'[OrgUnit]', RESEED, 5)
GO

-- ----------------------------
-- Records of OrgUnit
-- ----------------------------
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [OrgUnit] ON
GO
INSERT INTO [OrgUnit] ([OrgUnitID], [OrgUnitName]) VALUES (N'2', N'Branch One'), (N'1', N'Main Office')
GO
GO
SET IDENTITY_INSERT [OrgUnit] OFF
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for OrgUnit_Department
-- ----------------------------
CREATE TABLE [OrgUnit_Department] (
[OrgUnitID] int NOT NULL ,
[DepartmentID] int NOT NULL ,
[OrgDepID] int NOT NULL IDENTITY(1,1) 
)


GO
DBCC CHECKIDENT(N'[OrgUnit_Department]', RESEED, 21)
GO

-- ----------------------------
-- Records of OrgUnit_Department
-- ----------------------------
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [OrgUnit_Department] ON
GO
INSERT INTO [OrgUnit_Department] ([OrgUnitID], [DepartmentID], [OrgDepID]) VALUES (N'1', N'1', N'1'), (N'1', N'2', N'2'), (N'1', N'3', N'3'), (N'1', N'4', N'4'), (N'1', N'5', N'5'), (N'1', N'6', N'6'), (N'1', N'7', N'7'), (N'2', N'1', N'8'), (N'2', N'2', N'9'), (N'2', N'3', N'10'), (N'2', N'4', N'11')
GO
GO
SET IDENTITY_INSERT [OrgUnit_Department] OFF
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for Position
-- ----------------------------
CREATE TABLE [Position] (
[PositionID] int NOT NULL IDENTITY(1,1) ,
[PositionName] nvarchar(100) NOT NULL 
)


GO
DBCC CHECKIDENT(N'[Position]', RESEED, 34)
GO

-- ----------------------------
-- Records of Position
-- ----------------------------
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [Position] ON
GO
INSERT INTO [Position] ([PositionID], [PositionName]) VALUES (N'32', N'AAAxxxxx'), (N'3', N'Database Administrator'), (N'9', N'Finance Officer'), (N'10', N'Human Resources Officer'), (N'1', N'IT Office'), (N'12', N'Marketing Officer'), (N'4', N'Network Administrator'), (N'8', N'Production Officer'), (N'14', N'Production Specialist'), (N'2', N'Programmer'), (N'13', N'Public Relations Officer'), (N'11', N'Sales Officer'), (N'6', N'Software Testing Specialist'), (N'5', N'System Analyst'), (N'7', N'Website Designer'), (N'33', N'yyyyy')
GO
GO
SET IDENTITY_INSERT [Position] OFF
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for Role
-- ----------------------------
CREATE TABLE [Role] (
[RoleID] int NOT NULL IDENTITY(1,1) ,
[RoleName] nvarchar(20) NOT NULL 
)


GO
DBCC CHECKIDENT(N'[Role]', RESEED, 6)
GO

-- ----------------------------
-- Records of Role
-- ----------------------------
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [Role] ON
GO
INSERT INTO [Role] ([RoleID], [RoleName]) VALUES (N'1', N'Administrator'), (N'2', N'Editor'), (N'3', N'User')
GO
GO
SET IDENTITY_INSERT [Role] OFF
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- Table structure for User
-- ----------------------------
CREATE TABLE [User] (
[UserID] int NOT NULL IDENTITY(1,1) ,
[UserName] nvarchar(50) NOT NULL ,
[Password] nvarchar(50) NOT NULL ,
[FirstName] nvarchar(50) NOT NULL ,
[LastName] nvarchar(50) NOT NULL ,
[Note] nvarchar(MAX) NULL ,
[RoleID] int NOT NULL ,
[DateCreated] date NULL ,
[IsActivated] bit NULL DEFAULT ((1)) ,
[Gender] char(10) NULL ,
[OrgUnitID] int NULL ,
[DepartmentID] int NULL ,
[PositionID] int NULL 
)


GO
DBCC CHECKIDENT(N'[User]', RESEED, 134)
GO

-- ----------------------------
-- Records of User
-- ----------------------------
BEGIN TRANSACTION
GO
SET IDENTITY_INSERT [User] ON
GO
INSERT INTO [User] ([UserID], [UserName], [Password], [FirstName], [LastName], [Note], [RoleID], [DateCreated], [IsActivated], [Gender], [OrgUnitID], [DepartmentID], [PositionID]) VALUES (N'9', N'Mika', N'mika', N'Mika', N'Mika', null, N'2', null, N'0', null, null, null, null), (N'10', N'Pera', N'pera', N'Pera', N'Pera', null, N'2', null, N'0', null, null, null, null), (N'72', N'User', N'user', N'User', N'eee', null, N'3', null, N'0', null, null, null, null), (N'78', N'User2', N'user', N'User', N'User', null, N'3', null, N'0', null, null, null, null), (N'79', N'User3', N'user', N'user', N'user', null, N'3', null, N'0', null, null, null, null), (N'80', N'User4', N'user', N'user', N'user', null, N'2', null, N'0', null, null, null, null), (N'81', N'User5', N'user', N'user', N'user', null, N'3', null, N'0', null, null, null, null), (N'85', N'Lazaz01-13', N'lazz', N'laza', N'laz', null, N'3', null, N'0', null, null, null, null), (N'87', N'Laza01', N'oooo', N'Eeee', N'Jaaa', null, N'3', N'2020-06-29', N'0', null, null, null, null), (N'94', N'Mikan', N'mikan', N'mik', N'mik', null, N'3', null, N'0', null, null, null, null), (N'95', N'Bobo', N'dfdsf', N'Bobo', N'Bonobo Duo', N'trtmrt ptr prt
dasd
asdas
sdfdsf
dfsdf', N'3', null, N'0', N'Male      ', N'2', N'2', N'14'), (N'96', N'Bebe', N'bebe', N'Bebe', N'Bebe', null, N'3', null, N'1', N'Female    ', N'2', N'1', N'3'), (N'98', N'Ayyyxvvvvvvvvvz', N'ayyy', N'Gyyyxzz', N'Xyyy', null, N'2', N'2020-08-14', N'0', N'Female    ', N'2', N'2', null), (N'100', N'Admin', N'dima', N'Deda', N'Didi', N'Admin.Admin gfdg fdgdfg  fgddg  dfg fdguiotuo oisg iiy gfdg fdgdfg  fgddg  dfg fdguiotuo oisg iiy gfdg fdgdfg  fgddg  dfg fdguiotuo oisg iiy gfdg fdgdfg  fgddg  dfg fdguiotuo oisg iiy gfdg fdgdfg  fgddg  dfg fdguiotuo oisg iiy gfdg fdgdfg  fgddg  dfg fdguiotuo oisg iiy', N'1', null, N'1', N'Male      ', N'1', N'1', N'7'), (N'101', N'Lazazozon', N'Lazaz', N'laza', N'laz', null, N'3', null, N'0', null, null, null, null), (N'102', N'Lazaz02', N'lazz', N'laza', N'laz', null, N'3', null, N'0', null, null, null, null), (N'103', N'Lazaz01-01-02', N'lazz', N'Laza', N'Laz', null, N'2', N'2020-09-11', N'0', null, null, null, null), (N'104', N'Lazaz01-18', N'lazz', N'laza', N'laz', null, N'3', null, N'0', null, null, null, null), (N'105', N'Lazaz01-14', N'lazz', N'laza', N'laz', null, N'3', null, N'0', null, null, null, null), (N'106', N'Lazaz01-19', N'lazz', N'laza', N'laz', null, N'3', null, N'0', null, null, null, null), (N'107', N'Lazaz01-15', N'layy', N'laza', N'laz', null, N'2', null, N'0', null, null, null, null), (N'108', N'Lazaz01-16', N'lazz', N'laza', N'laz', null, N'3', null, N'0', null, null, null, null), (N'109', N'Lazaz01-20', N'lazz', N'laza', N'laz', null, N'3', null, N'0', null, null, null, null), (N'110', N'Lazaz01-17', N'lazz', N'laza', N'laz', null, N'3', null, N'0', null, null, null, null), (N'111', N'Asss', N'asss', N'Zika', N'Zikic', N'xxx', N'3', null, N'1', N'Male      ', N'1', null, null), (N'112', N'Lazaz01-02-02', N'lazz', N'Laza', N'Lazz', N'dasd sadasd gdfg fgdfg', N'3', null, N'0', null, null, null, null), (N'130', N'bbbb', N'bbbb', N'Bbbb', N'Bbbb', null, N'3', null, N'0', null, null, null, null), (N'131', N'cccc', N'cccc', N'Cccc', N'Cccc', null, N'3', N'2020-11-06', N'0', null, null, null, null), (N'134', N'Admo', N'admo', N'Admo', N'Admo', null, N'2', null, N'0', null, null, null, null)
GO
GO
SET IDENTITY_INSERT [User] OFF
GO
COMMIT TRANSACTION
GO

-- ----------------------------
-- View structure for DepartmentPositionView
-- ----------------------------
CREATE VIEW [DepartmentPositionView] AS 
SELECT
dbo.Department_Position.DepPosID,
dbo.Department.DepartmentName,
dbo.[Position].PositionName

FROM
dbo.Department
INNER JOIN dbo.Department_Position ON dbo.Department_Position.DepartmentID = dbo.Department.DepartmentID
INNER JOIN dbo.[Position] ON dbo.Department_Position.PositionID = dbo.[Position].PositionID
GO

-- ----------------------------
-- View structure for OrgUnitDepartmentView
-- ----------------------------
CREATE VIEW [OrgUnitDepartmentView] AS 
SELECT
	dbo.OrgUnit_Department.OrgDepID,
	dbo.OrgUnit.OrgUnitName,
	dbo.Department.DepartmentName
FROM
	dbo.OrgUnit
INNER JOIN dbo.OrgUnit_Department ON dbo.OrgUnit_Department.OrgUnitID = dbo.OrgUnit.OrgUnitID
INNER JOIN dbo.Department ON dbo.OrgUnit_Department.DepartmentID = dbo.Department.DepartmentID
GO

-- ----------------------------
-- View structure for UserDepartmentView
-- ----------------------------
CREATE VIEW [UserDepartmentView] AS 
SELECT
dbo.OrgUnit_Department.OrgUnitID,
dbo.Department.DepartmentName,
dbo.Department.DepartmentID

FROM
dbo.OrgUnit_Department
INNER JOIN dbo.Department ON dbo.OrgUnit_Department.DepartmentID = dbo.Department.DepartmentID
GO

-- ----------------------------
-- View structure for UserLoginView
-- ----------------------------
CREATE VIEW [UserLoginView] AS 
SELECT        UserID, UserName, Password, FirstName, LastName, IsActivated
FROM            dbo.[User]
GO

-- ----------------------------
-- View structure for UserPositionView
-- ----------------------------
CREATE VIEW [UserPositionView] AS 
SELECT        dbo.Department_Position.DepartmentID, dbo.Position.PositionID, dbo.Position.PositionName
FROM            dbo.Department_Position INNER JOIN
                         dbo.Position ON dbo.Department_Position.PositionID = dbo.Position.PositionID
GO

-- ----------------------------
-- Indexes structure for table Department
-- ----------------------------
CREATE UNIQUE INDEX [DepartmentNameIDX] ON [Department]
([DepartmentName] ASC) 
WITH (IGNORE_DUP_KEY = ON)
GO

-- ----------------------------
-- Primary Key structure for table Department
-- ----------------------------
ALTER TABLE [Department] ADD PRIMARY KEY ([DepartmentID])
GO

-- ----------------------------
-- Indexes structure for table Department_Position
-- ----------------------------
CREATE UNIQUE INDEX [DepPosIDX] ON [Department_Position]
([PositionID] ASC, [DepPosID] ASC) 
WITH (IGNORE_DUP_KEY = ON)
GO

-- ----------------------------
-- Primary Key structure for table Department_Position
-- ----------------------------
ALTER TABLE [Department_Position] ADD PRIMARY KEY ([DepPosID])
GO

-- ----------------------------
-- Uniques structure for table Department_Position
-- ----------------------------
ALTER TABLE [Department_Position] ADD UNIQUE ([DepartmentID] ASC, [PositionID] ASC)
GO
ALTER TABLE [Department_Position] ADD UNIQUE ([DepartmentID] ASC, [PositionID] ASC)
GO

-- ----------------------------
-- Indexes structure for table OrgUnit
-- ----------------------------
CREATE UNIQUE INDEX [OrgUnitNameIDX] ON [OrgUnit]
([OrgUnitName] ASC) 
WITH (IGNORE_DUP_KEY = ON)
GO

-- ----------------------------
-- Primary Key structure for table OrgUnit
-- ----------------------------
ALTER TABLE [OrgUnit] ADD PRIMARY KEY ([OrgUnitID])
GO

-- ----------------------------
-- Indexes structure for table OrgUnit_Department
-- ----------------------------
CREATE UNIQUE INDEX [OrgDepIDX] ON [OrgUnit_Department]
([DepartmentID] ASC, [OrgDepID] ASC) 
WITH (IGNORE_DUP_KEY = ON)
GO

-- ----------------------------
-- Primary Key structure for table OrgUnit_Department
-- ----------------------------
ALTER TABLE [OrgUnit_Department] ADD PRIMARY KEY ([OrgDepID])
GO

-- ----------------------------
-- Uniques structure for table OrgUnit_Department
-- ----------------------------
ALTER TABLE [OrgUnit_Department] ADD UNIQUE ([OrgUnitID] ASC, [DepartmentID] ASC)
GO
ALTER TABLE [OrgUnit_Department] ADD UNIQUE ([OrgUnitID] ASC, [DepartmentID] ASC)
GO

-- ----------------------------
-- Indexes structure for table Position
-- ----------------------------
CREATE UNIQUE INDEX [PositionNameIDX] ON [Position]
([PositionName] ASC) 
WITH (IGNORE_DUP_KEY = ON)
GO

-- ----------------------------
-- Primary Key structure for table Position
-- ----------------------------
ALTER TABLE [Position] ADD PRIMARY KEY ([PositionID])
GO

-- ----------------------------
-- Indexes structure for table Role
-- ----------------------------
CREATE UNIQUE INDEX [RoleIDX] ON [Role]
([RoleName] ASC) 
WITH (IGNORE_DUP_KEY = ON)
GO

-- ----------------------------
-- Primary Key structure for table Role
-- ----------------------------
ALTER TABLE [Role] ADD PRIMARY KEY ([RoleID])
GO

-- ----------------------------
-- Indexes structure for table User
-- ----------------------------
CREATE INDEX [FnLnIDX] ON [User]
([FirstName] ASC, [LastName] ASC) 
GO
CREATE UNIQUE INDEX [UserNameIDX] ON [User]
([UserName] ASC) 
WITH (IGNORE_DUP_KEY = ON)
GO

-- ----------------------------
-- Primary Key structure for table User
-- ----------------------------
ALTER TABLE [User] ADD PRIMARY KEY ([UserID])
GO

-- ----------------------------
-- Foreign Key structure for table [Department_Position]
-- ----------------------------
ALTER TABLE [Department_Position] ADD FOREIGN KEY ([DepartmentID]) REFERENCES [Department] ([DepartmentID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [Department_Position] ADD FOREIGN KEY ([PositionID]) REFERENCES [Position] ([PositionID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [Department_Position] ADD FOREIGN KEY ([DepartmentID]) REFERENCES [Department] ([DepartmentID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [Department_Position] ADD FOREIGN KEY ([PositionID]) REFERENCES [Position] ([PositionID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [OrgUnit_Department]
-- ----------------------------
ALTER TABLE [OrgUnit_Department] ADD FOREIGN KEY ([DepartmentID]) REFERENCES [Department] ([DepartmentID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [OrgUnit_Department] ADD FOREIGN KEY ([OrgUnitID]) REFERENCES [OrgUnit] ([OrgUnitID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [OrgUnit_Department] ADD FOREIGN KEY ([DepartmentID]) REFERENCES [Department] ([DepartmentID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [OrgUnit_Department] ADD FOREIGN KEY ([OrgUnitID]) REFERENCES [OrgUnit] ([OrgUnitID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [User]
-- ----------------------------
ALTER TABLE [User] ADD FOREIGN KEY ([DepartmentID]) REFERENCES [Department] ([DepartmentID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [User] ADD FOREIGN KEY ([OrgUnitID]) REFERENCES [OrgUnit] ([OrgUnitID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [User] ADD FOREIGN KEY ([PositionID]) REFERENCES [Position] ([PositionID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [User] ADD FOREIGN KEY ([RoleID]) REFERENCES [Role] ([RoleID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [User] ADD FOREIGN KEY ([DepartmentID]) REFERENCES [Department] ([DepartmentID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [User] ADD FOREIGN KEY ([OrgUnitID]) REFERENCES [OrgUnit] ([OrgUnitID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [User] ADD FOREIGN KEY ([PositionID]) REFERENCES [Position] ([PositionID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [User] ADD FOREIGN KEY ([RoleID]) REFERENCES [Role] ([RoleID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
