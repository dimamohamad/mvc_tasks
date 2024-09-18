namespace _18_9_2024.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ClassName = c.String(),
                        Description = c.String(),
                        TeacherID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Teacher", t => t.TeacherID, cascadeDelete: true)
                .Index(t => t.TeacherID);
            
            CreateTable(
                "dbo.Teacher",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TeacherName = c.String(nullable: false),
                        age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.StudentDetails",
                c => new
                    {
                        StudentDetailID = c.Int(nullable: false),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.StudentDetailID)
                .ForeignKey("dbo.Student", t => t.StudentDetailID)
                .Index(t => t.StudentDetailID);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        StudentDetailsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentDetails", "StudentDetailID", "dbo.Student");
            DropForeignKey("dbo.Course", "TeacherID", "dbo.Teacher");
            DropIndex("dbo.StudentDetails", new[] { "StudentDetailID" });
            DropIndex("dbo.Course", new[] { "TeacherID" });
            DropTable("dbo.Student");
            DropTable("dbo.StudentDetails");
            DropTable("dbo.Teacher");
            DropTable("dbo.Course");
        }
    }
}
