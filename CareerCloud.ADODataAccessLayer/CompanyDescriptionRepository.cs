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
    public class CompanyDescriptionRepository : BaseClass, IDataRepository<CompanyDescriptionPoco>
    {
        public void Add(params CompanyDescriptionPoco[] items)
        {
            using (SqlConnection cn = new SqlConnection(DbString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cn.Open();
                foreach (CompanyDescriptionPoco poco in items)
                {


                    cmd.CommandText = @"INSERT INTO [dbo].[Company_Descriptions]
                                           ([Id]
                                           ,[Company]
                                           ,[LanguageID]
                                           ,[Company_Name]
                                           ,[Company_Description])
                                           
                                     VALUES
                                           (@Id
                                           ,@Company
                                           ,@LanguageID
                                           ,@Company_Name
                                           ,@Company_Description)";
                                          
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Company", poco.Company);
                    cmd.Parameters.AddWithValue("@LanguageID", poco.LanguageId);
                    cmd.Parameters.AddWithValue("@Company_Name", poco.CompanyName);
                    cmd.Parameters.AddWithValue("@Company_Description", poco.CompanyDescription);
                    
                    
                    cmd.ExecuteNonQuery();
                    
                }
                cn.Close();
            }

        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyDescriptionPoco> GetAll(params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
        {
            using (SqlConnection cn = new SqlConnection(DbString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cn.Open();
                cmd.CommandText = @"SELECT [Id]
                                          ,[Company]
                                          ,[LanguageID]
                                          ,[Company_Name]
                                          ,[Company_Description]
                                          
                                      FROM 
                                           [dbo].[Company_Descriptions]";
                int counter = 0;
                CompanyDescriptionPoco[] pocos = new CompanyDescriptionPoco[5000];
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CompanyDescriptionPoco poco = new CompanyDescriptionPoco();
                    poco.Id = reader.GetGuid(0);
                    poco.Company = reader.GetGuid(1);
                    poco.LanguageId = reader.GetString(2);
                    poco.CompanyName = reader.GetString(3);
                    poco.CompanyDescription = reader.GetString(4);
                   
                    pocos[counter] = poco;
                    counter++;
                }
                cn.Close();
                return pocos.Where(a => a != null).ToList();
                
             
            }
        }

        public IList<CompanyDescriptionPoco> GetList(Func<CompanyDescriptionPoco, bool> where, params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyDescriptionPoco GetSingle(Func<CompanyDescriptionPoco, bool> where, params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
        {
            CompanyDescriptionPoco[] pocos = GetAll().ToArray();
            return pocos.Where(where).ToList().FirstOrDefault();
        }

        public void Remove(params CompanyDescriptionPoco[] items)
        {
            using (SqlConnection cn = new SqlConnection(DbString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cn.Open();
                foreach (var poco in items)
                {
                    cmd.CommandText = @"DELETE FROM [dbo].[Company_Descriptions]
                                      WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                   
                    cmd.ExecuteNonQuery();
                   
                }
                cn.Close();
            }
        }

        public void Update(params CompanyDescriptionPoco[] items)
        {
            using (SqlConnection cn = new SqlConnection(DbString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cn.Open();
                foreach (var poco in items)
                {
                    cmd.CommandText = @"UPDATE [dbo].[Company_Descriptions]
                                           SET [Id] = @Id
                                              ,[Company] = @Company
                                              ,[LanguageID] = @LanguageID
                                              ,[Company_Name] = @Company_Name
                                              ,[Company_Description] = @Company_Description
                                             
                                         WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Company", poco.Company);
                    cmd.Parameters.AddWithValue("@LanguageID", poco.LanguageId);
                    cmd.Parameters.AddWithValue("@Company_Name", poco.CompanyName);
                    cmd.Parameters.AddWithValue("@Company_Description", poco.CompanyDescription);

                  
                    cmd.ExecuteNonQuery();
                    
                }
                cn.Close();
            }
        }
    }
}
