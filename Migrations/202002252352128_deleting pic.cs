namespace PpWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletingpic : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Furnitures", "HasPic");
            DropColumn("dbo.Furnitures", "PicExtension");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Furnitures", "PicExtension", c => c.String());
            AddColumn("dbo.Furnitures", "HasPic", c => c.Int(nullable: false));
        }
    }
}
