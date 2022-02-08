/*
----------------------------------------------------------------------------
-- Object Name: dbo.spCreateSpiritualGems
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

CREATE PROCEDURE [dbo].[spCreateSpiritualGems]
    @BriefDescription NVARCHAR(255) NULL, 
    @LongDescription NVARCHAR(4000) NULL, 
    @IsDeleted BIT NULL

AS
BEGIN
    SET NOCOUNT ON;
	INSERT INTO [dbo].[tblSpiritualGems] ([BriefDescription],[LongDescription],[IsDeleted])
	VALUES (@BriefDescription,@LongDescription,@IsDeleted);
    DECLARE @Id INT;
    SET @Id=SCOPE_IDENTITY();
END