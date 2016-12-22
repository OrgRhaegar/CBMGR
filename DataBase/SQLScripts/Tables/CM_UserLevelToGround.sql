/*******************************************
 * data: 2016-12-21
 * auth: Rhaegar
 * desc: User level to ground
 *******************************************/
 IF EXISTS(SELECT NAME FROM SYSOBJECTS WHERE NAME='CM_UserLevelToGround')
 DROP TABLE CM_UserLevelToGround
 GO
 
 CREATE TABLE CM_UserLevelToGround
 (
 	[ID] VARCHAR(50) PRIMARY KEY NOT NULL
 	,[GROUND_ID] VARCHAR(50) NOT NULL
 	,[LEVEL_ID] INT NOT NULL
 	,[BALANCE_RATE] DECIMAL(10, 4) NOT NULL DEFAULT 25.0
 	,[BALANCE] BIT NOT NULL DEFAULT 1
 	,[CREATE_DATE] DATETIME NOT NULL
 	,[MODIFY_DATE] DATETIME NOT NULL
 )