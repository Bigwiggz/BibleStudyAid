/*
----------------------------------------------------------------------------
-- Object Name: dbo.spCreateFamilyStudyProjects
-- Project: DBBibleStudyAid
-- Business Process: N/A
-- Purpose: C Operations on a record into a table
-- Detailed Description: Insert a record into the dbo.FamilyStudyProjects table
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

CREATE PROCEDURE [dbo].[spCreateFamilyStudyProjects]
    @DateWhenCreated DATETIME2, 
    @FamilyStudyTitle NVARCHAR(100), 
    @FamilyStudyDescription NVARCHAR(1000), 
    @FamilyStudyFindings NVARCHAR(2000),
    @IsDeleted BIT NULL

AS
BEGIN
    SET NOCOUNT ON;
	INSERT INTO [dbo].[tblFamilyStudyProjects] ([DateWhenCreated],[FamilyStudyTitle],[FamilyStudyDescription],[FamilyStudyFindings])
	VALUES (@DateWhenCreated,@FamilyStudyTitle,@FamilyStudyDescription,@FamilyStudyFindings);
END