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
    @FKTableIdandName NVARCHAR(1000), 
    @ContentType NVARCHAR(255),
    @ContentDisposition NVARCHAR(255),
    @ContentSize BIGINT,
    @UniqueFileName NVARCHAR(255),
    @FileName NVARCHAR(255),
    @UniqueGUIDId UNIQUEIDENTIFIER,
    @Name NVARCHAR(255),
    @DocumentDescription NVARCHAR(1000),
    @IsDeleted BIT NULL

AS
BEGIN
    SET NOCOUNT ON;
	INSERT INTO [dbo].[tblDocuments] ([FKTableIdandName],[ContentType],[ContentDisposition],[ContentSize],[UniqueFileName],[FileName],[UniqueGUIDId],[Name],[DocumentDescription])
	VALUES (@FKTableIdandName,@ContentType,@ContentDisposition,@ContentSize,@UniqueFileName,@FileName,@UniqueGUIDId,@Name,@DocumentDescription);
    DECLARE @Id INT;
    SET @Id=SCOPE_IDENTITY();
END