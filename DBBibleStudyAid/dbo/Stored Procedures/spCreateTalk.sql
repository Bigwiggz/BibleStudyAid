/*
----------------------------------------------------------------------------
-- Object Name: dbo.spCreateTalk
-- Project: DBBibleStudyAid
-- Business Process: N/A
-- Purpose: C Operations on a record into a table
-- Detailed Description: Insert a record into the dbo.Talk table
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

CREATE PROCEDURE [dbo].[spCreateTalk]
    @TalkTitle NVARCHAR(100), 
    @DateGiven DATETIME2,  
    @MeetingTypeId INT, 
    @Description NVARCHAR(1000), 
    @TalkDocument VARBINARY(MAX), 
    @ThemeScripture NVARCHAR(1000) NULL,
    @ReferenceId INT NULL
AS
BEGIN
    SET NOCOUNT ON;
	INSERT INTO [dbo].[tblTalks] 
    ([TalkTitle],  
    [DateGiven],  
    [MeetingTypeId], 
    [Description], 
    [TalkDocument], 
    [ThemeScripture], 
    [ReferenceId])
	VALUES(
    @TalkTitle, 
    @DateGiven,  
    @MeetingTypeId, 
    @Description, 
    @TalkDocument, 
    @ThemeScripture,
    @ReferenceId);
END