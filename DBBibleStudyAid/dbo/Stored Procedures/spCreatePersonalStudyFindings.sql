/*
----------------------------------------------------------------------------
-- Object Name: dbo.spCreatePersonalStudyFindings
-- Project: DBBibleStudyAid
-- Business Process: N/A
-- Purpose: C Operations on a record into a table
-- Detailed Description: Insert a record into the dbo.PersonalStudyFindings table
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

CREATE PROCEDURE [dbo].[spCreatePersonalStudyFindings]
    @Scripture NVARCHAR(1000) NULL, 
    @Explanation NVARCHAR(1000),
    @FKPersonalStudyProjectId INT

AS
BEGIN
    SET NOCOUNT ON;
	INSERT INTO [dbo].[tblPersonalStudyFindings] 
    ([Scripture], 
    [Explanation],
    [FKPersonalStudyProjectId])
	VALUES(
    @Scripture, 
    @Explanation,
    @FKPersonalStudyProjectId);
END