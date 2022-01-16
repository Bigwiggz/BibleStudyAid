/*
----------------------------------------------------------------------------
-- Object Name: dbo.spUpdateFamilyStudyProjects
-- Project: SqlTerritories
-- Business Process: Sample code
-- Purpose: Update a record into a table
-- Detailed Description: Update a record into the dbo.FamilyStudyProjects table
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

CREATE PROCEDURE [dbo].[spUpdateFamilyStudyProjects]
    @Id INT,
    @DateWhenCreated DATETIME2, 
    @FamilyStudyTitle NVARCHAR(100), 
    @FamilyStudyDescription NVARCHAR(1000), 
    @FamilyStudyFindings NVARCHAR(2000),
    @IsDeleted BIT

AS
BEGIN 

 SET NOCOUNT ON; 

  BEGIN 
    UPDATE [dbo].[tblFamilyStudyProjects]
    SET 
    DateWhenCreated=ISNULL(@DateWhenCreated,DateWhenCreated), 
	FamilyStudyTitle=ISNULL(@FamilyStudyTitle,FamilyStudyTitle),
    FamilyStudyDescription=ISNULL(@FamilyStudyDescription,FamilyStudyDescription), 
	FamilyStudyFindings =ISNULL(@FamilyStudyFindings, FamilyStudyFindings),
    IsDeleted=ISNULL(@IsDeleted,IsDeleted)

	WHERE Id=@Id
    END 
END