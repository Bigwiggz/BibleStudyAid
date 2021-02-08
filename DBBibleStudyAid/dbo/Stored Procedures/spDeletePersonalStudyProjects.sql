/*
----------------------------------------------------------------------------
-- Object Name: dbo.spDeletePersonalStudyProjects
-- Project: DBBibleStudyAid
-- Business Process: N/A
-- Purpose: C Operations on a record into a table
-- Detailed Description: Insert a record into the dbo.PersonalStudyProjects table
-- Database: DBBibleStudyAid
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

CREATE PROCEDURE [dbo].[spDeletePersonalStudyProjects]
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;
	DELETE FROM [dbo].[tblPersonalStudyProjects] 
    WHERE Id=@Id
END