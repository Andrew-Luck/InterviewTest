CREATE TABLE [dbo].[CompletedTransactions]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), 
    [ExchangeRateId] UNIQUEIDENTIFIER NOT NULL, 
    [ForeignValue] MONEY NOT NULL, 
    [LocalValue] MONEY NOT NULL, 
    [DateCreated] DATETIMEOFFSET NOT NULL DEFAULT GETDATE(), 
    [IsDeleted] BIT NOT NULL DEFAULT 0, 
    [SurchargeId] UNIQUEIDENTIFIER NULL, 
    [SurchargeAmount] MONEY NULL, 
    CONSTRAINT [FK_CompletedTransactions_ExhangeRateHistory] FOREIGN KEY ([ExchangeRateId]) REFERENCES [ExchangeRateHistory]([Id]), 
    CONSTRAINT [FK_CompletedTransactions_Surcharge_SurchargeId] FOREIGN KEY ([SurchargeId]) REFERENCES [Surcharge]([Id])
)
