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
    public class SystemCountryCodeRepository : BaseClass, IDataRepository<SystemCountryCodePoco>
    {
        public void Add(params SystemCountryCodePoco[] items)
        {
            using (SqlConnection cn = new SqlConnection(DbString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cn.Open();
                foreach (SystemCountryCodePoco poco in items)
                {


                    cmd.CommandText = @"INSERT INTO [dbo].[System_Country_Codes]
                                           ([Code]
                                           ,[Name]
                                          )
                                     VALUES
                                           (@Code
                                           ,@Name)";
                                          
                    cmd.Parameters.AddWithValue("@Code", poco.Code);
                    cmd.Parameters.AddWithValue("@Name", poco.Name);
                    
                    
                    cmd.ExecuteNonQuery();
                    
                }
                cn.Close();
            }

        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<SystemCountryCodePoco> GetAll(params Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
        {
            using (SqlConnection cn = new SqlConnection(DbString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cn.Open();
                cmd.CommandText = @"SELECT [Code]
                                          ,[Name]
                                          
                                      FROM 
                                           [dbo].[System_Country_Codes]";
                int counter = 0;
                SystemCountryCodePoco[] pocos = new SystemCountryCodePoco[500];
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SystemCountryCodePoco poco = new SystemCountryCodePoco();
                    poco.Code = reader.GetString(0);
                    poco.Name = reader.GetString(1);
                    
                    pocos[counter] = poco;
                    counter++;
                }
                cn.Close();
                return pocos.Where(a => a != null).ToList();
             
            }
        }

        public IList<SystemCountryCodePoco> GetList(Func<SystemCountryCodePoco, bool> where, params Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SystemCountryCodePoco GetSingle(Func<SystemCountryCodePoco, bool> where, params Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
        {
            SystemCountryCodePoco[] pocos = GetAll().ToArray();
            return pocos.Where(where).ToList().FirstOrDefault();
        }

        public void Remove(params SystemCountryCodePoco[] items)
        {
            using (SqlConnection cn = new SqlConnection(DbString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cn.Open();
                foreach (var poco in items)
                {
                    cmd.CommandText = @"DELETE FROM [dbo].[System_Country_Codes]
                                      WHERE Code = @Code";
                    cmd.Parameters.AddWithValue("@Code", poco.Code);
                    
                    cmd.ExecuteNonQuery();
                    
                }
                cn.Close();
            }
        }

        public void Update(params SystemCountryCodePoco[] items)
        {
            using (SqlConnection cn = new SqlConnection(DbString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cn.Open();
                foreach (var poco in items)
                {
                    cmd.CommandText = @"UPDATE [dbo].[System_Country_Codes]
                                           SET [Code] = @Code
                                              ,[Name] = @Name
                                              
                                         WHERE Code = @Code";
                    cmd.Parameters.AddWithValue("@Code", poco.Code);
                    cmd.Parameters.AddWithValue("@Name", poco.Name);

                   
                    cmd.ExecuteNonQuery();
                    
                }
                cn.Close();
            }
        }
    }
}
