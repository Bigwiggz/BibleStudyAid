﻿CREATE TABLE [dbo].[tblReferences]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[FKTableIdandName] NVARCHAR(1000) NOT NULL,
    [Reference] NVARCHAR(1000) NOT NULL,
	[Description] NVARCHAR(2500) NULL,
	[DateUpdated] DATETIME2 NOT NULL DEFAULT getutcdate(),
	[IsDeleted] BIT NOT NULL DEFAULT 0

)
