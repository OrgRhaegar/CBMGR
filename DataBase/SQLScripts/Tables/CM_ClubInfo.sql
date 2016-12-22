/*******************************************
 * data: 2016-12-10
 * auth: Rhaegar
 * desc: Club information table
 *******************************************/
 IF EXISTS(SELECT NAME FROM SYSOBJECTS WHERE NAME='CM_ClubInfo')
 DROP TABLE CM_ClubInfo
 GO
 
 CREATE TABLE CM_ClubInfo
 (
 	[CLUB_ID] VARCHAR(50) PRIMARY KEY NOT NULL
 	,[CLUB_NAME] NVARCHAR(16) NOT NULL
 	,[CREATOR_ID] VARCHAR(50) NOT NULL
 	,[CREATOR_DATE] DATETIME NOT NULL
 	,[OWNER_ID] VARCHAR(50) NOT NULL
 	,[PIC_SRC] VARCHAR(200) NULL
 	,[COMMENT] NVARCHAR(200) NULL
 	,[ENABLED] BIT NOT NULL DEFAULT 1
 )