/*******************************************
 * data: 2016-12-05
 * auth: Rhaegar
 * desc: User login table
 *******************************************/
 IF EXISTS(SELECT NAME FROM SYSOBJECTS WHERE NAME='CBMG_TB_UserLogin')
 DROP TABLE CBMG_TB_UserLogin
 GO
 
 CREATE TABLE CBMG_TB_UserLogin
 (
 	[USER_ID] VARCHAR(50) PRIMARY KEY NOT NULL
 	,[USER_LOGIN_NAME] VARCHAR(16) NOT NULL 
 	,[USER_LOGIN_PWD] VARCHAR(200) NOT NULL
 	,[CREATEDATE] DATETIME NOT NULL
 	,[ENABLED] BIT NOT NULL DEFAULT 0
 )