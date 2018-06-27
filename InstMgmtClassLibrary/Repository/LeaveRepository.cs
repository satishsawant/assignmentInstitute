using InstMgmtClassLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstMgmtClassLibrary.Repository
{
    public class LeaveRepository
    {
        public Leave Get(int id)
        {
            var leave = new Leave();
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["InstCon"].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("GetLeaves", sqlconnection);
                    cmd.Parameters.Add(new SqlParameter("@LeaveID", id));
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            leave.LoginID= Convert.ToInt32(sdr["Department_Name"]);
                            leave.LeaveTypeID = Convert.ToInt32(sdr["LeaveTypeID"]);
                            leave.Reason = sdr["Reason"].ToString();
                            leave.DateFrom = Convert.ToDateTime(sdr["DateFrom"]);
                            leave.DateTo = Convert.ToDateTime(sdr["DateTo"]);
                            leave.IsApproved = Convert.ToBoolean(sdr["IsApproved"]);
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
            return leave;
        }

        public List<Leave> GetAll()
        {
            List<Leave> leaves = new List<Leave>();
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["InstCon"].ConnectionString))
                {
                    int id = 0;
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("GetLeaves", sqlconnection);
                    cmd.Parameters.Add(new SqlParameter("@LeaveID", id));
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            var leave = new Leave();
                            leave.LoginID = Convert.ToInt32(sdr["Department_Name"]);
                            leave.LeaveTypeID = Convert.ToInt32(sdr["LeaveTypeID"]);
                            leave.Reason = sdr["Reason"].ToString();
                            leave.DateFrom = Convert.ToDateTime(sdr["DateFrom"]);
                            leave.DateTo = Convert.ToDateTime(sdr["DateTo"]);
                            leave.IsApproved = Convert.ToBoolean(sdr["IsApproved"]);
                            leaves.Add(leave);
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
            return leaves;
        }

        public int Create(Leave leave)
        {
            int result=0;
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["InstCon"].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("SP_UpdateLeaveType", sqlconnection);
                    cmd.Parameters.Add(new SqlParameter("@LeaveTypeID", leave.LeaveTypeID));
                    cmd.Parameters.Add(new SqlParameter("@LoginID", leave.LoginID));
                    cmd.Parameters.Add(new SqlParameter("@DateFrom", leave.DateFrom));
                    cmd.Parameters.Add(new SqlParameter("@DateTo", leave.DateTo));
                    cmd.Parameters.Add(new SqlParameter("@Reason", leave.Reason));
                    cmd.Parameters.Add(new SqlParameter("@LeaveTypeID", leave.LeaveTypeID));

                }
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
    }
}
