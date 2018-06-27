using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using InstMgmtClassLibrary.Domain;
using InstMgmtClassLibrary.Interfaces;


namespace InstMgmtClassLibrary.Repository
{
    public class StudentRepository:IStudentRepository
    {
        //public Student Get(int id)
        //{
        //    var student = new Student();
        //    try
        //    {
        //        using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["InstCon"].ConnectionString))
        //        {
        //            sqlconnection.Open();
        //            SqlCommand cmd = new SqlCommand("GetStudentInfo", sqlconnection);
        //            cmd.Parameters.Add(new SqlParameter("@LoginId", id));
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            SqlDataReader sdr = cmd.ExecuteReader();
        //            if (sdr.HasRows)
        //            {
        //                while (sdr.Read())
        //                {
        //                    student.First_Name = sdr["First_Name"].ToString();
        //                    student.Middle_Name = sdr["Middle_Name"].ToString();
        //                    student.Last_Name = sdr["Last_Name"].ToString();
        //                    student.Address1 = sdr["Address1"].ToString();
        //                    student.Address2 = sdr["Address2"].ToString();
        //                    student.City = sdr["City"].ToString();
        //                    student.Pincode = sdr["Pincode"].ToString();
        //                    student.Country = sdr["Country"].ToString();
        //                    student.EmergencyContactNo = sdr["EmergencyContactNo"].ToString();
        //                    student.Gender = sdr["Gender"].ToString();
        //                    student.ContactNo = sdr["ContactNo"].ToString();
        //                    student.BloodGroup = sdr["BloodGroup"].ToString(); ;
        //                    student.Photo = sdr["Photo"].ToString();
        //                    student.DeptId = Convert.ToInt32(sdr["DeptId"]); 
        //                    student.DateOfBirth = Convert.ToDateTime(sdr["DateOfBirth"]); 
        //                    student.ParentsName = sdr["ParentsName"].ToString();
        //                    student.ParentsMobileNo = sdr["ParentsMobileNo"].ToString(); 
        //                }
        //            }
        //            sqlconnection.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Message.ToString();
        //    }
        //        return student;
        //}

