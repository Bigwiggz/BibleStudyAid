/*
----------------------------------------------------------------------------
-- Object Name: dbo.spUpdateDailyBibleReading
-- Project: SqlTerritories
-- Business Process: Sample code
-- Purpose: Update a record into a table
-- Detailed Description: Update a record into the dbo.DailyBibleReading table
-- Database: DBBibleStudyAid
-- Dependent Objects: None
-- Called By: Application
-- Upstream Systems: N\A
-- Downstream Systems: N\A
-- 
--------------------------------------------------------------------------------------
-- Rev | CMR | Date Modified | Developer  | Change Summary
--------------------------------------------------------------------------------------
-- 001 | N\A | 06.28.2020 | BWiggins | Original code
--
*/

CREATE PROCEDURE [dbo].[spUpdateDailyBibleReading]
    @Id INT,
    @ScriptureStartPoint NVARCHAR(1000), 
    @ScriptureEndPoint NVARCHAR(1000), 
    @LessonLearnedDescription NVARCHAR(1000), 
    @DateRead DATETIME2 NULL

AS
BEGIN 

 SET NOCOUNT ON; 

  BEGIN 
    UPDATE [dbo].[tblDailyBibleReading]
    SET 
    ScriptureStartPoint=ISNULL(@ScriptureStartPoint,ScriptureStartPoint), 
	ScriptureEndPoint=ISNULL(@ScriptureEndPoint,ScriptureEndPoint),
    LessonLearnedDescription=ISNULL(@LessonLearnedDescription,LessonLearnedDescription), 
	DateRead =ISNULL(@DateRead ,DateRead)

	WHERE Id=@Id
    END 
END