using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using InstMgmtClassLibrary.Domain;
using InstMgmtClassLibrary.Interface;

namespace InstMgmtClassLibrary.Repository
{
    public class StudentRepository: IStudentRepository
    {
        public Student Get(int id)
        {
            var student = new Student();
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings[""].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("", sqlconnection);
                    cmd.Parameters.Add(new SqlParameter("@SudentId", id));
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            student.Name = sdr["Name"].ToString();
                            student.Address = sdr["Address"].ToString();
                            student.City = sdr["City"].ToString();
                            student.State = sdr["State"].ToString();
                            student.CourseId = Convert.ToInt32(sdr["CourseId"]);
                            student.MobileNo = sdr["MobileNo"].ToString();
                            student.PhoneNo = sdr["PhoneNo"].ToString();
                            student.PinCode = Convert.ToInt32(sdr["PinCode"]);
                            student.RoolId = Convert.ToInt32(sdr["RoolId"]);
                            student.Gender = sdr["Gender"].ToString();
                            student.DateOfBirth = Convert.ToDateTime(sdr["DateOfBirth"]);
                        }
                    }
                    sqlconnection.Close();
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return student;
        }

        public IList<Student> GetAll()
        {
            List<Student> students = new List<Student>();
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
                            var student = new Student();
                            student.Name = sdr["Name"].ToString();
                            student.Address = sdr["Address"].ToString();
                            student.City = sdr["City"].ToString();
                            student.State = sdr["State"].ToString();
                            student.CourseId = Convert.ToInt32(sdr["CourseId"]);
                            student.MobileNo = sdr["MobileNo"].ToString();
                            student.PhoneNo = sdr["PhoneNo"].ToString();
                            student.PinCode = Convert.ToInt32(sdr["PinCode"]);
                            student.RoolId = Convert.ToInt32(sdr["RoolId"]);
                            student.Gender = sdr["Gender"].ToString();
                            student.DateOfBirth = Convert.ToDateTime(sdr["DateOfBirth"]);
                            students.Add(student);
                        }
                    }
                    sqlconnection.Close();
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return students.ToList();
        }

        public int Create(Student student)
        {
            int res = 0;
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings[""].ConnectionString))
                {
                    
                    SqlCommand cmd = new SqlCommand("", sqlconnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name",student.Name);
                    cmd.Parameters.AddWithValue("@Address", student.Address);
                    cmd.Parameters.AddWithValue("@City", student.City);
                    cmd.Parameters.AddWithValue("@State", student.State);
                    cmd.Parameters.AddWithValue("@CourseId", student.CourseId);
                    cmd.Parameters.AddWithValue("@PhoneNo", student.PhoneNo);
                    cmd.Parameters.AddWithValue("@MobileNo", student.MobileNo);
                    cmd.Parameters.AddWithValue("@PinCode", student.PinCode);
                    cmd.Parameters.AddWithValue("@Gender", student.Gender);
                    cmd.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth);
                    sqlconnection.Open();
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

        public int Update(Student student)
        {
            int res = 0;
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings[""].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("", sqlconnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", student.Name);
                    cmd.Parameters.AddWithValue("@Address", student.Address);
                    cmd.Parameters.AddWithValue("@City", student.City);
                    cmd.Parameters.AddWithValue("@State", student.State);
                    cmd.Parameters.AddWithValue("@CourseId", student.CourseId);
                    cmd.Parameters.AddWithValue("@PhoneNo", student.PhoneNo);
                    cmd.Parameters.AddWithValue("@MobileNo", student.MobileNo);
                    cmd.Parameters.AddWithValue("@PinCode", student.PinCode);
                    sqlconnection.Open();
                    res = cmd.ExecuteNonQuery();
                    sqlconnection.Close();

                }
            }
            catch(Exception ex)
            {
                ex.Message.ToString();
            }
            return res;
        } 

        public bool Delete(int id)
        {
            int i = 0;
         try
            {
                using (var sqlconnection=new SqlConnection(ConfigurationManager.ConnectionStrings[""].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("", sqlconnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StudentId", id);
                    sqlconnection.Open();
                    i = cmd.ExecuteNonQuery();
                    sqlconnection.Close();
                    
                }

            }
            catch(Exception ex)
            {
                ex.Message.ToString();
            }
            if (i >= 1)
                return true;
            else
                return false;
        }


    }
}

