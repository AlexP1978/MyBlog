namespace MyBlog3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Article1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "Comments", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Articles", "Comments");
        }
    }
}
