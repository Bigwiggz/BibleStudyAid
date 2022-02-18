CREATE TABLE [dbo].[tblMeetingsAssemblies]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CreatedDate] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [DateOfMeeting] DATETIME2 NOT NULL, 
    [PartTitle] NCHAR(100) NOT NULL, 
    [MeetingType] INT NOT NULL, 
    [Scripture] NVARCHAR(1000) NOT NULL, 
    [LessonLearnedDescription] NVARCHAR(1000) NOT NULL, 
    [PKIdtblMeetingsAssemblies] AS CONCAT(CONVERT(VARCHAR,[Id]),'tblMeetingsAssemblies'),
    [IsDeleted] BIT NOT NULL DEFAULT 0,
    CONSTRAINT [FK_tblMeetingsAssemblies_tblMeetingType] FOREIGN KEY ([MeetingType]) REFERENCES [tblMeetingType]([Id])
)
