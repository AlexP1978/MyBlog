namespace MyBlog3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Articles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "DataComment", c => c.DateTime(nullable: false));
            AddColumn("dbo.Articles", "AuthorComments", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Articles", "AuthorComments");
            DropColumn("dbo.Articles", "DataComment");
        }
    }
}
