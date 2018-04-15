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
    public class ApplicantJobApplicationRepository : BaseClass, IDataRepository<ApplicantJobApplicationPoco>
    {
        public void Add(params ApplicantJobApplicationPoco[] items)
        {
            using (SqlConnection cn = new SqlConnection(DbString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cn.Open();
                foreach (ApplicantJobApplicationPoco poco in items)
                {


                    cmd.CommandText = @"INSERT INTO [dbo].[Applicant_Job_Applications]
                                           ([Id]
                                           ,[Applicant]
                                           ,[Job]
                                           ,[Application_Date])
                                          
                                     VALUES
                                           (@Id
                                           ,@Applicant
                                           ,@Job
                                           ,@Application_Date)";
                                           
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
                    cmd.Parameters.AddWithValue("@Job", poco.Job);
                    cmd.Parameters.AddWithValue("@Application_Date", poco.ApplicationDate);
                   
                    cmd.ExecuteNonQuery();
                    
                }
                cn.Close();
            }

        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantJobApplicationPoco> GetAll(params Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
        {
            using (SqlConnection cn = new SqlConnection(DbString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cn.Open();
                cmd.CommandText = @"SELECT [Id]
                                           ,[Applicant]
                                           ,[Job]
                                           ,[Application_Date]
                                         
                                      FROM 
                                           [dbo].[Applicant_Job_Applications]";
                int counter = 0;
                ApplicantJobApplicationPoco[] pocos = new ApplicantJobApplicationPoco[5000];
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ApplicantJobApplicationPoco poco = new ApplicantJobApplicationPoco();
                    poco.Id = reader.GetGuid(0);
                    poco.Applicant = reader.GetGuid(1);
                    poco.Job = reader.GetGuid(2);
                    poco.ApplicationDate = reader.GetDateTime(3);
                    pocos[counter] = poco;
                    counter++;
                }
                cn.Close();
                return pocos.Where(a => a != null).ToList();
               
             
            }
        }

        public IList<ApplicantJobApplicationPoco> GetList(Func<ApplicantJobApplicationPoco, bool> where, params Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantJobApplicationPoco GetSingle(Func<ApplicantJobApplicationPoco, bool> where, params Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
        {
            ApplicantJobApplicationPoco[] pocos = GetAll().ToArray();
            return pocos.Where(where).ToList().FirstOrDefault();
        }

        public void Remove(params ApplicantJobApplicationPoco[] items)
        {
            using (SqlConnection cn = new SqlConnection(DbString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cn.Open();
                foreach (var poco in items)
                {
                    cmd.CommandText = @"DELETE FROM [dbo].[Applicant_Job_Applications]
                                      WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                   
                    cmd.ExecuteNonQuery();
                  
                }
                cn.Close();
            }
        }

        public void Update(params ApplicantJobApplicationPoco[] items)
        {
            using (SqlConnection cn = new SqlConnection(DbString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cn.Open();
                foreach (var poco in items)
                {
                    cmd.CommandText = @"UPDATE [dbo].[Applicant_Job_Applications]
                                           SET [Id] = @Id
                                              ,[Applicant] = @Applicant
                                              ,[Job] = @Job
                                              ,[Application_Date] = @Application_Date
                                         WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
                    cmd.Parameters.AddWithValue("@Job", poco.Job);
                    cmd.Parameters.AddWithValue("@Application_Date", poco.ApplicationDate);
                 
                    cmd.ExecuteNonQuery();
                    
                }
                cn.Close();
            }
        }
    }
}
