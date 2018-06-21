using InstMgmtClassLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace InstMgmtClassLibrary.Repository
{
    class TeacherRepository : ITeacherRepository
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
                            teacher.Name = sdr["Name"].ToString();
                            teacher.Address1 = sdr["Address1"].ToString();
                            teacher.Address2 = sdr["Address2"].ToString();
                            teacher.Address3 = sdr["Address3"].ToString();
                            teacher.MobileNo = sdr["MobileNo"].ToString();
                            teacher.PhoneNo = sdr["PhoneNo"].ToString();
                            teacher.ZipCode = Convert.ToInt32(sdr["ZipCode"]);
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
    }
}
