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
                    SqlCommand cmd = new SqlCommand("UpdateTeacherInfo", sqlconnection);
                    cmd.Parameters.Add(new SqlParameter("@LoginId", id));
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            teacher.First_Name = sdr["First_Name"].ToString();
                            teacher.Middle_Name = sdr["Midde_Name"].ToString();
                            teacher.Last_Name = sdr["Last_Name"].ToString();
                            teacher.Address1 = sdr["Address1"].ToString();
                            teacher.City= sdr["City"].ToString();
                            teacher.Pin = Convert.ToInt32(sdr["Pin"]);
                            teacher.Country= sdr["Country"].ToString();
                            teacher.EmergencyContactId = sdr["EmergencyContactId"].ToString();
                            teacher.ContactNo= sdr["ContactNo"].ToString();
                            teacher.EmailID= sdr["EmailID"].ToString();
                            teacher.BloogGroup= sdr["BloodGroup"].ToString();
                            teacher.JobType =sdr["JobType"].ToString();
                            teacher.WorkType= sdr["WorkType"].ToString();
                            teacher.Payment= Convert.ToDecimal(sdr["Payment"]);
                            teacher.IsResume = Convert.ToBoolean(sdr["Resume"]);
                            teacher.DeptId = Convert.ToInt32(sdr["DeptId"]);
                        }
                    }
                    sqlconnection.Close();
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return teacher;
        }
        
        public IList<Teacher> GetAll()
        {
            List<Teacher> teachers = new List<Teacher>();
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["InstCon"].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("UpdateTeacherInfo", sqlconnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            var teacher = new Teacher();
                            teacher.First_Name = sdr["First_Name"].ToString();
                            teacher.Middle_Name = sdr["Midde_Name"].ToString();
                            teacher.Last_Name = sdr["Last_Name"].ToString();
                            teacher.Address1 = sdr["Address1"].ToString();
                            teacher.City = sdr["City"].ToString();
                            teacher.Pin = Convert.ToInt32(sdr["Pin"]);
                            teacher.Country = sdr["Country"].ToString();
                            teacher.EmergencyContactId = sdr["EmergencyContactId"].ToString();
                            teacher.ContactNo = sdr["ContactNo"].ToString();
                            teacher.EmailID = sdr["EmailID"].ToString();
                            teacher.BloogGroup = sdr["BloodGroup"].ToString();
                            teacher.JobType = sdr["JobType"].ToString();
                            teacher.WorkType = sdr["WorkType"].ToString();
                            teacher.Payment = Convert.ToDecimal(sdr["Payment"]);
                            teacher.IsResume = Convert.ToBoolean(sdr["Resume"]);
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

        public string CreateTeacher(Teacher teacher)
        {
            int res = 0;
            string result="";   
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["InstCon"].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("UpdateTeacherInfo", sqlconnection);
                    cmd.Parameters.Add(new SqlParameter("@First_Name", teacher.First_Name));
                    cmd.Parameters.Add(new SqlParameter("@Last_Name", teacher.Last_Name));
                    cmd.Parameters.Add(new SqlParameter("@Midde_Name", teacher.Middle_Name));
                    cmd.Parameters.Add(new SqlParameter("@Address1", teacher.Address1));
                    cmd.Parameters.Add(new SqlParameter("@City", teacher.City));
                    cmd.Parameters.Add(new SqlParameter("@Pin", teacher.Pin));
                    cmd.Parameters.Add(new SqlParameter("@Country", teacher.Country));
                    cmd.Parameters.Add(new SqlParameter("@EmergencyContactId", teacher.EmergencyContactId));
                    cmd.Parameters.Add(new SqlParameter("@ContactNo", teacher.ContactNo));
                    cmd.Parameters.Add(new SqlParameter("@EmailID", teacher.EmailID));
                    cmd.Parameters.Add(new SqlParameter("@BloodGroup", teacher.BloogGroup));
                    cmd.Parameters.Add(new SqlParameter("@JobType", teacher.JobType));
                    cmd.Parameters.Add(new SqlParameter("@WorkType", teacher.WorkType));
                    cmd.Parameters.Add(new SqlParameter("@Payment", teacher.Payment));
                    cmd.Parameters.Add(new SqlParameter("@Resume", teacher.IsResume));
                    cmd.Parameters.Add(new SqlParameter("@DeptId", teacher.DeptId));
                    cmd.Parameters.Add(new SqlParameter("@DOB", teacher.DOB));
                    cmd.Parameters.Add(new SqlParameter("@UserName", teacher.UserName));
                    cmd.Parameters.Add(new SqlParameter("@Password", teacher.Password));
                    

                    cmd.CommandType = CommandType.StoredProcedure;
                    if (cmd.ExecuteNonQuery() > 0)
                        result = "Teacher Successfully Created";
                    sqlconnection.Close();
                }
            }
            catch (Exception ex)
            {
                result= ex.Message.ToString();
            }
            return result;
        }

        public int UpdateTeacher(Teacher teacher)
        {
            int res = 0;
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["InstCon"].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("", sqlconnection);
                    cmd.Parameters.Add(new SqlParameter("@First_Name", teacher.First_Name));
                    cmd.Parameters.Add(new SqlParameter("@Last_Name", teacher.Last_Name));
                    cmd.Parameters.Add(new SqlParameter("@Middle_Name", teacher.Middle_Name));
                    cmd.Parameters.Add(new SqlParameter("@Address1", teacher.Address1));
                    cmd.Parameters.Add(new SqlParameter("@City", teacher.City));
                    cmd.Parameters.Add(new SqlParameter("@Pin", teacher.Pin));
                    cmd.Parameters.Add(new SqlParameter("@Country", teacher.Country));
                    cmd.Parameters.Add(new SqlParameter("@EmergencyContactId", teacher.EmergencyContactId));
                    cmd.Parameters.Add(new SqlParameter("@ContactNo", teacher.ContactNo));
                    cmd.Parameters.Add(new SqlParameter("@EmailID", teacher.EmailID));
                    cmd.Parameters.Add(new SqlParameter("@BloodGroup", teacher.BloogGroup));
                    cmd.Parameters.Add(new SqlParameter("@JobType", teacher.JobType));
                    cmd.Parameters.Add(new SqlParameter("@WorkType", teacher.WorkType));
                    cmd.Parameters.Add(new SqlParameter("@Payment", teacher.Payment));
                    cmd.Parameters.Add(new SqlParameter("@Resume", teacher.IsResume));
                    cmd.Parameters.Add(new SqlParameter("@DeptId", teacher.DeptId));
                    cmd.Parameters.Add(new SqlParameter("@DOB", teacher.DOB));
                    cmd.Parameters.Add(new SqlParameter("@UserName", teacher.UserName));
                    cmd.Parameters.Add(new SqlParameter("@Password", teacher.Password));
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
