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
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings[""].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("", sqlconnection);
                    cmd.Parameters.Add(new SqlParameter("@Id", id));
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            teacher.First_Name = sdr["First_Name"].ToString();
                            teacher.Midde_Name = sdr["Midde_Name"].ToString();
                            teacher.Last_Name = sdr["Last_Name"].ToString();
                            teacher.Address = sdr["Address"].ToString();
                            teacher.ContactNo = sdr["ContactNo"].ToString();
                            teacher.EmergencyContactId = sdr["EmergencyContactId"].ToString();
                            teacher.City = sdr["EmergencyContactId"].ToString();
                            teacher.Country = sdr["Country"].ToString();
                            teacher.Pin = sdr["Pin"].ToString();
                            teacher.BloodGroup = sdr["BloodGroup"].ToString();
                            teacher.DOB = Convert.ToDateTime(sdr["DOB"]);
                            teacher.Designation = sdr["Designation"].ToString();
                            teacher.EmailID = sdr["EmailID"].ToString();
                            teacher.Payment =Convert.ToDecimal(sdr["Payment"]);
                            teacher.Gender = sdr["Gender"].ToString(); 
                            
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
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings[""].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("", sqlconnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            var teacher = new Teacher();
                            teacher.First_Name = sdr["First_Name"].ToString();
                            teacher.Midde_Name = sdr["Midde_Name"].ToString();
                            teacher.Last_Name = sdr["Last_Name"].ToString();
                            teacher.Address = sdr["Address"].ToString();
                            teacher.ContactNo = sdr["ContactNo"].ToString();
                            teacher.EmergencyContactId = sdr["EmergencyContactId"].ToString();
                            teacher.City = sdr["EmergencyContactId"].ToString();
                            teacher.Country = sdr["Country"].ToString();
                            teacher.Pin = sdr["Pin"].ToString();
                            teacher.BloodGroup = sdr["BloodGroup"].ToString();
                            teacher.DOB = Convert.ToDateTime(sdr["DOB"]);
                            teacher.Designation = sdr["Designation"].ToString();
                            teacher.EmailID = sdr["EmailID"].ToString();
                            teacher.Payment = Convert.ToDecimal(sdr["Payment"]);
                            teacher.Gender = sdr["Gender"].ToString();

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
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings[""].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("", sqlconnection);
                    cmd.Parameters.Add(new SqlParameter("@Name", teacher.First_Name));
                    cmd.Parameters.Add(new SqlParameter("@Gender", teacher.Midde_Name));
                    cmd.Parameters.Add(new SqlParameter("@EmailId", teacher.Last_Name));
                    cmd.Parameters.Add(new SqlParameter("@DOB", teacher.Address));
                    cmd.Parameters.Add(new SqlParameter("@Address1", teacher.City));
                    cmd.Parameters.Add(new SqlParameter("@Address2", teacher.Country));
                    cmd.Parameters.Add(new SqlParameter("@Address3", teacher.Pin));
                    cmd.Parameters.Add(new SqlParameter("@MobileNo", teacher.ContactNo));
                    cmd.Parameters.Add(new SqlParameter("@DeptId", teacher.EmergencyContactId));
                    cmd.Parameters.Add(new SqlParameter("@UserName", teacher.EmailID));
                    cmd.Parameters.Add(new SqlParameter("@Password", teacher.BloodGroup));
                    cmd.Parameters.Add(new SqlParameter("@ZipCode", teacher.Gender));
                    cmd.Parameters.Add(new SqlParameter("@Payment", teacher.Payment));
                    cmd.Parameters.Add(new SqlParameter("@Payment", teacher.Photo));
                    cmd.Parameters.Add(new SqlParameter("@Resume", teacher.Resume));
                    cmd.Parameters.Add(new SqlParameter("@UserName",teacher.UserName));
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

        public int UpdateTeacher(Teacher teacher)
        {
            int res = 0;
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings[""].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("", sqlconnection);
                    cmd.Parameters.Add(new SqlParameter("@Name", teacher.First_Name));
                    cmd.Parameters.Add(new SqlParameter("@Gender", teacher.Midde_Name));
                    cmd.Parameters.Add(new SqlParameter("@EmailId", teacher.Last_Name));
                    cmd.Parameters.Add(new SqlParameter("@DOB", teacher.Address));
                    cmd.Parameters.Add(new SqlParameter("@Address1", teacher.City));
                    cmd.Parameters.Add(new SqlParameter("@Address2", teacher.Country));
                    cmd.Parameters.Add(new SqlParameter("@Address3", teacher.Pin));
                    cmd.Parameters.Add(new SqlParameter("@MobileNo", teacher.ContactNo));
                    cmd.Parameters.Add(new SqlParameter("@DeptId", teacher.EmergencyContactId));
                    cmd.Parameters.Add(new SqlParameter("@UserName", teacher.EmailID));
                    cmd.Parameters.Add(new SqlParameter("@Password", teacher.BloodGroup));
                    cmd.Parameters.Add(new SqlParameter("@ZipCode", teacher.Gender));
                    cmd.Parameters.Add(new SqlParameter("@Payment", teacher.Payment));
                    cmd.Parameters.Add(new SqlParameter("@Payment", teacher.Photo));
                    cmd.Parameters.Add(new SqlParameter("@Resume", teacher.Resume));
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
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings[""].ConnectionString))
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
