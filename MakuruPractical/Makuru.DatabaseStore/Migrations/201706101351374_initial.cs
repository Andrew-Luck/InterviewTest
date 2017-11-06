namespace Makuru.DatabaseStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompletedTransactions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ExchangeRateId = c.Guid(nullable: false),
                        SurchargeId = c.Guid(nullable: false),
                        ForeignValue = c.Decimal(nullable: false, precision: 18, scale: 8),
                        LocalValue = c.Decimal(nullable: false, precision: 18, scale: 8),
                        DateCreated = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExchangeRateHistories", t => t.ExchangeRateId, cascadeDelete: false)
                .ForeignKey("dbo.Surcharges", t => t.SurchargeId, cascadeDelete: false)
                .Index(t => t.ExchangeRateId)
                .Index(t => t.SurchargeId);
            
            CreateTable(
                "dbo.ExchangeRateHistories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FromCurrencyId = c.Guid(nullable: false),
                        ToCurrencyId = c.Guid(nullable: false),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 8),
                        DateCreated = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Currency", t => t.FromCurrencyId, cascadeDelete: false)
                .ForeignKey("dbo.Currency", t => t.ToCurrencyId, cascadeDelete: false)
                .Index(t => t.FromCurrencyId)
                .Index(t => t.ToCurrencyId);
            
            CreateTable(
                "dbo.Currency",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(),
                        Description = c.String(),
                        ISOCode = c.String(),
                        DateCreated = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Surcharges",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CurrencyId = c.Guid(nullable: false),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 8),
                        DateCreated = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Currency", t => t.CurrencyId, cascadeDelete: false)
                .Index(t => t.CurrencyId);
            
            CreateTable(
                "dbo.ExchangeRateCaches",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FromCurrencyId = c.Guid(nullable: false),
                        ToCurrencyId = c.Guid(nullable: false),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 8),
                        DateCreated = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Currency", t => t.FromCurrencyId, cascadeDelete: false)
                .ForeignKey("dbo.Currency", t => t.ToCurrencyId, cascadeDelete: false)
                .Index(t => t.FromCurrencyId)
                .Index(t => t.ToCurrencyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExchangeRateCaches", "ToCurrencyId", "dbo.Currency");
            DropForeignKey("dbo.ExchangeRateCaches", "FromCurrencyId", "dbo.Currency");
            DropForeignKey("dbo.CompletedTransactions", "SurchargeId", "dbo.Surcharges");
            DropForeignKey("dbo.Surcharges", "CurrencyId", "dbo.Currency");
            DropForeignKey("dbo.CompletedTransactions", "ExchangeRateId", "dbo.ExchangeRateHistories");
            DropForeignKey("dbo.ExchangeRateHistories", "ToCurrencyId", "dbo.Currency");
            DropForeignKey("dbo.ExchangeRateHistories", "FromCurrencyId", "dbo.Currency");
            DropIndex("dbo.ExchangeRateCaches", new[] { "ToCurrencyId" });
            DropIndex("dbo.ExchangeRateCaches", new[] { "FromCurrencyId" });
            DropIndex("dbo.Surcharges", new[] { "CurrencyId" });
            DropIndex("dbo.ExchangeRateHistories", new[] { "ToCurrencyId" });
            DropIndex("dbo.ExchangeRateHistories", new[] { "FromCurrencyId" });
            DropIndex("dbo.CompletedTransactions", new[] { "SurchargeId" });
            DropIndex("dbo.CompletedTransactions", new[] { "ExchangeRateId" });
            DropTable("dbo.ExchangeRateCaches");
            DropTable("dbo.Surcharges");
            DropTable("dbo.Currency");
            DropTable("dbo.ExchangeRateHistories");
            DropTable("dbo.CompletedTransactions");
        }
    }
}
