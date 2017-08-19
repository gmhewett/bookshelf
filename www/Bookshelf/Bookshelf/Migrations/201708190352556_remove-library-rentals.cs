namespace Bookshelf.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removelibraryrentals : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rentals", "Library_Id", "dbo.Libraries");
            DropIndex("dbo.Rentals", new[] { "Library_Id" });
            DropColumn("dbo.Rentals", "Library_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rentals", "Library_Id", c => c.Int());
            CreateIndex("dbo.Rentals", "Library_Id");
            AddForeignKey("dbo.Rentals", "Library_Id", "dbo.Libraries", "Id");
        }
    }
}
