/*
----------------------------------------------------------------------------
-- Object Name: dbo.spUpdateTag
-- Project: SqlTerritories
-- Business Process: Sample code
-- Purpose: Update a record into a table
-- Detailed Description: Update a record into the dbo.Tag table
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

CREATE PROCEDURE [dbo].[spUpdateTag]

	@Id INT,
	@TagName NVARCHAR(100), 
    @TagDescription NVARCHAR(1000) NULL,
	@IsDeleted BIT

AS
BEGIN 

 SET NOCOUNT ON; 

  BEGIN 
    UPDATE [dbo].[tblTags]
    SET TagName=ISNULL(@TagName,TagName), 
		TagDescription=ISNULL(@TagDescription,TagDescription),
		IsDeleted=ISNULL(@IsDeleted,IsDeleted)
	WHERE Id=@Id
    END 
END