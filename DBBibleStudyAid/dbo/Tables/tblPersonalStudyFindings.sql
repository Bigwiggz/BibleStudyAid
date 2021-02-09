CREATE TABLE [dbo].[tblPersonalStudyFindings]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Scripture] NVARCHAR(1000) NULL, 
    [Explanation] NVARCHAR(1000) NOT NULL, 
    [FKIdtblPersonalStudyFindings] AS CONCAT(CONVERT(VARCHAR,[Id]),'tblPersonalStudyFindings'), 
    [FKPersonalStudyProjectId] INT NOT NULL, 
    CONSTRAINT [FK_tblPersonalStudyFindings_ToTable] FOREIGN KEY ([FKPersonalStudyProjectId]) REFERENCES [tblPersonalStudyProjects]([Id])
)
