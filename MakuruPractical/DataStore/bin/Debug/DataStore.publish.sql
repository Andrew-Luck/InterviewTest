﻿/*
Deployment script for Makuru

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "Makuru"
:setvar DefaultFilePrefix "Makuru"
:setvar DefaultDataPath "D:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\"
:setvar DefaultLogPath "D:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\"

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
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                RECOVERY FULL 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET PAGE_VERIFY NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Rename refactoring operation with key f88b70f0-31e0-484b-a52d-0e004d6577cb is skipped, element [dbo].[ExchangeRateCache].[CurrencyId] (SqlSimpleColumn) will not be renamed to FromCurrencyId';


GO
PRINT N'Rename refactoring operation with key 8d9d801f-4422-46a0-8b34-7396882e876c is skipped, element [dbo].[Table1].[IsDel] (SqlSimpleColumn) will not be renamed to IsDeleted';


GO
PRINT N'Rename refactoring operation with key 574dcf78-9e36-40f9-8e19-a5a6a8d73312 is skipped, element [dbo].[FK_FromCurrencyId_CurrencyId] (SqlForeignKeyConstraint) will not be renamed to [FK_ExchangeRateCache_FromCurrencyId_CurrencyId]';


GO
PRINT N'Rename refactoring operation with key bf15635d-0c91-4d8b-8e7e-3f3c71ffc14e is skipped, element [dbo].[FK_ExchangeRateCache_ToTable] (SqlForeignKeyConstraint) will not be renamed to [FK_ExchangeRateCache_ToCurrencyId_CurrencyId]';


GO
PRINT N'Creating [dbo].[ExchangeRateCache]...';


GO
CREATE TABLE [dbo].[ExchangeRateCache] (
    [Id]             UNIQUEIDENTIFIER   NOT NULL,
    [FromCurrencyId] UNIQUEIDENTIFIER   NOT NULL,
    [Value]          MONEY              NOT NULL,
    [ToCurrencyId]   UNIQUEIDENTIFIER   NOT NULL,
    [ModifiedDate]   DATETIMEOFFSET (7) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UK_CurrencyLinks] UNIQUE NONCLUSTERED ([FromCurrencyId] ASC, [ToCurrencyId] ASC)
);


GO
PRINT N'Creating [dbo].[ExchangeRateHistory]...';


GO
CREATE TABLE [dbo].[ExchangeRateHistory] (
    [Id]             UNIQUEIDENTIFIER   NOT NULL,
    [FromCurrencyId] UNIQUEIDENTIFIER   NOT NULL,
    [ToCurrencyId]   UNIQUEIDENTIFIER   NOT NULL,
    [Value]          MONEY              NOT NULL,
    [DateCreated]    DATETIMEOFFSET (7) NOT NULL,
    [IsDeleted]      BIT                NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating unnamed constraint on [dbo].[ExchangeRateCache]...';


GO
ALTER TABLE [dbo].[ExchangeRateCache]
    ADD DEFAULT NEWID() FOR [Id];


GO
PRINT N'Creating unnamed constraint on [dbo].[ExchangeRateCache]...';


GO
ALTER TABLE [dbo].[ExchangeRateCache]
    ADD DEFAULT GETDATE() FOR [ModifiedDate];


GO
PRINT N'Creating unnamed constraint on [dbo].[ExchangeRateHistory]...';


GO
ALTER TABLE [dbo].[ExchangeRateHistory]
    ADD DEFAULT NEWID() FOR [Id];


GO
PRINT N'Creating unnamed constraint on [dbo].[ExchangeRateHistory]...';


GO
ALTER TABLE [dbo].[ExchangeRateHistory]
    ADD DEFAULT GETDATE() FOR [DateCreated];


GO
PRINT N'Creating unnamed constraint on [dbo].[ExchangeRateHistory]...';


GO
ALTER TABLE [dbo].[ExchangeRateHistory]
    ADD DEFAULT 0 FOR [IsDeleted];


GO
PRINT N'Creating [dbo].[FK_ExchangeRateCache_FromCurrencyId_CurrencyId]...';


GO
ALTER TABLE [dbo].[ExchangeRateCache] WITH NOCHECK
    ADD CONSTRAINT [FK_ExchangeRateCache_FromCurrencyId_CurrencyId] FOREIGN KEY ([FromCurrencyId]) REFERENCES [dbo].[Currency] ([Id]);


GO
PRINT N'Creating [dbo].[FK_ExchangeRateCache_ToCurrencyId_CurrencyId]...';


GO
ALTER TABLE [dbo].[ExchangeRateCache] WITH NOCHECK
    ADD CONSTRAINT [FK_ExchangeRateCache_ToCurrencyId_CurrencyId] FOREIGN KEY ([ToCurrencyId]) REFERENCES [dbo].[Currency] ([Id]);


GO
PRINT N'Creating [dbo].[FK_ExchangeRateHistory_FromCurrencyId_CurrencyId]...';


GO
ALTER TABLE [dbo].[ExchangeRateHistory] WITH NOCHECK
    ADD CONSTRAINT [FK_ExchangeRateHistory_FromCurrencyId_CurrencyId] FOREIGN KEY ([FromCurrencyId]) REFERENCES [dbo].[Currency] ([Id]);


GO
PRINT N'Creating [dbo].[FK_ExchangeRateHistory_ToCurrencyId_CurrencyId]...';


GO
ALTER TABLE [dbo].[ExchangeRateHistory] WITH NOCHECK
    ADD CONSTRAINT [FK_ExchangeRateHistory_ToCurrencyId_CurrencyId] FOREIGN KEY ([ToCurrencyId]) REFERENCES [dbo].[Currency] ([Id]);


GO
-- Refactoring step to update target server with deployed transaction logs

IF OBJECT_ID(N'dbo.__RefactorLog') IS NULL
BEGIN
    CREATE TABLE [dbo].[__RefactorLog] (OperationKey UNIQUEIDENTIFIER NOT NULL PRIMARY KEY)
    EXEC sp_addextendedproperty N'microsoft_database_tools_support', N'refactoring log', N'schema', N'dbo', N'table', N'__RefactorLog'
END
GO
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'f88b70f0-31e0-484b-a52d-0e004d6577cb')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('f88b70f0-31e0-484b-a52d-0e004d6577cb')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '8d9d801f-4422-46a0-8b34-7396882e876c')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('8d9d801f-4422-46a0-8b34-7396882e876c')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '574dcf78-9e36-40f9-8e19-a5a6a8d73312')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('574dcf78-9e36-40f9-8e19-a5a6a8d73312')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'bf15635d-0c91-4d8b-8e7e-3f3c71ffc14e')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('bf15635d-0c91-4d8b-8e7e-3f3c71ffc14e')

GO

GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[ExchangeRateCache] WITH CHECK CHECK CONSTRAINT [FK_ExchangeRateCache_FromCurrencyId_CurrencyId];

ALTER TABLE [dbo].[ExchangeRateCache] WITH CHECK CHECK CONSTRAINT [FK_ExchangeRateCache_ToCurrencyId_CurrencyId];

ALTER TABLE [dbo].[ExchangeRateHistory] WITH CHECK CHECK CONSTRAINT [FK_ExchangeRateHistory_FromCurrencyId_CurrencyId];

ALTER TABLE [dbo].[ExchangeRateHistory] WITH CHECK CHECK CONSTRAINT [FK_ExchangeRateHistory_ToCurrencyId_CurrencyId];


GO
PRINT N'Update complete.';


GO
