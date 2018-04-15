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
    public class CompanyJobSkillRepository : BaseClass, IDataRepository<CompanyJobSkillPoco>
    {
        public void Add(params CompanyJobSkillPoco[] items)
        {
            using (SqlConnection cn = new SqlConnection(DbString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cn.Open();
                foreach (CompanyJobSkillPoco poco in items)
                {


                    cmd.CommandText = @"INSERT INTO [dbo].[Company_Job_Skills]
                                           ([Id]
                                           ,[Job]
                                           ,[Skill]
                                           ,[Skill_Level]
                                           ,[Importance])
                                          
                                     VALUES
                                           (@Id
                                           ,@Job
                                           ,@Skill
                                           ,@Skill_Level
                                           ,@Importance)";
                                          
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Job", poco.Job);
                    cmd.Parameters.AddWithValue("@Skill", poco.Skill);
                    cmd.Parameters.AddWithValue("@Skill_Level", poco.SkillLevel);
                    cmd.Parameters.AddWithValue("@Importance", poco.Importance);
                   
                   
                    cmd.ExecuteNonQuery();
                    
                }
                cn.Close();
            }

        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyJobSkillPoco> GetAll(params Expression<Func<CompanyJobSkillPoco, object>>[] navigationProperties)
        {
            using (SqlConnection cn = new SqlConnection(DbString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cn.Open();
                cmd.CommandText = @"SELECT [Id]
                                          ,[Job]
                                          ,[Skill]
                                          ,[Skill_Level]
                                          ,[Importance]
                                          
                                      FROM 
                                           [dbo].[Company_Job_Skills]";
                int counter = 0;
                CompanyJobSkillPoco[] pocos = new CompanyJobSkillPoco[50000];
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CompanyJobSkillPoco poco = new CompanyJobSkillPoco();
                    poco.Id = reader.GetGuid(0);
                    poco.Job = reader.GetGuid(1);
                    poco.Skill = reader.GetString(2);
                    poco.SkillLevel = reader.GetString(3);
                    poco.Importance = reader.GetInt32(4);
                    
                    pocos[counter] = poco;
                    counter++;
                }
                cn.Close();
                return pocos.Where(a => a != null).ToList();
               
             
            }
        }

        public IList<CompanyJobSkillPoco> GetList(Func<CompanyJobSkillPoco, bool> where, params Expression<Func<CompanyJobSkillPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyJobSkillPoco GetSingle(Func<CompanyJobSkillPoco, bool> where, params Expression<Func<CompanyJobSkillPoco, object>>[] navigationProperties)
        {
            CompanyJobSkillPoco[] pocos = GetAll().ToArray();
            return pocos.Where(where).ToList().FirstOrDefault();
        }

        public void Remove(params CompanyJobSkillPoco[] items)
        {
            using (SqlConnection cn = new SqlConnection(DbString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cn.Open();
                foreach (var poco in items)
                {
                    cmd.CommandText = @"DELETE FROM [dbo].[Company_Job_Skills]
                                      WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                   
                    cmd.ExecuteNonQuery();
                   
                }
                cn.Close();
            }
        }

        public void Update(params CompanyJobSkillPoco[] items)
        {
            using (SqlConnection cn = new SqlConnection(DbString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cn.Open();
                foreach (var poco in items)
                {
                    cmd.CommandText = @"UPDATE [dbo].[Company_Job_Skills]
                                           SET [Id] = @Id
                                              ,[Job] = @Job
                                              ,[Skill] = @Skill
                                              ,[Skill_Level] = @Skill_Level
                                              ,[Importance] = @Importance
                                              
                                         WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Job", poco.Job);
                    cmd.Parameters.AddWithValue("@Skill", poco.Skill);
                    cmd.Parameters.AddWithValue("@Skill_Level", poco.SkillLevel);
                    cmd.Parameters.AddWithValue("@Importance", poco.Importance);
                    
                    cmd.ExecuteNonQuery();
                
                }
                cn.Close();
            }
        }
    }
}
