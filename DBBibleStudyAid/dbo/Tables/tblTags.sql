﻿CREATE TABLE [dbo].[tblTags]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TagName] NVARCHAR(100) NOT NULL, 
    [TagDescription] NVARCHAR(1000) NULL, 
    [TagCreatedDate] DATETIME2 NOT NULL DEFAULT getutcdate()
)
