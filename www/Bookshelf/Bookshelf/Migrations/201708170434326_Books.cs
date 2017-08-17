namespace Bookshelf.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Books : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Publisher = c.String(),
                        PublishedDate = c.DateTime(nullable: false),
                        Isbn10 = c.String(),
                        Isbn13 = c.String(),
                        PageCount = c.Int(nullable: false),
                        MainCategory = c.String(),
                        AverageRating = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RatingsCount = c.Int(nullable: false),
                        ImageLinks_SmallThumbnail = c.String(),
                        ImageLinks_Thumbnail = c.String(),
                        ImageLinks_Small = c.String(),
                        ImageLinks_Medium = c.String(),
                        ImageLinks_Large = c.String(),
                        ImageLinks_ExtraLarge = c.String(),
                        Language = c.String(),
                        InfoLink = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Books");
        }
    }
}
