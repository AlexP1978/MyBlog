namespace MyBlog3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyMigration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "DataTxt", c => c.String());
            AddColumn("dbo.Articles", "Category", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Articles", "Category");
            DropColumn("dbo.Articles", "DataTxt");
        }
    }
}
