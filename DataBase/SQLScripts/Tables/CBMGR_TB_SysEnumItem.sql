/*******************************************
 * data: 2016-12-20
 * auth: Rhaegar
 * desc: System enum item
 *******************************************/
 
IF EXISTS(SELECT NAME FROM SYSOBJECTS WHERE NAME = 'CBMGR_TB_SysEnumItem')
DROP TABLE CBMGR_TB_SysEnumItem
GO

CREATE TABLE CBMGR_TB_SysEnumItem
(
	[ITME_ID] VARCHAR(50) PRIMARY KEY NOT NULL
	,[TYPE_INDEX] CHAR(4) NOT NULL
	,[ITEM_INDEX] INT NOT NULL 
	,[ITEM_NAME] NVARCHAR(20) NOT NULL
	,[CREATE_DATE] DATETIME NOT NULL
	,[COMMENT] NVARCHAR(200) NULL
)