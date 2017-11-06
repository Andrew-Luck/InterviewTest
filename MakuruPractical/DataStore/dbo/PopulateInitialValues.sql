/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

DECLARE @ZarId UNIQUEIDENTIFIER
DECLARE @UsdId UNIQUEIDENTIFIER
DECLARE @GbpId UNIQUEIDENTIFIER
DECLARE @EurId UNIQUEIDENTIFIER
DECLARE @KesId UNIQUEIDENTIFIER

IF NOT EXISTS (SELECT 1 FROM [dbo].[Currency] WHERE Code = 'ZAR')
BEGIN 
	SET @ZarId = NEWID();
	INSERT INTO [dbo].[Currency]
	(
		[Id],
		[Code],
		[Description],
		[IsoCode]
	)
	VALUES
	(
		@ZarId,
		'ZAR',
		'South African Rand',
		'710'
	)
END
ELSE
BEGIN
	SELECT @ZarId = Id FROM Currency WHERE Code = 'ZAR'
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[Currency] WHERE Code = 'USD')
BEGIN 
	SET @UsdId = NEWID();
	INSERT INTO [dbo].[Currency]
	(
		[Id],
		[Code],
		[Description],
		[IsoCode]
	)
	VALUES
	(
		@UsdId,
		'USD',
		'United States Dollar',
		'840'
	)
END
ELSE
BEGIN
	SELECT @UsdId = Id FROM Currency WHERE Code = 'USD'
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[Currency] WHERE Code = 'GBP')
BEGIN 
	SET @GbpId = NEWID();
	INSERT INTO [dbo].[Currency]
	(
		[Id],
		[Code],
		[Description],
		[IsoCode]
	)
	VALUES
	(
		@GbpId,
		'GBP',
		'Pound Sterling',
		'826'
	)
END
ELSE
BEGIN
	SELECT @GbpId = Id FROM Currency WHERE Code = 'GBP'
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[Currency] WHERE Code = 'EUR')
BEGIN 
	SET @EurId = NEWID();
	INSERT INTO [dbo].[Currency]
	(
		[Id],
		[Code],
		[Description],
		[IsoCode]
	)
	VALUES
	(
		@EurId,
		'EUR',
		'Euro',
		'978'
	)
END
ELSE
BEGIN
	SELECT @EurId = Id FROM Currency WHERE Code = 'EUR'
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[Currency] WHERE Code = 'KES')
BEGIN 
	SET @KesId = NEWID();
	INSERT INTO [dbo].[Currency]
	(
		[Id],
		[Code],
		[Description],
		[IsoCode]
	)
	VALUES
	(
		@KesId,
		'KES',
		'Kenyan shilling',
		'404'
	)
END
ELSE
BEGIN
	SELECT @KesId = Id FROM Currency WHERE Code = 'KES'
END


