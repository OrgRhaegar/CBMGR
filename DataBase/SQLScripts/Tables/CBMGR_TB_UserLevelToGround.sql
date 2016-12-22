/*******************************************
 * data: 2016-12-21
 * auth: Rhaegar
 * desc: User level to ground
 *******************************************/
 IF EXISTS(SELECT NAME FROM SYSOBJECTS WHERE NAME='CBMGR_TB_UserLevelToGround')
 DROP TABLE CBMGR_TB_UserLevelToGround
 GO
 
 CREATE TABLE CBMGR_TB_UserLevelToGround
 (
 	[ID] VARCHAR(50) PRIMARY KEY NOT NULL
 	,[GROUND_ID] VARCHAR(50) NOT NULL
 	,[LEVEL_ID] INT NOT NULL
 	,[BALANCE_RATE] DECIMAL(10, 4) NOT NULL DEFAULT 25.0
 	,[CREATE_DATE] DATETIME NOT NULL
 	,[MODIFY_DATE] DATETIME NOT NULL
 )