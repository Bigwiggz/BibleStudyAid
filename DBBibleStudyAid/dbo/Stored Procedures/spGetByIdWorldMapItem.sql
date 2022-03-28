/*
----------------------------------------------------------------------------
-- Object Name: dbo.spGetByIdWorldMapItem
-- Project: DBBibleStudyAid
-- Business Process: N/A
-- Purpose: C Operations on a record into a table
-- Detailed Description: Insert a record into the dbo.WorldMapItem table
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

CREATE PROCEDURE [dbo].[spGetByIdWorldMapItem]
	@Id INT

AS
BEGIN
    SET NOCOUNT ON;
	SELECT 
	[Id],               
    [FKTableIdandName], 
    [UpdatedDate],      
    [Description],      
    [Title],          
    GeographyData.Serialize() AS GeographyData,   
    [Color],            
    [Guid],            
    [GeographyType],    
    [IsDeleted] 
	FROM [dbo].[tblWorldMapItem]
	WHERE Id=@Id;
END