namespace Bookshelf.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Libraries : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Libraries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OwnerId = c.String(),
                        Owner_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Owner_Id)
                .Index(t => t.Owner_Id);
            
            AddColumn("dbo.Books", "LibraryId", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "LibraryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Books", "LibraryId");
            AddForeignKey("dbo.Books", "LibraryId", "dbo.Libraries", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "LibraryId", "dbo.Libraries");
            DropForeignKey("dbo.Libraries", "Owner_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Libraries", new[] { "Owner_Id" });
            DropIndex("dbo.Books", new[] { "LibraryId" });
            DropColumn("dbo.AspNetUsers", "LibraryId");
            DropColumn("dbo.Books", "LibraryId");
            DropTable("dbo.Libraries");
        }
    }
}
