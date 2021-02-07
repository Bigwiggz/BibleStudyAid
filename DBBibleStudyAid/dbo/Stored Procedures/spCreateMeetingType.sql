/*
----------------------------------------------------------------------------
-- Object Name: dbo.spCreateMeetingType
-- Project: DBBibleStudyAid
-- Business Process: N/A
-- Purpose: C Operations on a record into a table
-- Detailed Description: Insert a record into the dbo.MeetingType table
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

CREATE PROCEDURE [dbo].[spCreateMeetingType]
    @MeetingTypeName NVARCHAR(100),
	@MeetingTypeDescription NVARCHAR(1000) NULL

AS
BEGIN
    SET NOCOUNT ON;
	INSERT INTO [dbo].[tblMeetingType] ([MeetingTypeName],[MeetingTypeDescription])
	VALUES (@MeetingTypeName,@MeetingTypeDescription);
END