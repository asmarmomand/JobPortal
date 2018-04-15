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
    public class SecurityLoginsLogRepository : BaseClass, IDataRepository<SecurityLoginsLogPoco>
    {
        public void Add(params SecurityLoginsLogPoco[] items)
        {
            using (SqlConnection cn = new SqlConnection(DbString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cn.Open();
                foreach (SecurityLoginsLogPoco poco in items)
                {


                    cmd.CommandText = @"INSERT INTO [dbo].[Security_Logins_Log]
                                           ([Id]
                                           ,[Login]
                                           ,[Source_IP]
                                           ,[Logon_Date]
                                           ,[Is_Succesful]
                                           )
                                     VALUES
                                           (@Id
                                           ,@Login
                                           ,@Source_IP
                                           ,@Logon_Date
                                           ,@Is_Succesful)";
                                          
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Login", poco.Login);
                    cmd.Parameters.AddWithValue("@Source_IP", poco.SourceIP);
                    cmd.Parameters.AddWithValue("@Logon_Date", poco.LogonDate);
                    cmd.Parameters.AddWithValue("@Is_Succesful", poco.IsSuccesful);
                   
                    
                    cmd.ExecuteNonQuery();
                    
                }
                cn.Close();
            }

        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<SecurityLoginsLogPoco> GetAll(params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
        {
            using (SqlConnection cn = new SqlConnection(DbString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cn.Open();
                cmd.CommandText = @"SELECT [Id]
                                           ,[Login]
                                           ,[Source_IP]
                                           ,[Logon_Date]
                                           ,[Is_Succesful]
                                      FROM 
                                           [dbo].[Security_Logins_Log]";
                int counter = 0;
                SecurityLoginsLogPoco[] pocos = new SecurityLoginsLogPoco[5000];
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SecurityLoginsLogPoco poco = new SecurityLoginsLogPoco();
                    poco.Id = reader.GetGuid(0);
                    poco.Login = reader.GetGuid(1);
                    poco.SourceIP = reader.GetString(2);
                    poco.LogonDate = reader.GetDateTime(3);
                    poco.IsSuccesful = reader.GetBoolean(4);
                    
                    pocos[counter] = poco;
                    counter++;
                }
                cn.Close();
                return pocos.Where(a => a != null).ToList();
              
             
            }
        }

        public IList<SecurityLoginsLogPoco> GetList(Func<SecurityLoginsLogPoco, bool> where, params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityLoginsLogPoco GetSingle(Func<SecurityLoginsLogPoco, bool> where, params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
        {
            SecurityLoginsLogPoco[] pocos = GetAll().ToArray();
            return pocos.Where(where).ToList().FirstOrDefault();
        }

        public void Remove(params SecurityLoginsLogPoco[] items)
        {
            using (SqlConnection cn = new SqlConnection(DbString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cn.Open();
                foreach (var poco in items)
                {
                    cmd.CommandText = @"DELETE FROM [dbo].[Security_Logins_Log]
                                      WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    
                    cmd.ExecuteNonQuery();
                   
                }
                cn.Close();
            }
        }

        public void Update(params SecurityLoginsLogPoco[] items)
        {
            using (SqlConnection cn = new SqlConnection(DbString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cn.Open();
                foreach (var poco in items)
                {
                    cmd.CommandText = @"UPDATE [dbo].[Security_Logins_Log]
                                           SET [Id] = @Id
                                              ,[Login] = @Login
                                              ,[Source_IP] = @Source_IP
                                              ,[Logon_Date] = @Logon_Date
                                              ,[Is_Succesful] = @Is_Succesful
                                             
                                         WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Login", poco.Login);
                    cmd.Parameters.AddWithValue("@Source_IP", poco.SourceIP);
                    cmd.Parameters.AddWithValue("@Logon_Date", poco.LogonDate);
                    cmd.Parameters.AddWithValue("@Is_Succesful", poco.IsSuccesful);
                    
                    cmd.ExecuteNonQuery();
                    
                }
                cn.Close();
            }
        }
    }
}
