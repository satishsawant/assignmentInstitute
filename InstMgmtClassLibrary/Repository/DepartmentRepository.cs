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
            var department = new Department();
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["InstCon"].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("GetDepartment", sqlconnection);
                    cmd.Parameters.Add(new SqlParameter("@DepartmentID", id));
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            department.Department_Name = sdr["Department_Name"].ToString();
                            //department.DepartmentStartDate = Convert.ToDateTime(sdr["DepartmentStartDate"]);
                            //department.StudentCapacity = Convert.ToInt32(sdr["StudentCapacity"]);
                            //department.DepartmentDetail = sdr["DepartmentDetail"].ToString();
                        }
                    }
                    sqlconnection.Close();
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return department;
        }

        public IList<Department> GetAll()
        {
            List<Department> departments = new List<Department>();
            try
            {
                int id = 0;
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["InstCon"].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("GetDepartment", sqlconnection);
                    cmd.Parameters.Add(new SqlParameter("@DepartmentID", id));
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            var department = new Department();
                            department.DepartmentID= Convert.ToInt32(sdr["DepartmentID"]);
                            department.Department_Name = sdr["Department_Name"].ToString();
                            //department.DepartmentStartDate = Convert.ToDateTime(sdr["DepartmentStartDate"]);
                            //department.StudentCapacity = Convert.ToInt32(sdr["StudentCapacity"]);
                            //department.DepartmentDetail = sdr["DepartmentDetail"].ToString();
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
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["InstCon"].ConnectionString))
                {
                    int id = 0;
                    SqlCommand cmd = new SqlCommand("SP_CreateDepartment", sqlconnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DepartmentID", id);
                    cmd.Parameters.AddWithValue("@Department_Name", department.Department_Name);
                    //cmd.Parameters.AddWithValue("@DepartmentStartDate", department.DepartmentStartDate);
                    //cmd.Parameters.AddWithValue("@StudentCapacity", department.StudentCapacity);
                    //cmd.Parameters.AddWithValue("@DepartmentDetail", department.DepartmentDetail);
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
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["InstCon"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_CreateDepartment", sqlconnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DepartmentID", department.DepartmentID);
                    cmd.Parameters.AddWithValue("@Department_Name", department.Department_Name); //cmd.Parameters.AddWithValue("@DepartmentStartDate", department.DepartmentStartDate);
                    //cmd.Parameters.AddWithValue("@StudentCapacity", department.StudentCapacity);
                    //cmd.Parameters.AddWithValue("@DepartmentDetail", department.DepartmentDetail);
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

