﻿/*
Deployment script for GestionLaboDB

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "GestionLaboDB"
:setvar DefaultFilePrefix "GestionLaboDB"
:setvar DefaultDataPath "D:\Users\m.djelouah\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB"
:setvar DefaultLogPath "D:\Users\m.djelouah\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Rename refactoring operation with key 0335198b-9700-4c2c-87e5-d603eecf1cc3 is skipped, element [dbo].[Malades].[dcf] (SqlSimpleColumn) will not be renamed to Nom';


GO
PRINT N'Rename refactoring operation with key 86e4e83c-929b-435d-a1ac-9b184a85f299 is skipped, element [dbo].[Malades].[Resultat] (SqlSimpleColumn) will not be renamed to AnalyseID';


GO
PRINT N'Creating [dbo].[Malades]...';


GO
CREATE TABLE [dbo].[Malades] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Nom]       NVARCHAR (200) NOT NULL,
    [Prenom]    NVARCHAR (200) NOT NULL,
    [Birthday]  DATETIME2 (7)  NOT NULL,
    [AnalyseID] INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
-- Refactoring step to update target server with deployed transaction logs

IF OBJECT_ID(N'dbo.__RefactorLog') IS NULL
BEGIN
    CREATE TABLE [dbo].[__RefactorLog] (OperationKey UNIQUEIDENTIFIER NOT NULL PRIMARY KEY)
    EXEC sp_addextendedproperty N'microsoft_database_tools_support', N'refactoring log', N'schema', N'dbo', N'table', N'__RefactorLog'
END
GO
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '0335198b-9700-4c2c-87e5-d603eecf1cc3')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('0335198b-9700-4c2c-87e5-d603eecf1cc3')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '86e4e83c-929b-435d-a1ac-9b184a85f299')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('86e4e83c-929b-435d-a1ac-9b184a85f299')

GO

GO
PRINT N'Update complete.';


GO
