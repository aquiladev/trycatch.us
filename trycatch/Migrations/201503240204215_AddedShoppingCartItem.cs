namespace trycatch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedShoppingCartItem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShoppingCartItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        ArticleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Article", t => t.ArticleId, cascadeDelete: true)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.ArticleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingCartItem", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.ShoppingCartItem", "ArticleId", "dbo.Article");
            DropIndex("dbo.ShoppingCartItem", new[] { "ArticleId" });
            DropIndex("dbo.ShoppingCartItem", new[] { "CustomerId" });
            DropTable("dbo.ShoppingCartItem");
        }
    }
}
