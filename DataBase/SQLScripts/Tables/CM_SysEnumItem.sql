/*******************************************
 * data: 2016-12-20
 * auth: Rhaegar
 * desc: System enum item
 *******************************************/
 
IF EXISTS(SELECT NAME FROM SYSOBJECTS WHERE NAME = 'CM_SysEnumItem')
DROP TABLE CM_SysEnumItem
GO

CREATE TABLE CM_SysEnumItem
(
	[ITEM_ID] INT NOT NULL
	,[TYPE_ID] INT NOT NULL 
	,[ITEM_NAME] NVARCHAR(20) NOT NULL
	,[CREATE_DATE] DATETIME NOT NULL
	,[COMMENT] NVARCHAR(200) NULL
	,[ENABLED] BIT NOT NULL DEFAULT 1
	,PRIMARY KEY ([ITEM_ID], [TYPE_ID])
)

--User level
INSERT INTO CM_SysEnumItem([ITEM_ID],[TYPE_ID],ITEM_NAME,CREATE_DATE,COMMENT,[ENABLED])VALUES(1,1,N'所有人',GETDATE(),N'球会所有人',1)
INSERT INTO CM_SysEnumItem([ITEM_ID],[TYPE_ID],ITEM_NAME,CREATE_DATE,COMMENT,[ENABLED])VALUES(2,1,N'管理员',GETDATE(),N'球会管理员',1)
INSERT INTO CM_SysEnumItem([ITEM_ID],[TYPE_ID],ITEM_NAME,CREATE_DATE,COMMENT,[ENABLED])VALUES(3,1,N'会员',GETDATE(),N'球会会员',1)
INSERT INTO CM_SysEnumItem([ITEM_ID],[TYPE_ID],ITEM_NAME,CREATE_DATE,COMMENT,[ENABLED])VALUES(4,1,N'散客',GETDATE(),N'散客',1)
INSERT INTO CM_SysEnumItem([ITEM_ID],[TYPE_ID],ITEM_NAME,CREATE_DATE,COMMENT,[ENABLED])VALUES(5,1,N'自定义1',GETDATE(),N'自定义级别1',0)
INSERT INTO CM_SysEnumItem([ITEM_ID],[TYPE_ID],ITEM_NAME,CREATE_DATE,COMMENT,[ENABLED])VALUES(6,1,N'自定义2',GETDATE(),N'自定义级别2',0)
INSERT INTO CM_SysEnumItem([ITEM_ID],[TYPE_ID],ITEM_NAME,CREATE_DATE,COMMENT,[ENABLED])VALUES(7,1,N'自定义3',GETDATE(),N'自定义级别3',0)

--Balance type
INSERT INTO CM_SysEnumItem([ITEM_ID],[TYPE_ID],ITEM_NAME,CREATE_DATE,COMMENT,[ENABLED])VALUES(1,2,N'固定金额',GETDATE(),N'按会员等级每次活动固定金额',1)
INSERT INTO CM_SysEnumItem([ITEM_ID],[TYPE_ID],ITEM_NAME,CREATE_DATE,COMMENT,[ENABLED])VALUES(2,2,N'AA分摊',GETDATE(),N'参加活动的所有人员AA均摊费用',1)