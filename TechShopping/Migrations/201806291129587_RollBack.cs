namespace TechShopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RollBack : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CartItems", "ProductId", "dbo.Products");
            DropIndex("dbo.CartItems", new[] { "ProductId" });
            DropTable("dbo.CartItems");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CartItems",
                c => new
                    {
                        ItemId = c.String(nullable: false, maxLength: 128),
                        CartId = c.String(),
                        Quantity = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId);
            
            CreateIndex("dbo.CartItems", "ProductId");
            AddForeignKey("dbo.CartItems", "ProductId", "dbo.Products", "ProductID", cascadeDelete: true);
        }
    }
}
