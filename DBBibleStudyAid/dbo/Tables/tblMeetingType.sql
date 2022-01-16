CREATE TABLE [dbo].[tblMeetingType]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [MeetingTypeName] NVARCHAR(100) NOT NULL, 
    [MeetingTypeDescription] NVARCHAR(1000) NULL,
    [IsDeleted] BIT NOT NULL DEFAULT 0
)
