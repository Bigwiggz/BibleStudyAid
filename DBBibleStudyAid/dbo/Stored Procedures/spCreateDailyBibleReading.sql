/*
----------------------------------------------------------------------------
-- Object Name: dbo.spCreateDailyBibleReading
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

CREATE PROCEDURE [dbo].[spCreateDailyBibleReading]
    @Id INT OUTPUT,
    @ScriptureStartPoint NVARCHAR(1000), 
    @ScriptureEndPoint NVARCHAR(1000), 
    @LessonLearnedDescription NVARCHAR(1000), 
    @DateRead DATETIME2 NULL
AS
BEGIN
    SET NOCOUNT ON;
	INSERT INTO [dbo].[tblDailyBibleReading] ([ScriptureStartPoint],[ScriptureEndPoint],[LessonLearnedDescription],[DateRead])
	VALUES (@ScriptureStartPoint,@ScriptureEndPoint,@LessonLearnedDescription,@DateRead);
    SELECT @Id=SCOPE_IDENTITY();
END