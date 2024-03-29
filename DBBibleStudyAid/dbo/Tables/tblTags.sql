﻿CREATE TABLE [dbo].[tblTags]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TagName] NVARCHAR(100) NOT NULL, 
    [TagDescription] NVARCHAR(1000) NULL,
    [TagColor] NVARCHAR(7) NULL,
    [TagTextColor] NVARCHAR(7) NULL,
    [IsDeleted] BIT NOT NULL DEFAULT 0,
    [TagCreatedDate] DATETIME2 NOT NULL DEFAULT getutcdate()
)
