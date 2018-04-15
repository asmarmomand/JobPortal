using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CareerCloud.Pocos
{
    [Table("Applicant_Profiles")]
    public class ApplicantProfilePoco : IPoco
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid Login { get; set; }
        [Column("Current_Salary")]
        public Decimal? CurrentSalary { get; set; }
        public String Currency { get; set; }
        [Column("Current_Rate")]
        public Decimal? CurrentRate { get; set; }
        [Column("Country_Code")]
        public String Country { get; set; }
        [Column("State_Province_Code")]
        public String Province { get; set; }
        [Column("Street_Address")]
        public String Street { get; set; }
        [Column("City_Town")]
        public String City { get; set; }
        [Column("Zip_Postal_Code")]
        public String PostalCode { get; set; }
        [Column("Time_Stamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public byte[] TimeStamp { get; set; }

        public virtual ICollection<ApplicantWorkHistoryPoco> ApplicantWorksHistories { get; set; }
        public virtual ICollection<ApplicantJobApplicationPoco> ApplicantJobApplications { get; set; }
        //public virtual ApplicantResumePoco ApplicantResume { get; set; }
        public virtual ICollection<ApplicantSkillPoco> ApplicantSkills { get; set; }

    }
}
