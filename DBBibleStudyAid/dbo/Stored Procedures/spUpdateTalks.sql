/*
----------------------------------------------------------------------------
-- Object Name: dbo.spUpdateTalks
-- Project: SqlTerritories
-- Business Process: Sample code
-- Purpose: Update a record into a table
-- Detailed Description: Update a record into the dbo.Talks table
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

CREATE PROCEDURE [dbo].[spUpdateTalks]
    @Id INT,
    @TalkTitle NVARCHAR(100), 
    @DateGiven DATETIME2,  
    @MeetingTypeId INT, 
    @Description NVARCHAR(1000), 
    @TalkDocument VARBINARY(MAX), 
    @ThemeScripture NVARCHAR(1000) NULL

AS
BEGIN 

 SET NOCOUNT ON; 

  BEGIN 
    UPDATE [dbo].[tblTalks]
    SET 
    TalkTitle=ISNULL(@TalkTitle,TalkTitle), 
    DateGiven=ISNULL(@DateGiven,DateGiven),
    MeetingTypeId=ISNULL(@MeetingTypeId,MeetingTypeId),
	[Description]=ISNULL(@Description,[Description]),
    TalkDocument=ISNULL(@TalkDocument,TalkDocument), 
	ThemeScripture=ISNULL(@ThemeScripture,ThemeScripture)


	WHERE Id=@Id
    END 
END