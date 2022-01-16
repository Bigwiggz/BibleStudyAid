/*
----------------------------------------------------------------------------
-- Object Name: dbo.spCreateDocuments
-- Project: DBBibleStudyAid
-- Business Process: N/A
-- Purpose: C Operations on a record into a table
-- Detailed Description: Insert a record into the dbo.CreateDocuments table
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

CREATE PROCEDURE [dbo].[spCreateDocuments]
    @FKProject NVARCHAR(1000), 
    @DocumentName NVARCHAR(256), 
    @Document VARBINARY(MAX),
    @DocumentType NVARCHAR(256),
    @DocumentDescription NVARCHAR(1000),
    @IsDeleted BIT NULL

AS
BEGIN
    SET NOCOUNT ON;
	INSERT INTO [dbo].[tblDocuments] ([FKProject],[DocumentName],[Document],[DocumentType],[DocumentDescription])
	VALUES (@FKProject,@DocumentName,@Document,@DocumentType,@DocumentDescription);
    DECLARE @Id INT;
    SET @Id=SCOPE_IDENTITY();
END