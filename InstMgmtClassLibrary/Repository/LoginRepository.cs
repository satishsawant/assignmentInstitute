using InstMgmtClassLibrary.Domain;
using InstMgmtClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstMgmtClassLibrary.Repository
{
    public class LoginRepository : ILoginRepository 
    {
        public string Login(Login log)
        {
            string JsonStr;
            StringBuilder sb = new StringBuilder();
            string RoleName = "";
            int RoleId, LoginId;
            try
            {
                SqlConnection connection = new SqlConnection(
                System.Configuration.ConfigurationManager.ConnectionStrings["InstCon"].ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("Select * from Login where Username=@username And Password=@password", connection);
                command.Parameters.AddWithValue("@username", log.Username);
                command.Parameters.AddWithValue("@password", log.Password);
                SqlDataReader sdr = command.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        RoleName = sdr["RoleType"].ToString();
                        RoleId = Convert.ToInt32(sdr["RoleId"]);
                        LoginId = Convert.ToInt32(sdr["LoginId"]);
                        sb.Append(RoleName);
                        sb.Append(LoginId);
                        if (RoleName.Equals("Teacher"))
                        {
                            TeacherRepository tr = new TeacherRepository();
                            Teacher t = tr.Get(LoginId);
                            sb.Append(t.ToString());
                        }
                        else if (RoleName.Equals("Student"))
                        {
                            //TeacherRepository tr = new TeacherRepository();
                            //Student s = tr.Get(LoginId);
                        }
                    }
                }
                connection.Close();
            }
            catch (Exception)
            {
                
            }
            return sb.ToString();
        }
    }
}
