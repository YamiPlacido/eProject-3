namespace eProject3.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using eProject3.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<eProject3.Models.eProject3Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(eProject3.Models.eProject3Context context)
        {
            context.Courses.AddOrUpdate(x => x.CourseID,
                new Course() { CourseID = 1, CourseName = "Course1", CourseDescription = "Course Description 1", CourseDuration = "1 month", CourseStartDate = DateTime.Parse("2019-03-24"), CourseEndDate = DateTime.Parse("2019-04-24"), CourseImage = "~/Images/CourseImage/course1.jpg" },
                new Course() { CourseID = 2, CourseName = "Course2", CourseDescription = "Course Description 2", CourseDuration = "1 month", CourseStartDate = DateTime.Parse("2019-04-24"), CourseEndDate = DateTime.Parse("2019-05-24"), CourseImage = "~/Images/CourseImage/course2.jpg" }
                );
            context.Classes.AddOrUpdate(x => x.ClassID,
                new Class() { ClassID = 1, ClassName = "OnStandBy", ClassDescription = "On standby class", ClassEstimatedDuration = "6 month", ClassPaymentDeadline = DateTime.Parse("2019-03-24"), ClassTuitionFee = 0, ClassStartDate = DateTime.Parse("2019-03-24"), ClassEndDate = DateTime.Parse("2019-03-24") },
                new Class() { ClassID = 2, ClassName = "BelowStandard", ClassDescription = "Below standard class", ClassEstimatedDuration = "6 month", ClassPaymentDeadline = DateTime.Parse("2019-03-24"), ClassTuitionFee = 6000, ClassStartDate = DateTime.Parse("2019-03-24"), ClassEndDate = DateTime.Parse("2019-09-24") },
                new Class() { ClassID = 3, ClassName = "AboveStandard", ClassDescription = "Above standard class", ClassEstimatedDuration = "6 month", ClassPaymentDeadline = DateTime.Parse("2019-03-24"), ClassTuitionFee = 4000, ClassStartDate = DateTime.Parse("2019-03-24"), ClassEndDate = DateTime.Parse("2019-09-24") }
                );
            context.Students.AddOrUpdate(x => x.StudentRoll,
                new Student() { StudentRoll = 1, ClassID = 2, StudentFirstName = "Hy", StudentLastName = "Huynh", StudentAddress = "123 abc", StudentDOB = DateTime.Parse("1993-04-24"), StudentEmail = "haaaa@gmail.com", StudentResult = "pass" },
                new Student() { StudentRoll = 2, ClassID = 2, StudentFirstName = "Hoang", StudentLastName = "Vo", StudentAddress = "123 abcd", StudentDOB = DateTime.Parse("1996-04-24"), StudentEmail = "hooooa@gmail.com", StudentResult = "pass" }
                );
            context.CourseStudents.AddOrUpdate(x => x.StudentRoll,
                new CourseStudent() { CourseID = 1, StudentRoll = 1, LabFee = 1000 },
                new CourseStudent() { CourseID = 1, StudentRoll = 2, LabFee = 1000 }
                );
            context.EntranceExams.AddOrUpdate(x => x.EntranceExamID,
                new EntranceExam() { EntranceExamID = 1, EntranceExamName = "Entrance Exam March 2019", EntranceExamDescription = "Entrance Exam March 2019", EntranceExamStartDate = DateTime.Parse("2019-03-18") },
                new EntranceExam() { EntranceExamID = 2, EntranceExamName = "Entrance Exam April 2019", EntranceExamDescription = "Entrance Exam April 2019", EntranceExamStartDate = DateTime.Parse("2019-04-18") }
                );
            context.EntranceExamResults.AddOrUpdate(x => x.EntranceExamID,
                new EntranceExamResult() { StudentRoll = 1, EntranceExamID = 1, Mark = 80 },
                new EntranceExamResult() { StudentRoll = 2, EntranceExamID = 1, Mark = 90 }
                );
            context.UserGroups.AddOrUpdate(x => x.UserGroupID,
                new UserGroup() { UserGroupID = "USER", UserGroupName = "Normal User" },
                new UserGroup() { UserGroupID = "ADMIN", UserGroupName = "Admin" }
                );
            context.Users.AddOrUpdate(x => x.UserID,
                new User() { UserID = 0, UserName = "admin", UserPassword = "123", UserFirstName = "Ad", UserLastName = "min", UserAddress = "aaa123", UserDOB = DateTime.Parse("1996-04-24"), UserEmail = "admin@gmail.com", GroupID = "ADMIN" },
                new User() { UserID = 0, UserName = "user0", UserPassword = "123", UserFirstName = "John", UserLastName = "Cena", UserAddress = "jjj123", UserDOB = DateTime.Parse("1985-09-12"), UserEmail = "jcena@gmail.com", GroupID = "USER" }
                );
        }
    }
}
