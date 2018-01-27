namespace EbaNews.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShareCountField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.News", "ShareCount", c => c.Long(nullable: false));
            DropColumn("dbo.News", "Views");
        }
        
        public override void Down()
        {
            AddColumn("dbo.News", "Views", c => c.Long(nullable: false));
            DropColumn("dbo.News", "ShareCount");
        }
    }
}
