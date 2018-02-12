namespace EnlightEdu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnlightEduDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        RegistrationNo = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        Contacts = c.String(),
                        DepartmentId = c.Int(nullable: false),
                        Departments_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.Departments_Id)
                .Index(t => t.Departments_Id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubjectAndStudentRelations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.SubjectsStudents",
                c => new
                    {
                        Subjects_Id = c.Int(nullable: false),
                        Students_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Subjects_Id, t.Students_Id })
                .ForeignKey("dbo.Subjects", t => t.Subjects_Id, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Students_Id, cascadeDelete: true)
                .Index(t => t.Subjects_Id)
                .Index(t => t.Students_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubjectAndStudentRelations", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.SubjectAndStudentRelations", "StudentId", "dbo.Students");
            DropForeignKey("dbo.SubjectsStudents", "Students_Id", "dbo.Students");
            DropForeignKey("dbo.SubjectsStudents", "Subjects_Id", "dbo.Subjects");
            DropForeignKey("dbo.Students", "Departments_Id", "dbo.Departments");
            DropIndex("dbo.SubjectsStudents", new[] { "Students_Id" });
            DropIndex("dbo.SubjectsStudents", new[] { "Subjects_Id" });
            DropIndex("dbo.SubjectAndStudentRelations", new[] { "SubjectId" });
            DropIndex("dbo.SubjectAndStudentRelations", new[] { "StudentId" });
            DropIndex("dbo.Students", new[] { "Departments_Id" });
            DropTable("dbo.SubjectsStudents");
            DropTable("dbo.SubjectAndStudentRelations");
            DropTable("dbo.Subjects");
            DropTable("dbo.Students");
            DropTable("dbo.Departments");
        }
    }
}
