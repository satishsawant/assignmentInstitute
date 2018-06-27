using InstMgmtClassLibrary.Domain;
using InstMgmtClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstMgmtClassLibrary.Repository
{
    public class LoginRepository : ILoginRepository 
    {
        public LoginResponse Login(LoginRequestModel log)
        {
            
            LoginResponse response = new LoginResponse();
            try
            {
                int LoginId;
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["InstCon"].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand command = new SqlCommand("SP_LoginInfo", sqlconnection);
                    command.Parameters.AddWithValue("@Username", log.Username);
                    command.Parameters.AddWithValue("@password", log.Password);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = command.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            LoginId = Convert.ToInt32(sdr["LoginID"]);
                            if (log.RoleId == 2)
                            {
                                StudentRepository sr = new StudentRepository();
                                response.success = "true";
                                response.studentData = sr.GetStudent(LoginId);
                                response.RoleId= Convert.ToInt32(sdr["RoleID"]);
                            }
                            else if (log.RoleId == 3)
                            {
                                TeacherRepository tr = new TeacherRepository();
                                response.success = "true";
                                response.teacherData = tr.GetTeacher(LoginId);
                                response.RoleId = Convert.ToInt32(sdr["RoleID"]);
                            }
                        }
                    }
                    else { response.success = "false"; }
                }
            }
            catch (Exception ex)
            {
                response.success = "false";
                response.error = ex.Message;
            }
            return response;
        }
    }
}
