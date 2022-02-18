/*
----------------------------------------------------------------------------
-- Object Name: dbo.spUpdateMeetingsAssemblies
-- Project: SqlTerritories
-- Business Process: Sample code
-- Purpose: Update a record into a table
-- Detailed Description: Update a record into the dbo.MeetingsAssemblies table
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

CREATE PROCEDURE [dbo].[spUpdateMeetingsAssemblies]
    @Id INT,
    @DateOfMeeting DATETIME2, 
    @PartTitle NCHAR(100), 
    @MeetingType INT, 
    @Scripture NVARCHAR(1000), 
    @LessonLearnedDescription NVARCHAR(1000),
    @IsDeleted BIT

AS
BEGIN 

 SET NOCOUNT ON; 

  BEGIN 
    UPDATE [dbo].[tblMeetingsAssemblies]
    SET 
    DateOfMeeting=ISNULL(@DateOfMeeting,DateOfMeeting), 
	PartTitle=ISNULL(@PartTitle,PartTitle),
    MeetingType=ISNULL(@MeetingType,MeetingType), 
	Scripture =ISNULL(@Scripture ,Scripture),
    LessonLearnedDescription =ISNULL(@LessonLearnedDescription ,LessonLearnedDescription),
    IsDeleted=ISNULL(@IsDeleted,IsDeleted)
	WHERE Id=@Id;
    END 
END