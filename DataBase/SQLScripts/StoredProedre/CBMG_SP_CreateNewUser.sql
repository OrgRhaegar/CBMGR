/*******************************************
 * data: 2016-12-15
 * auth: Rhaegar
 * desc: Create a new user
 *******************************************/
 IF EXISTS(SELECT NAME FROM SYSOBJECTS WHERE NAME='CBMG_SP_CreateNewUser')
 DROP PROCEDURE CBMG_SP_CreateNewUser
 GO
 
 CREATE PROCEDURE CBMG_SP_CreateNewUser
 @LOGIN_NAME VARCHAR(16)
 ,@LOGIN_PWD VARCHAR(200)
 AS
 BEGIN
 	IF EXISTS(SELECT [USER_ID] FROM CBMG_TB_UserLogin WHERE USER_LOGIN_NAME = @LOGIN_NAME)
 	BEGIN
 		SELECT 0 AS RESULT, 'Login name already exists.' AS MSG
 	END
 	ELSE
 	BEGIN
 		DECLARE @ID VARCHAR(50) SET @ID = NEWID()
 		BEGIN TRY
 			BEGIN TRANSACTION
 			-- Current date
 			DECLARE @NOW DATETIME SET @NOW = GETDATE()
 			-- Login info
 			INSERT INTO CBMG_TB_UserLogin
 			([USER_ID], USER_LOGIN_NAME, USER_LOGIN_PWD, CREATEDATE, [ENABLED])
 			VALUES
 			(@ID, @LOGIN_NAME, @LOGIN_PWD, @NOW, 1)
 			-- Default user name
			DECLARE @NAME VARCHAR(50)
			SET @NAME = 'USER'
			SET @NAME = @NAME + CONVERT(VARCHAR, @NOW, 112)
			SET @NAME = @NAME + SUBSTRING(@ID, 1, 4)
			-- User info
 			INSERT INTO CBMG_TB_UserInfo
 			([USER_ID], [USER_NAME])
 			VALUES
 			(@ID, @NAME)
 			-- Commit transaction
 			COMMIT
 			-- Get operation result
 			SELECT 1 AS RESULT, @ID AS MSG
 		END TRY
 		BEGIN CATCH
 			ROLLBACK
 			SELECT 0 AS RESULT, ERROR_MESSAGE() AS MSG
 		END CATCH	
 	END
 END