CREATE TABLE [dbo].[ExchangeRateHistory]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), 
    [FromCurrencyId] UNIQUEIDENTIFIER NOT NULL, 
    [ToCurrencyId] UNIQUEIDENTIFIER NOT NULL, 
    [Value] MONEY NOT NULL, 
    [DateCreated] DATETIMEOFFSET NOT NULL DEFAULT GETDATE(), 
    [IsDeleted] BIT NOT NULL DEFAULT 0,
	CONSTRAINT [FK_ExchangeRateHistory_FromCurrencyId_CurrencyId] FOREIGN KEY ([FromCurrencyId]) REFERENCES [Currency]([Id]), 
    CONSTRAINT [FK_ExchangeRateHistory_ToCurrencyId_CurrencyId] FOREIGN KEY ([ToCurrencyId]) REFERENCES [Currency]([Id])
)
