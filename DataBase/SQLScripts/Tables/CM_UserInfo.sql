/*******************************************
 * data: 2016-12-10
 * auth: Rhaegar
 * desc: User information table
 *******************************************/
 IF EXISTS(SELECT NAME FROM SYSOBJECTS WHERE NAME='CM_UserInfo')
 DROP TABLE CM_UserInfo
 GO
 
 CREATE TABLE CM_UserInfo
 (
 	[USER_ID] VARCHAR(50) PRIMARY KEY NOT NULL
 	,[USER_NAME] NVARCHAR(16) NOT NULL
 	,[USER_SEX] BIT NOT NULL DEFAULT 0
 	,[USER_BIRTHDATY] INT NOT NULL DEFAULT 19000101
 	,[USER_PHONE] CHAR(11) NULL
 	,[USER_EMAIL] VARCHAR(50) NULL
 	,[USER_WX] VARCHAR(50) NULL
 	,[USER_COMMENT] NVARCHAR(200) NULL
 )