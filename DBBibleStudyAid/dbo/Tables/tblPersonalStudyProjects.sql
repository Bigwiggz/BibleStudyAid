CREATE TABLE [dbo].[tblPersonalStudyProjects]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CreatedDate] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [PersonalStudyTitle] NVARCHAR(100) NOT NULL, 
    [PersonalStudyDescription] NVARCHAR(1000) NOT NULL, 
    [PersonalStudyQuestionAssignment] NVARCHAR(1000) NOT NULL, 
    [DateFinished] DATETIME2 NULL, 
    [Scripture] NVARCHAR(1000) NULL, 
    [PersonalStudyFindingsId] INT NULL, 
    CONSTRAINT [FK_tblPersonalStudyProjects_tblPersonalStudyProjects] FOREIGN KEY ([PersonalStudyFindingsId]) REFERENCES [tblPersonalStudyFindings]([Id])
)
