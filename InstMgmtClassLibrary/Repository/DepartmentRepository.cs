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
    public class DepartmentRepository:IDepartmentRepository
    {
        public Department Get(int id)
        {
            var department = new Department() {DepartmentId=1,DepartmentName="Computer",DepartmentDetail="200 students" };
            //try
            //{
            //    using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings[""].ConnectionString))
            //    {
            //        sqlconnection.Open();
            //        SqlCommand cmd = new SqlCommand("", sqlconnection);
            //        cmd.Parameters.Add(new SqlParameter("@DepartmentId", id));
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        SqlDataReader sdr = cmd.ExecuteReader();
            //        if (sdr.HasRows)
            //        {
            //            while (sdr.Read())
            //            {
            //                department.DepartmentName = sdr["Name"].ToString();
            //                department.DepartmentStartDate = Convert.ToDateTime(sdr["DepartmentStartDate"]);
            //                department.StudentCapacity = Convert.ToInt32(sdr["StudentCapacity"]);
            //                department.DepartmentDetail = sdr["DepartmentDetail"].ToString();
                            
                            
            //            }
            //        }
            //        sqlconnection.Close();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ex.Message.ToString();
            //}
            return department;
        }

        public IList<Department> GetAll()
        {
            List<Department> departments = new List<Department>();
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
                            var department = new Department();
                            department.DepartmentName = sdr["Name"].ToString();
                            department.DepartmentStartDate = Convert.ToDateTime(sdr["DepartmentStartDate"]);
                            department.StudentCapacity = Convert.ToInt32(sdr["StudentCapacity"]);
                            department.DepartmentDetail = sdr["DepartmentDetail"].ToString();
                            departments.Add(department);
                        }
                    }
                    sqlconnection.Close();
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return departments.ToList();
        }

        public int CreateDepartment(Department department) 
        {
            int res = 0;
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings[""].ConnectionString))
                {

                    SqlCommand cmd = new SqlCommand("", sqlconnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DepartmentName", department.DepartmentName);
                    cmd.Parameters.AddWithValue("@DepartmentStartDate", department.DepartmentStartDate);
                    cmd.Parameters.AddWithValue("@StudentCapacity", department.StudentCapacity);
                    cmd.Parameters.AddWithValue("@DepartmentDetail", department.DepartmentDetail);
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

        public int UpdateDepartment(Department department)
        {
            int res = 0;
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings[""].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("", sqlconnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DepartmentName", department.DepartmentName);
                    cmd.Parameters.AddWithValue("@DepartmentStartDate", department.DepartmentStartDate);
                    cmd.Parameters.AddWithValue("@StudentCapacity", department.StudentCapacity);
                    cmd.Parameters.AddWithValue("@DepartmentDetail", department.DepartmentDetail);
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

       


    }
}

