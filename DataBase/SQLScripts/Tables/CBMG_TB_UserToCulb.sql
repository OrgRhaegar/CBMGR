/*******************************************
 * data: 2016-12-10
 * auth: Rhaegar
 * desc: Relationship between user and club
 *******************************************/
 IF EXISTS(SELECT NAME FROM SYSOBJECTS WHERE NAME='CBMGR_TB_UserToClub')
 DROP TABLE CBMGR_TB_UserToClub
 GO
 
 CREATE TABLE CBMGR_TB_UserToClub
 (
 	[ID] NVARCHAR(50) PRIMARY KEY NOT NULL
 	,[USER_ID] VARCHAR(50) NOT NULL
 	,[CLUB_ID] VARCHAR(50) NOT NULL
 	,[LEVEL_ID] VARCHAR(50) NOT NULL
 	,[JOIN_DATE] DATETIME NOT NULL
 )