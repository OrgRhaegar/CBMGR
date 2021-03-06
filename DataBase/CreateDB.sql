USE [master]
GO
/****** Object:  Database [CMBGR]    Script Date: 12/22/2016 9:06:19 PM ******/
CREATE DATABASE [CMBGR] ON  PRIMARY 
( NAME = N'CMBGR', FILENAME = N'C:\DATA\CMBGR.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CMBGR_log', FILENAME = N'C:\DATA\CMBGR_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CMBGR] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CMBGR].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CMBGR] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CMBGR] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CMBGR] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CMBGR] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CMBGR] SET ARITHABORT OFF 
GO
ALTER DATABASE [CMBGR] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CMBGR] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CMBGR] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CMBGR] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CMBGR] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CMBGR] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CMBGR] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CMBGR] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CMBGR] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CMBGR] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CMBGR] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CMBGR] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CMBGR] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CMBGR] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CMBGR] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CMBGR] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CMBGR] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CMBGR] SET RECOVERY FULL 
GO
ALTER DATABASE [CMBGR] SET  MULTI_USER 
GO
ALTER DATABASE [CMBGR] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CMBGR] SET DB_CHAINING OFF 
GO
EXEC sys.sp_db_vardecimal_storage_format N'CMBGR', N'ON'
GO
USE [CMBGR]
GO
/****** Object:  Table [dbo].[CM_ClubInfo]    Script Date: 12/22/2016 9:06:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CM_ClubInfo](
	[CLUB_ID] [varchar](50) NOT NULL,
	[CLUB_NAME] [nvarchar](16) NOT NULL,
	[CREATOR_ID] [varchar](50) NOT NULL,
	[CREATOR_DATE] [datetime] NOT NULL,
	[OWNER_ID] [varchar](50) NOT NULL,
	[PIC_SRC] [varchar](200) NULL,
	[COMMENT] [nvarchar](200) NULL,
	[ENABLED] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CLUB_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CM_GameInfo]    Script Date: 12/22/2016 9:06:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CM_GameInfo](
	[GAME_ID] [varchar](50) NOT NULL,
	[CLUB_ID] [varchar](50) NOT NULL,
	[GROUND_ID] [varchar](50) NOT NULL,
	[GAME_TITLE] [nvarchar](20) NOT NULL,
	[CREATOR_ID] [varchar](50) NOT NULL,
	[BEGIN_DATE] [datetime] NOT NULL,
	[END_DATE] [datetime] NOT NULL,
	[LOCK_DATE] [datetime] NOT NULL,
	[MAX_ATTACH_NUMBER] [int] NOT NULL,
	[GROUND_COUNT] [int] NOT NULL,
	[PERSON_PER_GROUND] [int] NOT NULL,
	[BALL_INFO] [nvarchar](50) NULL,
	[GAME_STATE] [int] NOT NULL,
	[COMMENT] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[GAME_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CM_GroundInfo]    Script Date: 12/22/2016 9:06:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CM_GroundInfo](
	[GROUND_ID] [varchar](50) NOT NULL,
	[CLUB_ID] [varchar](50) NOT NULL,
	[GROUND_NAME] [nvarchar](50) NOT NULL,
	[ADDRESS] [nvarchar](50) NULL,
	[PHONE_NUMBER] [varchar](20) NULL,
	[CREATE_DATE] [datetime] NOT NULL,
	[COMMENT] [nvarchar](200) NULL,
	[ENALBED] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[GROUND_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CM_SysEnumItem]    Script Date: 12/22/2016 9:06:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CM_SysEnumItem](
	[ITEM_ID] [int] NOT NULL,
	[TYPE_ID] [int] NOT NULL,
	[ITEM_NAME] [nvarchar](20) NOT NULL,
	[CREATE_DATE] [datetime] NOT NULL,
	[COMMENT] [nvarchar](200) NULL,
	[ENABLED] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ITEM_ID] ASC,
	[TYPE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CM_SysEnumType]    Script Date: 12/22/2016 9:06:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CM_SysEnumType](
	[TYPE_ID] [int] NOT NULL,
	[TYPE_NAME] [nvarchar](20) NOT NULL,
	[CREATE_DATE] [datetime] NOT NULL,
	[COMMENT] [nvarchar](200) NULL,
	[ENABLED] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TYPE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CM_UserInfo]    Script Date: 12/22/2016 9:06:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CM_UserInfo](
	[USER_ID] [varchar](50) NOT NULL,
	[USER_NAME] [nvarchar](16) NOT NULL,
	[USER_SEX] [bit] NOT NULL,
	[USER_BIRTHDATY] [int] NOT NULL,
	[USER_PHONE] [char](11) NULL,
	[USER_EMAIL] [varchar](50) NULL,
	[USER_WX] [varchar](50) NULL,
	[USER_COMMENT] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[USER_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CM_UserLevelToGround]    Script Date: 12/22/2016 9:06:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CM_UserLevelToGround](
	[ID] [varchar](50) NOT NULL,
	[GROUND_ID] [varchar](50) NOT NULL,
	[LEVEL_ID] [int] NOT NULL,
	[BALANCE_RATE] [decimal](10, 4) NOT NULL,
	[BALANCE] [bit] NOT NULL,
	[CREATE_DATE] [datetime] NOT NULL,
	[MODIFY_DATE] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CM_UserLogin]    Script Date: 12/22/2016 9:06:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CM_UserLogin](
	[USER_ID] [varchar](50) NOT NULL,
	[USER_LOGIN_NAME] [varchar](16) NOT NULL,
	[USER_LOGIN_PWD] [varchar](200) NOT NULL,
	[CREATEDATE] [datetime] NOT NULL,
	[MODIFY_DATE] [datetime] NOT NULL,
	[ENABLED] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[USER_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CM_UserSignUp]    Script Date: 12/22/2016 9:06:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CM_UserSignUp](
	[SIGNUP_ID] [varchar](50) NOT NULL,
	[USER_ID] [varchar](50) NOT NULL,
	[GAME_ID] [varchar](50) NOT NULL,
	[ATTACH_NUMBER] [int] NOT NULL,
	[CREATE_DATE] [datetime] NOT NULL,
	[CREATOR_ID] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SIGNUP_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CM_UserSignUpHistory]    Script Date: 12/22/2016 9:06:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CM_UserSignUpHistory](
	[HISTORY_ID] [varchar](50) NOT NULL,
	[USER_ID] [varchar](50) NOT NULL,
	[GAME_ID] [varchar](50) NOT NULL,
	[ATTACH_NUMBER] [int] NOT NULL,
	[CREATE_DATE] [datetime] NOT NULL,
	[CREATOR_ID] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[HISTORY_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CM_UserToClub]    Script Date: 12/22/2016 9:06:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CM_UserToClub](
	[ID] [nvarchar](50) NOT NULL,
	[USER_ID] [varchar](50) NOT NULL,
	[CLUB_ID] [varchar](50) NOT NULL,
	[LEVEL_ID] [int] NOT NULL,
	[ACCOUNT_BALANCE] [decimal](10, 4) NOT NULL,
	[JOIN_DATE] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[CM_ClubInfo] ADD  DEFAULT ((1)) FOR [ENABLED]
GO
ALTER TABLE [dbo].[CM_GameInfo] ADD  DEFAULT ((10)) FOR [MAX_ATTACH_NUMBER]
GO
ALTER TABLE [dbo].[CM_GameInfo] ADD  DEFAULT ((6)) FOR [PERSON_PER_GROUND]
GO
ALTER TABLE [dbo].[CM_GroundInfo] ADD  DEFAULT ((0)) FOR [ENALBED]
GO
ALTER TABLE [dbo].[CM_SysEnumItem] ADD  DEFAULT ((1)) FOR [ENABLED]
GO
ALTER TABLE [dbo].[CM_SysEnumType] ADD  DEFAULT ((1)) FOR [ENABLED]
GO
ALTER TABLE [dbo].[CM_UserInfo] ADD  DEFAULT ((0)) FOR [USER_SEX]
GO
ALTER TABLE [dbo].[CM_UserInfo] ADD  DEFAULT ((19000101)) FOR [USER_BIRTHDATY]
GO
ALTER TABLE [dbo].[CM_UserLevelToGround] ADD  DEFAULT ((25.0)) FOR [BALANCE_RATE]
GO
ALTER TABLE [dbo].[CM_UserLevelToGround] ADD  DEFAULT ((1)) FOR [BALANCE]
GO
ALTER TABLE [dbo].[CM_UserLogin] ADD  DEFAULT ((0)) FOR [ENABLED]
GO
ALTER TABLE [dbo].[CM_UserSignUp] ADD  DEFAULT ((0)) FOR [ATTACH_NUMBER]
GO
ALTER TABLE [dbo].[CM_UserSignUpHistory] ADD  DEFAULT ((0)) FOR [ATTACH_NUMBER]
GO
ALTER TABLE [dbo].[CM_UserToClub] ADD  DEFAULT ((0)) FOR [ACCOUNT_BALANCE]
GO
/****** Object:  StoredProcedure [dbo].[CM_SP_CreateClub]    Script Date: 12/22/2016 9:06:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
 CREATE PROCEDURE [dbo].[CM_SP_CreateClub]
 @CREATEOT_ID VARCHAR(50)
 ,@CLUB_NAME NVARCHAR(16)
 ,@COMMENT NVARCHAR(200)
 AS
 BEGIN
 	DECLARE @CID VARCHAR(50) SET @CID = NEWID()
 	DECLARE @GID VARCHAR(50) SET @GID = NEWID()
 	BEGIN TRY
 		BEGIN TRANSACTION
 		--Club info
 		INSERT INTO CM_ClubInfo
 		(CLUB_ID, CLUB_NAME, CREATOR_ID, CREATOR_DATE, OWNER_ID, PIC_SRC, COMMENT)
 		VALUES
 		(@CID, @CLUB_NAME, @CREATEOT_ID, GETDATE(), @CREATEOT_ID, '', @COMMENT)
 		--Default ground info
 		INSERT INTO CM_GroundInfo
 		( GROUND_ID, CLUB_ID, GROUND_NAME, CREATE_DATE, ENALBED )
 		VALUES
 		( @GID, @CID, '场地1', GETDATE(), 0 )
 		--Defalut level info
 		INSERT INTO CM_UserLevelToGround
 		( ID, GROUND_ID, LEVEL_ID, CREATE_DATE, MODIFY_DATE )
 		VALUES
 		( NEWID(), @GID, 1, GETDATE(), GETDATE() )
 		INSERT INTO CM_UserLevelToGround
 		( ID, GROUND_ID, LEVEL_ID, CREATE_DATE, MODIFY_DATE )
 		VALUES
 		( NEWID(), @GID, 2, GETDATE(), GETDATE() )
 		INSERT INTO CM_UserLevelToGround
 		( ID, GROUND_ID, LEVEL_ID, CREATE_DATE, MODIFY_DATE )
 		VALUES
 		( NEWID(), @GID, 3, GETDATE(), GETDATE() )
 		INSERT INTO CM_UserLevelToGround
 		( ID, GROUND_ID, LEVEL_ID, CREATE_DATE, MODIFY_DATE )
 		VALUES
 		( NEWID(), @GID, 4, GETDATE(), GETDATE() )
 		COMMIT
 	END TRY
 	BEGIN CATCH
 		ROLLBACK
 		SELECT 0 AS RESULT, ERROR_MESSAGE() AS MSG, NULL AS CLUBID
 	END CATCH
 END
GO
/****** Object:  StoredProcedure [dbo].[CM_SP_CreateGame]    Script Date: 12/22/2016 9:06:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
 CREATE PROCEDURE [dbo].[CM_SP_CreateGame]
 @CREATEOT_ID VARCHAR(50)
 ,@CLUB_ID VARCHAR(50)
 ,@GROUND_ID VARCHAR(50)
 ,@GAME_TITLE NVARCHAR(20) = ''
 ,@BEGIN_DATE DATETIME
 ,@END_DATE DATETIME
 ,@LOCK_DATE DATETIME = NULL
 ,@MAX_NUM INT = -1
 ,@G_COUNT INT
 ,@P_COUNT INT = 6
 ,@BALL_INFO NVARCHAR(50) = NULL
 ,@COMMENT NVARCHAR(200) = NULL
 AS
 BEGIN
 	BEGIN TRY
 		--Get default game title
 		IF @GAME_TITLE IS NULL
 		BEGIN
 			SELECT @GAME_TITLE = CLUB_NAME FROM CM_ClubInfo WHERE CLUB_ID = @CLUB_ID
 			SET @GAME_TITLE = @GAME_TITLE + N'日常活动'
 		END
 		--Get default lock date
 		IF @LOCK_DATE IS NULL
 		BEGIN
 			SET @LOCK_DATE = @BEGIN_DATE
 		END
 		--Create game info
 		INSERT INTO CM_GameInfo
 		( GAME_ID, CLUB_ID, GROUND_ID, GAME_TITLE, CREATOR_ID, BEGIN_DATE, END_DATE, LOCK_DATE, MAX_ATTACH_NUMBER, GROUND_COUNT, PERSON_PER_GROUND, BALL_INFO, GAME_STATE, COMMENT )
 		VALUES
 		( NEWID(), @CLUB_ID, @GAME_TITLE, @GROUND_ID, @CREATEOT_ID, @BEGIN_DATE, @END_DATE, @LOCK_DATE, @MAX_NUM, @G_COUNT, @P_COUNT, @BALL_INFO, 1, @COMMENT )
 		--Operation result
 		SELECT 1 AS RESUTL, @@IDENTITY AS GAME_ID, '' AS MSG
 	END TRY
 	BEGIN CATCH
  		SELECT 0 AS RESUTL, NULL AS GAME_ID, ERROR_MESSAGE() AS MSG
 	END CATCH
 END
GO
/****** Object:  StoredProcedure [dbo].[CM_SP_CreateNewUser]    Script Date: 12/22/2016 9:06:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CM_SP_CreateNewUser]
 @LOGIN_NAME VARCHAR(16)
 ,@LOGIN_PWD VARCHAR(200)
 AS
 BEGIN
 	IF EXISTS(SELECT [USER_ID] FROM CM_UserLogin WHERE USER_LOGIN_NAME = @LOGIN_NAME)
 	BEGIN
 		SELECT 0 AS RESULT, 'Login name already exists.' AS MSG
 	END
 	ELSE
 	BEGIN
 		DECLARE @ID VARCHAR(50) SET @ID = NEWID()
 		BEGIN TRY
 			BEGIN TRANSACTION
 			-- Current date
 			DECLARE @NOW DATETIME SET @NOW = GETDATE()
 			-- Login info
 			INSERT INTO CM_UserLogin
 			([USER_ID], USER_LOGIN_NAME, USER_LOGIN_PWD, CREATEDATE, [ENABLED])
 			VALUES
 			(@ID, @LOGIN_NAME, @LOGIN_PWD, @NOW, 1)
 			-- Default user name
			DECLARE @NAME VARCHAR(50)
			SET @NAME = 'USER'
			SET @NAME = @NAME + CONVERT(VARCHAR, @NOW, 112)
			SET @NAME = @NAME + SUBSTRING(@ID, 1, 4)
			-- User info
 			INSERT INTO CM_UserInfo
 			([USER_ID], [USER_NAME])
 			VALUES
 			(@ID, @NAME)
 			-- Commit transaction
 			COMMIT
 			-- Get operation result
 			SELECT 1 AS RESULT, @ID AS MSG
 		END TRY
 		BEGIN CATCH
 			ROLLBACK
 			SELECT 0 AS RESULT, ERROR_MESSAGE() AS MSG
 		END CATCH	
 	END
 END

GO
USE [master]
GO
ALTER DATABASE [CMBGR] SET  READ_WRITE 
GO
