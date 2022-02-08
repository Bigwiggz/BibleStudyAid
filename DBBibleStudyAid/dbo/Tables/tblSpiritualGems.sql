CREATE TABLE [dbo].[tblSpiritualGems]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [BriefDescription] NVARCHAR(255) NULL, 
    [LongDescription] NVARCHAR(4000) NULL, 
    [DateUpdated] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [PKIdtblSpiritualGems] AS CONCAT(CONVERT(VARCHAR,[Id]),'tblSpiritualGems'),
    [IsDeleted] BIT NULL DEFAULT 0
)
