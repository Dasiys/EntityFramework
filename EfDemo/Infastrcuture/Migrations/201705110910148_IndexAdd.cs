namespace Infastrcuture.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IndexAdd : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Students", "Id", unique: true, name: "Student_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Students", "Student_Id");
        }
    }
}
