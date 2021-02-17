CREATE TYPE [dbo].[TagsToOtherTablesType] AS TABLE
(
    [TagsId] INT, 
    [tblId] INT,  
    [FKTableIdandName] NVARCHAR(1000)
)
