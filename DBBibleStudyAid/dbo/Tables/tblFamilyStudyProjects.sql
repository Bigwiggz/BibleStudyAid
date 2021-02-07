CREATE TABLE [dbo].[tblFamilyStudyProjects]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [DateCreated] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [DateWhenCreated] DATETIME2 NOT NULL, 
    [FamilyStudyTitle] NVARCHAR(100) NOT NULL, 
    [FamilyStudyDescription] NVARCHAR(1000) NOT NULL, 
    [FamilyStudyFindings] NVARCHAR(2000) NOT NULL, 
    [ReferenceId] INT NULL, 
    [FKIdtblFamilyStudyProjects] AS CONCAT(CONVERT(VARCHAR,[Id]),'tblFamilyStudyProjects'), 
    CONSTRAINT [FK_tblFamilyStudyProjects_tblReferences] FOREIGN KEY ([ReferenceId]) REFERENCES [tblReferences]([Id])
)
