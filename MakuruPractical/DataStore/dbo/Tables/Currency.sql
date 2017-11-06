CREATE TABLE [dbo].[Currency] (
    [Id]          UNIQUEIDENTIFIER CONSTRAINT [DF_Currency_Id] DEFAULT (newid()) NOT NULL,
    [Code]        VARCHAR (10)     NOT NULL,
    [Description] VARCHAR (100)    NOT NULL,
    [ISOCode]     VARCHAR (10)     NOT NULL,
    [IsDeleted]   BIT              CONSTRAINT [DF_Currency_IsDeleted] DEFAULT ((0)) NOT NULL,
    [DateCreated] DATETIMEOFFSET NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [PK_Currency] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UX_CurrencyCode] UNIQUE NONCLUSTERED ([Code] ASC)
);

