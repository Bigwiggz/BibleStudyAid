/*
----------------------------------------------------------------------------
-- Object Name: dbo.spUpdateReferences
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

CREATE PROCEDURE [dbo].[spUpdateReferences]
    @Id INT,
    @Reference NVARCHAR(1000),
	@FKTableIdandName NVARCHAR(1000),
    @Description NVARCHAR(2500) NULL,
    @IsDeleted BIT

AS
BEGIN 

 SET NOCOUNT ON; 

  BEGIN 
    UPDATE [dbo].[tblReferences]
    SET 
    Reference=ISNULL(@Reference,Reference), 
	FKTableIdandName=ISNULL(@FKTableIdandName,FKTableIdandName),
    [Description]=ISNULL(@Description,[Description]),
    DateUpdated=GETUTCDATE(),
    IsDeleted=ISNULL(@IsDeleted,IsDeleted)
	WHERE Id=@Id;
    END 
END