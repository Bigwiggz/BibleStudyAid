﻿CREATE TABLE [dbo].[tblScriptures]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Scripture] NVARCHAR(1000) NOT NULL,
    [Book] NVARCHAR(1000) NOT NULL,
    [Chapter] NVARCHAR(3),
    [Verse] NVARCHAR(1000) NOT NULL,
    [UniqueId] UNIQUEIDENTIFIER NOT NULL DEFAULT newId(), 
    [FKTableIdandName] NVARCHAR(1000) NOT NULL
)
