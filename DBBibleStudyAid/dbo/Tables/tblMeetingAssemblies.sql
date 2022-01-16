CREATE TABLE [dbo].[tblMeetingAssemblies]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CreatedDate] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [DateOfMeeting] DATETIME2 NOT NULL, 
    [PartTitle] NCHAR(100) NOT NULL, 
    [MeetingTypeId] INT NOT NULL, 
    [Scripture] NVARCHAR(1000) NOT NULL, 
    [LessonLearnedDescription] NVARCHAR(1000) NOT NULL, 
    [PKIdtblMeetingAssemblies] AS CONCAT(CONVERT(VARCHAR,[Id]),'tblMeetingAssemblies'),
    [IsDeleted] BIT NOT NULL DEFAULT 0,
    CONSTRAINT [FK_tblMeetingAssemblies_tblMeetingType] FOREIGN KEY ([MeetingTypeId]) REFERENCES [tblMeetingType]([Id])
)
