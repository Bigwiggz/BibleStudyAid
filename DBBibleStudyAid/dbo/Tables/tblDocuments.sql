CREATE TABLE [dbo].[tblDocuments]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FKTableIdandName] NVARCHAR(1000) NOT NULL, 
    [ContentType] NVARCHAR(255) NOT NULL,
    [ContentDisposition] NVARCHAR(255) NOT NULL,
    [ContentSize] BIGINT NOT NULL,
    [UniqueFileName] NVARCHAR(255) NOT NULL,
    [FileName] NVARCHAR(255) NOT NULL,
    [UniqueGUIDId] UNIQUEIDENTIFIER NOT NULL,
    [Name] NVARCHAR(255) NOT NULL,
    [DateUploaded] DATETIME2 NOT NULL DEFAULT getUTCDate(), 
    [DocumentDescription] NVARCHAR(1000) NULL, 
    [IsDeleted] BIT NOT NULL DEFAULT 0
)
