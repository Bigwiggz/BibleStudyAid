/*
----------------------------------------------------------------------------
-- Object Name: dbo.spCreateScriptures
-- Project: DBBibleStudyAid
-- Business Process: N/A
-- Purpose: C Operations on a record into a table
-- Detailed Description: Insert a record into the dbo.Reference table
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

CREATE PROCEDURE [dbo].[spCreateScriptures]
    @Scripture NVARCHAR(1000),
	@FKTableIdandName NVARCHAR(1000)

AS
BEGIN
    SET NOCOUNT ON;
	INSERT INTO [dbo].[tblScriptures] ([Scripture],[FKTableIdandName])
	VALUES (@Scripture,@FKTableIdandName);
END