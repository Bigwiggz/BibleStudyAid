/*
----------------------------------------------------------------------------
-- Object Name: dbo.spGetByIdDailyBibleReading
-- Project: DBBibleStudyAid
-- Business Process: N/A
-- Purpose: C Operations on a record into a table
-- Detailed Description: Insert a record into the dbo.DailyBibleReading table
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

CREATE PROCEDURE [dbo].[spGetByIdDailyBibleReading]
	@Id INT,

AS
BEGIN
    SET NOCOUNT ON;
	SELECT *
	FROM [dbo].[tblDailyBibleReading]
	WHERE Id=@Id;
END