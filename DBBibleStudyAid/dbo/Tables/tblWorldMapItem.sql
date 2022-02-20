CREATE TABLE [dbo].[tblWorldMapItem]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FKTableIdandName] NVARCHAR(1000) NOT NULL,
    [UpdatedDate] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [Description] NVARCHAR(1000) NULL, 
    [Title] NVARCHAR(255) NOT NULL, 
    [GeographyData] [sys].[geography] NOT NULL, 
    [Color] NVARCHAR(7) NOT NULL, 
    [Guid] UNIQUEIDENTIFIER NOT NULL DEFAULT newid(), 
    [GeographyType] NCHAR(255) NOT NULL, 
    [IsDeleted] BIT NOT NULL DEFAULT 0,
)
