CREATE TABLE [dbo].[tblTalks]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TalkTitle] NVARCHAR(100) NOT NULL, 
    [CreatedDate] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [DateGiven] DATETIME2 NOT NULL,  
    [MeetingTypeId] INT NOT NULL, 
    [Description] NVARCHAR(1000) NOT NULL, 
    [TalkDocumentName] NVARCHAR(256) NOT NULL,
    [ThemeScripture] NVARCHAR(1000) NULL, 
    [PKIdtblTalks] AS CONCAT(CONVERT(VARCHAR,[Id]),'tblTalks'), 
    [IsDeleted] BIT NOT NULL DEFAULT 0,
    CONSTRAINT [FK_tblTalks_tblMeetingType] FOREIGN KEY ([MeetingTypeId]) REFERENCES [tblMeetingType]([Id])
)