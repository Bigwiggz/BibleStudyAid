/*
----------------------------------------------------------------------------
-- Object Name: dbo.spDeleteTag
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

CREATE PROCEDURE [dbo].[spDeleteTag]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM [dbo].[tblTags]
	WHERE Id=@Id
END


