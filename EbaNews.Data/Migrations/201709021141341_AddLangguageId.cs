namespace EbaNews.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLangguageId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.News", "Language_Id", "dbo.Languages");
            DropIndex("dbo.News", new[] { "Language_Id" });
            RenameColumn(table: "dbo.News", name: "Language_Id", newName: "LanguageId");
            AlterColumn("dbo.News", "LanguageId", c => c.Int(nullable: false));
            CreateIndex("dbo.News", "LanguageId");
            AddForeignKey("dbo.News", "LanguageId", "dbo.Languages", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.News", "LanguageId", "dbo.Languages");
            DropIndex("dbo.News", new[] { "LanguageId" });
            AlterColumn("dbo.News", "LanguageId", c => c.Int());
            RenameColumn(table: "dbo.News", name: "LanguageId", newName: "Language_Id");
            CreateIndex("dbo.News", "Language_Id");
            AddForeignKey("dbo.News", "Language_Id", "dbo.Languages", "Id");
        }
    }
}
