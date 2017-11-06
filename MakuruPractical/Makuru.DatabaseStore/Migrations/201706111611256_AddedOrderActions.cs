namespace Makuru.DatabaseStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOrderActions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderActions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        OrderActionId = c.Int(nullable: false),
                        Value = c.String(),
                        CurrencyId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Currency", t => t.CurrencyId, cascadeDelete: true)
                .Index(t => t.CurrencyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderActions", "CurrencyId", "dbo.Currency");
            DropIndex("dbo.OrderActions", new[] { "CurrencyId" });
            DropTable("dbo.OrderActions");
        }
    }
}
