/*******************************************
 * data: 2016-12-18
 * auth: Rhaegar
 * desc: User sign up history record.
 *******************************************/
 IF EXISTS(SELECT NAME FROM SYSOBJECTS WHERE NAME='CM_UserSignUpHistory')
 DROP TABLE CM_UserSignUpHistory
 GO
 
 CREATE TABLE CM_UserSignUpHistory
 (
 	[HISTORY_ID] VARCHAR(50) PRIMARY KEY NOT NULL
 	,[USER_ID] VARCHAR(50) NOT NULL
 	,[GAME_ID] VARCHAR(50) NOT NULL
 	,[ATTACH_NUMBER] INT NOT NULL DEFAULT 0
 	,[CREATE_DATE] DATETIME NOT NULL
 	,[CREATOR_ID] VARCHAR(50) NOT NULL
 )