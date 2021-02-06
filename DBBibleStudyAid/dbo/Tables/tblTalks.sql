CREATE TABLE [dbo].[tblTalks]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TalkTitle] NVARCHAR(100) NOT NULL, 
    [CreatedDate] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [DateGiven] DATETIME2 NOT NULL,  
    [MeetingTypeId] INT NOT NULL, 
    [Description] NVARCHAR(1000) NOT NULL, 
    [TalkDocument] VARBINARY(MAX) NOT NULL, 
    [Theme Scripture] NVARCHAR(1000) NULL, 
    [ReferenceId] INT NULL, 
    [FKIdtblTalks] AS CONCAT(CAST([Id] AS VARCHAR),'tblTalks'), 
    CONSTRAINT [FK_tblTalks_tblReferences] FOREIGN KEY ([ReferenceId]) REFERENCES [tblReferences]([Id]), 
    CONSTRAINT [FK_tblTalks_tblMeetingType] FOREIGN KEY ([MeetingTypeId]) REFERENCES [tblMeetingType]([Id])
)