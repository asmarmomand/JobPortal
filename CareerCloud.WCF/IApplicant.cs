using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CareerCloud.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IApplicant" in both code and config file together.
    [ServiceContract]
    public interface IApplicant
    {
        [OperationContract]
        void AddApplicantEducation(ApplicantEducationPoco[] items);
        [OperationContract]
        List<ApplicantEducationPoco> GetAllApplicantEducation();

        [OperationContract]
        ApplicantEducationPoco GetSingleApplicantEducation(string Id);

        [OperationContract]
        void RemoveApplicantEducation(ApplicantEducationPoco[] items);

        [OperationContract]
        void UpdateApplicantEducation(ApplicantEducationPoco[] items);

        //Applicant Job Application

        [OperationContract]
        void AddApplicantJobApplication(ApplicantJobApplicationPoco[] items);
        [OperationContract]
        List<ApplicantJobApplicationPoco> GetAllApplicantJobApplication();

        [OperationContract]
        ApplicantJobApplicationPoco GetSingleApplicantJobApplication(string Id);

        [OperationContract]
        void RemoveApplicantJobApplication(ApplicantJobApplicationPoco[] items);

        [OperationContract]
        void UpdateApplicantJobApplication(ApplicantJobApplicationPoco[] items);

        // Applicant Profile 
        [OperationContract]
        void AddApplicantProfile(ApplicantProfilePoco[] items);
        [OperationContract]
        List<ApplicantProfilePoco> GetAllApplicantProfile();

        [OperationContract]
        ApplicantProfilePoco GetSingleApplicantProfile(string Id);

        [OperationContract]
        void RemoveApplicantProfile(ApplicantProfilePoco[] items);

        [OperationContract]
        void UpdateApplicantProfile(ApplicantProfilePoco[] items);

        //Applicant Resume 

        [OperationContract]
        void AddApplicantResume(ApplicantResumePoco[] items);
        [OperationContract]
        List<ApplicantResumePoco> GetAllApplicantResume();

        [OperationContract]
        ApplicantResumePoco GetSingleApplicantResume(string Id);

        [OperationContract]
        void RemoveApplicantResume(ApplicantResumePoco[] items);

        [OperationContract]
        void UpdateApplicantResume(ApplicantResumePoco[] items);

        // Applicant Skill

        [OperationContract]
        void AddApplicantSkill(ApplicantSkillPoco[] items);
        [OperationContract]
        List<ApplicantSkillPoco> GetAllApplicantSkill();

        [OperationContract]
        ApplicantSkillPoco GetSingleApplicantSkill(string Id);

        [OperationContract]
        void RemoveApplicantSkill(ApplicantSkillPoco[] items);

        [OperationContract]
        void UpdateApplicantSkill(ApplicantSkillPoco[] items);

        // Applicant Work History

        [OperationContract]
        void AddApplicantWorkHistory(ApplicantWorkHistoryPoco[] items);
        [OperationContract]
        List<ApplicantWorkHistoryPoco> GetAllApplicantWorkHistory();

        [OperationContract]
        ApplicantWorkHistoryPoco GetSingleApplicantWorkHistory(string Id);

        [OperationContract]
        void RemoveApplicantWorkHistory(ApplicantWorkHistoryPoco[] items);

        [OperationContract]
        void UpdateApplicantWorkHistory(ApplicantWorkHistoryPoco[] items);
    }
}
