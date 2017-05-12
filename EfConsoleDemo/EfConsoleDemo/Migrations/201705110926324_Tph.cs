namespace EfConsoleDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tph : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Age", c => c.Int());
            AddColumn("dbo.User", "School", c => c.String());
            AddColumn("dbo.User", "Type", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "Type");
            DropColumn("dbo.User", "School");
            DropColumn("dbo.User", "Age");
        }
    }
}
