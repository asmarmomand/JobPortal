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
    public class CompanyJobRepository : BaseClass, IDataRepository<CompanyJobPoco>
    {
        public void Add(params CompanyJobPoco[] items)
        {
            using (SqlConnection cn = new SqlConnection(DbString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cn.Open();
                foreach (CompanyJobPoco poco in items)
                {


                    cmd.CommandText = @"INSERT INTO [dbo].[Company_Jobs]
                                           ([Id]
                                           ,[Company]
                                           ,[Profile_Created]
                                           ,[Is_Inactive]
                                           ,[Is_Company_hidden]
                                          )
                                     VALUES
                                           (@Id
                                           ,@Company
                                           ,@Profile_Created
                                           ,@Is_Inactive
                                           ,@Is_Company_hidden 
                                          )";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Company", poco.Company);
                    cmd.Parameters.AddWithValue("@Profile_Created", poco.ProfileCreated);
                    cmd.Parameters.AddWithValue("@Is_Inactive", poco.IsInactive);
                    cmd.Parameters.AddWithValue("@Is_Company_hidden", poco.IsCompanyHidden);
                   
                    
                    cmd.ExecuteNonQuery();
                   
                }
                cn.Close();
            }

        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyJobPoco> GetAll(params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
        {
            using (SqlConnection cn = new SqlConnection(DbString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cn.Open();
                cmd.CommandText = @"SELECT [Id]
                                          ,[Company]
                                          ,[Profile_Created]
                                          ,[Is_Inactive]
                                          ,[Is_Company_Hidden]
                                         
                                      FROM 
                                           [dbo].[Company_Jobs]";
                int counter = 0;
                CompanyJobPoco[] pocos = new CompanyJobPoco[5000];
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CompanyJobPoco poco = new CompanyJobPoco();
                    poco.Id = reader.GetGuid(0);
                    poco.Company = reader.GetGuid(1);
                    poco.ProfileCreated = reader.GetDateTime(2);
                    poco.IsInactive = reader.GetBoolean(3);
                    poco.IsCompanyHidden = reader.GetBoolean(4);
                   
                    pocos[counter] = poco;
                    counter++;
                }
                cn.Close();
                return pocos.Where(a => a != null).ToList();
               
            }
        }

        public IList<CompanyJobPoco> GetList(Func<CompanyJobPoco, bool> where, params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyJobPoco GetSingle(Func<CompanyJobPoco, bool> where, params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
        {
            CompanyJobPoco[] pocos = GetAll().ToArray();
            return pocos.Where(where).ToList().FirstOrDefault();
        }

        public void Remove(params CompanyJobPoco[] items)
        {
            using (SqlConnection cn = new SqlConnection(DbString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cn.Open();
                foreach (var poco in items)
                {
                    cmd.CommandText = @"DELETE FROM [dbo].[Company_Jobs]
                                      WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                   
                    cmd.ExecuteNonQuery();

                }
                cn.Close();
            }
        }

        public void Update(params CompanyJobPoco[] items)
        {
            using (SqlConnection cn = new SqlConnection(DbString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cn.Open();
                foreach (var poco in items)
                {
                    cmd.CommandText = @"UPDATE [dbo].[Company_Jobs]
                                           SET [Id] = @Id
                                              ,[Company] = @Company
                                              ,[Profile_Created] = @Profile_Created
                                              ,[Is_Inactive] = @Is_Inactive
                                              ,[Is_Company_hidden] = @Is_Company_hidden
                                            
                                         WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Company", poco.Company);
                    cmd.Parameters.AddWithValue("@Profile_Created", poco.ProfileCreated);
                    cmd.Parameters.AddWithValue("@Is_Inactive", poco.IsInactive);
                    cmd.Parameters.AddWithValue("@Is_Company_hidden", poco.IsCompanyHidden);
                   
                    cmd.ExecuteNonQuery();
                   
                }
                cn.Close();
            }
        }
    }
}
