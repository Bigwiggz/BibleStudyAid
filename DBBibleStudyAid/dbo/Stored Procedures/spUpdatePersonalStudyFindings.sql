/*
----------------------------------------------------------------------------
-- Object Name: dbo.spUpdatePersonalStudyFindings
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

CREATE PROCEDURE [dbo].[spUpdatePersonalStudyFindings]
    @Id INT,
    @Scripture NVARCHAR(1000) NULL, 
    @Explanation NVARCHAR(1000),
    @FKPersonalStudyProjectId INT

AS
BEGIN 

 SET NOCOUNT ON; 

  BEGIN 
    UPDATE [dbo].[tblPersonalStudyFindings]
    SET 
    Scripture=ISNULL(@Scripture,Scripture), 
	Explanation=ISNULL(@Explanation,Explanation),
    FKPersonalStudyProjectId=ISNULL(@FKPersonalStudyProjectId,FKPersonalStudyProjectId)


	WHERE Id=@Id
    END 
END