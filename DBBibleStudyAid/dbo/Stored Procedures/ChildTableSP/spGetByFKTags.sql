﻿/*
----------------------------------------------------------------------------
-- Object Name: dbo.spGetByFKTagToOtherScriptures
-- Project: DBBibleStudyAid
-- Business Process: N/A
-- Purpose: C Operations on a record into a table
-- Detailed Description: Insert a record into the dbo.TagToOtherScriptures table
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

CREATE PROCEDURE [dbo].[spGetByFKTags]
	@FK NVARCHAR(1000)
AS
BEGIN
    SET NOCOUNT ON;
	SELECT [tblTags].*
	FROM [dbo].[tblTagsToOtherTables]
	INNER JOIN [dbo].[tblTags] ON [tblTagsToOtherTables].[TagsId]=[tblTags].[Id]
	WHERE FKTableIdandName=@FK
	AND [dbo].[tblTagsToOtherTables].[IsDeleted]='FALSE';
END