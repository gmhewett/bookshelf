namespace Bookshelf.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rentals : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        Student_Id = c.String(nullable: false, maxLength: 128),
                        Library_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId)
                .ForeignKey("dbo.AspNetUsers", t => t.Student_Id)
                .ForeignKey("dbo.Libraries", t => t.Library_Id)
                .Index(t => t.BookId)
                .Index(t => t.Student_Id)
                .Index(t => t.Library_Id);
            
            AddColumn("dbo.Books", "TotalCopies", c => c.Int(nullable: false));
            AddColumn("dbo.Books", "AvailableCopies", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "Library_Id", "dbo.Libraries");
            DropForeignKey("dbo.Rentals", "Student_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Rentals", "BookId", "dbo.Books");
            DropIndex("dbo.Rentals", new[] { "Library_Id" });
            DropIndex("dbo.Rentals", new[] { "Student_Id" });
            DropIndex("dbo.Rentals", new[] { "BookId" });
            DropColumn("dbo.Books", "AvailableCopies");
            DropColumn("dbo.Books", "TotalCopies");
            DropTable("dbo.Rentals");
        }
    }
}
