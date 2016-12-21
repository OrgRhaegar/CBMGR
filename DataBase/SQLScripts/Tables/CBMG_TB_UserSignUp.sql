/*******************************************
 * data: 2016-12-14
 * auth: Rhaegar
 * desc: User sign up information
 *******************************************/
 IF EXISTS(SELECT NAME FROM SYSOBJECTS WHERE NAME='CBMGR_TB_UserSignUp')
 DROP TABLE CBMGR_TB_UserSignUp
 GO
 
 CREATE TABLE CBMGR_TB_UserSignUp
 (
 	[SIGNUP_ID] VARCHAR(50) PRIMARY KEY NOT NULL
 	,[USER_ID] VARCHAR(50) NOT NULL
 	,[GAME_ID] VARCHAR(50) NOT NULL
 	,[ATTACH_NUMBER] INT NOT NULL DEFAULT 0
 	,[CREATE_DATE] DATETIME NOT NULL
 	,[CREATOR_ID] VARCHAR(50) NOT NULL
 )