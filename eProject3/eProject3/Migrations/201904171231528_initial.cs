namespace eProject3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AboutUs",
                c => new
                    {
                        Aid = c.Int(nullable: false, identity: true),
                        Aintroduction = c.String(nullable: false, maxLength: 500, unicode: false),
                        Aservice = c.String(nullable: false, maxLength: 500, unicode: false),
                    })
                .PrimaryKey(t => t.Aid);
            
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        ClassID = c.Int(nullable: false, identity: true),
                        ClassName = c.String(nullable: false, maxLength: 50),
                        ClassDescription = c.String(nullable: false, maxLength: 500),
                        ClassTuitionFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ClassPaymentDeadline = c.DateTime(nullable: false),
                        ClassEstimatedDuration = c.String(nullable: false, maxLength: 50),
                        ClassStartDate = c.DateTime(nullable: false),
                        ClassEndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ClassID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentRoll = c.Int(nullable: false, identity: true),
                        StudentFirstName = c.String(nullable: false, maxLength: 50),
                        StudentLastName = c.String(nullable: false, maxLength: 50),
                        StudentAddress = c.String(nullable: false, maxLength: 50),
                        StudentDOB = c.DateTime(nullable: false),
                        StudentEmail = c.String(nullable: false, maxLength: 30),
                        StudentResult = c.String(nullable: false, maxLength: 4),
                        ClassID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentRoll)
                .ForeignKey("dbo.Classes", t => t.ClassID, cascadeDelete: true)
                .Index(t => t.ClassID);
            
            CreateTable(
                "dbo.CourseStudents",
                c => new
                    {
                        CourseID = c.Int(nullable: false),
                        StudentRoll = c.Int(nullable: false),
                        LabFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.CourseID, t.StudentRoll })
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentRoll, cascadeDelete: true)
                .Index(t => t.CourseID)
                .Index(t => t.StudentRoll);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        CourseName = c.String(nullable: false, maxLength: 50, unicode: false),
                        CourseDescription = c.String(nullable: false, maxLength: 500, unicode: false),
                        CourseDuration = c.String(nullable: false, maxLength: 50, unicode: false),
                        CourseStartDate = c.DateTime(nullable: false),
                        CourseEndDate = c.DateTime(nullable: false),
                        CourseImage = c.String(),
                    })
                .PrimaryKey(t => t.CourseID);
            
            CreateTable(
                "dbo.EntranceExamResults",
                c => new
                    {
                        StudentRoll = c.Int(nullable: false),
                        EntranceExamID = c.Int(nullable: false),
                        Mark = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.StudentRoll, t.EntranceExamID })
                .ForeignKey("dbo.EntranceExams", t => t.EntranceExamID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentRoll, cascadeDelete: true)
                .Index(t => t.StudentRoll)
                .Index(t => t.EntranceExamID);
            
            CreateTable(
                "dbo.EntranceExams",
                c => new
                    {
                        EntranceExamID = c.Int(nullable: false, identity: true),
                        EntranceExamName = c.String(nullable: false, maxLength: 50),
                        EntranceExamDescription = c.String(nullable: false, maxLength: 500),
                        EntranceExamStartDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EntranceExamID);
            
            CreateTable(
                "dbo.ContactUs",
                c => new
                    {
                        Cid = c.Int(nullable: false, identity: true),
                        Clocation = c.String(nullable: false, maxLength: 2000, unicode: false),
                        Caddress = c.String(nullable: false, maxLength: 1000, unicode: false),
                        Cemail = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Cid);
            
            CreateTable(
                "dbo.Credentials",
                c => new
                    {
                        UserGroupID = c.String(nullable: false, maxLength: 128),
                        RoleID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserGroupID, t.RoleID })
                .ForeignKey("dbo.Roles", t => t.RoleID, cascadeDelete: true)
                .ForeignKey("dbo.UserGroups", t => t.UserGroupID, cascadeDelete: true)
                .Index(t => t.UserGroupID)
                .Index(t => t.RoleID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.String(nullable: false, maxLength: 128),
                        RoleDetail = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.UserGroups",
                c => new
                    {
                        UserGroupID = c.String(nullable: false, maxLength: 128),
                        UserGroupName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserGroupID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 20),
                        UserPassword = c.String(nullable: false, maxLength: 20),
                        UserFirstName = c.String(nullable: false, maxLength: 20),
                        UserLastName = c.String(nullable: false, maxLength: 20),
                        UserAddress = c.String(nullable: false, maxLength: 50),
                        UserDOB = c.DateTime(nullable: false),
                        UserEmail = c.String(nullable: false, maxLength: 50),
                        GroupID = c.String(),
                        UserGroup_UserGroupID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.UserGroups", t => t.UserGroup_UserGroupID)
                .Index(t => t.UserGroup_UserGroupID);
            
            CreateTable(
                "dbo.FAQs",
                c => new
                    {
                        Fid = c.Int(nullable: false, identity: true),
                        Fquestion = c.String(nullable: false, maxLength: 2000, unicode: false),
                        Fanswer = c.String(nullable: false, maxLength: 2000, unicode: false),
                    })
                .PrimaryKey(t => t.Fid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "UserGroup_UserGroupID", "dbo.UserGroups");
            DropForeignKey("dbo.Credentials", "UserGroupID", "dbo.UserGroups");
            DropForeignKey("dbo.Credentials", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.EntranceExamResults", "StudentRoll", "dbo.Students");
            DropForeignKey("dbo.EntranceExamResults", "EntranceExamID", "dbo.EntranceExams");
            DropForeignKey("dbo.CourseStudents", "StudentRoll", "dbo.Students");
            DropForeignKey("dbo.CourseStudents", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.Students", "ClassID", "dbo.Classes");
            DropIndex("dbo.Users", new[] { "UserGroup_UserGroupID" });
            DropIndex("dbo.Credentials", new[] { "RoleID" });
            DropIndex("dbo.Credentials", new[] { "UserGroupID" });
            DropIndex("dbo.EntranceExamResults", new[] { "EntranceExamID" });
            DropIndex("dbo.EntranceExamResults", new[] { "StudentRoll" });
            DropIndex("dbo.CourseStudents", new[] { "StudentRoll" });
            DropIndex("dbo.CourseStudents", new[] { "CourseID" });
            DropIndex("dbo.Students", new[] { "ClassID" });
            DropTable("dbo.FAQs");
            DropTable("dbo.Users");
            DropTable("dbo.UserGroups");
            DropTable("dbo.Roles");
            DropTable("dbo.Credentials");
            DropTable("dbo.ContactUs");
            DropTable("dbo.EntranceExams");
            DropTable("dbo.EntranceExamResults");
            DropTable("dbo.Courses");
            DropTable("dbo.CourseStudents");
            DropTable("dbo.Students");
            DropTable("dbo.Classes");
            DropTable("dbo.AboutUs");
        }
    }
}
