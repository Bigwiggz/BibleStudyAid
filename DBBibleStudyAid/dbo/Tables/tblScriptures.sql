﻿CREATE TABLE [dbo].[tblScriptures]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Scripture] NVARCHAR(1000) NOT NULL,
    [Book] NVARCHAR(1000) NOT NULL,
    [Chapter] NVARCHAR(3) NULL,
    [Verse] NVARCHAR(1000) NOT NULL,
    [UniqueId] UNIQUEIDENTIFIER NOT NULL DEFAULT newId(), 
    [FKTableIdandName] NVARCHAR(1000) NOT NULL,
    [Description] NVARCHAR(2500) NULL,
    [DateUpdated] DATETIME2 NOT NULL DEFAULT getutcdate(),
    [IsDeleted] BIT NOT NULL DEFAULT 0
)
