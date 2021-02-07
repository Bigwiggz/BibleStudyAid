CREATE TABLE [dbo].[tblDailyBibleReading]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [DateTimeWhenDone] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [ScriptureStartPoint] NVARCHAR(1000) NOT NULL, 
    [ScriptureEndPoint] NVARCHAR(1000) NOT NULL, 
    [LessonLearnedDescription] NVARCHAR(1000) NOT NULL, 
    [DateRead] DATETIME2 NULL, 
    [FKIdtblDailyBibleReadings] AS CONCAT(CONVERT(VARCHAR,[Id]),'tblDailyBibleReading')
)
