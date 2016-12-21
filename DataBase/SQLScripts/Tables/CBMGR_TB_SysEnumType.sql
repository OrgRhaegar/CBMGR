/*******************************************
 * data: 2016-12-20
 * auth: Rhaegar
 * desc: System enum type
 *******************************************/
 
IF EXISTS(SELECT NAME FROM SYSOBJECTS WHERE NAME = 'CBMGR_TB_SysEnumType')
DROP TABLE CBMGR_TB_SysEnumType
GO

CREATE TABLE CBMGR_TB_SysEnumType
(
	[TYPE_ID] VARCHAR(50) PRIMARY KEY NOT NULL
	,[TYPE_INDEX] INT NOT NULL
	,[TYPE_NAME] NVARCHAR(20) NOT NULL
	,[CREATE_DATE] DATETIME NOT NULL
	,[COMMENT] NVARCHAR(200) NULL
)