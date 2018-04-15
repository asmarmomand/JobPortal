using System;
using CareerCloud.DataAccessLayer;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.Pocos;
using System.Linq.Expressions;
using System.Data.SqlClient;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantWorkHistoryRepository : BaseClass, IDataRepository<ApplicantWorkHistoryPoco>
    {
        public void Add(params ApplicantWorkHistoryPoco[] items)
        {
            using (SqlConnection cn = new SqlConnection(DbString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cn.Open();
                foreach (ApplicantWorkHistoryPoco poco in items)
                {


                    cmd.CommandText = @"INSERT INTO [dbo].[Applicant_Work_History]
                                           ([Id]
                                           ,[Applicant]
                                           ,[Company_Name]
                                            ,[Country_Code]
                                            ,[Location]
                                            ,[Job_Title]
                                            ,[Job_Description]
                                           ,[Start_Month]
                                           ,[Start_Year]
                                           ,[End_Month]
                                           ,[End_Year])
                                           
                                     VALUES
                                           (@Id
                                           ,@Applicant
                                           ,@Company_Name
                                           ,@Country_Code
                                            ,@Location
                                            ,@Job_Title
                                            ,@Job_Description
                                           ,@Start_Month 
                                           ,@Start_Year
                                           ,@End_Month
                                           ,@End_Year)";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
                    cmd.Parameters.AddWithValue("@Company_Name", poco.CompanyName);
                    cmd.Parameters.AddWithValue("@Country_Code", poco.CountryCode);
                    cmd.Parameters.AddWithValue("@Location", poco.Location);
                    cmd.Parameters.AddWithValue("@Job_Title", poco.JobTitle);
                    cmd.Parameters.AddWithValue("@Job_Description", poco.JobDescription);
                    cmd.Parameters.AddWithValue("@Start_Month", poco.StartMonth);
                    cmd.Parameters.AddWithValue("@Start_Year", poco.StartYear);
                    cmd.Parameters.AddWithValue("@End_Month", poco.EndMonth);
                    cmd.Parameters.AddWithValue("@End_Year", poco.EndYear);
                    
                    cmd.ExecuteNonQuery();
                    
                }
                cn.Close();
            }

        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantWorkHistoryPoco> GetAll(params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            using (SqlConnection cn = new SqlConnection(DbString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cn.Open();
                cmd.CommandText = @"SELECT [Id]
                                           ,[Applicant]
                                           ,[Company_Name]
                                            ,[Country_Code]
                                            ,[Location]
                                            ,[Job_Title]
                                            ,[Job_Description]
                                           ,[Start_Month]
                                           ,[Start_Year]
                                           ,[End_Month]
                                           ,[End_Year]
                                      FROM 
                                           [dbo].[Applicant_Work_History]";
                int counter = 0;
                ApplicantWorkHistoryPoco[] pocos = new ApplicantWorkHistoryPoco[5000];
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ApplicantWorkHistoryPoco poco = new ApplicantWorkHistoryPoco();
                    poco.Id = reader.GetGuid(0);
                    poco.Applicant = reader.GetGuid(1);
                    poco.CompanyName = reader.GetString(2);
                    poco.CountryCode = reader.GetString(3);
                    poco.Location = reader.GetString(4);
                    poco.JobTitle = reader.GetString(5);
                    poco.JobDescription = reader.GetString(6);
                    poco.StartMonth = reader.GetInt16(7);
                    poco.StartYear = reader.GetInt32(8);
                    poco.EndMonth = reader.GetInt16(9);
                    poco.EndYear = reader.GetInt32(10);
                    pocos[counter] = poco;
                    counter++;
                }
                cn.Close();
                return pocos.Where(a => a != null).ToList();
                

            }
        }

        public IList<ApplicantWorkHistoryPoco> GetList(Func<ApplicantWorkHistoryPoco, bool> where, params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantWorkHistoryPoco GetSingle(Func<ApplicantWorkHistoryPoco, bool> where, params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            ApplicantWorkHistoryPoco[] pocos = GetAll().ToArray();
            return pocos.Where(where).ToList().FirstOrDefault();
        }

        public void Remove(params ApplicantWorkHistoryPoco[] items)
        {
            using (SqlConnection cn = new SqlConnection(DbString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cn.Open();
                foreach (var poco in items)
                {
                    cmd.CommandText = @"DELETE FROM [dbo].[Applicant_Work_History]
                                      WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                  
                    cmd.ExecuteNonQuery();
                  
                }
                cn.Close();
            }
        }

        public void Update(params ApplicantWorkHistoryPoco[] items)
        {
            using (SqlConnection cn = new SqlConnection(DbString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cn.Open();
                foreach (var poco in items)
                {
                    cmd.CommandText = @"UPDATE [dbo].[Applicant_Work_History]
                                           SET [Id] = @Id
                                              ,[Applicant] = @Applicant
                                              ,[Company_Name] = @Company_Name
                                              ,[Country_Code] = @Country_Code
                                              ,[Location] = @Location
                                              ,[Job_Title] = @Job_Title
                                              ,[Job_Description] = @Job_Description
                                              ,[Start_Month] = @Start_Month
                                              ,[Start_Year] = @Start_Year
                                              ,[End_Month] = @End_Month
                                              ,[End_Year] = @End_Year
                                         WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
                    cmd.Parameters.AddWithValue("@Company_Name", poco.CompanyName);
                    cmd.Parameters.AddWithValue("@Country_Code", poco.CountryCode);
                    cmd.Parameters.AddWithValue("@Location", poco.Location);
                    cmd.Parameters.AddWithValue("@Job_Title", poco.JobTitle);
                    cmd.Parameters.AddWithValue("@Job_Description", poco.JobDescription);
                    cmd.Parameters.AddWithValue("@Start_Month", poco.StartMonth);
                    cmd.Parameters.AddWithValue("@Start_Year", poco.StartYear);
                    cmd.Parameters.AddWithValue("@End_Month", poco.EndMonth);
                    cmd.Parameters.AddWithValue("@End_Year", poco.EndYear);
                  
                    cmd.ExecuteNonQuery();
                   
                }
                cn.Close();
            }
        }
    }
}
