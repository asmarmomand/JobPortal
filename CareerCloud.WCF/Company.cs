using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;

namespace CareerCloud.WCF
{
    class Company : ICompany
    {
        public void AddCompanyDescription(CompanyDescriptionPoco[] items)
        {
            var reference = new CompanyDescriptionLogic(new EFGenericRepository<CompanyDescriptionPoco>(false));
            reference.Add(items);
        }

        public void AddCompanyJob(CompanyJobPoco[] items)
        {
            var reference = new CompanyJobLogic(new EFGenericRepository<CompanyJobPoco>(false));
            reference.Add(items);
        }

        public void AddCompanyJobDescription(CompanyJobDescriptionPoco[] items)
        {
            var reference = new CompanyJobDescriptionLogic(new EFGenericRepository<CompanyJobDescriptionPoco>(false));
            reference.Add(items);
        }

        public void AddCompanyJobEducation(CompanyJobEducationPoco[] items)
        {
            var reference = new CompanyJobEducationLogic(new EFGenericRepository<CompanyJobEducationPoco>(false));
            reference.Add(items);
        }

        public void AddCompanyJobSkill(CompanyJobSkillPoco[] items)
        {
            var reference = new CompanyJobSkillLogic(new EFGenericRepository<CompanyJobSkillPoco>(false));
            reference.Add(items);
        }

        public void AddCompanyLocation(CompanyLocationPoco[] items)
        {
            var reference = new CompanyLocationLogic(new EFGenericRepository<CompanyLocationPoco>(false));
            reference.Add(items);
        }

        public void AddCompanyProfile(CompanyProfilePoco[] items)
        {
            var reference = new CompanyProfileLogic(new EFGenericRepository<CompanyProfilePoco>(false));
            reference.Add(items);
        }

        public List<CompanyDescriptionPoco> GetAllCompanyDescription()
        {
            var reference = new CompanyDescriptionLogic(new EFGenericRepository<CompanyDescriptionPoco>(false));
            return reference.GetAll();
        }

        public List<CompanyJobPoco> GetAllCompanyJob()
        {
            var reference = new CompanyJobLogic(new EFGenericRepository<CompanyJobPoco>(false));
            return reference.GetAll();
        }

        public List<CompanyJobDescriptionPoco> GetAllCompanyJobDescription()
        {
            var reference = new CompanyJobDescriptionLogic(new EFGenericRepository<CompanyJobDescriptionPoco>(false));
            return reference.GetAll();
        }

        public List<CompanyJobEducationPoco> GetAllCompanyJobEducation()
        {
            var reference = new CompanyJobEducationLogic(new EFGenericRepository<CompanyJobEducationPoco>(false));
            return reference.GetAll();
        }

        public List<CompanyJobSkillPoco> GetAllCompanyJobSkill()
        {
            var reference = new CompanyJobSkillLogic(new EFGenericRepository<CompanyJobSkillPoco>(false));
            return reference.GetAll();
        }

        public List<CompanyLocationPoco> GetAllCompanyLocation()
        {
            var reference = new CompanyLocationLogic(new EFGenericRepository<CompanyLocationPoco>(false));
            return reference.GetAll();
        }

        public List<CompanyProfilePoco> GetAllCompanyProfile()
        {
            var reference = new CompanyProfileLogic(new EFGenericRepository<CompanyProfilePoco>(false));
            return reference.GetAll();
        }

        public CompanyDescriptionPoco GetSingleCompanyDescription(string Id)
        {
            var reference = new CompanyDescriptionLogic(new EFGenericRepository<CompanyDescriptionPoco>(false));
            return reference.Get(Guid.Parse(Id));
        }

        public CompanyJobPoco GetSingleCompanyJob(string Id)
        {
            var reference = new CompanyJobLogic(new EFGenericRepository<CompanyJobPoco>(false));
            return reference.Get(Guid.Parse(Id));
        }

        public CompanyJobDescriptionPoco GetSingleCompanyJobDescription(string Id)
        {
            var reference = new CompanyJobDescriptionLogic(new EFGenericRepository<CompanyJobDescriptionPoco>(false));
            return reference.Get(Guid.Parse(Id));
        }

