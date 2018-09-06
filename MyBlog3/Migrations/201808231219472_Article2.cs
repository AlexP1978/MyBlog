namespace MyBlog3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Article2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArticleId = c.Int(nullable: false),
                        DataComment = c.DateTime(nullable: false),
                        Author = c.String(),
                        Comments = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Articles", "Comments");
            DropColumn("dbo.Articles", "DataComment");
            DropColumn("dbo.Articles", "AuthorComments");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Articles", "AuthorComments", c => c.String());
            AddColumn("dbo.Articles", "DataComment", c => c.DateTime(nullable: false));
            AddColumn("dbo.Articles", "Comments", c => c.String());
            DropTable("dbo.Comments");
        }
    }
}
