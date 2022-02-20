CREATE TABLE [dbo].[tblTestGeometry]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Address] NVARCHAR(255) NOT NULL, 
    [City] NVARCHAR(255) NOT NULL, 
    [State] NCHAR(2) NOT NULL, 
    [ZipCode] NCHAR(10) NOT NULL, 
    [GeographyTestData] [sys].[geography] NOT NULL,
	
)
