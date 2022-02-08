/*
----------------------------------------------------------------------------
-- Object Name: dbo.spUpdateSpiritualGems
-- Project: SqlTerritories
-- Business Process: Sample code
-- Purpose: Update a record into a table
-- Detailed Description: Update a record into the dbo.SpiritualGems table
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

CREATE PROCEDURE [dbo].[spUpdateSpiritualGems]
	@Id INT, 
    @BriefDescription NVARCHAR(255) NULL, 
    @LongDescription NVARCHAR(4000) NULL, 
    @IsDeleted BIT NULL

AS
BEGIN 

 SET NOCOUNT ON; 

  BEGIN 
    UPDATE [dbo].[tblSpiritualGems]
    SET 
    BriefDescription=ISNULL(@BriefDescription,BriefDescription), 
	LongDescription=ISNULL(@LongDescription,LongDescription),
    IsDeleted=ISNULL(@IsDeleted,IsDeleted)
	WHERE Id=@Id;
    END 
END