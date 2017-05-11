namespace EfConsoleDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "Name", c => c.String(maxLength: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "Name", c => c.String());
        }
    }
}
