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
            var teacher = new Teacher() { Id = 1, Name="satish",Address1="pune",Address2="aurangabad",DOB=DateTime.Now,Gender="Male",EmailId="sawantss.77@gmail.com",Password="test",UserName="satish",MobileNo="12345",PhoneNo="22222"};
            //try
            //{
            //    using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings[""].ConnectionString))
            //    {
            //        sqlconnection.Open();
            //        SqlCommand cmd = new SqlCommand("", sqlconnection);
            //        cmd.Parameters.Add(new SqlParameter("@Id", id));
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        SqlDataReader sdr = cmd.ExecuteReader();
            //        if (sdr.HasRows)
            //        {
            //            while (sdr.Read())
            //            {
            //                teacher.Name = sdr["Name"].ToString();
            //                teacher.Address1 = sdr["Address1"].ToString();
            //                teacher.Address2 = sdr["Address2"].ToString();
            //                teacher.Address3 = sdr["Address3"].ToString();
            //                teacher.MobileNo = sdr["MobileNo"].ToString();
            //                teacher.PhoneNo = sdr["PhoneNo"].ToString();
            //                teacher.ZipCode = Convert.ToInt32(sdr["ZipCode"]);
            //                teacher.DeptId = Convert.ToInt32(sdr["DeptId"]);
            //            }
            //        }
            //        sqlconnection.Close();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ex.Message.ToString();
            //}
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
                            teacher.Name = sdr["Name"].ToString();
                            teacher.Address1 = sdr["Address1"].ToString();
                            teacher.Address2 = sdr["Address2"].ToString();
                            teacher.Address3 = sdr["Address3"].ToString();
                            teacher.MobileNo = sdr["MobileNo"].ToString();
                            teacher.PhoneNo = sdr["PhoneNo"].ToString();
                            teacher.ZipCode = Convert.ToInt32(sdr["ZipCode"]);
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
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings[""].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("", sqlconnection);
                    cmd.Parameters.Add(new SqlParameter("@Name", teacher.Name));
                    cmd.Parameters.Add(new SqlParameter("@Gender", teacher.Gender));
                    cmd.Parameters.Add(new SqlParameter("@EmailId", teacher.EmailId));
                    cmd.Parameters.Add(new SqlParameter("@DOB", teacher.DOB));
                    cmd.Parameters.Add(new SqlParameter("@Address1", teacher.Address1));
                    cmd.Parameters.Add(new SqlParameter("@Address2", teacher.Address2));
                    cmd.Parameters.Add(new SqlParameter("@Address3", teacher.Address3));
                    cmd.Parameters.Add(new SqlParameter("@MobileNo", teacher.MobileNo));
                    cmd.Parameters.Add(new SqlParameter("@DeptId", teacher.DeptId));
                    cmd.Parameters.Add(new SqlParameter("@UserName", teacher.UserName));
                    cmd.Parameters.Add(new SqlParameter("@Password", teacher.Password));
                    cmd.Parameters.Add(new SqlParameter("@ZipCode", teacher.ZipCode));

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
                    cmd.Parameters.Add(new SqlParameter("@Name", teacher.Name));
                    cmd.Parameters.Add(new SqlParameter("@Gender", teacher.Gender));
                    cmd.Parameters.Add(new SqlParameter("@EmailId", teacher.EmailId));
                    cmd.Parameters.Add(new SqlParameter("@DOB", teacher.DOB));
                    cmd.Parameters.Add(new SqlParameter("@Address1", teacher.Address1));
                    cmd.Parameters.Add(new SqlParameter("@Address2", teacher.Address2));
                    cmd.Parameters.Add(new SqlParameter("@Address3", teacher.Address3));
                    cmd.Parameters.Add(new SqlParameter("@MobileNo", teacher.MobileNo));
                    cmd.Parameters.Add(new SqlParameter("@DeptId", teacher.DeptId));
                    cmd.Parameters.Add(new SqlParameter("@UserName", teacher.UserName));
                    cmd.Parameters.Add(new SqlParameter("@Password", teacher.Password));
                    cmd.Parameters.Add(new SqlParameter("@ZipCode", teacher.ZipCode));
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
