/*
----------------------------------------------------------------------------
-- Object Name: dbo.spUpdateMeetingType
-- Project: SqlTerritories
-- Business Process: Sample code
-- Purpose: Update a record into a table
-- Detailed Description: Update a record into the dbo.MeetingType table
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

CREATE PROCEDURE [dbo].[spUpdateMeetingType]
    @Id INT,
    @MeetingTypeName NVARCHAR(100),
	@MeetingTypeDescription NVARCHAR(1000) NULL

AS
BEGIN 

 SET NOCOUNT ON; 

  BEGIN 
    UPDATE [dbo].[tblMeetingType]
    SET 
    MeetingTypeName=ISNULL(@MeetingTypeName,MeetingTypeName), 
	MeetingTypeDescription=ISNULL(@MeetingTypeDescription,MeetingTypeDescription)

	WHERE Id=@Id
    END 
END