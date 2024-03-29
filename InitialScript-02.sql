USE [gangaprakash_livedb]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 7/29/2020 11:03:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[Id] [uniqueidentifier] NOT NULL,
	[CountryId] [uniqueidentifier] NOT NULL,
	[StateId] [uniqueidentifier] NOT NULL,
	[CityId] [uniqueidentifier] NOT NULL,
	[AddressLine] [nvarchar](max) NOT NULL,
	[Area] [nvarchar](max) NOT NULL,
	[Pincode] [nvarchar](6) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[LastChanged] [datetime] NOT NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApplicationUser]    Script Date: 7/29/2020 11:03:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationUser](
	[Id] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[DoctorId] [uniqueidentifier] NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[Lastname] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[ShortName] [nvarchar](50) NOT NULL,
	[MobileNo] [nchar](10) NOT NULL,
	[UserImageBase64String] [nvarchar](max) NULL,
	[IsDoctor] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[LastChanged] [datetime] NOT NULL,
 CONSTRAINT [PK_ApplicationUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 7/29/2020 11:03:15 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 7/29/2020 11:03:15 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 7/29/2020 11:03:15 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 7/29/2020 11:03:15 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 7/29/2020 11:03:15 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[City]    Script Date: 7/29/2020 11:03:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[Id] [uniqueidentifier] NOT NULL,
	[CountryId] [uniqueidentifier] NOT NULL,
	[StateId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[LastChanged] [datetime] NOT NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 7/29/2020 11:03:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[LastChanged] [datetime] NOT NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 7/29/2020 11:03:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[LastChanged] [datetime] NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Doctor]    Script Date: 7/29/2020 11:03:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctor](
	[Id] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[MiddleName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[DOB] [nvarchar](8) NOT NULL,
	[MedicalRegistrationNo] [nvarchar](max) NOT NULL,
	[GenderId] [uniqueidentifier] NOT NULL,
	[AddressId] [uniqueidentifier] NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[MobileNo] [nchar](10) NOT NULL,
	[DoctorImageBase64String] [nvarchar](max) NULL,
	[DoctorSignatureBase64String] [nvarchar](max) NULL,
	[ApplicationUserId] [uniqueidentifier] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[LastChanged] [datetime] NOT NULL,
 CONSTRAINT [PK_Doctor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DoctorDepartment]    Script Date: 7/29/2020 11:03:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DoctorDepartment](
	[Id] [uniqueidentifier] NOT NULL,
	[DoctorId] [uniqueidentifier] NOT NULL,
	[DepartmentId] [uniqueidentifier] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[LastChanged] [datetime] NOT NULL,
 CONSTRAINT [PK_DoctorDepartment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DoctorIdentity]    Script Date: 7/29/2020 11:03:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DoctorIdentity](
	[Id] [uniqueidentifier] NOT NULL,
	[DoctorId] [uniqueidentifier] NOT NULL,
	[IdentityTypeId] [uniqueidentifier] NOT NULL,
	[IdentityNo] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[LastChanged] [datetime] NOT NULL,
 CONSTRAINT [PK_DoctorIdentity] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DoctorQualification]    Script Date: 7/29/2020 11:03:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DoctorQualification](
	[Id] [uniqueidentifier] NOT NULL,
	[DoctorId] [uniqueidentifier] NOT NULL,
	[Qualification] [nvarchar](50) NOT NULL,
	[YearOfPassing] [nvarchar](10) NOT NULL,
	[Grade] [nvarchar](10) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[LastChanged] [datetime] NOT NULL,
 CONSTRAINT [PK_DoctorQualification] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gender]    Script Date: 7/29/2020 11:03:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gender](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[LastChanged] [datetime] NOT NULL,
 CONSTRAINT [PK_Gender] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IdentityType]    Script Date: 7/29/2020 11:03:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdentityType](
	[Id] [uniqueidentifier] NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[LastChanged] [datetime] NOT NULL,
 CONSTRAINT [PK_IdentityType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InternalChat]    Script Date: 7/29/2020 11:03:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InternalChat](
	[Id] [uniqueidentifier] NOT NULL,
	[ApplicationUserId] [uniqueidentifier] NOT NULL,
	[Username] [nvarchar](max) NOT NULL,
	[Text] [nvarchar](max) NOT NULL,
	[DateTime] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[LastChanged] [datetime] NOT NULL,
 CONSTRAINT [PK_InternalChat] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 7/29/2020 11:03:15 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MenuPrivilege]    Script Date: 7/29/2020 11:03:15 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Module]    Script Date: 7/29/2020 11:03:15 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Privilege]    Script Date: 7/29/2020 11:03:15 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 7/29/2020 11:03:15 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleMenu]    Script Date: 7/29/2020 11:03:15 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleMenuPrivilege]    Script Date: 7/29/2020 11:03:15 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[State]    Script Date: 7/29/2020 11:03:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[State](
	[Id] [uniqueidentifier] NOT NULL,
	[CountryId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[LastChanged] [datetime] NOT NULL,
 CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 7/29/2020 11:03:15 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ApplicationUser] ([Id], [UserId], [DoctorId], [UserName], [FirstName], [Lastname], [Email], [ShortName], [MobileNo], [UserImageBase64String], [IsDoctor], [IsActive], [LastChanged]) VALUES (N'21c1d269-175d-4197-873d-c64e3ee6a1ba', N'43cf99fa-451c-4fec-a3db-4a489e051ca9', N'00000000-0000-0000-0000-000000000000', N'dixitabhi66', N'Abhishek', N'Dixit', N'abhishekd9519@gmail.com', N'Abhi', N'7769037550', N'', 0, 1, CAST(N'2020-07-18T09:19:02.343' AS DateTime))
INSERT [dbo].[ApplicationUser] ([Id], [UserId], [DoctorId], [UserName], [FirstName], [Lastname], [Email], [ShortName], [MobileNo], [UserImageBase64String], [IsDoctor], [IsActive], [LastChanged]) VALUES (N'f957fb00-b569-4e4c-9eb7-c9a7f73961ee', N'e46dce43-bdd4-45ef-8679-48449eebe443', N'00000000-0000-0000-0000-000000000000', N'superadmin', N'Super', N'Admin', N'superadmin@gangaprakash.com', N'Superadmin', N'7559132699', N'data:image/jpeg;base64,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', 0, 1, CAST(N'2020-07-05T10:28:48.863' AS DateTime))
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'43cf99fa-451c-4fec-a3db-4a489e051ca9', N'abhishekd9519@gmail.com', 1, N'APyGjY4ieJjEf1uxGc/7a7O/LScHVbPEU0zbxOTqsAjl1CoFP03Y2fop9/dDg+S/wA==', N'dcd3dfba-39cf-42b1-9ba8-ff3b486eff2e', NULL, 0, 0, NULL, 0, 0, N'dixitabhi66')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e46dce43-bdd4-45ef-8679-48449eebe443', N'superadmin@gangaprakash.com', 1, N'ABsVnK76GJ/n/vR6/1Bpll67CVHMIwsQKnXsAGXE1DzSzQXSsC6J6KjVe9Aafg9fUA==', N'e6535d37-64ce-456a-8d47-b732c1a4fd64', NULL, 0, 0, NULL, 0, 0, N'superadmin')
INSERT [dbo].[City] ([Id], [CountryId], [StateId], [Name], [IsActive], [LastChanged]) VALUES (N'50b802fe-45b2-48b3-bb2b-158a1e7a7ae5', N'8d5d7dda-f055-48c4-a196-074fb35ff105', N'0f7402eb-1147-4619-bbd2-0a3cb457b9bd', N'Kolhapur', 1, CAST(N'2020-07-25T18:34:44.940' AS DateTime))
INSERT [dbo].[Country] ([Id], [Name], [IsActive], [LastChanged]) VALUES (N'8d5d7dda-f055-48c4-a196-074fb35ff105', N'India', 1, CAST(N'2020-07-25T11:52:15.240' AS DateTime))
INSERT [dbo].[Country] ([Id], [Name], [IsActive], [LastChanged]) VALUES (N'23f01ce6-aa49-4ac9-99ed-827dc03ba944', N'Australia', 1, CAST(N'2020-07-25T14:36:13.837' AS DateTime))
INSERT [dbo].[Department] ([Id], [Name], [IsActive], [LastChanged]) VALUES (N'9d283c97-ae4b-406a-92ef-1b692b7bced2', N'Cardiology', 1, CAST(N'2020-07-26T11:08:16.943' AS DateTime))
INSERT [dbo].[Gender] ([Id], [Name], [IsActive], [LastChanged]) VALUES (N'd2eda65a-ff78-4d29-9fe4-54a7e64de733', N'Male', 1, CAST(N'2020-07-27T21:11:02.230' AS DateTime))
INSERT [dbo].[Gender] ([Id], [Name], [IsActive], [LastChanged]) VALUES (N'b173d5cc-86a7-4252-ac03-958dd0954d52', N'Trangender', 1, CAST(N'2020-07-27T21:11:28.667' AS DateTime))
INSERT [dbo].[Gender] ([Id], [Name], [IsActive], [LastChanged]) VALUES (N'5da2f242-18c1-4687-9266-d4d918db1a85', N'Female', 1, CAST(N'2020-07-27T21:11:06.003' AS DateTime))
INSERT [dbo].[Gender] ([Id], [Name], [IsActive], [LastChanged]) VALUES (N'dce2d45d-68c6-45d8-923c-f48a2741eb88', N'Undetermined', 1, CAST(N'2020-07-27T21:13:02.553' AS DateTime))
INSERT [dbo].[InternalChat] ([Id], [ApplicationUserId], [Username], [Text], [DateTime], [IsActive], [LastChanged]) VALUES (N'46b6a4f6-68de-4753-8844-0120407491f9', N'f957fb00-b569-4e4c-9eb7-c9a7f73961ee', N'superadmin', N'Good Morning', CAST(N'2020-07-26T11:12:58.370' AS DateTime), 1, CAST(N'2020-07-26T11:12:58.370' AS DateTime))
INSERT [dbo].[InternalChat] ([Id], [ApplicationUserId], [Username], [Text], [DateTime], [IsActive], [LastChanged]) VALUES (N'f34e531c-0f1b-4dc1-a75a-2762f7e136e7', N'f957fb00-b569-4e4c-9eb7-c9a7f73961ee', N'superadmin', N'Hi all', CAST(N'2020-07-26T11:12:49.503' AS DateTime), 1, CAST(N'2020-07-26T11:12:49.503' AS DateTime))
INSERT [dbo].[Menu] ([Id], [Name], [Controller], [Action], [Area], [SequenceNo], [ParentId], [ModuleId], [IsActive], [LastChanged]) VALUES (N'91031266-338d-4259-8518-076a3fa8e427', N'Menu', N'Menu', N'Index', N'Administration', 3, N'1182dd63-94ff-4cdd-90fd-f8924ae0ed0b', N'fc5dfdc1-562a-4287-921e-d863bb6b77c8', 1, CAST(N'2020-07-07T15:54:10.860' AS DateTime))
INSERT [dbo].[Menu] ([Id], [Name], [Controller], [Action], [Area], [SequenceNo], [ParentId], [ModuleId], [IsActive], [LastChanged]) VALUES (N'44429eaa-ad49-42c2-9453-12c3807aa31c', N'Privilege', N'Privilege', N'Index', N'Administration', 2, N'1182dd63-94ff-4cdd-90fd-f8924ae0ed0b', N'fc5dfdc1-562a-4287-921e-d863bb6b77c8', 1, CAST(N'2020-07-07T15:53:50.110' AS DateTime))
INSERT [dbo].[Menu] ([Id], [Name], [Controller], [Action], [Area], [SequenceNo], [ParentId], [ModuleId], [IsActive], [LastChanged]) VALUES (N'e425165f-28c6-41ee-a2ab-24b84021527e', N'Country', N'Country', N'Index', N'Configuration', 1, N'e7c54ad1-ca47-4974-84a5-77d67158c51a', N'fa5218c2-36e6-4e54-9777-d5c602324521', 1, CAST(N'2020-07-25T11:50:42.670' AS DateTime))
INSERT [dbo].[Menu] ([Id], [Name], [Controller], [Action], [Area], [SequenceNo], [ParentId], [ModuleId], [IsActive], [LastChanged]) VALUES (N'db5e6470-de16-4bba-9030-2ff230f7404c', N'City', N'City', N'Index', N'Configuration', 3, N'e7c54ad1-ca47-4974-84a5-77d67158c51a', N'fa5218c2-36e6-4e54-9777-d5c602324521', 1, CAST(N'2020-07-25T18:09:54.853' AS DateTime))
INSERT [dbo].[Menu] ([Id], [Name], [Controller], [Action], [Area], [SequenceNo], [ParentId], [ModuleId], [IsActive], [LastChanged]) VALUES (N'7cd3ac3b-1ee3-476b-996f-52d2795ce063', N'Transaction', N'Transaction', N'Index', N'Configuration', 2, N'00000000-0000-0000-0000-000000000000', N'fa5218c2-36e6-4e54-9777-d5c602324521', 1, CAST(N'2020-07-25T11:50:23.770' AS DateTime))
INSERT [dbo].[Menu] ([Id], [Name], [Controller], [Action], [Area], [SequenceNo], [ParentId], [ModuleId], [IsActive], [LastChanged]) VALUES (N'32f23615-a6e2-42a8-86c1-6280d9b73c94', N'Role', N'Role', N'Index', N'Administration', 4, N'1182dd63-94ff-4cdd-90fd-f8924ae0ed0b', N'fc5dfdc1-562a-4287-921e-d863bb6b77c8', 1, CAST(N'2020-07-07T15:55:00.497' AS DateTime))
INSERT [dbo].[Menu] ([Id], [Name], [Controller], [Action], [Area], [SequenceNo], [ParentId], [ModuleId], [IsActive], [LastChanged]) VALUES (N'65f22a02-3f90-4834-91d4-6610189f3539', N'Role Menu Privilege', N'RoleMenuPrivilege', N'Index', N'Administration', 1, N'f1fd9ec8-3665-459e-92a8-b5c465a64d14', N'fc5dfdc1-562a-4287-921e-d863bb6b77c8', 1, CAST(N'2020-07-07T15:55:32.403' AS DateTime))
INSERT [dbo].[Menu] ([Id], [Name], [Controller], [Action], [Area], [SequenceNo], [ParentId], [ModuleId], [IsActive], [LastChanged]) VALUES (N'1aa15e14-5fec-4119-a7ca-672b218a2eab', N'Department', N'Department', N'Index', N'Configuration', 4, N'e7c54ad1-ca47-4974-84a5-77d67158c51a', N'fa5218c2-36e6-4e54-9777-d5c602324521', 1, CAST(N'2020-07-26T10:56:19.660' AS DateTime))
INSERT [dbo].[Menu] ([Id], [Name], [Controller], [Action], [Area], [SequenceNo], [ParentId], [ModuleId], [IsActive], [LastChanged]) VALUES (N'0b4abfda-4a47-4636-8610-6af3f43627a5', N'User', N'ApplicationUser', N'Index', N'Administration', 2, N'f1fd9ec8-3665-459e-92a8-b5c465a64d14', N'fc5dfdc1-562a-4287-921e-d863bb6b77c8', 1, CAST(N'2020-07-18T09:17:12.537' AS DateTime))
INSERT [dbo].[Menu] ([Id], [Name], [Controller], [Action], [Area], [SequenceNo], [ParentId], [ModuleId], [IsActive], [LastChanged]) VALUES (N'e7c54ad1-ca47-4974-84a5-77d67158c51a', N'Master', N'Master', N'Index', N'Configuration', 1, N'00000000-0000-0000-0000-000000000000', N'fa5218c2-36e6-4e54-9777-d5c602324521', 1, CAST(N'2020-07-25T11:50:09.273' AS DateTime))
INSERT [dbo].[Menu] ([Id], [Name], [Controller], [Action], [Area], [SequenceNo], [ParentId], [ModuleId], [IsActive], [LastChanged]) VALUES (N'316e5103-7f30-4276-a4d2-859b08a827bc', N'State', N'State', N'Index', N'Configuration', 2, N'e7c54ad1-ca47-4974-84a5-77d67158c51a', N'fa5218c2-36e6-4e54-9777-d5c602324521', 1, CAST(N'2020-07-25T14:28:10.637' AS DateTime))
INSERT [dbo].[Menu] ([Id], [Name], [Controller], [Action], [Area], [SequenceNo], [ParentId], [ModuleId], [IsActive], [LastChanged]) VALUES (N'e7844ebb-d134-4e59-a349-8a75357a5dc0', N'Master', N'Master', N'Index', N'Appointment', 1, N'00000000-0000-0000-0000-000000000000', N'a678db10-66d1-4c93-a8bc-90fc3f812016', 1, CAST(N'2020-07-26T18:46:11.980' AS DateTime))
INSERT [dbo].[Menu] ([Id], [Name], [Controller], [Action], [Area], [SequenceNo], [ParentId], [ModuleId], [IsActive], [LastChanged]) VALUES (N'f1fd9ec8-3665-459e-92a8-b5c465a64d14', N'Transaction', N'Transaction', N'Index', N'Administration', 2, N'00000000-0000-0000-0000-000000000000', N'fc5dfdc1-562a-4287-921e-d863bb6b77c8', 1, CAST(N'2020-07-07T15:53:08.930' AS DateTime))
INSERT [dbo].[Menu] ([Id], [Name], [Controller], [Action], [Area], [SequenceNo], [ParentId], [ModuleId], [IsActive], [LastChanged]) VALUES (N'551684f0-2f6c-4131-b7f9-ec4ca1309fdd', N'Module', N'Module', N'Index', N'Administration', 1, N'1182dd63-94ff-4cdd-90fd-f8924ae0ed0b', N'fc5dfdc1-562a-4287-921e-d863bb6b77c8', 1, CAST(N'2020-07-07T15:53:29.487' AS DateTime))
INSERT [dbo].[Menu] ([Id], [Name], [Controller], [Action], [Area], [SequenceNo], [ParentId], [ModuleId], [IsActive], [LastChanged]) VALUES (N'8c6f0e13-a09f-453c-a1db-f7b98e3e457d', N'Chat', N'InternalChat', N'Index', N'Administration', 5, N'1182dd63-94ff-4cdd-90fd-f8924ae0ed0b', N'fc5dfdc1-562a-4287-921e-d863bb6b77c8', 1, CAST(N'2020-07-18T01:04:46.340' AS DateTime))
INSERT [dbo].[Menu] ([Id], [Name], [Controller], [Action], [Area], [SequenceNo], [ParentId], [ModuleId], [IsActive], [LastChanged]) VALUES (N'1182dd63-94ff-4cdd-90fd-f8924ae0ed0b', N'Master', N'Master', N'Index', N'Administration', 1, N'00000000-0000-0000-0000-000000000000', N'fc5dfdc1-562a-4287-921e-d863bb6b77c8', 1, CAST(N'2020-07-07T15:52:51.727' AS DateTime))
INSERT [dbo].[Menu] ([Id], [Name], [Controller], [Action], [Area], [SequenceNo], [ParentId], [ModuleId], [IsActive], [LastChanged]) VALUES (N'ba844076-8208-4075-a9f0-fae60a888a95', N'Appointment Schedule', N'AppointmentSchedule', N'Index', N'Appointment', 1, N'e7844ebb-d134-4e59-a349-8a75357a5dc0', N'a678db10-66d1-4c93-a8bc-90fc3f812016', 1, CAST(N'2020-07-26T18:46:51.727' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'2a344841-be42-4f49-b724-02037dc5fa83', N'32f23615-a6e2-42a8-86c1-6280d9b73c94', N'3205ad4d-e119-4380-92af-ab57f70a03c6', 1, CAST(N'2020-07-07T15:55:00.737' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'fb9064ba-76a4-483a-9ebd-07a0946471c3', N'551684f0-2f6c-4131-b7f9-ec4ca1309fdd', N'6c79ea64-08a6-4950-a170-5e8223f33659', 1, CAST(N'2020-07-07T15:53:29.560' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'f6ea3ff5-543f-48fd-8c95-0a1f4d8027a1', N'db5e6470-de16-4bba-9030-2ff230f7404c', N'159bdd1d-11e6-4c1d-a2c9-893d6d218b75', 1, CAST(N'2020-07-25T18:09:54.980' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'41ee4fe3-66d6-493c-81b5-10f74777d0c9', N'ba844076-8208-4075-a9f0-fae60a888a95', N'159bdd1d-11e6-4c1d-a2c9-893d6d218b75', 1, CAST(N'2020-07-26T18:46:51.727' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'e228d48a-1181-4f49-b544-125a25f14629', N'db5e6470-de16-4bba-9030-2ff230f7404c', N'5af0dc03-3050-48c2-b22b-5acac4a2e749', 1, CAST(N'2020-07-25T18:09:54.980' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'6264714f-e06b-43c0-8b73-12da0c210b22', N'1aa15e14-5fec-4119-a7ca-672b218a2eab', N'6c79ea64-08a6-4950-a170-5e8223f33659', 1, CAST(N'2020-07-26T10:56:19.693' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'897aefcc-5b28-418a-b5a2-1adccf407d05', N'316e5103-7f30-4276-a4d2-859b08a827bc', N'5af0dc03-3050-48c2-b22b-5acac4a2e749', 1, CAST(N'2020-07-25T14:28:10.680' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'4fda0e15-91c8-4cfe-8d6f-200ec8242b79', N'1aa15e14-5fec-4119-a7ca-672b218a2eab', N'5af0dc03-3050-48c2-b22b-5acac4a2e749', 1, CAST(N'2020-07-26T10:56:19.717' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'fe71fa51-a1c8-4a40-bcaa-20d76f1f7bec', N'91031266-338d-4259-8518-076a3fa8e427', N'5af0dc03-3050-48c2-b22b-5acac4a2e749', 1, CAST(N'2020-07-07T15:54:11.010' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'3cefc5dc-43d8-4b89-9b5a-2a34902bca97', N'db5e6470-de16-4bba-9030-2ff230f7404c', N'6c79ea64-08a6-4950-a170-5e8223f33659', 1, CAST(N'2020-07-25T18:09:54.953' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'377f38d3-428f-40c5-81c0-317d2138f4dc', N'91031266-338d-4259-8518-076a3fa8e427', N'159bdd1d-11e6-4c1d-a2c9-893d6d218b75', 1, CAST(N'2020-07-07T15:54:11.160' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'94a585eb-65c1-4a18-a441-32e7bab3a34b', N'32f23615-a6e2-42a8-86c1-6280d9b73c94', N'6c79ea64-08a6-4950-a170-5e8223f33659', 1, CAST(N'2020-07-07T15:55:00.580' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'5c01ac38-306e-44fe-8c24-37d2480aa6b9', N'32f23615-a6e2-42a8-86c1-6280d9b73c94', N'159bdd1d-11e6-4c1d-a2c9-893d6d218b75', 1, CAST(N'2020-07-07T15:55:00.810' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'd90e8f34-4604-4a0b-8446-3b189b43ec87', N'44429eaa-ad49-42c2-9453-12c3807aa31c', N'3205ad4d-e119-4380-92af-ab57f70a03c6', 1, CAST(N'2020-07-07T15:53:50.333' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'0833dd61-3759-46eb-b055-3c5cff2551d3', N'0b4abfda-4a47-4636-8610-6af3f43627a5', N'3205ad4d-e119-4380-92af-ab57f70a03c6', 1, CAST(N'2020-07-18T09:17:12.910' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'1ebc2329-3f78-46e4-9480-3d7dec250d8b', N'1aa15e14-5fec-4119-a7ca-672b218a2eab', N'3205ad4d-e119-4380-92af-ab57f70a03c6', 1, CAST(N'2020-07-26T10:56:19.717' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'93e41c5c-0e70-4a20-9e36-3e5939a6621d', N'551684f0-2f6c-4131-b7f9-ec4ca1309fdd', N'159bdd1d-11e6-4c1d-a2c9-893d6d218b75', 1, CAST(N'2020-07-07T15:53:29.807' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'b6850831-9442-472b-b16c-3f3e4cfeaac9', N'65f22a02-3f90-4834-91d4-6610189f3539', N'159bdd1d-11e6-4c1d-a2c9-893d6d218b75', 1, CAST(N'2020-07-07T15:55:32.480' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'a40a2f75-d915-43f8-a055-44cb6f1df08d', N'e7c54ad1-ca47-4974-84a5-77d67158c51a', N'159bdd1d-11e6-4c1d-a2c9-893d6d218b75', 1, CAST(N'2020-07-25T11:50:09.333' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'990e1ef8-8084-4015-8f75-495feedb8a44', N'e425165f-28c6-41ee-a2ab-24b84021527e', N'3205ad4d-e119-4380-92af-ab57f70a03c6', 1, CAST(N'2020-07-25T11:50:42.673' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'8f12522f-a475-4e25-aa98-5c7f525e59c9', N'551684f0-2f6c-4131-b7f9-ec4ca1309fdd', N'5af0dc03-3050-48c2-b22b-5acac4a2e749', 1, CAST(N'2020-07-07T15:53:29.647' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'391bbc6d-c85a-4551-bc69-6a768d238af9', N'1182dd63-94ff-4cdd-90fd-f8924ae0ed0b', N'159bdd1d-11e6-4c1d-a2c9-893d6d218b75', 1, CAST(N'2020-07-07T15:52:51.813' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'85639381-04c7-4180-99eb-7e6e786ed997', N'316e5103-7f30-4276-a4d2-859b08a827bc', N'6c79ea64-08a6-4950-a170-5e8223f33659', 1, CAST(N'2020-07-25T14:28:10.670' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'6f43edbd-9bf4-4f53-a13d-7fb154860238', N'1aa15e14-5fec-4119-a7ca-672b218a2eab', N'159bdd1d-11e6-4c1d-a2c9-893d6d218b75', 1, CAST(N'2020-07-26T10:56:19.720' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'2dac8e70-cb66-444a-a33c-8829c7f540e3', N'e425165f-28c6-41ee-a2ab-24b84021527e', N'6c79ea64-08a6-4950-a170-5e8223f33659', 1, CAST(N'2020-07-25T11:50:42.670' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'863575e4-f0b0-4fc7-acab-8a23fd71bd9b', N'7cd3ac3b-1ee3-476b-996f-52d2795ce063', N'159bdd1d-11e6-4c1d-a2c9-893d6d218b75', 1, CAST(N'2020-07-25T11:50:23.773' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'ab01b83f-21f1-49ad-baa5-8ac691d6181e', N'db5e6470-de16-4bba-9030-2ff230f7404c', N'3205ad4d-e119-4380-92af-ab57f70a03c6', 1, CAST(N'2020-07-25T18:09:54.980' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'1a34aaba-fc9a-48f3-b5d3-8d5cc4727d89', N'0b4abfda-4a47-4636-8610-6af3f43627a5', N'159bdd1d-11e6-4c1d-a2c9-893d6d218b75', 1, CAST(N'2020-07-18T09:17:12.970' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'029996a8-f399-497d-9d0e-90b43d70eb29', N'551684f0-2f6c-4131-b7f9-ec4ca1309fdd', N'3205ad4d-e119-4380-92af-ab57f70a03c6', 1, CAST(N'2020-07-07T15:53:29.727' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'b8c6acac-c09f-4ce6-b296-9d04b47c0f44', N'e7844ebb-d134-4e59-a349-8a75357a5dc0', N'159bdd1d-11e6-4c1d-a2c9-893d6d218b75', 1, CAST(N'2020-07-26T18:46:12.067' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'b28c6395-6f7b-4932-a6a8-a06eea1613eb', N'91031266-338d-4259-8518-076a3fa8e427', N'6c79ea64-08a6-4950-a170-5e8223f33659', 1, CAST(N'2020-07-07T15:54:10.933' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'18da0a7f-fcd5-419d-847e-a8f0d97da6d7', N'8c6f0e13-a09f-453c-a1db-f7b98e3e457d', N'159bdd1d-11e6-4c1d-a2c9-893d6d218b75', 1, CAST(N'2020-07-18T01:04:47.050' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'8863e236-c63e-44dd-b774-aa517c4c266a', N'32f23615-a6e2-42a8-86c1-6280d9b73c94', N'5af0dc03-3050-48c2-b22b-5acac4a2e749', 1, CAST(N'2020-07-07T15:55:00.660' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'a85a4a29-4ab4-424f-aae6-af68ff8c2c27', N'0b4abfda-4a47-4636-8610-6af3f43627a5', N'6c79ea64-08a6-4950-a170-5e8223f33659', 1, CAST(N'2020-07-18T09:17:12.800' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'a2400da4-08fe-43f5-b4cd-b5b70c1c95b2', N'e425165f-28c6-41ee-a2ab-24b84021527e', N'5af0dc03-3050-48c2-b22b-5acac4a2e749', 1, CAST(N'2020-07-25T11:50:42.673' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'5edee0bb-cd16-4e2f-b339-c644e148188c', N'316e5103-7f30-4276-a4d2-859b08a827bc', N'159bdd1d-11e6-4c1d-a2c9-893d6d218b75', 1, CAST(N'2020-07-25T14:28:10.713' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'a5c12ea7-abf8-4e3d-902c-c6b82f1311b1', N'44429eaa-ad49-42c2-9453-12c3807aa31c', N'159bdd1d-11e6-4c1d-a2c9-893d6d218b75', 1, CAST(N'2020-07-07T15:53:50.407' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'303a3c71-4e74-48b6-a935-d64b056bcf67', N'91031266-338d-4259-8518-076a3fa8e427', N'3205ad4d-e119-4380-92af-ab57f70a03c6', 1, CAST(N'2020-07-07T15:54:11.083' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'0233668c-b15e-4c24-9b75-de5bccbebf02', N'44429eaa-ad49-42c2-9453-12c3807aa31c', N'5af0dc03-3050-48c2-b22b-5acac4a2e749', 1, CAST(N'2020-07-07T15:53:50.260' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'92899ef5-dbe5-45d1-8c4c-e96533a164b6', N'0b4abfda-4a47-4636-8610-6af3f43627a5', N'5af0dc03-3050-48c2-b22b-5acac4a2e749', 1, CAST(N'2020-07-18T09:17:12.867' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'6f0d6517-ebea-4dce-91cd-eac7d21ceb15', N'316e5103-7f30-4276-a4d2-859b08a827bc', N'3205ad4d-e119-4380-92af-ab57f70a03c6', 1, CAST(N'2020-07-25T14:28:10.683' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'b1f87289-5fde-4d96-87ab-eaedc78f41f6', N'44429eaa-ad49-42c2-9453-12c3807aa31c', N'6c79ea64-08a6-4950-a170-5e8223f33659', 1, CAST(N'2020-07-07T15:53:50.183' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'2582e646-1284-4d0a-b1e9-f5ea204065d9', N'e425165f-28c6-41ee-a2ab-24b84021527e', N'159bdd1d-11e6-4c1d-a2c9-893d6d218b75', 1, CAST(N'2020-07-25T11:50:42.673' AS DateTime))
INSERT [dbo].[MenuPrivilege] ([Id], [MenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'add7e861-8a82-40bf-b86b-f8dd37e40ae6', N'f1fd9ec8-3665-459e-92a8-b5c465a64d14', N'159bdd1d-11e6-4c1d-a2c9-893d6d218b75', 1, CAST(N'2020-07-07T15:53:09.003' AS DateTime))
INSERT [dbo].[Module] ([Id], [Name], [SequenceNo], [IsActive], [LastChanged]) VALUES (N'a678db10-66d1-4c93-a8bc-90fc3f812016', N'Appointment', 3, 1, CAST(N'2020-07-26T18:45:14.373' AS DateTime))
INSERT [dbo].[Module] ([Id], [Name], [SequenceNo], [IsActive], [LastChanged]) VALUES (N'fa5218c2-36e6-4e54-9777-d5c602324521', N'Configuration', 2, 1, CAST(N'2020-07-25T11:49:49.317' AS DateTime))
INSERT [dbo].[Module] ([Id], [Name], [SequenceNo], [IsActive], [LastChanged]) VALUES (N'fc5dfdc1-562a-4287-921e-d863bb6b77c8', N'Administration', 1, 1, CAST(N'2020-07-07T15:51:43.123' AS DateTime))
INSERT [dbo].[Privilege] ([Id], [Name], [SequenceNo], [IsActive], [LastChanged]) VALUES (N'5af0dc03-3050-48c2-b22b-5acac4a2e749', N'Delete    ', 4, 1, CAST(N'2020-07-07T15:52:22.453' AS DateTime))
INSERT [dbo].[Privilege] ([Id], [Name], [SequenceNo], [IsActive], [LastChanged]) VALUES (N'6c79ea64-08a6-4950-a170-5e8223f33659', N'Create    ', 2, 1, CAST(N'2020-07-07T15:52:06.580' AS DateTime))
INSERT [dbo].[Privilege] ([Id], [Name], [SequenceNo], [IsActive], [LastChanged]) VALUES (N'159bdd1d-11e6-4c1d-a2c9-893d6d218b75', N'Index     ', 1, 1, CAST(N'2020-07-07T15:52:00.460' AS DateTime))
INSERT [dbo].[Privilege] ([Id], [Name], [SequenceNo], [IsActive], [LastChanged]) VALUES (N'3205ad4d-e119-4380-92af-ab57f70a03c6', N'Edit      ', 3, 1, CAST(N'2020-07-07T15:52:14.843' AS DateTime))
INSERT [dbo].[Role] ([Id], [Name], [IsActive], [LastChanged]) VALUES (N'2b42792d-7699-422f-b43f-4ebcb23cb9f0', N'Developer', 1, CAST(N'2020-07-18T09:19:28.920' AS DateTime))
INSERT [dbo].[Role] ([Id], [Name], [IsActive], [LastChanged]) VALUES (N'a4a189e2-0b99-48ab-9542-ec526813df5d', N'SysAdmin', 1, CAST(N'2020-07-07T15:07:35.753' AS DateTime))
INSERT [dbo].[RoleMenu] ([Id], [RoleId], [MenuId], [IsActive], [LastChanged]) VALUES (N'13f1c5b3-7693-4cd1-a663-043a3beb970e', N'2b42792d-7699-422f-b43f-4ebcb23cb9f0', N'ba844076-8208-4075-a9f0-fae60a888a95', 1, CAST(N'2020-07-26T18:47:14.560' AS DateTime))
INSERT [dbo].[RoleMenu] ([Id], [RoleId], [MenuId], [IsActive], [LastChanged]) VALUES (N'b636e5a4-93d0-475e-bacd-046e7640086c', N'a4a189e2-0b99-48ab-9542-ec526813df5d', N'8c6f0e13-a09f-453c-a1db-f7b98e3e457d', 1, CAST(N'2020-07-18T01:04:59.410' AS DateTime))
INSERT [dbo].[RoleMenu] ([Id], [RoleId], [MenuId], [IsActive], [LastChanged]) VALUES (N'8ed12bb8-8439-4b2b-826d-178d74d78b23', N'a4a189e2-0b99-48ab-9542-ec526813df5d', N'1aa15e14-5fec-4119-a7ca-672b218a2eab', 1, CAST(N'2020-07-26T10:56:51.967' AS DateTime))
INSERT [dbo].[RoleMenu] ([Id], [RoleId], [MenuId], [IsActive], [LastChanged]) VALUES (N'35136bb4-a862-4842-ac1e-1ab0ba0f7924', N'2b42792d-7699-422f-b43f-4ebcb23cb9f0', N'551684f0-2f6c-4131-b7f9-ec4ca1309fdd', 1, CAST(N'2020-07-18T09:19:28.940' AS DateTime))
INSERT [dbo].[RoleMenu] ([Id], [RoleId], [MenuId], [IsActive], [LastChanged]) VALUES (N'3e00592f-fd55-4b5b-97a5-24fe512e9f32', N'a4a189e2-0b99-48ab-9542-ec526813df5d', N'db5e6470-de16-4bba-9030-2ff230f7404c', 1, CAST(N'2020-07-25T18:10:12.360' AS DateTime))
INSERT [dbo].[RoleMenu] ([Id], [RoleId], [MenuId], [IsActive], [LastChanged]) VALUES (N'4357a2a4-9128-49dd-b330-2b29a260957a', N'2b42792d-7699-422f-b43f-4ebcb23cb9f0', N'db5e6470-de16-4bba-9030-2ff230f7404c', 1, CAST(N'2020-07-25T18:10:07.477' AS DateTime))
INSERT [dbo].[RoleMenu] ([Id], [RoleId], [MenuId], [IsActive], [LastChanged]) VALUES (N'd0a2caa9-4107-4d6d-8ded-2beee7dedd39', N'2b42792d-7699-422f-b43f-4ebcb23cb9f0', N'316e5103-7f30-4276-a4d2-859b08a827bc', 1, CAST(N'2020-07-25T14:29:20.600' AS DateTime))
INSERT [dbo].[RoleMenu] ([Id], [RoleId], [MenuId], [IsActive], [LastChanged]) VALUES (N'7ba345c6-ad71-40c8-a50f-339ca5c24b1d', N'2b42792d-7699-422f-b43f-4ebcb23cb9f0', N'91031266-338d-4259-8518-076a3fa8e427', 1, CAST(N'2020-07-18T09:19:28.940' AS DateTime))
INSERT [dbo].[RoleMenu] ([Id], [RoleId], [MenuId], [IsActive], [LastChanged]) VALUES (N'fa049931-2991-4610-a73a-390c38300b27', N'a4a189e2-0b99-48ab-9542-ec526813df5d', N'0b4abfda-4a47-4636-8610-6af3f43627a5', 1, CAST(N'2020-07-18T09:17:30.430' AS DateTime))
INSERT [dbo].[RoleMenu] ([Id], [RoleId], [MenuId], [IsActive], [LastChanged]) VALUES (N'b32cbaf1-e0f4-4e57-93fb-4fdc7d9a1224', N'2b42792d-7699-422f-b43f-4ebcb23cb9f0', N'1182dd63-94ff-4cdd-90fd-f8924ae0ed0b', 1, CAST(N'2020-07-18T09:19:28.940' AS DateTime))
INSERT [dbo].[RoleMenu] ([Id], [RoleId], [MenuId], [IsActive], [LastChanged]) VALUES (N'82e8a657-9986-47f9-99d8-56f157c49f67', N'2b42792d-7699-422f-b43f-4ebcb23cb9f0', N'0b4abfda-4a47-4636-8610-6af3f43627a5', 1, CAST(N'2020-07-18T09:19:28.940' AS DateTime))
INSERT [dbo].[RoleMenu] ([Id], [RoleId], [MenuId], [IsActive], [LastChanged]) VALUES (N'1b38143c-39d2-4f1e-baca-6b801a80b5d9', N'a4a189e2-0b99-48ab-9542-ec526813df5d', N'e7c54ad1-ca47-4974-84a5-77d67158c51a', 1, CAST(N'2020-07-25T11:51:33.877' AS DateTime))
INSERT [dbo].[RoleMenu] ([Id], [RoleId], [MenuId], [IsActive], [LastChanged]) VALUES (N'636df545-9df1-4cef-b69c-6c6a013a9ae0', N'a4a189e2-0b99-48ab-9542-ec526813df5d', N'91031266-338d-4259-8518-076a3fa8e427', 1, CAST(N'2020-07-07T15:56:04.083' AS DateTime))
INSERT [dbo].[RoleMenu] ([Id], [RoleId], [MenuId], [IsActive], [LastChanged]) VALUES (N'4688690c-7c56-4c15-97c4-73287d9bf28a', N'a4a189e2-0b99-48ab-9542-ec526813df5d', N'1182dd63-94ff-4cdd-90fd-f8924ae0ed0b', 1, CAST(N'2020-07-07T15:56:03.783' AS DateTime))
INSERT [dbo].[RoleMenu] ([Id], [RoleId], [MenuId], [IsActive], [LastChanged]) VALUES (N'25a3502b-3369-4612-b616-7577a8e98ccb', N'a4a189e2-0b99-48ab-9542-ec526813df5d', N'551684f0-2f6c-4131-b7f9-ec4ca1309fdd', 1, CAST(N'2020-07-07T15:56:03.860' AS DateTime))
INSERT [dbo].[RoleMenu] ([Id], [RoleId], [MenuId], [IsActive], [LastChanged]) VALUES (N'd3673f19-3301-4099-ab5a-89f4f7222031', N'2b42792d-7699-422f-b43f-4ebcb23cb9f0', N'65f22a02-3f90-4834-91d4-6610189f3539', 1, CAST(N'2020-07-18T09:19:28.930' AS DateTime))
INSERT [dbo].[RoleMenu] ([Id], [RoleId], [MenuId], [IsActive], [LastChanged]) VALUES (N'14adb415-dee7-4da7-b356-8a5d06c45cbe', N'2b42792d-7699-422f-b43f-4ebcb23cb9f0', N'8c6f0e13-a09f-453c-a1db-f7b98e3e457d', 1, CAST(N'2020-07-18T09:19:28.943' AS DateTime))
INSERT [dbo].[RoleMenu] ([Id], [RoleId], [MenuId], [IsActive], [LastChanged]) VALUES (N'9c8fa079-5f4a-45a6-a362-8f1b03fed190', N'a4a189e2-0b99-48ab-9542-ec526813df5d', N'65f22a02-3f90-4834-91d4-6610189f3539', 1, CAST(N'2020-07-07T15:56:03.710' AS DateTime))
INSERT [dbo].[RoleMenu] ([Id], [RoleId], [MenuId], [IsActive], [LastChanged]) VALUES (N'789fe104-5fcd-40c8-b002-8fda5c1583e4', N'2b42792d-7699-422f-b43f-4ebcb23cb9f0', N'e7c54ad1-ca47-4974-84a5-77d67158c51a', 1, CAST(N'2020-07-25T11:51:38.243' AS DateTime))
INSERT [dbo].[RoleMenu] ([Id], [RoleId], [MenuId], [IsActive], [LastChanged]) VALUES (N'281a2146-26ca-4c9e-9cbc-ab1215513e9a', N'2b42792d-7699-422f-b43f-4ebcb23cb9f0', N'e425165f-28c6-41ee-a2ab-24b84021527e', 1, CAST(N'2020-07-25T11:51:38.243' AS DateTime))
INSERT [dbo].[RoleMenu] ([Id], [RoleId], [MenuId], [IsActive], [LastChanged]) VALUES (N'285d18ae-1a1e-4068-8461-addbfab8d7be', N'a4a189e2-0b99-48ab-9542-ec526813df5d', N'7cd3ac3b-1ee3-476b-996f-52d2795ce063', 1, CAST(N'2020-07-25T11:51:33.877' AS DateTime))
INSERT [dbo].[RoleMenu] ([Id], [RoleId], [MenuId], [IsActive], [LastChanged]) VALUES (N'251a1451-5424-4e14-bd72-ba332c551214', N'a4a189e2-0b99-48ab-9542-ec526813df5d', N'316e5103-7f30-4276-a4d2-859b08a827bc', 1, CAST(N'2020-07-25T14:29:34.787' AS DateTime))
INSERT [dbo].[RoleMenu] ([Id], [RoleId], [MenuId], [IsActive], [LastChanged]) VALUES (N'255e98b7-44aa-4c18-a842-bd731f3c99cd', N'2b42792d-7699-422f-b43f-4ebcb23cb9f0', N'f1fd9ec8-3665-459e-92a8-b5c465a64d14', 1, CAST(N'2020-07-18T09:19:28.940' AS DateTime))
INSERT [dbo].[RoleMenu] ([Id], [RoleId], [MenuId], [IsActive], [LastChanged]) VALUES (N'49d2720a-e45b-4f0d-85d7-bf5757514c9e', N'2b42792d-7699-422f-b43f-4ebcb23cb9f0', N'1aa15e14-5fec-4119-a7ca-672b218a2eab', 1, CAST(N'2020-07-26T10:56:46.583' AS DateTime))
INSERT [dbo].[RoleMenu] ([Id], [RoleId], [MenuId], [IsActive], [LastChanged]) VALUES (N'5ba1cb6e-1566-4216-a6a0-c020d1c9c75a', N'a4a189e2-0b99-48ab-9542-ec526813df5d', N'f1fd9ec8-3665-459e-92a8-b5c465a64d14', 1, CAST(N'2020-07-07T15:56:03.933' AS DateTime))
INSERT [dbo].[RoleMenu] ([Id], [RoleId], [MenuId], [IsActive], [LastChanged]) VALUES (N'11e9d39b-d2b3-4a48-a5da-cfe2f1caafcb', N'2b42792d-7699-422f-b43f-4ebcb23cb9f0', N'32f23615-a6e2-42a8-86c1-6280d9b73c94', 1, CAST(N'2020-07-18T09:19:28.943' AS DateTime))
INSERT [dbo].[RoleMenu] ([Id], [RoleId], [MenuId], [IsActive], [LastChanged]) VALUES (N'966d004c-9341-4b16-9d50-d8e370e3b386', N'a4a189e2-0b99-48ab-9542-ec526813df5d', N'32f23615-a6e2-42a8-86c1-6280d9b73c94', 1, CAST(N'2020-07-07T15:56:04.157' AS DateTime))
INSERT [dbo].[RoleMenu] ([Id], [RoleId], [MenuId], [IsActive], [LastChanged]) VALUES (N'7bfffd3a-d37c-4e51-a953-e61df4dbe28a', N'2b42792d-7699-422f-b43f-4ebcb23cb9f0', N'44429eaa-ad49-42c2-9453-12c3807aa31c', 1, CAST(N'2020-07-18T09:19:28.940' AS DateTime))
INSERT [dbo].[RoleMenu] ([Id], [RoleId], [MenuId], [IsActive], [LastChanged]) VALUES (N'44863fbd-0e24-4e63-b6e5-e9610d92d672', N'2b42792d-7699-422f-b43f-4ebcb23cb9f0', N'7cd3ac3b-1ee3-476b-996f-52d2795ce063', 1, CAST(N'2020-07-25T11:51:38.243' AS DateTime))
INSERT [dbo].[RoleMenu] ([Id], [RoleId], [MenuId], [IsActive], [LastChanged]) VALUES (N'54f6ffdc-281d-4cb4-b329-eeafa4f4541c', N'a4a189e2-0b99-48ab-9542-ec526813df5d', N'44429eaa-ad49-42c2-9453-12c3807aa31c', 1, CAST(N'2020-07-07T15:56:04.007' AS DateTime))
INSERT [dbo].[RoleMenu] ([Id], [RoleId], [MenuId], [IsActive], [LastChanged]) VALUES (N'6eb3f14d-bd0d-4be0-8ca1-f057a60a2486', N'a4a189e2-0b99-48ab-9542-ec526813df5d', N'e425165f-28c6-41ee-a2ab-24b84021527e', 1, CAST(N'2020-07-25T11:51:33.877' AS DateTime))
INSERT [dbo].[RoleMenu] ([Id], [RoleId], [MenuId], [IsActive], [LastChanged]) VALUES (N'85ea0e4a-2069-4653-b9be-faa7074df07e', N'2b42792d-7699-422f-b43f-4ebcb23cb9f0', N'e7844ebb-d134-4e59-a349-8a75357a5dc0', 1, CAST(N'2020-07-26T18:47:14.557' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'6b541ff5-808d-4fe4-8604-00ae8c9df9a6', N'8ed12bb8-8439-4b2b-826d-178d74d78b23', N'159bdd1d-11e6-4c1d-a2c9-893d6d218b75', 1, CAST(N'2020-07-26T10:57:16.313' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'd4c82b1a-3844-4dbf-a065-028e48319885', N'8ed12bb8-8439-4b2b-826d-178d74d78b23', N'5af0dc03-3050-48c2-b22b-5acac4a2e749', 1, CAST(N'2020-07-26T10:57:16.313' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'a138869d-cb8c-4bbc-8ae1-02900a674567', N'25a3502b-3369-4612-b616-7577a8e98ccb', N'6c79ea64-08a6-4950-a170-5e8223f33659', 1, CAST(N'2020-07-07T15:56:42.187' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'353423ad-b41c-4fe6-8386-071c39a1ae39', N'6eb3f14d-bd0d-4be0-8ca1-f057a60a2486', N'3205ad4d-e119-4380-92af-ab57f70a03c6', 1, CAST(N'2020-07-25T11:52:01.677' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'f4279d0a-4cd6-48c5-9bf3-0a34636f3647', N'6eb3f14d-bd0d-4be0-8ca1-f057a60a2486', N'159bdd1d-11e6-4c1d-a2c9-893d6d218b75', 1, CAST(N'2020-07-25T11:52:01.680' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'e6ea5bdb-8d37-45e2-969d-0c6f2c3884c2', N'11e9d39b-d2b3-4a48-a5da-cfe2f1caafcb', N'3205ad4d-e119-4380-92af-ab57f70a03c6', 1, CAST(N'2020-07-18T09:19:55.620' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'36f89c42-274e-4138-baa2-0e1f8737eafe', N'251a1451-5424-4e14-bd72-ba332c551214', N'3205ad4d-e119-4380-92af-ab57f70a03c6', 1, CAST(N'2020-07-25T14:30:17.743' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'a3da9fc7-333e-4350-82a1-103390edf6f4', N'54f6ffdc-281d-4cb4-b329-eeafa4f4541c', N'6c79ea64-08a6-4950-a170-5e8223f33659', 1, CAST(N'2020-07-07T15:56:41.640' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'36a89d43-342f-4e5b-b480-14fe59491cad', N'13f1c5b3-7693-4cd1-a663-043a3beb970e', N'159bdd1d-11e6-4c1d-a2c9-893d6d218b75', 1, CAST(N'2020-07-26T18:47:33.013' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'2219b9be-fb23-4aa1-a5b3-1789b70ac623', N'fa049931-2991-4610-a73a-390c38300b27', N'3205ad4d-e119-4380-92af-ab57f70a03c6', 1, CAST(N'2020-07-18T09:17:59.007' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'95d3174e-a633-4437-bfe0-1b2a60d77c84', N'54f6ffdc-281d-4cb4-b329-eeafa4f4541c', N'159bdd1d-11e6-4c1d-a2c9-893d6d218b75', 1, CAST(N'2020-07-07T15:56:41.493' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'f4067e8f-7dfb-4b61-949c-1bf7cc0ee477', N'4357a2a4-9128-49dd-b330-2b29a260957a', N'159bdd1d-11e6-4c1d-a2c9-893d6d218b75', 1, CAST(N'2020-07-25T18:10:22.880' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'1fccf544-b9bc-4e11-b8f5-1c6889498281', N'636df545-9df1-4cef-b69c-6c6a013a9ae0', N'159bdd1d-11e6-4c1d-a2c9-893d6d218b75', 1, CAST(N'2020-07-07T15:56:41.110' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'594fa7b3-27e1-423b-bce0-23264277ec3e', N'3e00592f-fd55-4b5b-97a5-24fe512e9f32', N'3205ad4d-e119-4380-92af-ab57f70a03c6', 1, CAST(N'2020-07-25T18:10:30.470' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'e05a77ab-f06f-4aec-be5d-265474b72a1a', N'636df545-9df1-4cef-b69c-6c6a013a9ae0', N'5af0dc03-3050-48c2-b22b-5acac4a2e749', 1, CAST(N'2020-07-07T15:56:41.030' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'b16d71a4-7095-41ec-9851-2bd68b517a58', N'7bfffd3a-d37c-4e51-a953-e61df4dbe28a', N'6c79ea64-08a6-4950-a170-5e8223f33659', 1, CAST(N'2020-07-18T09:19:55.620' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'041cb1c7-9107-4e02-9be2-2d7b84f3bd8b', N'54f6ffdc-281d-4cb4-b329-eeafa4f4541c', N'3205ad4d-e119-4380-92af-ab57f70a03c6', 1, CAST(N'2020-07-07T15:56:41.417' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'801acb31-a2ca-441d-bf76-2fb2e5082524', N'251a1451-5424-4e14-bd72-ba332c551214', N'6c79ea64-08a6-4950-a170-5e8223f33659', 1, CAST(N'2020-07-25T14:30:17.743' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'fed0fe8e-a571-4443-b5c1-30f4621e0152', N'3e00592f-fd55-4b5b-97a5-24fe512e9f32', N'159bdd1d-11e6-4c1d-a2c9-893d6d218b75', 1, CAST(N'2020-07-25T18:10:30.470' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'33d4debf-4464-4173-bc99-3f67e4c8421f', N'7ba345c6-ad71-40c8-a50f-339ca5c24b1d', N'6c79ea64-08a6-4950-a170-5e8223f33659', 1, CAST(N'2020-07-18T09:19:55.613' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'1eeffec5-5a33-484e-a0ac-443ef41b22f0', N'281a2146-26ca-4c9e-9cbc-ab1215513e9a', N'6c79ea64-08a6-4950-a170-5e8223f33659', 1, CAST(N'2020-07-25T11:51:54.237' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'340a9081-4df2-45bd-9d3b-4720a4a605e8', N'35136bb4-a862-4842-ac1e-1ab0ba0f7924', N'159bdd1d-11e6-4c1d-a2c9-893d6d218b75', 1, CAST(N'2020-07-18T09:19:55.627' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'72771279-38b0-4517-a75f-47975a3e388e', N'251a1451-5424-4e14-bd72-ba332c551214', N'5af0dc03-3050-48c2-b22b-5acac4a2e749', 1, CAST(N'2020-07-25T14:30:17.740' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'2bdda9d4-4dc1-4ce2-bb33-48c5b426f6c4', N'966d004c-9341-4b16-9d50-d8e370e3b386', N'159bdd1d-11e6-4c1d-a2c9-893d6d218b75', 1, CAST(N'2020-07-07T15:56:41.950' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'b3431a06-e8a3-4f3a-b95b-4984a2c1a349', N'35136bb4-a862-4842-ac1e-1ab0ba0f7924', N'3205ad4d-e119-4380-92af-ab57f70a03c6', 1, CAST(N'2020-07-18T09:19:55.627' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'd44f9327-4cdf-4871-afe9-4b08c5379c85', N'25a3502b-3369-4612-b616-7577a8e98ccb', N'5af0dc03-3050-48c2-b22b-5acac4a2e749', 1, CAST(N'2020-07-07T15:56:42.413' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'f8f3af35-0549-4ec7-a58d-4bb3ebf61bae', N'25a3502b-3369-4612-b616-7577a8e98ccb', N'159bdd1d-11e6-4c1d-a2c9-893d6d218b75', 1, CAST(N'2020-07-07T15:56:42.340' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'77a94418-580a-4c7e-8110-4bdfb3dccd4a', N'7ba345c6-ad71-40c8-a50f-339ca5c24b1d', N'5af0dc03-3050-48c2-b22b-5acac4a2e749', 1, CAST(N'2020-07-18T09:19:55.590' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'32f0480a-4ce2-484a-bbb5-4f8220f746ab', N'8ed12bb8-8439-4b2b-826d-178d74d78b23', N'6c79ea64-08a6-4950-a170-5e8223f33659', 1, CAST(N'2020-07-26T10:57:16.313' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'a0253e49-f8a0-4b57-bda8-53571a325c34', N'fa049931-2991-4610-a73a-390c38300b27', N'159bdd1d-11e6-4c1d-a2c9-893d6d218b75', 1, CAST(N'2020-07-18T09:17:59.010' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'64fc3a30-9a35-4474-8cc4-558ee4fa465c', N'25a3502b-3369-4612-b616-7577a8e98ccb', N'3205ad4d-e119-4380-92af-ab57f70a03c6', 1, CAST(N'2020-07-07T15:56:42.487' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'7da0b29f-1159-4e45-bc0d-5729eb13eae9', N'8ed12bb8-8439-4b2b-826d-178d74d78b23', N'3205ad4d-e119-4380-92af-ab57f70a03c6', 1, CAST(N'2020-07-26T10:57:16.313' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'729c79dd-f361-416d-80fd-572afe0cf077', N'251a1451-5424-4e14-bd72-ba332c551214', N'159bdd1d-11e6-4c1d-a2c9-893d6d218b75', 1, CAST(N'2020-07-25T14:30:17.743' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'f2d404f0-43f1-4dda-ab46-57c9ba326ff1', N'7bfffd3a-d37c-4e51-a953-e61df4dbe28a', N'3205ad4d-e119-4380-92af-ab57f70a03c6', 1, CAST(N'2020-07-18T09:19:55.617' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'422cdf87-84ae-426d-ad3e-59c18c598de3', N'9c8fa079-5f4a-45a6-a362-8f1b03fed190', N'159bdd1d-11e6-4c1d-a2c9-893d6d218b75', 1, CAST(N'2020-07-07T15:56:42.113' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'3915b31c-92a9-42bd-ac00-61e9424b5acb', N'4357a2a4-9128-49dd-b330-2b29a260957a', N'6c79ea64-08a6-4950-a170-5e8223f33659', 0, CAST(N'2020-07-25T18:10:22.880' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'5943c489-48f5-498c-8465-631c7cf5beef', N'3e00592f-fd55-4b5b-97a5-24fe512e9f32', N'5af0dc03-3050-48c2-b22b-5acac4a2e749', 0, CAST(N'2020-07-25T18:10:30.470' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'c37cee9a-9477-4cda-8994-646eafaece96', N'7ba345c6-ad71-40c8-a50f-339ca5c24b1d', N'3205ad4d-e119-4380-92af-ab57f70a03c6', 1, CAST(N'2020-07-18T09:19:55.617' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'7292dce8-9c7c-48b2-bda2-68be08979b78', N'281a2146-26ca-4c9e-9cbc-ab1215513e9a', N'3205ad4d-e119-4380-92af-ab57f70a03c6', 1, CAST(N'2020-07-25T11:51:54.230' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'5b2edb77-90b5-4f9e-816d-6f71d182a688', N'7bfffd3a-d37c-4e51-a953-e61df4dbe28a', N'159bdd1d-11e6-4c1d-a2c9-893d6d218b75', 1, CAST(N'2020-07-18T09:19:55.617' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'c6d6c515-508e-40c6-8eec-70d6fa33f1e2', N'7ba345c6-ad71-40c8-a50f-339ca5c24b1d', N'159bdd1d-11e6-4c1d-a2c9-893d6d218b75', 1, CAST(N'2020-07-18T09:19:55.613' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'6008fdd1-f081-4783-a290-711cdcb88759', N'3e00592f-fd55-4b5b-97a5-24fe512e9f32', N'5af0dc03-3050-48c2-b22b-5acac4a2e749', 1, CAST(N'2020-07-25T18:36:16.033' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'367ee4aa-fc88-4800-8fba-7a2f9b6b87a9', N'fa049931-2991-4610-a73a-390c38300b27', N'5af0dc03-3050-48c2-b22b-5acac4a2e749', 1, CAST(N'2020-07-18T09:17:59.010' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'9c8fca2b-aa56-4fcf-aef5-7aab181dcd1f', N'd0a2caa9-4107-4d6d-8ded-2beee7dedd39', N'5af0dc03-3050-48c2-b22b-5acac4a2e749', 1, CAST(N'2020-07-25T14:30:02.057' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'2f4676dc-bc08-491e-8a6d-8254046d4e60', N'd3673f19-3301-4099-ab5a-89f4f7222031', N'159bdd1d-11e6-4c1d-a2c9-893d6d218b75', 1, CAST(N'2020-07-18T09:19:55.620' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'a848e102-f1cc-4420-8942-8636810a9c37', N'35136bb4-a862-4842-ac1e-1ab0ba0f7924', N'5af0dc03-3050-48c2-b22b-5acac4a2e749', 1, CAST(N'2020-07-18T09:19:55.627' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'0e622b1f-718c-4dc5-b447-86f5bd4ec2a5', N'49d2720a-e45b-4f0d-85d7-bf5757514c9e', N'3205ad4d-e119-4380-92af-ab57f70a03c6', 1, CAST(N'2020-07-26T10:57:04.803' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'3bf318a3-7fbd-487f-99f6-889b56c45725', N'966d004c-9341-4b16-9d50-d8e370e3b386', N'6c79ea64-08a6-4950-a170-5e8223f33659', 1, CAST(N'2020-07-07T15:56:41.790' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'e83607aa-18c8-4b7c-9b40-892d05d2277f', N'14adb415-dee7-4da7-b356-8a5d06c45cbe', N'159bdd1d-11e6-4c1d-a2c9-893d6d218b75', 1, CAST(N'2020-07-18T09:19:55.627' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'd3d1ddf5-f162-4f8d-abeb-8aefc0836cf5', N'7bfffd3a-d37c-4e51-a953-e61df4dbe28a', N'5af0dc03-3050-48c2-b22b-5acac4a2e749', 1, CAST(N'2020-07-18T09:19:55.617' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'ab44a63b-6ccf-438d-9ca3-95d57b1012ad', N'82e8a657-9986-47f9-99d8-56f157c49f67', N'5af0dc03-3050-48c2-b22b-5acac4a2e749', 1, CAST(N'2020-07-18T09:19:55.623' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'c70aff00-f93b-4db5-9b7d-9d6b0c11950f', N'fa049931-2991-4610-a73a-390c38300b27', N'6c79ea64-08a6-4950-a170-5e8223f33659', 1, CAST(N'2020-07-18T09:17:59.010' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'e5d94234-8691-46c8-990a-a5c6a071a766', N'49d2720a-e45b-4f0d-85d7-bf5757514c9e', N'159bdd1d-11e6-4c1d-a2c9-893d6d218b75', 1, CAST(N'2020-07-26T10:57:04.803' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'619faa42-cd09-41bf-96bf-a6043143349d', N'636df545-9df1-4cef-b69c-6c6a013a9ae0', N'3205ad4d-e119-4380-92af-ab57f70a03c6', 1, CAST(N'2020-07-07T15:56:41.343' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'8bb1fe58-8048-4bd9-8205-a9113165ca67', N'4357a2a4-9128-49dd-b330-2b29a260957a', N'5af0dc03-3050-48c2-b22b-5acac4a2e749', 0, CAST(N'2020-07-25T18:10:22.880' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'd62198e6-9337-4a3a-b683-aeaf7b13a83c', N'54f6ffdc-281d-4cb4-b329-eeafa4f4541c', N'5af0dc03-3050-48c2-b22b-5acac4a2e749', 1, CAST(N'2020-07-07T15:56:41.567' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'cbb5c2b2-1975-4f16-ba52-b6e7e3b90200', N'11e9d39b-d2b3-4a48-a5da-cfe2f1caafcb', N'159bdd1d-11e6-4c1d-a2c9-893d6d218b75', 1, CAST(N'2020-07-18T09:19:55.620' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'484ee8c3-0d45-47ae-bab0-b9fa7a1ab739', N'966d004c-9341-4b16-9d50-d8e370e3b386', N'3205ad4d-e119-4380-92af-ab57f70a03c6', 1, CAST(N'2020-07-07T15:56:41.717' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'1bb76635-70fa-4be1-86ec-bb6ccfc3e31a', N'49d2720a-e45b-4f0d-85d7-bf5757514c9e', N'5af0dc03-3050-48c2-b22b-5acac4a2e749', 1, CAST(N'2020-07-26T10:57:04.803' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'027f82f6-9b12-4649-8d58-c1bd8a25a579', N'82e8a657-9986-47f9-99d8-56f157c49f67', N'6c79ea64-08a6-4950-a170-5e8223f33659', 1, CAST(N'2020-07-18T09:19:55.623' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'7c73a99d-e305-40b0-adc3-c73d5bdd2e0c', N'35136bb4-a862-4842-ac1e-1ab0ba0f7924', N'6c79ea64-08a6-4950-a170-5e8223f33659', 1, CAST(N'2020-07-18T09:19:55.623' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'8e21e3ff-32cb-493b-b35b-c811201deeca', N'11e9d39b-d2b3-4a48-a5da-cfe2f1caafcb', N'6c79ea64-08a6-4950-a170-5e8223f33659', 1, CAST(N'2020-07-18T09:19:55.620' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'bf50d78b-3c53-443b-bf05-cb7f7927866b', N'6eb3f14d-bd0d-4be0-8ca1-f057a60a2486', N'6c79ea64-08a6-4950-a170-5e8223f33659', 1, CAST(N'2020-07-25T11:52:01.677' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'7f7625d4-65e7-42ae-b55d-ccadf0d56bee', N'd0a2caa9-4107-4d6d-8ded-2beee7dedd39', N'3205ad4d-e119-4380-92af-ab57f70a03c6', 1, CAST(N'2020-07-25T14:30:02.097' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'069d0a4f-716c-419d-9de8-cf3eab27503c', N'4357a2a4-9128-49dd-b330-2b29a260957a', N'3205ad4d-e119-4380-92af-ab57f70a03c6', 0, CAST(N'2020-07-25T18:10:22.883' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'db497951-e340-4fbe-b326-d1ba4568d8d0', N'49d2720a-e45b-4f0d-85d7-bf5757514c9e', N'6c79ea64-08a6-4950-a170-5e8223f33659', 1, CAST(N'2020-07-26T10:57:04.800' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'e1fc524b-bc24-4f94-bbda-db6813fe3fc0', N'd0a2caa9-4107-4d6d-8ded-2beee7dedd39', N'6c79ea64-08a6-4950-a170-5e8223f33659', 1, CAST(N'2020-07-25T14:30:02.067' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'ba3be09a-553f-4e3e-94d9-dd36c084c7d1', N'966d004c-9341-4b16-9d50-d8e370e3b386', N'5af0dc03-3050-48c2-b22b-5acac4a2e749', 1, CAST(N'2020-07-07T15:56:42.030' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'21dcb2ae-3396-46e4-9c30-dd9db87427bb', N'281a2146-26ca-4c9e-9cbc-ab1215513e9a', N'159bdd1d-11e6-4c1d-a2c9-893d6d218b75', 1, CAST(N'2020-07-25T11:51:54.243' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'7ac71556-b320-4ead-8bec-e129d5335ae8', N'636df545-9df1-4cef-b69c-6c6a013a9ae0', N'6c79ea64-08a6-4950-a170-5e8223f33659', 1, CAST(N'2020-07-07T15:56:41.270' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'6c7588c7-074f-40ca-8d6e-e1b48b450041', N'11e9d39b-d2b3-4a48-a5da-cfe2f1caafcb', N'5af0dc03-3050-48c2-b22b-5acac4a2e749', 1, CAST(N'2020-07-18T09:19:55.620' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'30ad17ad-cc48-40f2-ab48-e489b9295f74', N'6eb3f14d-bd0d-4be0-8ca1-f057a60a2486', N'5af0dc03-3050-48c2-b22b-5acac4a2e749', 1, CAST(N'2020-07-25T11:52:01.680' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'1d2e7ecc-cc8b-494d-9b1d-ec01d214092a', N'b636e5a4-93d0-475e-bacd-046e7640086c', N'159bdd1d-11e6-4c1d-a2c9-893d6d218b75', 1, CAST(N'2020-07-18T01:05:07.743' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'eb96a21b-4051-465c-afd9-ec66252d8aaf', N'82e8a657-9986-47f9-99d8-56f157c49f67', N'3205ad4d-e119-4380-92af-ab57f70a03c6', 1, CAST(N'2020-07-18T09:19:55.620' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'a8f6bf23-cee8-48ab-ad93-f364d4d012e0', N'281a2146-26ca-4c9e-9cbc-ab1215513e9a', N'5af0dc03-3050-48c2-b22b-5acac4a2e749', 1, CAST(N'2020-07-25T11:51:54.240' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'ff843800-e754-423d-a592-f3ab66aeb9cc', N'3e00592f-fd55-4b5b-97a5-24fe512e9f32', N'6c79ea64-08a6-4950-a170-5e8223f33659', 1, CAST(N'2020-07-25T18:10:30.470' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'6ab2f2a4-512a-476b-a7e7-f68cc865b3f5', N'd0a2caa9-4107-4d6d-8ded-2beee7dedd39', N'159bdd1d-11e6-4c1d-a2c9-893d6d218b75', 1, CAST(N'2020-07-25T14:30:02.093' AS DateTime))
INSERT [dbo].[RoleMenuPrivilege] ([Id], [RoleMenuId], [PrivilegeId], [IsActive], [LastChanged]) VALUES (N'4a66f56b-7129-4a99-9e60-f7bfcbfd209c', N'82e8a657-9986-47f9-99d8-56f157c49f67', N'159bdd1d-11e6-4c1d-a2c9-893d6d218b75', 1, CAST(N'2020-07-18T09:19:55.623' AS DateTime))
INSERT [dbo].[State] ([Id], [CountryId], [Name], [IsActive], [LastChanged]) VALUES (N'0f7402eb-1147-4619-bbd2-0a3cb457b9bd', N'8d5d7dda-f055-48c4-a196-074fb35ff105', N'Maharashtra', 1, CAST(N'2020-07-25T14:47:44.930' AS DateTime))
INSERT [dbo].[UserRole] ([Id], [ApplicationUserId], [RoleId], [IsActive], [LastChanged]) VALUES (N'9a326ef2-20c7-45a8-aa79-2c4801a7a8f5', N'21c1d269-175d-4197-873d-c64e3ee6a1ba', N'2b42792d-7699-422f-b43f-4ebcb23cb9f0', 1, CAST(N'2020-07-18T11:07:40.127' AS DateTime))
INSERT [dbo].[UserRole] ([Id], [ApplicationUserId], [RoleId], [IsActive], [LastChanged]) VALUES (N'797330c2-43f5-449d-8e3f-3ab8c38cd2c8', N'f957fb00-b569-4e4c-9eb7-c9a7f73961ee', N'a4a189e2-0b99-48ab-9542-ec526813df5d', 1, CAST(N'2020-07-07T15:08:12.177' AS DateTime))
ALTER TABLE [dbo].[Address] ADD  CONSTRAINT [DF_Address_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Address] ADD  CONSTRAINT [DF_Address_LastChanged]  DEFAULT (getdate()) FOR [LastChanged]
GO
ALTER TABLE [dbo].[ApplicationUser] ADD  CONSTRAINT [DF_ApplicationUser_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[ApplicationUser] ADD  CONSTRAINT [DF_ApplicationUser_DoctorId]  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [DoctorId]
GO
ALTER TABLE [dbo].[ApplicationUser] ADD  CONSTRAINT [DF_ApplicationUser_LastChanged]  DEFAULT (getdate()) FOR [LastChanged]
GO
ALTER TABLE [dbo].[City] ADD  CONSTRAINT [DF_City_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[City] ADD  CONSTRAINT [DF_City_LastChanged]  DEFAULT (getdate()) FOR [LastChanged]
GO
ALTER TABLE [dbo].[Country] ADD  CONSTRAINT [DF_Country_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Country] ADD  CONSTRAINT [DF_Country_LastChanged]  DEFAULT (getdate()) FOR [LastChanged]
GO
ALTER TABLE [dbo].[Department] ADD  CONSTRAINT [DF_Department_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Department] ADD  CONSTRAINT [DF_Department_LastChanged]  DEFAULT (getdate()) FOR [LastChanged]
GO
ALTER TABLE [dbo].[Doctor] ADD  CONSTRAINT [DF_Doctor_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Doctor] ADD  CONSTRAINT [DF_Doctor_LastChanged]  DEFAULT (getdate()) FOR [LastChanged]
GO
ALTER TABLE [dbo].[DoctorDepartment] ADD  CONSTRAINT [DF_DoctorDepartment_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[DoctorDepartment] ADD  CONSTRAINT [DF_DoctorDepartment_LastChanged]  DEFAULT (getdate()) FOR [LastChanged]
GO
ALTER TABLE [dbo].[DoctorIdentity] ADD  CONSTRAINT [DF_DoctorIdentity_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[DoctorIdentity] ADD  CONSTRAINT [DF_DoctorIdentity_LastChanged]  DEFAULT (getdate()) FOR [LastChanged]
GO
ALTER TABLE [dbo].[DoctorQualification] ADD  CONSTRAINT [DF_DoctorQualification_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[DoctorQualification] ADD  CONSTRAINT [DF_DoctorQualification_LastChanged]  DEFAULT (getdate()) FOR [LastChanged]
GO
ALTER TABLE [dbo].[Gender] ADD  CONSTRAINT [DF_Gender_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Gender] ADD  CONSTRAINT [DF_Gender_LastChanged]  DEFAULT (getdate()) FOR [LastChanged]
GO
ALTER TABLE [dbo].[IdentityType] ADD  CONSTRAINT [DF_IdentityType_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[IdentityType] ADD  CONSTRAINT [DF_IdentityType_LastChanged]  DEFAULT (getdate()) FOR [LastChanged]
GO
ALTER TABLE [dbo].[InternalChat] ADD  CONSTRAINT [DF_InternalChat_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[InternalChat] ADD  CONSTRAINT [DF_InternalChat_DateTime]  DEFAULT (getdate()) FOR [DateTime]
GO
ALTER TABLE [dbo].[InternalChat] ADD  CONSTRAINT [DF_InternalChat_LastChanged]  DEFAULT (getdate()) FOR [LastChanged]
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
ALTER TABLE [dbo].[State] ADD  CONSTRAINT [DF_State_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[State] ADD  CONSTRAINT [DF_State_LastChanged]  DEFAULT (getdate()) FOR [LastChanged]
GO
ALTER TABLE [dbo].[UserRole] ADD  CONSTRAINT [DF_UserRole_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[UserRole] ADD  CONSTRAINT [DF_UserRole_LastChanged]  DEFAULT (getdate()) FOR [LastChanged]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_City] FOREIGN KEY([CityId])
REFERENCES [dbo].[City] ([Id])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_City]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_Country] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Id])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_Country]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_State] FOREIGN KEY([StateId])
REFERENCES [dbo].[State] ([Id])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_State]
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
ALTER TABLE [dbo].[City]  WITH CHECK ADD  CONSTRAINT [FK_City_Country] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Id])
GO
ALTER TABLE [dbo].[City] CHECK CONSTRAINT [FK_City_Country]
GO
ALTER TABLE [dbo].[City]  WITH CHECK ADD  CONSTRAINT [FK_City_State] FOREIGN KEY([StateId])
REFERENCES [dbo].[State] ([Id])
GO
ALTER TABLE [dbo].[City] CHECK CONSTRAINT [FK_City_State]
GO
ALTER TABLE [dbo].[Doctor]  WITH CHECK ADD  CONSTRAINT [FK_Doctor_Address] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Address] ([Id])
GO
ALTER TABLE [dbo].[Doctor] CHECK CONSTRAINT [FK_Doctor_Address]
GO
ALTER TABLE [dbo].[Doctor]  WITH CHECK ADD  CONSTRAINT [FK_Doctor_ApplicationUser] FOREIGN KEY([ApplicationUserId])
REFERENCES [dbo].[ApplicationUser] ([Id])
GO
ALTER TABLE [dbo].[Doctor] CHECK CONSTRAINT [FK_Doctor_ApplicationUser]
GO
ALTER TABLE [dbo].[Doctor]  WITH CHECK ADD  CONSTRAINT [FK_Doctor_Gender] FOREIGN KEY([GenderId])
REFERENCES [dbo].[Gender] ([Id])
GO
ALTER TABLE [dbo].[Doctor] CHECK CONSTRAINT [FK_Doctor_Gender]
GO
ALTER TABLE [dbo].[DoctorDepartment]  WITH CHECK ADD  CONSTRAINT [FK_DoctorDepartment_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[DoctorDepartment] CHECK CONSTRAINT [FK_DoctorDepartment_Department]
GO
ALTER TABLE [dbo].[DoctorDepartment]  WITH CHECK ADD  CONSTRAINT [FK_DoctorDepartment_Doctor] FOREIGN KEY([DoctorId])
REFERENCES [dbo].[Doctor] ([Id])
GO
ALTER TABLE [dbo].[DoctorDepartment] CHECK CONSTRAINT [FK_DoctorDepartment_Doctor]
GO
ALTER TABLE [dbo].[DoctorIdentity]  WITH CHECK ADD  CONSTRAINT [FK_DoctorIdentity_Doctor] FOREIGN KEY([DoctorId])
REFERENCES [dbo].[Doctor] ([Id])
GO
ALTER TABLE [dbo].[DoctorIdentity] CHECK CONSTRAINT [FK_DoctorIdentity_Doctor]
GO
ALTER TABLE [dbo].[DoctorIdentity]  WITH CHECK ADD  CONSTRAINT [FK_DoctorIdentity_IdentityType] FOREIGN KEY([IdentityTypeId])
REFERENCES [dbo].[IdentityType] ([Id])
GO
ALTER TABLE [dbo].[DoctorIdentity] CHECK CONSTRAINT [FK_DoctorIdentity_IdentityType]
GO
ALTER TABLE [dbo].[DoctorQualification]  WITH CHECK ADD  CONSTRAINT [FK_DoctorQualification_Doctor] FOREIGN KEY([DoctorId])
REFERENCES [dbo].[Doctor] ([Id])
GO
ALTER TABLE [dbo].[DoctorQualification] CHECK CONSTRAINT [FK_DoctorQualification_Doctor]
GO
ALTER TABLE [dbo].[InternalChat]  WITH CHECK ADD  CONSTRAINT [FK_InternalChat_ApplicationUser] FOREIGN KEY([ApplicationUserId])
REFERENCES [dbo].[ApplicationUser] ([Id])
GO
ALTER TABLE [dbo].[InternalChat] CHECK CONSTRAINT [FK_InternalChat_ApplicationUser]
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
ALTER TABLE [dbo].[State]  WITH CHECK ADD  CONSTRAINT [FK_State_Country] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Id])
GO
ALTER TABLE [dbo].[State] CHECK CONSTRAINT [FK_State_Country]
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
