/*
----------------------------------------------------------------------------
-- Object Name: dbo.spUpdateDocuments
-- Project: SqlTerritories
-- Business Process: Sample code
-- Purpose: Update a record into a table
-- Detailed Description: Update a record into the dbo.Documents table
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

CREATE PROCEDURE [dbo].[spUpdateDocuments]
    @Id INT,
    @FKProject NVARCHAR(1000), 
    @DocumentName NVARCHAR(256), 
    @Document VARBINARY(MAX),
    @DocumentType NVARCHAR(256),
    @DocumentDescription NVARCHAR(1000)

AS
BEGIN 

 SET NOCOUNT ON; 

  BEGIN 
    UPDATE [dbo].[tblDocuments]
    SET 
    FKProject=ISNULL(@FKProject,FKProject), 
    DocumentName=ISNULL(@DocumentName,DocumentName), 
	Document =ISNULL(@Document ,Document),
    DocumentType =ISNULL(@DocumentType , DocumentType),
    DocumentDescription=ISNULL(@DocumentDescription,[DocumentDescription])

	WHERE Id=@Id
    END 
END