/*
----------------------------------------------------------------------------
-- Object Name: dbo.spUpdateTagsToOtherTables
-- Project: SqlTerritories
-- Business Process: Sample code
-- Purpose: Update a record into a table
-- Detailed Description: Update a record into the dbo.TagsToOtherTables table
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

CREATE PROCEDURE [dbo].[spUpdateTagsToOtherTables]
    @Id INT,
    @TagsId INT, 
    @tblId INT, 
    @tblName NVARCHAR(100), 
    @FKTableIdandName NVARCHAR(1000),
    @IsDeleted BIT

AS
BEGIN 

 SET NOCOUNT ON; 

  BEGIN 
    UPDATE [dbo].[tblTagsToOtherTables]
    SET 
    TagsId=ISNULL(@TagsId,TagsId), 
	tblId=ISNULL(@tblId,tblId),
    tblName=ISNULL(@tblName,tblName), 
	FKTableIdandName=ISNULL(@FKTableIdandName,FKTableIdandName),
    IsDeleted=ISNULL(@IsDeleted,IsDeleted)


	WHERE Id=@Id
    END 
END