/*******************************************
 * data: 2016-12-15
 * auth: Rhaegar
 * desc: Ground info
 *******************************************/
 
 IF EXISTS(SELECT NAME FROM SYSOBJECTS WHERE NAME = 'CBMGR_TB_GroundInfo')
 DROP TABLE CBMGR_TB_GroundInfo
 GO
 
 CREATE TABLE CBMGR_TB_GroundInfo
 (
 	[GROUND_ID] VARCHAR(50) PRIMARY KEY NOT NULL
 	,[GROUND_NAME] NVARCHAR(50) NOT NULL
 	,[ADDRESS] NVARCHAR(50) NULL
 	,[PHONE_NUMBER] VARCHAR(20) NULL
 	,[CREATE_DATE] DATETIME NOT NULL
 	,[COMMENT] NVARCHAR(200) NULL
 	,[ENALBED] BIT NOT NULL DEFAULT 0
 )