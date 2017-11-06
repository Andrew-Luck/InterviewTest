namespace Makuru.DatabaseStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _000 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CompletedTransactions", "Discount", c => c.Decimal(nullable: false, precision: 18, scale: 8));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CompletedTransactions", "Discount");
        }
    }
}
