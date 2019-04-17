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
                new Course() { CourseID = 1, CourseName = "Course1", CourseDescription = "Course Description 1", CourseDuration = "1 month", CourseStartDate = DateTime.Parse("2019-03-24"), CourseEndDate = DateTime.Parse("2019-04-24"), CourseImage = "/Images/CourseImage/course1.jpg" },
                new Course() { CourseID = 2, CourseName = "Course2", CourseDescription = "Course Description 2", CourseDuration = "1 month", CourseStartDate = DateTime.Parse("2019-04-24"), CourseEndDate = DateTime.Parse("2019-05-24"), CourseImage = "/Images/CourseImage/course2.jpg" }
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
            context.FAQs.AddOrUpdate(x => x.Fid,
                new FAQ() { Fid = 0, Fquestion = "How to join the course?", Fanswer = "On this the admin should be able to enter or update the procedures for joining the course that the institute offers" },
                new FAQ() { Fid = 0, Fquestion = "Why to join the institute?", Fanswer = "The various benefits that the student can gain by joining the institution is to be provided" },
                new FAQ() { Fid = 0, Fquestion = "When will be Entrance Examinations Conducted?", Fanswer = "Once in 6 months, and one need to check the website for knowing when is the entrance exam entitled, the fees for the entrance exam." },
                new FAQ() { Fid = 0, Fquestion = "Can I use the Lab facilities after my class hours? Will there be any extra hidden charges?", Fanswer = "Yes, you can use the lab sessions even after your class hours. There will be no charges during the course days (i.e., during the course period if you want to use the lab sessions after the class hours we do provide the lab session and the labs will be kept opened till 9 PM in the evening. But yes if you want to use the lab session after your course completion, then it will be charged based on the scenario (like 1000$ if opted at the time of registering and 1500$ if opted after the completion of the cours" },
                new FAQ() { Fid = 0, Fquestion = "How can I apply for the entrance exam?", Fanswer = "Once the entrance exams are entitled, one need to visit the centre for applying it through paper and fill all the necessary details through online. On the application form one should chose which course he/she wanted to pursue." },
                new FAQ() { Fid = 0, Fquestion = "Will there be any fees for the entrance exam?", Fanswer = "Yes there will be and it will be available on the application form" },
                new FAQ() { Fid = 0, Fquestion = "How to make the payment?", Fanswer = "payment can be done through draft, or through cheque or through cash. For making the payment through cash, one needs to come to one of the centre of the institute, and make the payment there itself. Once the payment is done (through cash or through DD), the student will be provided with the receipt with a receipt number. This receipt number is to be inputted in the application form. For the payments done through cheque and DD, one need to enter the DD number and the cheque number, bank details, etc. are to be entered on the application form and the cheque is to be pinned to the application form. Only once the payment is received the student’s application will be accepted. Once the application is accepted, the student is mailed with the acknowledgement form along with the details of the examination, subject chosen, date and time of exam, and the roll number" }
                );
            context.ContactUss.AddOrUpdate(x => x.Cid,
                new ContactUs() { Cid = 0, Caddress = "Cach mang thang 8", Cemail = "Aptech@gmail.com", Clocation = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.3175880091044!2d106.66413191517475!3d10.786969992314361!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752ed2392c44df%3A0xd2ecb62e0d050fe9!2sFPT-Aptech+Computer+Education+HCM!5e0!3m2!1sen!2s!4v1555502756420!5m2!1sen!2s" }
                );
            context.AboutUss.AddOrUpdate(x => x.Aid,
                new AboutUs() { Aid=0,Aintroduction="Introduction 1",Aservice="Service 1"}
            );
        }
    }
}
