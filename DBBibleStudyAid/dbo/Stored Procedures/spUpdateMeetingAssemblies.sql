/*
----------------------------------------------------------------------------
-- Object Name: dbo.spUpdateMeetingAssemblies
-- Project: SqlTerritories
-- Business Process: Sample code
-- Purpose: Update a record into a table
-- Detailed Description: Update a record into the dbo.MeetingAssemblies table
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

CREATE PROCEDURE [dbo].[spUpdateMeetingAssemblies]
    @Id INT,
    @DateOfMeeting DATETIME2, 
    @PartTitle NCHAR(100), 
    @MeetingTypeId INT, 
    @Scripture NVARCHAR(1000), 
    @LessonLearnedDescription NVARCHAR(1000),
    @IsDeleted BIT

AS
BEGIN 

 SET NOCOUNT ON; 

  BEGIN 
    UPDATE [dbo].[tblMeetingAssemblies]
    SET 
    DateOfMeeting=ISNULL(@DateOfMeeting,DateOfMeeting), 
	PartTitle=ISNULL(@PartTitle,PartTitle),
    MeetingTypeId=ISNULL(@MeetingTypeId,MeetingTypeId), 
	Scripture =ISNULL(@Scripture ,Scripture),
    LessonLearnedDescription =ISNULL(@LessonLearnedDescription ,LessonLearnedDescription),
    IsDeleted=ISNULL(@IsDeleted,IsDeleted)
	WHERE Id=@Id;
    END 
END