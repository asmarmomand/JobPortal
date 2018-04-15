using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.Pocos;

namespace CareerCloud.EntityFrameworkDataAccess
{
	public class CareerCloudContext : DbContext
	{
		public CareerCloudContext(bool createProxy = true) : base("dbconnection")
		{
			Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
			Configuration.ProxyCreationEnabled = createProxy;
		}
		public DbSet<ApplicantEducationPoco> ApplicantEducations { get; set; }
		public DbSet<ApplicantJobApplicationPoco> ApplicantJobApplications { get; set; }
		public DbSet<ApplicantProfilePoco> ApplicantProfiles { get; set; }
		public DbSet<ApplicantResumePoco> ApplicantResumes { get; set; }
		public DbSet<ApplicantSkillPoco> ApplicantSkills { get; set; }
		public DbSet<ApplicantWorkHistoryPoco> ApplicantWorkHistories { get; set; }
		public DbSet<CompanyDescriptionPoco> CompanyDescriptions { get; set; }
		public DbSet<CompanyJobDescriptionPoco> CompanyJobDescriptions { get; set; }
		public DbSet<CompanyJobEducationPoco> CompanyJobEducations { get; set; }
		public DbSet<CompanyJobPoco> CompanyJobs { get; set; }
		public DbSet<CompanyJobSkillPoco> CompanyJobSkills { get; set; }
		public DbSet<CompanyLocationPoco> CompanyLocations { get; set; }
		public DbSet<CompanyProfilePoco> CompanyProfiles { get; set; }
		public DbSet<SecurityLoginPoco> SecurityLogins { get; set; }
		public DbSet<SecurityLoginsLogPoco> SecurityLoginsLogs { get; set; }
		public DbSet<SecurityLoginsRolePoco> SecurityLoginsRoles { get; set; }
		public DbSet<SecurityRolePoco> SecurityRoles { get; set; }
		public DbSet<SystemCountryCodePoco> SystemCountryCodes { get; set; }
		public DbSet<SystemLanguageCodePoco> SystemLanguageCodes { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<CompanyLocationPoco>()
				.HasRequired(c => c.CompanyProfile)
				.WithMany(c => c.CompanyLocations)
				.HasForeignKey(t => t.Company);

			modelBuilder.Entity<ApplicantWorkHistoryPoco>()
				.HasRequired(c => c.ApplicantProfile)
				.WithMany(c => c.ApplicantWorksHistories)
				.HasForeignKey(t => t.Applicant);

			modelBuilder.Entity<ApplicantJobApplicationPoco>()
				.HasRequired(c => c.ApplicantProfile)
				.WithMany(c => c.ApplicantJobApplications)
				.HasForeignKey(t => t.Applicant);

			modelBuilder.Entity<ApplicantSkillPoco>()
				.HasRequired(c => c.ApplicantProfile)
				.WithMany(c => c.ApplicantSkills)
				.HasForeignKey(t => t.Applicant);

			modelBuilder.Entity<CompanyJobPoco>()
				.HasRequired(c => c.CompanyProfile)
				.WithMany(c => c.CompanyJobs)
				.HasForeignKey(t => t.Company);

			modelBuilder.Entity<CompanyDescriptionPoco>()
				.HasRequired(c => c.CompanyProfiles)
				.WithMany(c => c.CompanyDescriptions)
				.HasForeignKey(t => t.Company);

			modelBuilder.Entity<CompanyJobSkillPoco>()
				.HasRequired(c => c.CompanyJob)
				.WithMany(c => c.CompanyJobSkills)
				.HasForeignKey(t => t.Job);

			modelBuilder.Entity<SecurityLoginsLogPoco>()
				.HasRequired(c => c.SecurityLogin)
				.WithMany(c => c.SecurityLoginLogs)
				.HasForeignKey(t => t.Login);

			modelBuilder.Entity<SecurityLoginsRolePoco>()
				.HasRequired(c => c.SecurityRole)
				.WithMany(c => c.SecurityLoginsRoles)
				.HasForeignKey(t => t.Role);

			base.OnModelCreating(modelBuilder);
		}
		private void FixEfProviderServicesProblem()
		{
			// The Entity Framework provider type 'System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer'
			// for the 'System.Data.SqlClient' ADO.NET provider could not be loaded. 
			// Make sure the provider assembly is available to the running application. 
			// See http://go.microsoft.com/fwlink/?LinkId=260882 for more information.
			var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
		}


	}
}
