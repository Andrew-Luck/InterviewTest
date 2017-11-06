CREATE TABLE [dbo].[ExchangeRateCache]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY , 
    [FromCurrencyId] UNIQUEIDENTIFIER NOT NULL, 
    [Value] DECIMAL(18, 6) NOT NULL, 
    [ToCurrencyId] UNIQUEIDENTIFIER NOT NULL, 
    [DateCreated] DATETIMEOFFSET NOT NULL DEFAULT GETDATE(), 
    [IsDeleted] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [UK_CurrencyLinks] UNIQUE ([FromCurrencyId], [ToCurrencyId]), 
    CONSTRAINT [FK_ExchangeRateCache_FromCurrencyId_CurrencyId] FOREIGN KEY ([FromCurrencyId]) REFERENCES [Currency]([Id]), 
    CONSTRAINT [FK_ExchangeRateCache_ToCurrencyId_CurrencyId] FOREIGN KEY ([ToCurrencyId]) REFERENCES [Currency]([Id])
)
