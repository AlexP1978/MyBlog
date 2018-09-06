namespace MyBlog3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Article : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Articles", "DataTxt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Articles", "DataTxt", c => c.String());
        }
    }
}
