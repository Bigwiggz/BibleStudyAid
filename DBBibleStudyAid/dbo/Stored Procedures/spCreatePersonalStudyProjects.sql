/*
----------------------------------------------------------------------------
-- Object Name: dbo.spCreatePersonalStudyProjects
-- Project: DBBibleStudyAid
-- Business Process: N/A
-- Purpose: C Operations on a record into a table
-- Detailed Description: Insert a record into the dbo.PersonalStudyProjects table
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

CREATE PROCEDURE [dbo].[spCreatePersonalStudyProjects]
    @PersonalStudyTitle NVARCHAR(100) , 
    @PersonalStudyDescription NVARCHAR(1000) , 
    @PersonalStudyQuestionAssignment NVARCHAR(1000) , 
    @DateFinished DATETIME2 NULL, 
    @BaseScripture NVARCHAR(1000) NULL, 
    @PersonalStudyFindingsId INT NULL 
AS
BEGIN
    SET NOCOUNT ON;
	INSERT INTO [dbo].[tblPersonalStudyProjects] 
    ([PersonalStudyTitle], 
    [PersonalStudyDescription], 
    [PersonalStudyQuestionAssignment], 
    [DateFinished], 
    [BaseScripture], 
    [PersonalStudyFindingsId])
	VALUES(
    @PersonalStudyTitle, 
    @PersonalStudyDescription, 
    @PersonalStudyQuestionAssignment, 
    @DateFinished, 
    @BaseScripture, 
    @PersonalStudyFindingsId);
END