        public IList<Student> GetStudent(int id)
        {
            List<Student> students = new List<Student>();
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["InstCon"].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("GetStudentInfo", sqlconnection);
                    cmd.Parameters.Add(new SqlParameter("@LoginId", id));
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            var student = new Student();
                            student.StudentID= Convert.ToInt32(sdr["StudentID"]);
                            student.LoginID= Convert.ToInt32(sdr["LoginID"]);
                            student.First_Name = sdr["First_Name"].ToString();
                            student.Middle_Name = sdr["Middle_Name"].ToString();
                            student.Last_Name = sdr["Last_Name"].ToString();
                            student.Address1 = sdr["Address1"].ToString();
                            student.Address2 = sdr["Address2"].ToString();
                            student.City = sdr["City"].ToString();
                            student.Pincode = sdr["Pin"].ToString();
                            student.Country = sdr["Country"].ToString();
                            student.EmergencyContactNo = sdr["EmergencyContactNo"].ToString();
                            student.Gender = sdr["Gender"].ToString();
                            student.ContactNo = sdr["ContactNo"].ToString();
                            student.BloodGroup = sdr["BloodGroup"].ToString(); ;
                            student.Photo = sdr["Photo"].ToString();
                            student.DeptId = Convert.ToInt32(sdr["DeptId"]);
                            student.DateOfBirth = Convert.ToDateTime(sdr["DateOfBirth"]);
                            student.ParentsName = sdr["ParentsName"].ToString();
                            student.ParentsMobileNo = sdr["ParentsMobileNo"].ToString();
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

        public int CreateStudent(Student student)
        {
            int res = 0;
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["InstCon"].ConnectionString))
                {
                    sqlconnection.Open();
                    int RoleId = 2;
                    bool isUpdate = false;
                    SqlCommand cmdLogin = new SqlCommand("SP_InsertLogin", sqlconnection);
                    cmdLogin.Parameters.AddWithValue("@Username", student.UserName);
                    cmdLogin.Parameters.AddWithValue("@Password", student.Password);
                    cmdLogin.Parameters.AddWithValue("@RoleId", RoleId);                    
                    cmdLogin.CommandType = CommandType.StoredProcedure;
                    SqlParameter returnParameter = cmdLogin.Parameters.Add("@LoginId", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    cmdLogin.ExecuteNonQuery();
                    int LoginId = (int)returnParameter.Value;
                    if (LoginId>0)
                    {
                        SqlCommand cmd = new SqlCommand("SP_InsertStudentInfo", sqlconnection);
                        cmd.Parameters.AddWithValue("@LoginId", LoginId);
                        cmd.Parameters.AddWithValue("@First_Name", student.First_Name);
                        cmd.Parameters.AddWithValue("@Middle_Name", student.Middle_Name);
                        cmd.Parameters.AddWithValue("@Last_Name", student.Last_Name);
                        cmd.Parameters.AddWithValue("@Address1", student.Address1);
                        cmd.Parameters.AddWithValue("@Address2", student.Address2);
                        cmd.Parameters.AddWithValue("@City", student.City);
                        cmd.Parameters.AddWithValue("@Country", student.Country);
                        cmd.Parameters.AddWithValue("@Pin", student.Pincode);
                        cmd.Parameters.AddWithValue("@Gender", student.Gender);
                        cmd.Parameters.AddWithValue("@ContactNo", student.ContactNo);
                        cmd.Parameters.AddWithValue("@EmergencyContactNo", student.EmergencyContactNo);
                        cmd.Parameters.AddWithValue("@EmailID", student.EmailID);
                        cmd.Parameters.AddWithValue("@DeptId", student.DeptId);
                        cmd.Parameters.AddWithValue("@BloodGroup", student.BloodGroup);
                        cmd.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth);
                        cmd.Parameters.AddWithValue("@ParentsName", student.ParentsName);
                        cmd.Parameters.AddWithValue("@ParentsMobileNo", student.ParentsMobileNo);
                        cmd.Parameters.AddWithValue("@IsUpdate", isUpdate);
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

        public int UpdateStudent(Student student)
        {
            int res = 0;
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["InstCon"].ConnectionString))
                {
                    bool isUpdate = true;
                    SqlCommand cmd = new SqlCommand("SP_InsertStudentInfo", sqlconnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@First_Name", student.First_Name);
                    cmd.Parameters.AddWithValue("@Middle_Name", student.Middle_Name);
                    cmd.Parameters.AddWithValue("@Last_Name", student.Last_Name);
                    cmd.Parameters.AddWithValue("@Address1", student.Address1);
                    cmd.Parameters.AddWithValue("@Address2", student.Address2);
                    cmd.Parameters.AddWithValue("@City", student.City);
                    cmd.Parameters.AddWithValue("@Country", student.Country);
                    cmd.Parameters.AddWithValue("@Pincode", student.Pincode);
                    cmd.Parameters.AddWithValue("@Gender", student.Gender);
                    cmd.Parameters.AddWithValue("@EmergencyContactNo", student.EmergencyContactNo);
                    cmd.Parameters.AddWithValue("@EmailID", student.EmailID);
                    cmd.Parameters.AddWithValue("@DeptId", student.DeptId);
                    cmd.Parameters.AddWithValue("@ContactNo", student.ContactNo);
                    cmd.Parameters.AddWithValue("@BloodGroup", student.BloodGroup);
                    cmd.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth);
                    cmd.Parameters.AddWithValue("@ParentsName", student.ParentsName);
                    cmd.Parameters.AddWithValue("@ParentsMobileNo", student.ParentsMobileNo);
                    cmd.Parameters.AddWithValue("@IsUpdate", isUpdate);
                    cmd.Parameters.AddWithValue("@LoginId", student.LoginID);
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

        public bool DeleteStudent(int id)
        {
            int i = 0;
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings[""].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("", sqlconnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StudentID", id);
                    sqlconnection.Open();
                    i = cmd.ExecuteNonQuery();
                    sqlconnection.Close();
                }

            }
            catch (Exception ex)
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

