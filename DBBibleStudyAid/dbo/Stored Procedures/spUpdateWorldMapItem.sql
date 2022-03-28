/*
----------------------------------------------------------------------------
-- Object Name: dbo.spUpdateWorldMapItem
-- Project: SqlTerritories
-- Business Process: Sample code
-- Purpose: Update a record into a table
-- Detailed Description: Update a record into the dbo.WorldMapItem table
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

CREATE PROCEDURE [dbo].[spUpdateWorldMapItem]

	@Id INT, 
    @FKTableIdandName NVARCHAR(1000),
    @Description NVARCHAR(1000), 
    @Title NVARCHAR(255), 
    @GeographyData GEOGRAPHY, 
    @Color NVARCHAR(7), 
    @GeographyType NCHAR(255), 
    @IsDeleted BIT

AS
BEGIN 

 SET NOCOUNT ON; 

  BEGIN 
    UPDATE [dbo].[tblWorldMapItem]
    SET 
    FKTableIdandName=ISNULL(@FKTableIdandName,FKTableIdandName), 
	[Description]=ISNULL(@Description,[Description]),
    Title=ISNULL(@Title,Title), 
	GeographyData =ISNULL(@GeographyData ,GeographyData),
    Color=ISNULL(@Color,Color),
    GeographyType=ISNULL(@GeographyType,GeographyType),
    IsDeleted=ISNULL(@IsDeleted,IsDeleted)
	WHERE Id=@Id;
    END 
END