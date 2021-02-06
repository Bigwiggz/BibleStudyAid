CREATE TABLE [dbo].[tblTagsToDailyBibleReading]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TagsId] INT NOT NULL, 
    [tblId] INT NOT NULL, 
    [tblName] NVARCHAR(100) NOT NULL, 
    [TagApplicationGUID] UNIQUEIDENTIFIER NOT NULL DEFAULT newId(), 
    [FKtblIdAndName] NVARCHAR(1000) NOT NULL, 
    CONSTRAINT [FK_tblTagsToDailyBibleReading_tblTags] FOREIGN KEY ([TagsId]) REFERENCES [tblTags]([Id]) 
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'This is the name of the table applied to the tag',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'tblTagsToDailyBibleReading',
    @level2type = N'COLUMN',
    @level2name = N'tblName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'This is the id of the tag',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'tblTagsToDailyBibleReading',
    @level2type = N'COLUMN',
    @level2name = N'tblId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'This is a created guid to uniquely identify each tag',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'tblTagsToDailyBibleReading',
    @level2type = N'COLUMN',
    @level2name = N'TagApplicationGUID'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'This is the tag Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'tblTagsToDailyBibleReading',
    @level2type = N'COLUMN',
    @level2name = N'TagsId'