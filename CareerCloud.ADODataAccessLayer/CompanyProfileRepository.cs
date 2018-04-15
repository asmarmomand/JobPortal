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
    public class CompanyProfileRepository : BaseClass, IDataRepository<CompanyProfilePoco>
    {
        public void Add(params CompanyProfilePoco[] items)
        {
            using (SqlConnection cn = new SqlConnection(DbString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cn.Open();
                foreach (CompanyProfilePoco poco in items)
                {


                    cmd.CommandText = @"INSERT INTO [dbo].[Company_Profiles]
                                           ([Id]
                                           ,[Registration_Date]
                                           ,[Company_Website]
                                           ,[Contact_Phone]
                                           ,[Contact_Name]
                                           ,[Company_Logo])
                                          
                                     VALUES
                                           (@Id
                                           ,@Registration_Date
                                           ,@Company_Website
                                           ,@Contact_Phone
                                           ,@Contact_Name 
                                           ,@Company_Logo)";
                                           
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Registration_Date", poco.RegistrationDate);
                    cmd.Parameters.AddWithValue("@Company_Website", poco.CompanyWebsite);
                    cmd.Parameters.AddWithValue("@Contact_Phone", poco.ContactPhone);
                    cmd.Parameters.AddWithValue("@Contact_Name", poco.ContactName);
                    cmd.Parameters.AddWithValue("@Company_Logo", poco.CompanyLogo);
                    
                   
                    cmd.ExecuteNonQuery();
                   
                }
                cn.Close();
            }

        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyProfilePoco> GetAll(params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            using (SqlConnection cn = new SqlConnection(DbString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cn.Open();
                cmd.CommandText = @"SELECT[Id]
                                           ,[Registration_Date]
                                           ,[Company_Website]
                                           ,[Contact_Phone]
                                           ,[Contact_Name]
                                           ,[Company_Logo]
                                      FROM 
                                           [dbo].[Company_Profiles]";
                int counter = 0;
                CompanyProfilePoco[] pocos = new CompanyProfilePoco[500];
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CompanyProfilePoco poco = new CompanyProfilePoco();
                    poco.Id = reader.GetGuid(0);
                    poco.RegistrationDate = reader.GetDateTime(1);
                    if (reader.IsDBNull(2))
                    {
                        poco.CompanyWebsite = "";
                    }
                    else
                    {
                        poco.CompanyWebsite =reader.GetString(2);
                    }
                   
                    poco.ContactPhone = reader.GetString(3);
                    if (reader.IsDBNull(4))
                    {
                        poco.ContactName = "";
                    }
                    else
                    {
                        poco.ContactName = reader.GetString(4);
                    }
                   
                    if (reader.IsDBNull(5))
                    {
                        poco.CompanyLogo = null;
                    }
                    else
                    {
                        poco.CompanyLogo = (byte[])reader[5];
                    }
                   
                    
                    pocos[counter] = poco;
                    counter++;
                }
                cn.Close();
                return pocos.Where(a => a != null).ToList();
                
             
            }
        }

        public IList<CompanyProfilePoco> GetList(Func<CompanyProfilePoco, bool> where, params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyProfilePoco GetSingle(Func<CompanyProfilePoco, bool> where, params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            CompanyProfilePoco[] pocos = GetAll().ToArray();
            return pocos.Where(where).ToList().FirstOrDefault();
        }

        public void Remove(params CompanyProfilePoco[] items)
        {
            using (SqlConnection cn = new SqlConnection(DbString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cn.Open();
                foreach (var poco in items)
                {
                    cmd.CommandText = @"DELETE FROM [dbo].[Company_Profiles]
                                      WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                   
                    cmd.ExecuteNonQuery();
                 
                }
                cn.Close();
            }
        }

        public void Update(params CompanyProfilePoco[] items)
        {
            using (SqlConnection cn = new SqlConnection(DbString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cn.Open();
                foreach (var poco in items)
                {
                    cmd.CommandText = @"UPDATE [dbo].[Company_Profiles]
                                           SET [Id] = @Id
                                              ,[Registration_Date] = @Registration_Date
                                              ,[Company_Website] = @Company_Website
                                              ,[Contact_Phone] = @Contact_Phone
                                              ,[Contact_Name] = @Contact_Name
                                              ,[Company_Logo] = @Company_Logo
                                             
                                         WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Registration_Date", poco.RegistrationDate);
                    cmd.Parameters.AddWithValue("@Company_Website", poco.CompanyWebsite);
                    cmd.Parameters.AddWithValue("@Contact_Phone", poco.ContactPhone);
                    cmd.Parameters.AddWithValue("@Contact_Name", poco.ContactName);
                    cmd.Parameters.AddWithValue("@Company_Logo", poco.CompanyLogo);

                    
                    cmd.ExecuteNonQuery();
                    
                }
                cn.Close();
            }
        }
    }
}
