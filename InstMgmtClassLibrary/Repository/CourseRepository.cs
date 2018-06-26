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
   public class CourseRepository:ICourseRepository
    {
         public Course Get(int id)
            {
                var course = new Course() { CourseId=1,CourseName=".NET",Duration="6 months",Fees=1900};
                //try
                //{
                //    using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings[""].ConnectionString))
                //    {
                //        sqlconnection.Open();
                //        SqlCommand cmd = new SqlCommand("", sqlconnection);
                //        cmd.Parameters.Add(new SqlParameter("@CourseId", id));
                //        cmd.CommandType = CommandType.StoredProcedure;
                //        SqlDataReader sdr = cmd.ExecuteReader();
                //        if (sdr.HasRows)
                //        {
                //            while (sdr.Read())
                //            {
                //                course.CourseName = sdr["CourseName"].ToString();
                //                course.CourseTypeId = Convert.ToInt32(sdr["CourseTypeId"]);
                //                course.Duration = sdr["Duration"].ToString();
                //                course.Fees = Convert.ToInt32(sdr["Fees"]);
                //            }
                //        }
                //        sqlconnection.Close();
                //    }
                //}
                //catch (Exception ex)
                //{
                //    ex.Message.ToString();
                //}
                return course;
            }

            public IList<Course> GetAll()
            {
                List<Course> courses = new List<Course>();
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
                               var course = new Course();
                               course.CourseName = sdr["CourseName"].ToString();
                               course.CourseTypeId = Convert.ToInt32(sdr["CourseTypeId"]);
                               course.Duration = sdr["Duration"].ToString();
                               course.Fees = Convert.ToInt32(sdr["Fees"]);
                               courses.Add(course);
                            }
                        }
                        sqlconnection.Close();
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
                return courses.ToList();
            }

            public int CreateCourse(Course course)
            {
                int res = 0;
                try
                {
                    using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings[""].ConnectionString))
                    {

                        SqlCommand cmd = new SqlCommand("", sqlconnection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CourseName", course.CourseName);
                        cmd.Parameters.AddWithValue("@CourseTypeId", course.CourseTypeId);
                        cmd.Parameters.AddWithValue("@Duration", course.Duration);
                        cmd.Parameters.AddWithValue("@Fees", course.Fees);
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

            public int UpdateCourse(Course course)
            {
                int res = 0;
                try
                {
                    using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings[""].ConnectionString))
                    {
                        SqlCommand cmd = new SqlCommand("", sqlconnection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CourseName", course.CourseName);
                        cmd.Parameters.AddWithValue("@CourseTypeId", course.CourseTypeId);
                        cmd.Parameters.AddWithValue("@Duration", course.Duration);
                        cmd.Parameters.AddWithValue("@Fees", course.Fees);
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

