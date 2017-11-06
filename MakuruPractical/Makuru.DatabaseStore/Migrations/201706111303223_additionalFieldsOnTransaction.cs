namespace Makuru.DatabaseStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class additionalFieldsOnTransaction : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CompletedTransactions", "ExchangeRateValue", c => c.Decimal(nullable: false, precision: 18, scale: 8));
            AddColumn("dbo.CompletedTransactions", "SurchargePercent", c => c.Decimal(nullable: false, precision: 18, scale: 8));
            AddColumn("dbo.CompletedTransactions", "SurchargeValue", c => c.Decimal(nullable: false, precision: 18, scale: 8));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CompletedTransactions", "SurchargeValue");
            DropColumn("dbo.CompletedTransactions", "SurchargePercent");
            DropColumn("dbo.CompletedTransactions", "ExchangeRateValue");
        }
    }
}
