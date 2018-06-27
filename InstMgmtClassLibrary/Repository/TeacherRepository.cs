using InstMgmtClassLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using InstMgmtClassLibrary.Interfaces;

namespace InstMgmtClassLibrary.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        public Teacher Get(int id)
        {
            var teacher = new Teacher();
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["InstCon"].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("GetTeacherInfo", sqlconnection);
                    cmd.Parameters.Add(new SqlParameter("@LoginId", id));
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            teacher.First_Name = sdr["First_Name"].ToString();
                            teacher.Midde_Name = sdr["Middle_Name"].ToString();
                            teacher.Last_Name = sdr["Last_Name"].ToString();
                            teacher.Address = sdr["Address1"].ToString();
                            teacher.City = sdr["City"].ToString();
                            teacher.Pin = sdr["Pin"].ToString();
                            teacher.Country = sdr["Country"].ToString();
                            teacher.Gender = sdr["Gender"].ToString();
                            teacher.EmergencyContactNo = sdr["EmergencyContactNo"].ToString();
                            teacher.ContactNo = sdr["ContactNo"].ToString();
                            teacher.EmailID = sdr["EmailID"].ToString();
                            teacher.BloodGroup = sdr["BloodGroup"].ToString();
                            teacher.JobType = Convert.ToInt32(sdr["JobType"]);
                            teacher.WorkType = Convert.ToInt32(sdr["WorkType"]);
                            teacher.Payment = Convert.ToDecimal(sdr["Payment"]);
                            teacher.Photo = sdr["Photo"].ToString();
                            teacher.DeptId = Convert.ToInt32(sdr["DeptId"]);
                        }
                    }
                    else { teacher=null;}
                    sqlconnection.Close();
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return teacher;
        }
        
        public IList<Teacher> GetTeacher(int id)
        {
            List<Teacher> teachers = new List<Teacher>();
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["InstCon"].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("GetTeacherInfo", sqlconnection);
                    cmd.Parameters.Add(new SqlParameter("@LoginId", id));
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            var teacher = new Teacher();
                            teacher.TeacherId = Convert.ToInt32(sdr["TeacherID"]);
                            teacher.LoginId= Convert.ToInt32(sdr["LoginID"]);
                            teacher.First_Name = sdr["First_Name"].ToString();
                            teacher.First_Name = sdr["First_Name"].ToString();
                            teacher.Midde_Name = sdr["Middle_Name"].ToString();
                            teacher.Last_Name = sdr["Last_Name"].ToString();
                            teacher.Address = sdr["Address1"].ToString();
                            teacher.City = sdr["City"].ToString();
                            teacher.Pin = sdr["Pin"].ToString();
                            teacher.Designation = sdr["Designation"].ToString();
                            teacher.Country = sdr["Country"].ToString();
                            teacher.Gender = sdr["Gender"].ToString();
                            teacher.EmergencyContactNo = sdr["EmergencyContactNo"].ToString();
                            teacher.ContactNo = sdr["ContactNo"].ToString();
                            teacher.EmailID = sdr["EmailID"].ToString();
                            teacher.BloodGroup = sdr["BloodGroup"].ToString();
                            teacher.JobType = Convert.ToInt32(sdr["JobType"]);
                            teacher.WorkType = Convert.ToInt32(sdr["WorkType"]);
                            teacher.Payment = Convert.ToDecimal(sdr["Payment"]);
                            teacher.Photo = sdr["Photo"].ToString();
                            teacher.DeptId = Convert.ToInt32(sdr["DeptId"]);

                            teachers.Add(teacher);
                        }
                    }
                    sqlconnection.Close();
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return teachers.ToList();
        }

        public int CreateTeacher(Teacher teacher)
        {
            int res = 0;
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["InstCon"].ConnectionString))
                {
                    sqlconnection.Open();
                    int RoleId = 3;
                    bool isUpdate = false;
                    SqlCommand cmdLogin = new SqlCommand("SP_InsertLogin", sqlconnection);
                    cmdLogin.Parameters.AddWithValue("@Username", teacher.UserName);
                    cmdLogin.Parameters.AddWithValue("@Password", teacher.Password);
                    cmdLogin.Parameters.AddWithValue("@RoleId", RoleId);
                    cmdLogin.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = cmdLogin.Parameters.Add("@LoginId", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    cmdLogin.ExecuteNonQuery();
                    int LoginId = (int)returnParameter.Value;
                    if (LoginId > 0)
                    {
                        SqlCommand cmd = new SqlCommand("SP_InsertTeacherInfo", sqlconnection);
                        cmd.Parameters.Add(new SqlParameter("@First_Name", teacher.First_Name));
                        cmd.Parameters.Add(new SqlParameter("@Middle_Name", teacher.Midde_Name));
                        cmd.Parameters.Add(new SqlParameter("@Last_Name", teacher.Last_Name));
                        cmd.Parameters.Add(new SqlParameter("@Address1", teacher.Address));
                        cmd.Parameters.Add(new SqlParameter("@City", teacher.City));
                        cmd.Parameters.Add(new SqlParameter("@Country", teacher.Country));
                        cmd.Parameters.Add(new SqlParameter("@Gender", teacher.Gender));
                        cmd.Parameters.Add(new SqlParameter("@Pin", teacher.Pin));
                        cmd.Parameters.Add(new SqlParameter("@ContactNo", teacher.ContactNo));
                        cmd.Parameters.Add(new SqlParameter("@EmailID", teacher.EmailID));
                        cmd.Parameters.Add(new SqlParameter("@Designation", teacher.Designation));
                        cmd.Parameters.Add(new SqlParameter("@BloodGroup", teacher.BloodGroup));
                        cmd.Parameters.Add(new SqlParameter("@DeptId", teacher.DeptId));
                        cmd.Parameters.Add(new SqlParameter("@Payment", teacher.Payment));
                        cmd.Parameters.Add(new SqlParameter("@LoginId", LoginId));
                        cmd.Parameters.Add(new SqlParameter("@EmergencyContactNo", teacher.EmergencyContactNo));
                        cmd.Parameters.Add(new SqlParameter("@JobType", teacher.JobType));
                        cmd.Parameters.Add(new SqlParameter("@WorkType", teacher.WorkType));
                        cmd.Parameters.Add(new SqlParameter("@Resume", teacher.IsResume));
                        cmd.Parameters.Add(new SqlParameter("@IsUpdate", isUpdate));

                        cmd.CommandType = CommandType.StoredProcedure;
                        res = cmd.ExecuteNonQuery();
                    }
                    sqlconnection.Close();
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return res;
        }

        public int UpdateTeacher(Teacher teacher)
        {
            int res = 0;
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["InstCon"].ConnectionString))
                {
                    bool isUpdate = true;
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("SP_InsertTeacherInfo", sqlconnection);
                    cmd.Parameters.Add(new SqlParameter("@First_Name", teacher.First_Name));
                    cmd.Parameters.Add(new SqlParameter("@Middle_Name", teacher.Midde_Name));
                    cmd.Parameters.Add(new SqlParameter("@Last_Name", teacher.Last_Name));
                    cmd.Parameters.Add(new SqlParameter("@Address1", teacher.Address));
                    cmd.Parameters.Add(new SqlParameter("@City", teacher.City));
                    cmd.Parameters.Add(new SqlParameter("@Country", teacher.Country));
                    cmd.Parameters.Add(new SqlParameter("@Gender", teacher.Gender));
                    cmd.Parameters.Add(new SqlParameter("@Pin", teacher.Pin));
                    cmd.Parameters.Add(new SqlParameter("@ContactNo", teacher.ContactNo));
                    cmd.Parameters.Add(new SqlParameter("@EmailID", teacher.EmailID));
                    cmd.Parameters.Add(new SqlParameter("@Designation", teacher.Designation));
                    cmd.Parameters.Add(new SqlParameter("@BloodGroup", teacher.BloodGroup));
                    cmd.Parameters.Add(new SqlParameter("@DeptId", teacher.DeptId));
                    cmd.Parameters.Add(new SqlParameter("@Payment", teacher.Payment));
                    cmd.Parameters.Add(new SqlParameter("@LoginId", teacher.LoginId));
                    cmd.Parameters.Add(new SqlParameter("@EmergencyContactNo", teacher.EmergencyContactNo));
                    cmd.Parameters.Add(new SqlParameter("@JobType", teacher.JobType));
                    cmd.Parameters.Add(new SqlParameter("@WorkType", teacher.WorkType));
                    cmd.Parameters.Add(new SqlParameter("@Resume", teacher.IsResume));
                    cmd.Parameters.Add(new SqlParameter("@IsUpdate", isUpdate));
                    cmd.CommandType = CommandType.StoredProcedure;
                    res = cmd.ExecuteNonQuery();
                    sqlconnection.Close();
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return res;
        }

        public bool DeleteTeacher(int id)
        {
            bool result = false;
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["InstCon"].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("", sqlconnection);
                    cmd.Parameters.AddWithValue("@Id", id);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        result = true;
                    }
                    else {
                        result = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return result;
        }
    }
}
