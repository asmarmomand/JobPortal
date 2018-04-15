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
    public class SecurityLoginRepository : BaseClass, IDataRepository<SecurityLoginPoco>
    {
        public void Add(params SecurityLoginPoco[] items)
        {
            using (SqlConnection cn = new SqlConnection(DbString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cn.Open();
                foreach (SecurityLoginPoco poco in items)
                {


                    cmd.CommandText = @"INSERT INTO [dbo].[Security_Logins]
                                           ([Id]
                                           ,[Login]
                                           ,[Password]
                                           ,[Created_Date]
                                           ,[Password_Update_Date]
                                           ,[Agreement_Accepted_Date]
                                           ,[Is_Locked]
                                           ,[is_Inactive]
                                           ,[Email_Address]
                                           ,[Phone_Number]
                                           ,[Full_Name]
                                           ,[Force_Change_Password]
                                           ,[Prefferred_Language]
                                            )
                                     VALUES
                                           (@Id
                                           ,@Login
                                           ,@Password
                                           ,@Created_Date
                                           ,@Password_Updated_Date 
                                           ,@Agreement_Accepted_Date
                                           ,@Is_Locked
                                           ,@is_Inactive
                                           ,@Email_Address
                                           ,@Phone_Number
                                           ,@Full_Name
                                           ,@Force_Change_Password
                                           ,@Prefferred_Language)";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Login", poco.Login);
                    cmd.Parameters.AddWithValue("@Password", poco.Password);
                    cmd.Parameters.AddWithValue("@Created_Date", poco.Created);
                    cmd.Parameters.AddWithValue("@Password_Updated_Date", poco.PasswordUpdate);
                    cmd.Parameters.AddWithValue("@Agreement_Accepted_Date", poco.AgreementAccepted);
                    cmd.Parameters.AddWithValue("@Is_Locked", poco.IsLocked);
                    cmd.Parameters.AddWithValue("@is_Inactive", poco.IsInactive);
                    cmd.Parameters.AddWithValue("@Email_Address", poco.EmailAddress);
                    cmd.Parameters.AddWithValue("@Phone_Number", poco.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Full_Name", poco.FullName);
                    cmd.Parameters.AddWithValue("@Force_Change_Password", poco.ForceChangePassword);
                    cmd.Parameters.AddWithValue("@Prefferred_Language", poco.PrefferredLanguage);
                    
                    cmd.ExecuteNonQuery();
                    
                }
                cn.Close();
            }

        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<SecurityLoginPoco> GetAll(params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            using (SqlConnection cn = new SqlConnection(DbString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cn.Open();
                cmd.CommandText = @"SELECT[Id]
                                           ,[Login]
                                           ,[Password]
                                           ,[Created_Date]
                                           ,[Password_Update_Date]
                                           ,[Agreement_Accepted_Date]
                                           ,[Is_Locked]
                                           ,[is_Inactive]
                                           ,[Email_Address]
                                           ,[Phone_Number]
                                           ,[Full_Name]
                                           ,[Force_Change_Password]
                                           ,[Prefferred_Language]
                                      FROM 
                                           [dbo].[Security_Logins]";
                int counter = 0;
                SecurityLoginPoco[] pocos = new SecurityLoginPoco[500];
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SecurityLoginPoco poco = new SecurityLoginPoco();
                    poco.Id = reader.GetGuid(0);
                    poco.Login = reader.GetString(1);
                    poco.Password = reader.GetString(2);
                    poco.Created = reader.GetDateTime(3);
                    if (reader.IsDBNull(4))
                    {
                        poco.PasswordUpdate = null;
                    }
                    else
                    {
                        poco.PasswordUpdate = reader.GetDateTime(4);//.GetDateTime(4);
                    }
                    if (reader.IsDBNull(5))
                    {
                        poco.AgreementAccepted = null;
                    }
                    else
                    {
                        poco.AgreementAccepted = reader.GetDateTime(5);//.GetDateTime(4);
                    }
                    poco.IsLocked = reader.GetBoolean(6);
                    poco.IsInactive = reader.GetBoolean(7);
                    poco.EmailAddress = reader.GetString(8);
                    poco.PhoneNumber = Convert.ToString(reader[9]);
                    poco.FullName = reader.GetString(10);
                    poco.ForceChangePassword = reader.GetBoolean(11);
                    if (reader.IsDBNull(12))
                    {
                        poco.PrefferredLanguage = "";
                    }
                    else
                    {
                        poco.PrefferredLanguage = reader.GetString(12);//.GetDateTime(4);
                    }
                    
                    pocos[counter] = poco;
                    counter++;
                }
                cn.Close();
                return pocos.Where(a => a != null).ToList();
                
            }
        }

        public IList<SecurityLoginPoco> GetList(Func<SecurityLoginPoco, bool> where, params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityLoginPoco GetSingle(Func<SecurityLoginPoco, bool> where, params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            SecurityLoginPoco[] pocos = GetAll().ToArray();
            return pocos.Where(where).ToList().FirstOrDefault();
        }

        public void Remove(params SecurityLoginPoco[] items)
        {
            using (SqlConnection cn = new SqlConnection(DbString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cn.Open();
                foreach (var poco in items)
                {
                    cmd.CommandText = @"DELETE FROM [dbo].[Security_Logins]
                                      WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                   
                    cmd.ExecuteNonQuery();
                  
                }
                cn.Close();
            }
        }

        public void Update(params SecurityLoginPoco[] items)
        {
            using (SqlConnection cn = new SqlConnection(DbString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cn.Open();
                foreach (var poco in items)
                {
                    cmd.CommandText = @"UPDATE [dbo].[Security_Logins]
                                           SET [Id] = @Id
                                              ,[Login] = @Login
                                              ,[Password] = @Password
                                              ,[Created_Date] = @Created_Date
                                              ,[Password_Update_Date] = @Password_Updated_Date
                                              ,[Agreement_Accepted_Date] = @Agreement_Accepted_Date
                                              ,[Is_Locked] = @Is_Locked
                                              ,[is_Inactive] = @is_Inactive
                                              ,[Email_Address] = @Email_Address
                                              ,[Phone_Number] = @Phone_Number
                                              ,[Full_Name] = @Full_Name
                                              ,[Force_Change_Password] = @Force_Change_Password
                                              ,[Prefferred_Language] = @Prefferred_Language
                                         WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Login", poco.Login);
                    cmd.Parameters.AddWithValue("@Password", poco.Password);
                    cmd.Parameters.AddWithValue("@Created_Date", poco.Created);
                    cmd.Parameters.AddWithValue("@Password_Updated_Date", poco.PasswordUpdate);
                    cmd.Parameters.AddWithValue("@Agreement_Accepted_Date", poco.AgreementAccepted);
                    cmd.Parameters.AddWithValue("@Is_Locked", poco.IsLocked);
                    cmd.Parameters.AddWithValue("@is_Inactive", poco.IsInactive);
                    cmd.Parameters.AddWithValue("@Email_Address", poco.EmailAddress);
                    cmd.Parameters.AddWithValue("@Phone_Number", poco.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Full_Name", poco.FullName);
                    cmd.Parameters.AddWithValue("@Force_Change_Password", poco.ForceChangePassword);
                    cmd.Parameters.AddWithValue("@Prefferred_Language", poco.PrefferredLanguage);
                    
                    cmd.ExecuteNonQuery();
                   
                }
                cn.Close();
            }
        }
    }
}
