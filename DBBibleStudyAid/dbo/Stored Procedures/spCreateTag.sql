/*
----------------------------------------------------------------------------
-- Object Name: dbo.spCreateTag
-- Project: DBBibleStudyAid
-- Business Process: N/A
-- Purpose: CRUD Operations on a record into a table
-- Detailed Description: Insert a record into the dbo.Tag table
-- Database: SqlTerritoriesDB
-- Dependent Objects: None
-- Called By: Application
-- Upstream Systems: N\A
-- Downstream Systems: NONE
-- 
--------------------------------------------------------------------------------------
-- Rev | CMR | Date Modified | Developer  | Change Summary
--------------------------------------------------------------------------------------
-- 001 | N\A | 06.28.2020 | BWiggins | Original code-CONFIRMED
--
*/

CREATE PROCEDURE [dbo].[spCreateTag]
	@TagName NVARCHAR(100), 
    @TagDescription NVARCHAR(1000) NULL,
	@TagColor NVARCHAR(7),
	@IsDeleted BIT NULL
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [dbo].[tblTags] ([TagName],[TagDescription],[TagColor],[IsDeleted])
	VALUES (@TagName,@TagDescription,@TagColor,@IsDeleted);
END


