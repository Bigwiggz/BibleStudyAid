CREATE TABLE [dbo].[tblTalks]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TalkTitle] NVARCHAR(100) NOT NULL, 
    [CreatedDate] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [DateGiven] DATETIME2 NOT NULL,  
    [MeetingTypeId] INT NOT NULL, 
    [Description] NVARCHAR(1000) NOT NULL, 
    [TalkDocument] VARBINARY(MAX) NOT NULL, 
    [ThemeScripture] NVARCHAR(1000) NULL, 
    [FKIdtblTalks] AS CONCAT(CONVERT(VARCHAR,[Id]),'tblTalks'), 
    CONSTRAINT [FK_tblTalks_tblMeetingType] FOREIGN KEY ([MeetingTypeId]) REFERENCES [tblMeetingType]([Id])
)