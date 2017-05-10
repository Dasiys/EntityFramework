namespace Infastrcuture.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreates : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                        Score = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        No = c.String(),
                        FlowerNum = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        No = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentSubjectMap",
                c => new
                    {
                        StundetId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StundetId, t.SubjectId })
                .ForeignKey("dbo.Students", t => t.StundetId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.StundetId)
                .Index(t => t.SubjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Grades", "StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentSubjectMap", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.StudentSubjectMap", "StundetId", "dbo.Students");
            DropForeignKey("dbo.Grades", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.StudentSubjectMap", new[] { "SubjectId" });
            DropIndex("dbo.StudentSubjectMap", new[] { "StundetId" });
            DropIndex("dbo.Grades", new[] { "SubjectId" });
            DropIndex("dbo.Grades", new[] { "StudentId" });
            DropTable("dbo.StudentSubjectMap");
            DropTable("dbo.Subjects");
            DropTable("dbo.Students");
            DropTable("dbo.Grades");
        }
    }
}