        public CompanyJobEducationPoco GetSingleCompanyJobEducation(string Id)
        {
            var reference = new CompanyJobEducationLogic(new EFGenericRepository<CompanyJobEducationPoco>(false));
            return reference.Get(Guid.Parse(Id));
        }

        public CompanyJobSkillPoco GetSingleCompanyJobSkill(string Id)
        {
            var reference = new CompanyJobSkillLogic(new EFGenericRepository<CompanyJobSkillPoco>(false));
            return reference.Get(Guid.Parse(Id));
        }

        public CompanyLocationPoco GetSingleCompanyLocation(string Id)
        {
            var reference = new CompanyLocationLogic(new EFGenericRepository<CompanyLocationPoco>(false));
            return reference.Get(Guid.Parse(Id));
        }

        public CompanyProfilePoco GetSingleCompanyProfile(string Id)
        {
            var reference = new CompanyProfileLogic(new EFGenericRepository<CompanyProfilePoco>(false));
            return reference.Get(Guid.Parse(Id));
        }

        public void RemoveCompanyDescription(CompanyDescriptionPoco[] items)
        {
            var reference = new CompanyDescriptionLogic(new EFGenericRepository<CompanyDescriptionPoco>(false));
            reference.Delete(items);
        }

        public void RemoveCompanyJob(CompanyJobPoco[] items)
        {
            var reference = new CompanyJobLogic(new EFGenericRepository<CompanyJobPoco>(false));
            reference.Delete(items);
        }

        public void RemoveCompanyJobDescription(CompanyJobDescriptionPoco[] items)
        {
            var reference = new CompanyJobDescriptionLogic(new EFGenericRepository<CompanyJobDescriptionPoco>(false));
            reference.Delete(items);
        }

        public void RemoveCompanyJobEducation(CompanyJobEducationPoco[] items)
        {
            var reference = new CompanyJobEducationLogic(new EFGenericRepository<CompanyJobEducationPoco>(false));
            reference.Delete(items);
        }

        public void RemoveCompanyJobSkill(CompanyJobSkillPoco[] items)
        {
            var reference = new CompanyJobSkillLogic(new EFGenericRepository<CompanyJobSkillPoco>(false));
            reference.Delete(items);
        }

        public void RemoveCompanyLocation(CompanyLocationPoco[] items)
        {
            var reference = new CompanyLocationLogic(new EFGenericRepository<CompanyLocationPoco>(false));
            reference.Delete(items);
        }

        public void RemoveCompanyProfile(CompanyProfilePoco[] items)
        {
            var reference = new CompanyProfileLogic(new EFGenericRepository<CompanyProfilePoco>(false));
            reference.Delete(items);
        }

        public void UpdateCompanyDescription(CompanyDescriptionPoco[] items)
        {
            var reference = new CompanyDescriptionLogic(new EFGenericRepository<CompanyDescriptionPoco>(false));
            reference.Update(items);
        }

        public void UpdateCompanyJob(CompanyJobPoco[] items)
        {
            var reference = new CompanyJobLogic(new EFGenericRepository<CompanyJobPoco>(false));
            reference.Update(items);
        }

        public void UpdateCompanyJobDescription(CompanyJobDescriptionPoco[] items)
        {
            var reference = new CompanyJobDescriptionLogic(new EFGenericRepository<CompanyJobDescriptionPoco>(false));
            reference.Update(items);
        }

        public void UpdateCompanyJobEducation(CompanyJobEducationPoco[] items)
        {
            var reference = new CompanyJobEducationLogic(new EFGenericRepository<CompanyJobEducationPoco>(false));
            reference.Update(items);
        }

        public void UpdateCompanyJobSkill(CompanyJobSkillPoco[] items)
        {
            var reference = new CompanyJobSkillLogic(new EFGenericRepository<CompanyJobSkillPoco>(false));
            reference.Update(items);
        }

        public void UpdateCompanyLocation(CompanyLocationPoco[] items)
        {
            var reference = new CompanyLocationLogic(new EFGenericRepository<CompanyLocationPoco>(false));
            reference.Update(items);
        }

        public void UpdateCompanyProfile(CompanyProfilePoco[] items)
        {
            var reference = new CompanyProfileLogic(new EFGenericRepository<CompanyProfilePoco>(false));
            reference.Update(items);
        }
    }
}
