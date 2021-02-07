CREATE TABLE [dbo].[tblMeetingAssemblies]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CreatedDate] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [DateOfMeeting] DATETIME2 NOT NULL, 
    [PartTitle] NCHAR(100) NOT NULL, 
    [MeetingTypeId] INT NOT NULL, 
    [Scripture] NVARCHAR(1000) NOT NULL, 
    [ReferenceId] INT NULL, 
    [LessonLearnedDescription] NVARCHAR(1000) NOT NULL, 
    [FKIdtblMeetingAssemblies] AS CONCAT(CONVERT(VARCHAR,[Id]),'tblMeetingAssemblies'), 
    CONSTRAINT [FK_tblMeetingAssemblies_tblReferences] FOREIGN KEY ([ReferenceId]) REFERENCES [tblReferences]([Id]),
    CONSTRAINT [FK_tblMeetingAssemblies_tblMeetingType] FOREIGN KEY ([MeetingTypeId]) REFERENCES [tblMeetingType]([Id])
)
