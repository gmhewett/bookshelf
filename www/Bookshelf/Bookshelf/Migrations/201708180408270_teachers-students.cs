namespace Bookshelf.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teachersstudents : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "LibraryId", "dbo.Libraries");
            DropIndex("dbo.Libraries", new[] { "Owner_Id" });
            DropColumn("dbo.Libraries", "OwnerId");
            RenameColumn(table: "dbo.Libraries", name: "Owner_Id", newName: "OwnerId");
            CreateTable(
                "dbo.LibraryStudents",
                c => new
                    {
                        Library_Id = c.Int(nullable: false),
                        Student_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Library_Id, t.Student_Id })
                .ForeignKey("dbo.Libraries", t => t.Library_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.Student_Id, cascadeDelete: true)
                .Index(t => t.Library_Id)
                .Index(t => t.Student_Id);
            
            AddColumn("dbo.AspNetUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Libraries", "OwnerId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Libraries", "OwnerId");
            AddForeignKey("dbo.Books", "LibraryId", "dbo.Libraries", "Id");
            DropColumn("dbo.AspNetUsers", "LibraryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "LibraryId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Books", "LibraryId", "dbo.Libraries");
            DropForeignKey("dbo.LibraryStudents", "Student_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.LibraryStudents", "Library_Id", "dbo.Libraries");
            DropIndex("dbo.LibraryStudents", new[] { "Student_Id" });
            DropIndex("dbo.LibraryStudents", new[] { "Library_Id" });
            DropIndex("dbo.Libraries", new[] { "OwnerId" });
            AlterColumn("dbo.Libraries", "OwnerId", c => c.String());
            DropColumn("dbo.AspNetUsers", "Discriminator");
            DropTable("dbo.LibraryStudents");
            RenameColumn(table: "dbo.Libraries", name: "OwnerId", newName: "Owner_Id");
            AddColumn("dbo.Libraries", "OwnerId", c => c.String());
            CreateIndex("dbo.Libraries", "Owner_Id");
            AddForeignKey("dbo.Books", "LibraryId", "dbo.Libraries", "Id", cascadeDelete: true);
        }
    }
}
