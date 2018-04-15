using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;

namespace CareerCloud.WCF
{
    public class Applicant : IApplicant
    {
        public void AddApplicantEducation(ApplicantEducationPoco[] items)
        {
            var reference = new ApplicantEducationLogic(new EFGenericRepository<ApplicantEducationPoco>(false));
            reference.Add(items);
        }

        public void AddApplicantJobApplication(ApplicantJobApplicationPoco[] items)
        {
            var reference = new ApplicantJobApplicationLogic(new EFGenericRepository<ApplicantJobApplicationPoco>(false));
            reference.Add(items);
        }

        public void AddApplicantProfile(ApplicantProfilePoco[] items)
        {
            var reference = new ApplicantProfileLogic(new EFGenericRepository<ApplicantProfilePoco>(false));
            reference.Add(items);
        }

        public void AddApplicantResume(ApplicantResumePoco[] items)
        {
            var reference = new ApplicantResumeLogic(new EFGenericRepository<ApplicantResumePoco>(false));
            reference.Add(items);
        }

        public void AddApplicantSkill(ApplicantSkillPoco[] items)
        {
            var reference = new ApplicantSkillLogic(new EFGenericRepository<ApplicantSkillPoco>(false));
            reference.Add(items);
        }

        public void AddApplicantWorkHistory(ApplicantWorkHistoryPoco[] items)
        {
            var reference = new ApplicantWorkHistoryLogic(new EFGenericRepository<ApplicantWorkHistoryPoco>(false));
            reference.Add(items);
        }

        public List<ApplicantEducationPoco> GetAllApplicantEducation()
        {
            var reference = new ApplicantEducationLogic(new EFGenericRepository<ApplicantEducationPoco>(false));
            return reference.GetAll();
        }

        public List<ApplicantJobApplicationPoco> GetAllApplicantJobApplication()
        {
            var reference = new ApplicantJobApplicationLogic(new EFGenericRepository<ApplicantJobApplicationPoco>(false));
            return reference.GetAll();
        }

        public List<ApplicantProfilePoco> GetAllApplicantProfile()
        {
            var reference = new ApplicantProfileLogic(new EFGenericRepository<ApplicantProfilePoco>(false));
            return reference.GetAll();
        }

        public List<ApplicantResumePoco> GetAllApplicantResume()
        {
            var reference = new ApplicantResumeLogic(new EFGenericRepository<ApplicantResumePoco>(false));
            return reference.GetAll();
        }

        public List<ApplicantSkillPoco> GetAllApplicantSkill()
        {
            var reference = new ApplicantSkillLogic(new EFGenericRepository<ApplicantSkillPoco>(false));
            return reference.GetAll();
        }

        public List<ApplicantWorkHistoryPoco> GetAllApplicantWorkHistory()
        {
            var reference = new ApplicantWorkHistoryLogic(new EFGenericRepository<ApplicantWorkHistoryPoco>(false));
            return reference.GetAll();
        }

        public ApplicantEducationPoco GetSingleApplicantEducation(string Id)
        {
            var reference = new ApplicantEducationLogic(new EFGenericRepository<ApplicantEducationPoco>(false));
            return reference.Get(Guid.Parse(Id));
        }

        public ApplicantJobApplicationPoco GetSingleApplicantJobApplication(string Id)
        {
            var reference = new ApplicantJobApplicationLogic(new EFGenericRepository<ApplicantJobApplicationPoco>(false));
            return reference.Get(Guid.Parse(Id));
        }

        public ApplicantProfilePoco GetSingleApplicantProfile(string Id)
        {
            var reference = new ApplicantProfileLogic(new EFGenericRepository<ApplicantProfilePoco>(false));
            return reference.Get(Guid.Parse(Id));
        }

        public ApplicantResumePoco GetSingleApplicantResume(string Id)
        {
            var reference = new ApplicantResumeLogic(new EFGenericRepository<ApplicantResumePoco>(false));
            return reference.Get(Guid.Parse(Id));
        }

        public ApplicantSkillPoco GetSingleApplicantSkill(string Id)
        {
            var reference = new ApplicantSkillLogic(new EFGenericRepository<ApplicantSkillPoco>(false));
            return reference.Get(Guid.Parse(Id));
        }

        public ApplicantWorkHistoryPoco GetSingleApplicantWorkHistory(string Id)
        {
            var reference = new ApplicantWorkHistoryLogic(new EFGenericRepository<ApplicantWorkHistoryPoco>(false));
            return reference.Get(Guid.Parse(Id));
        }

        public void RemoveApplicantEducation(ApplicantEducationPoco[] items)
        {
            var reference = new ApplicantEducationLogic(new EFGenericRepository<ApplicantEducationPoco>(false));
            reference.Delete(items);
        }

        public void RemoveApplicantJobApplication(ApplicantJobApplicationPoco[] items)
        {
            var reference = new ApplicantJobApplicationLogic(new EFGenericRepository<ApplicantJobApplicationPoco>(false));
            reference.Delete(items);
        }

        public void RemoveApplicantProfile(ApplicantProfilePoco[] items)
        {
            var reference = new ApplicantProfileLogic(new EFGenericRepository<ApplicantProfilePoco>(false));
            reference.Delete(items);
        }

        public void RemoveApplicantResume(ApplicantResumePoco[] items)
        {
            var reference = new ApplicantResumeLogic(new EFGenericRepository<ApplicantResumePoco>(false));
            reference.Delete(items);
        }

        public void RemoveApplicantSkill(ApplicantSkillPoco[] items)
        {
            var reference = new ApplicantSkillLogic(new EFGenericRepository<ApplicantSkillPoco>(false));
            reference.Delete(items);
        }

        public void RemoveApplicantWorkHistory(ApplicantWorkHistoryPoco[] items)
        {
            var reference = new ApplicantWorkHistoryLogic(new EFGenericRepository<ApplicantWorkHistoryPoco>(false));
            reference.Delete(items);
        }

        public void UpdateApplicantEducation(ApplicantEducationPoco[] items)
        {
            var reference = new ApplicantEducationLogic(new EFGenericRepository<ApplicantEducationPoco>(false));
            reference.Update(items);
        }

        public void UpdateApplicantJobApplication(ApplicantJobApplicationPoco[] items)
        {
            var reference = new ApplicantJobApplicationLogic(new EFGenericRepository<ApplicantJobApplicationPoco>(false));
            reference.Update(items);
        }

        public void UpdateApplicantProfile(ApplicantProfilePoco[] items)
        {
            var reference = new ApplicantProfileLogic(new EFGenericRepository<ApplicantProfilePoco>(false));
            reference.Update(items);
        }

        public void UpdateApplicantResume(ApplicantResumePoco[] items)
        {
            var reference = new ApplicantResumeLogic(new EFGenericRepository<ApplicantResumePoco>(false));
            reference.Update(items);
        }

        public void UpdateApplicantSkill(ApplicantSkillPoco[] items)
        {
            var reference = new ApplicantSkillLogic(new EFGenericRepository<ApplicantSkillPoco>(false));
            reference.Update(items);
        }

        public void UpdateApplicantWorkHistory(ApplicantWorkHistoryPoco[] items)
        {
            var reference = new ApplicantWorkHistoryLogic(new EFGenericRepository<ApplicantWorkHistoryPoco>(false));
            reference.Update(items);
        }
    }
}
