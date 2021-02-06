CREATE TABLE [dbo].[tblPersonalStudyFindings]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Scripture] NVARCHAR(1000) NULL, 
    [Explanation] NVARCHAR(1000) NOT NULL, 
    [ReferenceId] INT NULL, 
    [FKIdtblPersonalStudyFindings] AS CONCAT(CAST([Id] AS VARCHAR),'tblPersonalStudyFindings'), 
    CONSTRAINT [FK_tblPersonalStudyFindings_tblReferences] FOREIGN KEY ([ReferenceId]) REFERENCES [tblReferences]([Id])
)
