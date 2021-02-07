CREATE TABLE [dbo].[tblScriptures]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Scripture] NVARCHAR(1000) NOT NULL, 
    [UniqueId] UNIQUEIDENTIFIER NOT NULL DEFAULT newId(), 
    [FKTableIdandName] NVARCHAR(1000) NOT NULL
)
