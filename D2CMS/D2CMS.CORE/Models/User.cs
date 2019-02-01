using System;
using System.Collections.Generic;
using System.Text;

namespace D2CMS.CORE.Models
{
    /// <summary>
    /// User
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Account { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int DepartmentId { get; set; }
        public int TitleId { get; set; }
        public int RoleId { get; set; }
        public int Sex { get; set; }
        public DateTime? Dob { get; set; }
        public string PhoneNumber { get; set; }
        public string IdCard { get; set; }
        public DateTime? IdDate { get; set; }
        public string IdLocation { get; set; }
        public string BankAccount { get; set; }
        public string TaxCode { get; set; }
        public string SocialInsurrance { get; set; }
        public string HealthInsurrance { get; set; }
        public string Household { get; set; }
        public string Address { get; set; }
        public int EducationBackgroundId { get; set; }
        public int SchoolId { get; set; }
        public string Specialized { get; set; }
        public string Email { get; set; }
        public DateTime? JoinDate { get; set; }
        public DateTime? LeaveDate { get; set; }
        public DateTime? TrainingContactStart { get; set; }
        public DateTime? TrainingContactEnd { get; set; }
        public DateTime? TrailContactStart { get; set; }
        public DateTime? TrailContactEnd { get; set; }
        public DateTime? OfficialContactStart { get; set; }
        public DateTime? OfficialContactEnd { get; set; }
        public int CurrentContract { get; set; }
        public int Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public Department Department { get; set; }
        public Title Title { get; set; }
        public Role Role { get; set; }
        public EducationBackground EducationBackground { get; set; }
        public School School { get; set; }
    }
}
