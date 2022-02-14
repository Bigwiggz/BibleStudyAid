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

CREATE PROCEDURE [dbo].[spUpdatePersonalStudyProjects]
    @Id INT,
    @PersonalStudyTitle NVARCHAR(100) , 
    @PersonalStudyDescription NVARCHAR(1000) , 
    @PersonalStudyQuestionAssignment NVARCHAR(1000) , 
    @DateFinished DATETIME2 NULL, 
    @BaseScripture NVARCHAR(1000) NULL,
    @IsDeleted BIT NULL,

AS
BEGIN 

 SET NOCOUNT ON; 

  BEGIN 
    UPDATE [dbo].[tblPersonalStudyProjects]
    SET 
    PersonalStudyTitle=ISNULL(@PersonalStudyTitle,PersonalStudyTitle), 
	PersonalStudyDescription=ISNULL(@PersonalStudyDescription,PersonalStudyDescription),
    PersonalStudyQuestionAssignment=ISNULL(@PersonalStudyQuestionAssignment,PersonalStudyQuestionAssignment), 
	DateFinished=ISNULL(@DateFinished,DateFinished),
    BaseScripture=ISNULL(@BaseScripture,BaseScripture),
    IsDeleted=ISNULL(@IsDeleted,IsDeleted)
	WHERE Id=@Id;
    END 
END