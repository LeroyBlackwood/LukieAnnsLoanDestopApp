USE [master]
GO
/****** Object:  Database [LukieAnnsLoans_db]    Script Date: 3/20/2024 2:58:41 PM ******/
CREATE DATABASE [LukieAnnsLoans_db]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LukieAnnsLoans_db', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\LukieAnnsLoans_db.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LukieAnnsLoans_db_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\LukieAnnsLoans_db_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [LukieAnnsLoans_db] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LukieAnnsLoans_db].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LukieAnnsLoans_db] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LukieAnnsLoans_db] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LukieAnnsLoans_db] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LukieAnnsLoans_db] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LukieAnnsLoans_db] SET ARITHABORT OFF 
GO
ALTER DATABASE [LukieAnnsLoans_db] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [LukieAnnsLoans_db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LukieAnnsLoans_db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LukieAnnsLoans_db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LukieAnnsLoans_db] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LukieAnnsLoans_db] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LukieAnnsLoans_db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LukieAnnsLoans_db] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LukieAnnsLoans_db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LukieAnnsLoans_db] SET  ENABLE_BROKER 
GO
ALTER DATABASE [LukieAnnsLoans_db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LukieAnnsLoans_db] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LukieAnnsLoans_db] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LukieAnnsLoans_db] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LukieAnnsLoans_db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LukieAnnsLoans_db] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LukieAnnsLoans_db] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LukieAnnsLoans_db] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [LukieAnnsLoans_db] SET  MULTI_USER 
GO
ALTER DATABASE [LukieAnnsLoans_db] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LukieAnnsLoans_db] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LukieAnnsLoans_db] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LukieAnnsLoans_db] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LukieAnnsLoans_db] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [LukieAnnsLoans_db] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [LukieAnnsLoans_db] SET QUERY_STORE = ON
GO
ALTER DATABASE [LukieAnnsLoans_db] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [LukieAnnsLoans_db]
GO
/****** Object:  Table [dbo].[LoanInterest]    Script Date: 3/20/2024 2:58:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoanInterest](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Rate] [decimal](18, 2) NULL,
 CONSTRAINT [PK__LoanInte__3214EC07ECB3A926] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[loanIssueance]    Script Date: 3/20/2024 2:58:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[loanIssueance](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LoanRequest_Id] [int] NULL,
	[LoanAmount] [decimal](18, 2) NULL,
	[MonthlyPayment] [decimal](18, 2) NULL,
	[Total] [decimal](18, 2) NULL,
	[status] [nvarchar](50) NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL,
 CONSTRAINT [PK_loanIssueance_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoanRequest_Linker]    Script Date: 3/20/2024 2:58:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoanRequest_Linker](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Customer_Id] [int] NULL,
	[LoanType_Id] [int] NULL,
	[LoanTerm_Id] [int] NULL,
 CONSTRAINT [PK_LoanTermLinkTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoanTerm]    Script Date: 3/20/2024 2:58:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoanTerm](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Term] [decimal](18, 2) NULL,
 CONSTRAINT [PK__LoanTerm__3214EC07A9412FC2] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoanType]    Script Date: 3/20/2024 2:58:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoanType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](100) NULL,
	[LoanInterest_Id] [int] NULL,
 CONSTRAINT [PK__LoanType__3214EC07DD2AE135] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Login_DateTimeTable]    Script Date: 3/20/2024 2:58:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login_DateTimeTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login_ID] [int] NULL,
	[Login_DateTime] [datetime] NULL,
	[Logout_DateTime] [datetime] NULL,
 CONSTRAINT [PK_Login_DateTimeTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[personnel_LogIn]    Script Date: 3/20/2024 2:58:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[personnel_LogIn](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](100) NULL,
	[Personel_ID] [int] NULL,
	[isActive] [bit] NULL,
 CONSTRAINT [PK__LogIn__3214EC27B5823C87] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ__LogIn__87909B15F2FF9ED4] UNIQUE NONCLUSTERED 
(
	[Password] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personnel_Login_LinkerTable]    Script Date: 3/20/2024 2:58:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personnel_Login_LinkerTable](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[personnel_Role_ID] [int] NULL,
	[Personnel_ID] [int] NULL,
 CONSTRAINT [PK_LogIn_UserLinkerTalbe] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personnel_Table]    Script Date: 3/20/2024 2:58:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personnel_Table](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[MiddleName] [nvarchar](50) NULL,
	[Address] [nvarchar](500) NULL,
	[emailAddress] [nvarchar](100) NULL,
	[Telephone] [bigint] NULL,
 CONSTRAINT [PK_Customer_Table] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonnelRoleTable]    Script Date: 3/20/2024 2:58:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonnelRoleTable](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[personnelRole] [nvarchar](50) NULL,
	[roleShortName] [nvarchar](50) NULL,
 CONSTRAINT [PK_UserTable] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Repayment]    Script Date: 3/20/2024 2:58:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Repayment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[loanIssuance_Id] [int] NULL,
	[Amount] [decimal](18, 2) NULL,
	[totalRepayment] [decimal](18, 2) NULL,
	[balance] [decimal](18, 2) NULL,
	[PaymentDate] [date] NULL,
 CONSTRAINT [PK_Repayment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[loanIssueance]  WITH CHECK ADD  CONSTRAINT [FK_loanIssueance_CusLoanRequest_Linker] FOREIGN KEY([LoanRequest_Id])
REFERENCES [dbo].[LoanRequest_Linker] ([Id])
GO
ALTER TABLE [dbo].[loanIssueance] CHECK CONSTRAINT [FK_loanIssueance_CusLoanRequest_Linker]
GO
ALTER TABLE [dbo].[LoanRequest_Linker]  WITH CHECK ADD  CONSTRAINT [FK_LoanTermLinkTable_Customer_Table] FOREIGN KEY([Customer_Id])
REFERENCES [dbo].[Personnel_Table] ([id])
GO
ALTER TABLE [dbo].[LoanRequest_Linker] CHECK CONSTRAINT [FK_LoanTermLinkTable_Customer_Table]
GO
ALTER TABLE [dbo].[LoanRequest_Linker]  WITH CHECK ADD  CONSTRAINT [FK_LoanTermLinkTable_LoanTerm] FOREIGN KEY([LoanTerm_Id])
REFERENCES [dbo].[LoanTerm] ([Id])
GO
ALTER TABLE [dbo].[LoanRequest_Linker] CHECK CONSTRAINT [FK_LoanTermLinkTable_LoanTerm]
GO
ALTER TABLE [dbo].[LoanRequest_Linker]  WITH CHECK ADD  CONSTRAINT [FK_LoanTermLinkTable_LoanType] FOREIGN KEY([LoanType_Id])
REFERENCES [dbo].[LoanType] ([Id])
GO
ALTER TABLE [dbo].[LoanRequest_Linker] CHECK CONSTRAINT [FK_LoanTermLinkTable_LoanType]
GO
ALTER TABLE [dbo].[LoanType]  WITH CHECK ADD  CONSTRAINT [FK_LoanType_LoanInterest] FOREIGN KEY([LoanInterest_Id])
REFERENCES [dbo].[LoanInterest] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LoanType] CHECK CONSTRAINT [FK_LoanType_LoanInterest]
GO
ALTER TABLE [dbo].[Login_DateTimeTable]  WITH NOCHECK ADD  CONSTRAINT [FK_Login_DateTimeTable_LogIn] FOREIGN KEY([Login_ID])
REFERENCES [dbo].[personnel_LogIn] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[Login_DateTimeTable] CHECK CONSTRAINT [FK_Login_DateTimeTable_LogIn]
GO
ALTER TABLE [dbo].[personnel_LogIn]  WITH CHECK ADD  CONSTRAINT [FK_personnel_LogIn_Personnel_Table] FOREIGN KEY([Personel_ID])
REFERENCES [dbo].[Personnel_Table] ([id])
GO
ALTER TABLE [dbo].[personnel_LogIn] CHECK CONSTRAINT [FK_personnel_LogIn_Personnel_Table]
GO
ALTER TABLE [dbo].[Personnel_Login_LinkerTable]  WITH CHECK ADD  CONSTRAINT [FK_LogIn_UserLinkerTalbe_UserTable] FOREIGN KEY([personnel_Role_ID])
REFERENCES [dbo].[PersonnelRoleTable] ([id])
GO
ALTER TABLE [dbo].[Personnel_Login_LinkerTable] CHECK CONSTRAINT [FK_LogIn_UserLinkerTalbe_UserTable]
GO
ALTER TABLE [dbo].[Personnel_Login_LinkerTable]  WITH CHECK ADD  CONSTRAINT [FK_Personnel_Login_LinkerTable_Personnel_Table] FOREIGN KEY([Personnel_ID])
REFERENCES [dbo].[Personnel_Table] ([id])
GO
ALTER TABLE [dbo].[Personnel_Login_LinkerTable] CHECK CONSTRAINT [FK_Personnel_Login_LinkerTable_Personnel_Table]
GO
ALTER TABLE [dbo].[Repayment]  WITH CHECK ADD  CONSTRAINT [FK_Repayment_loanIssueance] FOREIGN KEY([loanIssuance_Id])
REFERENCES [dbo].[loanIssueance] ([Id])
GO
ALTER TABLE [dbo].[Repayment] CHECK CONSTRAINT [FK_Repayment_loanIssueance]
GO
USE [master]
GO
ALTER DATABASE [LukieAnnsLoans_db] SET  READ_WRITE 
GO
