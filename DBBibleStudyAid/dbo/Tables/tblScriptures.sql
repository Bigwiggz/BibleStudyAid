﻿CREATE TABLE [dbo].[tblScriptures]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Scripture] NVARCHAR(1000) NOT NULL,
    [Book] NVARCHAR(1000) NOT NULL,
    [Chapter] NVARCHAR(3) NULL,
    [Verse] NVARCHAR(1000) NOT NULL,
    [UniqueId] UNIQUEIDENTIFIER NOT NULL DEFAULT newId(), 
    [FKTableIdandName] NVARCHAR(1000) NOT NULL,
    [Description] NVARCHAR(2500) NULL,
    [IsDeleted] BIT NOT NULL DEFAULT 0
)
