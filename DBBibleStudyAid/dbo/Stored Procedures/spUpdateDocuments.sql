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
    @FKTableIdandName NVARCHAR(1000), 
    @ContentType NVARCHAR(255),
    @ContentDisposition NVARCHAR(255),
    @ContentSize BIGINT,
    @FileName NVARCHAR(255),
    @UniqueGUIDId UNIQUEIDENTIFIER,
    @Name NVARCHAR(255),
    @DocumentDescription NVARCHAR(1000),
    @IsDeleted BIT NULL

AS
BEGIN 

 SET NOCOUNT ON; 

  BEGIN 
    UPDATE [dbo].[tblDocuments]
    SET 
    FKTableIdandName=ISNULL(@FKTableIdandName,FKTableIdandName), 
    ContentType=ISNULL(@ContentType,ContentType), 
	ContentDisposition =ISNULL(@ContentDisposition ,ContentDisposition),
    ContentSize =ISNULL(@ContentSize , ContentSize),
    [FileName]=ISNULL(@FileName,[FileName]),
    [UniqueGUIDId]=ISNULL(@UniqueGUIDId,[UniqueGUIDId]),
    [Name]=ISNULL(@Name,[Name]),
    [DocumentDescription]=ISNULL(@DocumentDescription,[DocumentDescription]),
    IsDeleted=ISNULL(@IsDeleted,IsDeleted)
	WHERE Id=@Id;
    END 
END