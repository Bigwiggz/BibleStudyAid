/*
----------------------------------------------------------------------------
-- Object Name: dbo.spCreateMeetingsAssemblies
-- Project: DBBibleStudyAid
-- Business Process: N/A
-- Purpose: C Operations on a record into a table
-- Detailed Description: Insert a record into the dbo.MeetingsAssemblies table
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

CREATE PROCEDURE [dbo].[spCreateMeetingsAssemblies]
    @DateOfMeeting DATETIME2, 
    @PartTitle NCHAR(100), 
    @MeetingType INT, 
    @Scripture NVARCHAR(1000), 
    @LessonLearnedDescription NVARCHAR(1000),
    @IsDeleted BIT NULL
AS
BEGIN
    SET NOCOUNT ON;
	INSERT INTO [dbo].[tblMeetingsAssemblies] 
    ([DateOfMeeting], 
    [PartTitle], 
    [MeetingType], 
    [Scripture], 
    [LessonLearnedDescription],
    [IsDeleted])
	VALUES(
    @DateOfMeeting, 
    @PartTitle, 
    @MeetingType, 
    @Scripture, 
    @LessonLearnedDescription,
    @IsDeleted);
END