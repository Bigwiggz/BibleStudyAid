/*
----------------------------------------------------------------------------
-- Object Name: dbo.spCreateTagsToOtherTables
-- Project: DBBibleStudyAid
-- Business Process: N/A
-- Purpose: C Operations on a record into a table
-- Detailed Description: Insert a record into the dbo.TagsToOtherTables table
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

CREATE PROCEDURE [dbo].[spCreateTagsToOtherTables]
    @TagsId INT, 
    @tblId INT, 
    @tblName NVARCHAR(100), 
    @FKtblIdAndName NVARCHAR(1000)
AS
BEGIN
    SET NOCOUNT ON;
	INSERT INTO [dbo].[tblTagsToOtherTables] 
    ([TagsId], 
    [tblId], 
    [tblName], 
    [FKtblIdAndName])
	VALUES(
    @TagsId, 
    @tblId, 
    @tblName, 
    @FKtblIdAndName);
END