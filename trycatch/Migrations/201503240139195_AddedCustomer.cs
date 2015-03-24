namespace trycatch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCustomer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        HousNumber = c.String(),
                        ZipCode = c.String(),
                        City = c.String(),
                        Email = c.String(),
                        IsGuest = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Customer");
        }
    }
}
