﻿CREATE TABLE [dbo].[Malades]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nom] NVARCHAR(200) NOT NULL, 
    [Prenom] NVARCHAR(200) NOT NULL, 
    [Birthday] DATETIME2 NOT NULL 
    
)
