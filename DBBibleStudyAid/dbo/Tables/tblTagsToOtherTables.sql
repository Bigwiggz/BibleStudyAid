CREATE TABLE [dbo].[tblTagsToOtherTables]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TagsId] INT NOT NULL,
    [TagApplicationGUID] UNIQUEIDENTIFIER NOT NULL DEFAULT newId(), 
    [FKTableIdandName] NVARCHAR(1000) NOT NULL, 
    [IsDeleted] BIT NOT NULL DEFAULT 0,
    CONSTRAINT [FK_tblTagsToOtherTables_tblTags] FOREIGN KEY ([TagsId]) REFERENCES [tblTags]([Id]) 
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'This is a created guid to uniquely identify each tag',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'tblTagsToOtherTables',
    @level2type = N'COLUMN',
    @level2name = N'TagApplicationGUID'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'This is the tag Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'tblTagsToOtherTables',
    @level2type = N'COLUMN',
    @level2name = N'TagsId'