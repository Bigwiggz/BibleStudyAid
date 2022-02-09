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
    @TalkDocumentName NVARCHAR(256),
    @ThemeScripture NVARCHAR(1000) NULL,
    @IsDeleted BIT NULL
AS
BEGIN
    SET NOCOUNT ON;
	INSERT INTO [dbo].[tblTalks] 
    ([TalkTitle],  
    [DateGiven],  
    [MeetingTypeId], 
    [Description], 
    [TalkDocumentName],
    [ThemeScripture],
    [IsDeleted])
	VALUES(
    @TalkTitle, 
    @DateGiven,  
    @MeetingTypeId, 
    @Description, 
    @TalkDocumentName,
    @ThemeScripture,
    @IsDeleted);
END