/*
----------------------------------------------------------------------------
-- Object Name: dbo.spCreateMeetingAssemblies
-- Project: DBBibleStudyAid
-- Business Process: N/A
-- Purpose: C Operations on a record into a table
-- Detailed Description: Insert a record into the dbo.MeetingAssemblies table
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

CREATE PROCEDURE [dbo].[spCreateMeetingAssemblies]
    @DateOfMeeting DATETIME2, 
    @PartTitle NCHAR(100), 
    @MeetingTypeId INT, 
    @Scripture NVARCHAR(1000), 
    @ReferenceId INT NULL, 
    @LessonLearnedDescription NVARCHAR(1000) 
AS
BEGIN
    SET NOCOUNT ON;
	INSERT INTO [dbo].[tblMeetingAssemblies] 
    ([DateOfMeeting], 
    [PartTitle], 
    [MeetingTypeId], 
    [Scripture], 
    [ReferenceId], 
    [LessonLearnedDescription])
	VALUES(
    @DateOfMeeting, 
    @PartTitle, 
    @MeetingTypeId, 
    @Scripture, 
    @ReferenceId, 
    @LessonLearnedDescription);
END