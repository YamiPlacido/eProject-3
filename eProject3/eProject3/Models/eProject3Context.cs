using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace eProject3.Models
{
    public class eProject3Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public eProject3Context() : base("name=ProjectContext")
        {
        }

        public System.Data.Entity.DbSet<eProject3.Models.Course> Courses { get; set; }

        public System.Data.Entity.DbSet<eProject3.Models.CourseStudent> CourseStudents { get; set; }

        public System.Data.Entity.DbSet<eProject3.Models.Student> Students { get; set; }

        public System.Data.Entity.DbSet<eProject3.Models.Class> Classes { get; set; }

        public System.Data.Entity.DbSet<eProject3.Models.EntranceExam> EntranceExams { get; set; }

        public System.Data.Entity.DbSet<eProject3.Models.EntranceExamResult> EntranceExamResults { get; set; }

        public System.Data.Entity.DbSet<eProject3.Models.FAQ> FAQs { get; set; }

        public System.Data.Entity.DbSet<eProject3.Models.ContactUs> ContactUss { get; set; }

        public System.Data.Entity.DbSet<eProject3.Models.AboutUs> AboutUss { get; set; }

        public System.Data.Entity.DbSet<eProject3.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<eProject3.Models.UserGroup> UserGroups { get; set; }

        public System.Data.Entity.DbSet<eProject3.Models.Role> Roles { get; set; }

        public System.Data.Entity.DbSet<eProject3.Models.Credential> Credentials { get; set; }



    }
}
