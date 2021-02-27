CREATE TABLE [dbo].[tblDocuments]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [FKProject] NVARCHAR(1000) NOT NULL, 
    [DocumentName] NVARCHAR(256) NOT NULL, 
    [Document] VARBINARY(MAX) NOT NULL, 
    [DateUploaded] DATETIME2 NOT NULL DEFAULT getUTCDate(), 
    [DocumentType] NVARCHAR(256) NOT NULL
)
