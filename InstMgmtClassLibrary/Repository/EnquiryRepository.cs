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
    public class EnquiryRepository: IEnquiryRepository
    {
        public IList<Enquiry> GetAll()
        {
            List<Enquiry> enquiries = new List<Enquiry>();
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
                            var enquiry = new Enquiry();
                            enquiry.EnquiryName = sdr["EnquiryName"].ToString();
                            enquiry.Course = sdr["Course"].ToString();
                            enquiry.Other = sdr["Other"].ToString();
                            enquiry.DateOfEnq = Convert.ToDateTime(sdr["DateOfEnq"]);
                            enquiry.FollowUpDate = Convert.ToDateTime(sdr["FollowUpDate"]);
                            enquiry.Remark = sdr["Remark"].ToString();
                            enquiries.Add(enquiry);
                        }
                    }
                    sqlconnection.Close();
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return enquiries.ToList();
        }
        public int CreateEnquiry(Enquiry enquiry)
        {
            int res = 0;
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings[""].ConnectionString))
                {

                    SqlCommand cmd = new SqlCommand("", sqlconnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EnquiryName", enquiry.EnquiryName);
                    cmd.Parameters.AddWithValue("@Course", enquiry.Course);
                    cmd.Parameters.AddWithValue("@Other", enquiry.Other);
                    cmd.Parameters.AddWithValue("@DateOfEnq", enquiry.DateOfEnq);
                    cmd.Parameters.AddWithValue("@FollowUpDate", enquiry.FollowUpDate);
                    cmd.Parameters.AddWithValue("@Remark", enquiry.Remark);
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
