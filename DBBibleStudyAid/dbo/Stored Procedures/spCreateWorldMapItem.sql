/*
----------------------------------------------------------------------------
-- Object Name: dbo.spCreateWorldMapItem
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

CREATE PROCEDURE [dbo].[spCreateWorldMapItem]

    @Description NVARCHAR(1000) NULL, 
    @FKTableIdandName NVARCHAR(1000), 
    @Title NVARCHAR(255) , 
    @GeographyData GEOGRAPHY, 
    @Color NVARCHAR(7) ,  
    @GeographyType NCHAR(255),
    @IsDeleted BIT
AS
BEGIN
    SET NOCOUNT ON;
	INSERT INTO [dbo].[tblWorldMapItem] ([Description],[FKTableIdandName],[Title],[GeographyData],[Color],[GeographyType],[IsDeleted])
	VALUES (@Description,@FKTableIdandName,@Title,@GeographyData,@Color,@GeographyType,@IsDeleted);
    DECLARE @Id INT;
    SET @Id=SCOPE_IDENTITY();
END