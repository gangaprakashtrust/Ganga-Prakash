/****** Object:  Table [dbo].[ApplicationUser]    Script Date: 7/7/2020 9:31:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationUser](
	[Id] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[Lastname] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[ShortName] [nvarchar](50) NOT NULL,
	[MobileNo] [nchar](10) NOT NULL,
	[ImagePath] [nvarchar](max) NULL,
	[IsDoctor] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[LastChanged] [datetime] NOT NULL,
 CONSTRAINT [PK_ApplicationUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 7/7/2020 9:31:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 7/7/2020 9:31:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 7/7/2020 9:31:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 7/7/2020 9:31:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 7/7/2020 9:31:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 7/7/2020 9:31:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Controller] [nvarchar](50) NOT NULL,
	[Action] [nvarchar](50) NOT NULL,
	[Area] [nvarchar](50) NOT NULL,
	[SequenceNo] [int] NOT NULL,
	[ParentId] [uniqueidentifier] NOT NULL,
	[ModuleId] [uniqueidentifier] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[LastChanged] [datetime] NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MenuPrivilege]    Script Date: 7/7/2020 9:31:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuPrivilege](
	[Id] [uniqueidentifier] NOT NULL,
	[MenuId] [uniqueidentifier] NOT NULL,
	[PrivilegeId] [uniqueidentifier] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[LastChanged] [datetime] NOT NULL,
 CONSTRAINT [PK_MenuPrivilege] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Module]    Script Date: 7/7/2020 9:31:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Module](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[SequenceNo] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[LastChanged] [datetime] NOT NULL,
 CONSTRAINT [PK_Module] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Privilege]    Script Date: 7/7/2020 9:31:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Privilege](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nchar](10) NOT NULL,
	[SequenceNo] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[LastChanged] [datetime] NOT NULL,
 CONSTRAINT [PK_Privilege] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 7/7/2020 9:31:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[LastChanged] [datetime] NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleMenu]    Script Date: 7/7/2020 9:31:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleMenu](
	[Id] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
	[MenuId] [uniqueidentifier] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[LastChanged] [datetime] NOT NULL,
 CONSTRAINT [PK_RoleMenu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleMenuPrivilege]    Script Date: 7/7/2020 9:31:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleMenuPrivilege](
	[Id] [uniqueidentifier] NOT NULL,
	[RoleMenuId] [uniqueidentifier] NOT NULL,
	[PrivilegeId] [uniqueidentifier] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[LastChanged] [datetime] NOT NULL,
 CONSTRAINT [PK_RoleMenuPrivilege] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 7/7/2020 9:31:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[Id] [uniqueidentifier] NOT NULL,
	[ApplicationUserId] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[LastChanged] [datetime] NOT NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ApplicationUser] ([Id], [UserId], [UserName], [FirstName], [Lastname], [Email], [ShortName], [MobileNo], [ImagePath], [IsDoctor], [IsActive], [LastChanged]) VALUES (N'f957fb00-b569-4e4c-9eb7-c9a7f73961ee', N'e46dce43-bdd4-45ef-8679-48449eebe443', N'superadmin', N'Super', N'Admin', N'superadmin@gangaprakash.com', N'Superadmin', N'7559132699', N'', 0, 1, CAST(N'2020-07-05T10:28:48.863' AS DateTime))
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e46dce43-bdd4-45ef-8679-48449eebe443', N'superadmin@gangaprakash.com', 0, N'ABsVnK76GJ/n/vR6/1Bpll67CVHMIwsQKnXsAGXE1DzSzQXSsC6J6KjVe9Aafg9fUA==', N'e6535d37-64ce-456a-8d47-b732c1a4fd64', NULL, 0, 0, NULL, 0, 0, N'superadmin')
INSERT [dbo].[Menu] ([Id], [Name], [Controller], [Action], [Area], [SequenceNo], [ParentId], [ModuleId], [IsActive], [LastChanged]) VALUES (N'91031266-338d-4259-8518-076a3fa8e427', N'Menu', N'Menu', N'Index', N'Administration', 3, N'1182dd63-94ff-4cdd-90fd-f8924ae0ed0b', N'fc5dfdc1-562a-4287-921e-d863bb6b77c8', 1, CAST(N'2020-07-07T15:54:10.860' AS DateTime))
INSERT [dbo].[Menu] ([Id], [Name], [Controller], [Action], [Area], [SequenceNo], [ParentId], [ModuleId], [IsActive], [LastChanged]) VALUES (N'44429eaa-ad49-42c2-9453-12c3807aa31c', N'Privilege', N'Privilege', N'Index', N'Administration', 2, N'1182dd63-94ff-4cdd-90fd-f8924ae0ed0b', N'fc5dfdc1-562a-4287-921e-d863bb6b77c8', 1, CAST(N'2020-07-07T15:53:50.110' AS DateTime))
INSERT [dbo].[Menu] ([Id], [Name], [Controller], [Action], [Area], [SequenceNo], [ParentId], [ModuleId], [IsActive], [LastChanged]) VALUES (N'32f23615-a6e2-42a8-86c1-6280d9b73c94', N'Role', N'Role', N'Index', N'Administration', 4, N'1182dd63-94ff-4cdd-90fd-f8924ae0ed0b', N'fc5dfdc1-562a-4287-921e-d863bb6b77c8', 1, CAST(N'2020-07-07T15:55:00.497' AS DateTime))
INSERT [dbo].[Menu] ([Id], [Name], [Controller], [Action], [Area], [SequenceNo], [ParentId], [ModuleId], [IsActive], [LastChanged]) VALUES (N'65f22a02-3f90-4834-91d4-6610189f3539', N'Role Menu Privilege', N'RoleMenuPrivilege', N'Index', N'Administration', 1, N'f1fd9ec8-3665-459e-92a8-b5c465a64d14', N'fc5dfdc1-562a-4287-921e-d863bb6b77c8', 1, CAST(N'2020-07-07T15:55:32.403' AS DateTime))
INSERT [dbo].[Menu] ([Id], [Name], [Controller], [Action], [Area], [SequenceNo], [ParentId], [ModuleId], [IsActive], [LastChanged]) VALUES (N'f1fd9ec8-3665-459e-92a8-b5c465a64d14', N'Transaction', N'Transaction', N'Index', N'Administration', 2, N'00000000-0000-0000-0000-000000000000', N'fc5dfdc1-562a-4287-921e-d863bb6b77c8', 1, CAST(N'2020-07-07T15:53:08.930' AS DateTime))
INSERT [dbo].[Menu] ([Id], [Name], [Controller], [Action], [Area], [SequenceNo], [ParentId], [ModuleId], [IsActive], [LastChanged]) VALUES (N'551684f0-2f6c-4131-b7f9-ec4ca1309fdd', N'Module', N'Module', N'Index', N'Administration', 1, N'1182dd63-94ff-4cdd-90fd-f8924ae0ed0b', N'fc5dfdc1-562a-4287-921e-d863bb6b77c8', 1, CAST(N'2020-07-07T15:53:29.487' AS DateTime))
INSERT [dbo].[Menu] ([Id], [Name], [Controller], [Action], [Area], [SequenceNo], [ParentId], [ModuleId], [IsActive], [LastChanged]) VALUES (N'1182dd63-94ff-4cdd-90fd-f8924ae0ed0b', N'Master', N'Master', N'Index', N'Administration', 1, N'00000000-0000-0000-0000-000000000000', N'fc5dfdc1-562a-4287-921e-d863bb6b77c8', 1, CAST(N'2020-07-07T15:52:51.727' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'2a344841-be42-4f49-b724-02037dc5fa83', N'32f23615-a6e2-42a8-86c1-6280d9b73c94', N'3205ad4d-e119-4380-92af-ab57f70a03c6', 1, CAST(N'2020-07-07T15:55:00.737' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'fb9064ba-76a4-483a-9ebd-07a0946471c3', N'551684f0-2f6c-4131-b7f9-ec4ca1309fdd', N'6c79ea64-08a6-4950-a170-5e8223f33659', 1, CAST(N'2020-07-07T15:53:29.560' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'fe71fa51-a1c8-4a40-bcaa-20d76f1f7bec', N'91031266-338d-4259-8518-076a3fa8e427', N'5af0dc03-3050-48c2-b22b-5acac4a2e749', 1, CAST(N'2020-07-07T15:54:11.010' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'377f38d3-428f-40c5-81c0-317d2138f4dc', N'91031266-338d-4259-8518-076a3fa8e427', N'159bdd1d-11e6-4c1d-a2c9-893d6d218b75', 1, CAST(N'2020-07-07T15:54:11.160' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'94a585eb-65c1-4a18-a441-32e7bab3a34b', N'32f23615-a6e2-42a8-86c1-6280d9b73c94', N'6c79ea64-08a6-4950-a170-5e8223f33659', 1, CAST(N'2020-07-07T15:55:00.580' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'5c01ac38-306e-44fe-8c24-37d2480aa6b9', N'32f23615-a6e2-42a8-86c1-6280d9b73c94', N'159bdd1d-11e6-4c1d-a2c9-893d6d218b75', 1, CAST(N'2020-07-07T15:55:00.810' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'd90e8f34-4604-4a0b-8446-3b189b43ec87', N'44429eaa-ad49-42c2-9453-12c3807aa31c', N'3205ad4d-e119-4380-92af-ab57f70a03c6', 1, CAST(N'2020-07-07T15:53:50.333' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'93e41c5c-0e70-4a20-9e36-3e5939a6621d', N'551684f0-2f6c-4131-b7f9-ec4ca1309fdd', N'159bdd1d-11e6-4c1d-a2c9-893d6d218b75', 1, CAST(N'2020-07-07T15:53:29.807' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'b6850831-9442-472b-b16c-3f3e4cfeaac9', N'65f22a02-3f90-4834-91d4-6610189f3539', N'159bdd1d-11e6-4c1d-a2c9-893d6d218b75', 1, CAST(N'2020-07-07T15:55:32.480' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'8f12522f-a475-4e25-aa98-5c7f525e59c9', N'551684f0-2f6c-4131-b7f9-ec4ca1309fdd', N'5af0dc03-3050-48c2-b22b-5acac4a2e749', 1, CAST(N'2020-07-07T15:53:29.647' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'391bbc6d-c85a-4551-bc69-6a768d238af9', N'1182dd63-94ff-4cdd-90fd-f8924ae0ed0b', N'159bdd1d-11e6-4c1d-a2c9-893d6d218b75', 1, CAST(N'2020-07-07T15:52:51.813' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'029996a8-f399-497d-9d0e-90b43d70eb29', N'551684f0-2f6c-4131-b7f9-ec4ca1309fdd', N'3205ad4d-e119-4380-92af-ab57f70a03c6', 1, CAST(N'2020-07-07T15:53:29.727' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'b28c6395-6f7b-4932-a6a8-a06eea1613eb', N'91031266-338d-4259-8518-076a3fa8e427', N'6c79ea64-08a6-4950-a170-5e8223f33659', 1, CAST(N'2020-07-07T15:54:10.933' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'8863e236-c63e-44dd-b774-aa517c4c266a', N'32f23615-a6e2-42a8-86c1-6280d9b73c94', N'5af0dc03-3050-48c2-b22b-5acac4a2e749', 1, CAST(N'2020-07-07T15:55:00.660' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'a5c12ea7-abf8-4e3d-902c-c6b82f1311b1', N'44429eaa-ad49-42c2-9453-12c3807aa31c', N'159bdd1d-11e6-4c1d-a2c9-893d6d218b75', 1, CAST(N'2020-07-07T15:53:50.407' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'303a3c71-4e74-48b6-a935-d64b056bcf67', N'91031266-338d-4259-8518-076a3fa8e427', N'3205ad4d-e119-4380-92af-ab57f70a03c6', 1, CAST(N'2020-07-07T15:54:11.083' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'0233668c-b15e-4c24-9b75-de5bccbebf02', N'44429eaa-ad49-42c2-9453-12c3807aa31c', N'5af0dc03-3050-48c2-b22b-5acac4a2e749', 1, CAST(N'2020-07-07T15:53:50.260' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'b1f87289-5fde-4d96-87ab-eaedc78f41f6', N'44429eaa-ad49-42c2-9453-12c3807aa31c', N'6c79ea64-08a6-4950-a170-5e8223f33659', 1, CAST(N'2020-07-07T15:53:50.183' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'add7e861-8a82-40bf-b86b-f8dd37e40ae6', N'f1fd9ec8-3665-459e-92a8-b5c465a64d14', N'159bdd1d-11e6-4c1d-a2c9-893d6d218b75', 1, CAST(N'2020-07-07T15:53:09.003' AS DateTime))
INSERT [dbo].[Module] ([Id], [Name], [SequenceNo], [IsActive], [LastChanged]) VALUES (N'fc5dfdc1-562a-4287-921e-d863bb6b77c8', N'Administration', 1, 1, CAST(N'2020-07-07T15:51:43.123' AS DateTime))
INSERT [dbo].[Privilege] ([Id], [Name], [SequenceNo], [IsActive], [LastChanged]) VALUES (N'5af0dc03-3050-48c2-b22b-5acac4a2e749', N'Delete    ', 4, 1, CAST(N'2020-07-07T15:52:22.453' AS DateTime))
INSERT [dbo].[Privilege] ([Id], [Name], [SequenceNo], [IsActive], [LastChanged]) VALUES (N'6c79ea64-08a6-4950-a170-5e8223f33659', N'Create    ', 2, 1, CAST(N'2020-07-07T15:52:06.580' AS DateTime))
INSERT [dbo].[Privilege] ([Id], [Name], [SequenceNo], [IsActive], [LastChanged]) VALUES (N'159bdd1d-11e6-4c1d-a2c9-893d6d218b75', N'Index     ', 1, 1, CAST(N'2020-07-07T15:52:00.460' AS DateTime))
INSERT [dbo].[Privilege] ([Id], [Name], [SequenceNo], [IsActive], [LastChanged]) VALUES (N'3205ad4d-e119-4380-92af-ab57f70a03c6', N'Edit      ', 3, 1, CAST(N'2020-07-07T15:52:14.843' AS DateTime))
INSERT [dbo].[Role] ([Id], [Name], [IsActive], [LastChanged]) VALUES (N'a4a189e2-0b99-48ab-9542-ec526813df5d', N'SysAdmin', 1, CAST(N'2020-07-07T15:07:35.753' AS DateTime))
INSERT [dbo].[RoleMenu] ([Id], [RoleId], [MenuId], [IsActive], [LastChanged]) VALUES (N'636df545-9df1-4cef-b69c-6c6a013a9ae0', N'a4a189e2-0b99-48ab-9542-ec526813df5d', N'91031266-338d-4259-8518-076a3fa8e427', 1, CAST(N'2020-07-07T15:56:04.083' AS DateTime))
INSERT [dbo].[RoleMenu] ([Id], [RoleId], [MenuId], [IsActive], [LastChanged]) VALUES (N'4688690c-7c56-4c15-97c4-73287d9bf28a', N'a4a189e2-0b99-48ab-9542-ec526813df5d', N'1182dd63-94ff-4cdd-90fd-f8924ae0ed0b', 1, CAST(N'2020-07-07T15:56:03.783' AS DateTime))
INSERT [dbo].[RoleMenu] ([Id], [RoleId], [MenuId], [IsActive], [LastChanged]) VALUES (N'25a3502b-3369-4612-b616-7577a8e98ccb', N'a4a189e2-0b99-48ab-9542-ec526813df5d', N'551684f0-2f6c-4131-b7f9-ec4ca1309fdd', 1, CAST(N'2020-07-07T15:56:03.860' AS DateTime))
INSERT [dbo].[RoleMenu] ([Id], [RoleId], [MenuId], [IsActive], [LastChanged]) VALUES (N'9c8fa079-5f4a-45a6-a362-8f1b03fed190', N'a4a189e2-0b99-48ab-9542-ec526813df5d', N'65f22a02-3f90-4834-91d4-6610189f3539', 1, CAST(N'2020-07-07T15:56:03.710' AS DateTime))
INSERT [dbo].[RoleMenu] ([Id], [RoleId], [MenuId], [IsActive], [LastChanged]) VALUES (N'5ba1cb6e-1566-4216-a6a0-c020d1c9c75a', N'a4a189e2-0b99-48ab-9542-ec526813df5d', N'f1fd9ec8-3665-459e-92a8-b5c465a64d14', 1, CAST(N'2020-07-07T15:56:03.933' AS DateTime))
INSERT [dbo].[RoleMenu] ([Id], [RoleId], [MenuId], [IsActive], [LastChanged]) VALUES (N'966d004c-9341-4b16-9d50-d8e370e3b386', N'a4a189e2-0b99-48ab-9542-ec526813df5d', N'32f23615-a6e2-42a8-86c1-6280d9b73c94', 1, CAST(N'2020-07-07T15:56:04.157' AS DateTime))
INSERT [dbo].[RoleMenu] ([Id], [RoleId], [MenuId], [IsActive], [LastChanged]) VALUES (N'54f6ffdc-281d-4cb4-b329-eeafa4f4541c', N'a4a189e2-0b99-48ab-9542-ec526813df5d', N'44429eaa-ad49-42c2-9453-12c3807aa31c', 1, CAST(N'2020-07-07T15:56:04.007' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'a138869d-cb8c-4bbc-8ae1-02900a674567', N'25a3502b-3369-4612-b616-7577a8e98ccb', N'6c79ea64-08a6-4950-a170-5e8223f33659', 1, CAST(N'2020-07-07T15:56:42.187' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'a3da9fc7-333e-4350-82a1-103390edf6f4', N'54f6ffdc-281d-4cb4-b329-eeafa4f4541c', N'6c79ea64-08a6-4950-a170-5e8223f33659', 1, CAST(N'2020-07-07T15:56:41.640' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'95d3174e-a633-4437-bfe0-1b2a60d77c84', N'54f6ffdc-281d-4cb4-b329-eeafa4f4541c', N'159bdd1d-11e6-4c1d-a2c9-893d6d218b75', 1, CAST(N'2020-07-07T15:56:41.493' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'1fccf544-b9bc-4e11-b8f5-1c6889498281', N'636df545-9df1-4cef-b69c-6c6a013a9ae0', N'159bdd1d-11e6-4c1d-a2c9-893d6d218b75', 1, CAST(N'2020-07-07T15:56:41.110' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'e05a77ab-f06f-4aec-be5d-265474b72a1a', N'636df545-9df1-4cef-b69c-6c6a013a9ae0', N'5af0dc03-3050-48c2-b22b-5acac4a2e749', 1, CAST(N'2020-07-07T15:56:41.030' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'041cb1c7-9107-4e02-9be2-2d7b84f3bd8b', N'54f6ffdc-281d-4cb4-b329-eeafa4f4541c', N'3205ad4d-e119-4380-92af-ab57f70a03c6', 1, CAST(N'2020-07-07T15:56:41.417' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'2bdda9d4-4dc1-4ce2-bb33-48c5b426f6c4', N'966d004c-9341-4b16-9d50-d8e370e3b386', N'159bdd1d-11e6-4c1d-a2c9-893d6d218b75', 1, CAST(N'2020-07-07T15:56:41.950' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'd44f9327-4cdf-4871-afe9-4b08c5379c85', N'25a3502b-3369-4612-b616-7577a8e98ccb', N'5af0dc03-3050-48c2-b22b-5acac4a2e749', 1, CAST(N'2020-07-07T15:56:42.413' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'f8f3af35-0549-4ec7-a58d-4bb3ebf61bae', N'25a3502b-3369-4612-b616-7577a8e98ccb', N'159bdd1d-11e6-4c1d-a2c9-893d6d218b75', 1, CAST(N'2020-07-07T15:56:42.340' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'64fc3a30-9a35-4474-8cc4-558ee4fa465c', N'25a3502b-3369-4612-b616-7577a8e98ccb', N'3205ad4d-e119-4380-92af-ab57f70a03c6', 1, CAST(N'2020-07-07T15:56:42.487' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'422cdf87-84ae-426d-ad3e-59c18c598de3', N'9c8fa079-5f4a-45a6-a362-8f1b03fed190', N'159bdd1d-11e6-4c1d-a2c9-893d6d218b75', 1, CAST(N'2020-07-07T15:56:42.113' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'3bf318a3-7fbd-487f-99f6-889b56c45725', N'966d004c-9341-4b16-9d50-d8e370e3b386', N'6c79ea64-08a6-4950-a170-5e8223f33659', 1, CAST(N'2020-07-07T15:56:41.790' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'619faa42-cd09-41bf-96bf-a6043143349d', N'636df545-9df1-4cef-b69c-6c6a013a9ae0', N'3205ad4d-e119-4380-92af-ab57f70a03c6', 1, CAST(N'2020-07-07T15:56:41.343' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'd62198e6-9337-4a3a-b683-aeaf7b13a83c', N'54f6ffdc-281d-4cb4-b329-eeafa4f4541c', N'5af0dc03-3050-48c2-b22b-5acac4a2e749', 1, CAST(N'2020-07-07T15:56:41.567' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'484ee8c3-0d45-47ae-bab0-b9fa7a1ab739', N'966d004c-9341-4b16-9d50-d8e370e3b386', N'3205ad4d-e119-4380-92af-ab57f70a03c6', 1, CAST(N'2020-07-07T15:56:41.717' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'ba3be09a-553f-4e3e-94d9-dd36c084c7d1', N'966d004c-9341-4b16-9d50-d8e370e3b386', N'5af0dc03-3050-48c2-b22b-5acac4a2e749', 1, CAST(N'2020-07-07T15:56:42.030' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'7ac71556-b320-4ead-8bec-e129d5335ae8', N'636df545-9df1-4cef-b69c-6c6a013a9ae0', N'6c79ea64-08a6-4950-a170-5e8223f33659', 1, CAST(N'2020-07-07T15:56:41.270' AS DateTime))
INSERT [dbo].[UserRole] ([Id], [ApplicationUserId], [RoleId], [IsActive], [LastChanged]) VALUES (N'797330c2-43f5-449d-8e3f-3ab8c38cd2c8', N'f957fb00-b569-4e4c-9eb7-c9a7f73961ee', N'a4a189e2-0b99-48ab-9542-ec526813df5d', 1, CAST(N'2020-07-07T15:08:12.177' AS DateTime))
ALTER TABLE [dbo].[ApplicationUser] ADD  CONSTRAINT [DF_ApplicationUser_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[ApplicationUser] ADD  CONSTRAINT [DF_ApplicationUser_LastChanged]  DEFAULT (getdate()) FOR [LastChanged]
GO
ALTER TABLE [dbo].[Menu] ADD  CONSTRAINT [DF_Menu_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Menu] ADD  CONSTRAINT [DF_Menu_ParentId]  DEFAULT (CONVERT([uniqueidentifier],'00000000-0000-0000-0000-000000000000')) FOR [ParentId]
GO
ALTER TABLE [dbo].[Menu] ADD  CONSTRAINT [DF_Menu_LastChanged]  DEFAULT (getdate()) FOR [LastChanged]
GO
ALTER TABLE [dbo].[MenuPrivilege] ADD  CONSTRAINT [DF_MenuPrivilege_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[MenuPrivilege] ADD  CONSTRAINT [DF_MenuPrivilege_LastChanged]  DEFAULT (getdate()) FOR [LastChanged]
GO
ALTER TABLE [dbo].[Module] ADD  CONSTRAINT [DF_Module_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Module] ADD  CONSTRAINT [DF_Module_LastChanged]  DEFAULT (getdate()) FOR [LastChanged]
GO
ALTER TABLE [dbo].[Privilege] ADD  CONSTRAINT [DF_Privilege_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Privilege] ADD  CONSTRAINT [DF_Privilege_LastChanged]  DEFAULT (getdate()) FOR [LastChanged]
GO
ALTER TABLE [dbo].[Role] ADD  CONSTRAINT [DF_Role_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Role] ADD  CONSTRAINT [DF_Role_LastChanged]  DEFAULT (getdate()) FOR [LastChanged]
GO
ALTER TABLE [dbo].[RoleMenu] ADD  CONSTRAINT [DF_RoleMenu_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[RoleMenu] ADD  CONSTRAINT [DF_RoleMenu_LastChanged]  DEFAULT (getdate()) FOR [LastChanged]
GO
ALTER TABLE [dbo].[RoleMenuPrivilege] ADD  CONSTRAINT [DF_RoleMenuPrivilege_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[RoleMenuPrivilege] ADD  CONSTRAINT [DF_RoleMenuPrivilege_LastChanged]  DEFAULT (getdate()) FOR [LastChanged]
GO
ALTER TABLE [dbo].[UserRole] ADD  CONSTRAINT [DF_UserRole_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[UserRole] ADD  CONSTRAINT [DF_UserRole_LastChanged]  DEFAULT (getdate()) FOR [LastChanged]
GO
ALTER TABLE [dbo].[ApplicationUser]  WITH CHECK ADD  CONSTRAINT [FK_ApplicationUser_ApplicationUser] FOREIGN KEY([Id])
REFERENCES [dbo].[ApplicationUser] ([Id])
GO
ALTER TABLE [dbo].[ApplicationUser] CHECK CONSTRAINT [FK_ApplicationUser_ApplicationUser]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[MenuPrivilege]  WITH CHECK ADD  CONSTRAINT [FK_MenuPrivilege_Menu] FOREIGN KEY([MenuId])
REFERENCES [dbo].[Menu] ([Id])
GO
ALTER TABLE [dbo].[MenuPrivilege] CHECK CONSTRAINT [FK_MenuPrivilege_Menu]
GO
ALTER TABLE [dbo].[MenuPrivilege]  WITH CHECK ADD  CONSTRAINT [FK_MenuPrivilege_Privilege] FOREIGN KEY([PrivilegeId])
REFERENCES [dbo].[Privilege] ([Id])
GO
ALTER TABLE [dbo].[MenuPrivilege] CHECK CONSTRAINT [FK_MenuPrivilege_Privilege]
GO
ALTER TABLE [dbo].[RoleMenu]  WITH CHECK ADD  CONSTRAINT [FK_RoleMenu_Menu] FOREIGN KEY([MenuId])
REFERENCES [dbo].[Menu] ([Id])
GO
ALTER TABLE [dbo].[RoleMenu] CHECK CONSTRAINT [FK_RoleMenu_Menu]
GO
ALTER TABLE [dbo].[RoleMenu]  WITH CHECK ADD  CONSTRAINT [FK_RoleMenu_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[RoleMenu] CHECK CONSTRAINT [FK_RoleMenu_Role]
GO
ALTER TABLE [dbo].[RoleMenuPrivilege]  WITH CHECK ADD  CONSTRAINT [FK_RoleMenuPrivilege_Privilege] FOREIGN KEY([PrivilegeId])
REFERENCES [dbo].[Privilege] ([Id])
GO
ALTER TABLE [dbo].[RoleMenuPrivilege] CHECK CONSTRAINT [FK_RoleMenuPrivilege_Privilege]
GO
ALTER TABLE [dbo].[RoleMenuPrivilege]  WITH CHECK ADD  CONSTRAINT [FK_RoleMenuPrivilege_RoleMenu] FOREIGN KEY([RoleMenuId])
REFERENCES [dbo].[RoleMenu] ([Id])
GO
ALTER TABLE [dbo].[RoleMenuPrivilege] CHECK CONSTRAINT [FK_RoleMenuPrivilege_RoleMenu]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_ApplicationUser] FOREIGN KEY([ApplicationUserId])
REFERENCES [dbo].[ApplicationUser] ([Id])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_ApplicationUser]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_Role]
GO
