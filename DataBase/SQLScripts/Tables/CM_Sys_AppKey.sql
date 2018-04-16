/*******************************************
 * data: 2018-04-15
 * auth: Rhaegar
 * desc: APP key table
 *******************************************/
 IF EXISTS(SELECT NAME FROM SYSOBJECTS WHERE NAME='CM_Sys_AppKey')
 DROP TABLE CM_Sys_AppKey
 GO
 
 CREATE TABLE CM_Sys_AppKey
 (
	[KEY_ID] VARCHAR(50) PRIMARY KEY NOT NULL,
	[KEY_VALUE] VARCHAR(200) NOT NULL,
	[EMAIL] VARCHAR(50) NOT NULL,
	[CREATE_DATE] DATETIME NOT NULL,
	[LAST_REQUIRED] DATETIME NOT NULL,
	[STATU] BIT NOT NULL,
	[COMMENT] NVARCHAR NULL
 )