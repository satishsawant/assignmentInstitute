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
    public class CourseRepository : ICourseRepository
    {
        public Course Get(int id)
        {
            var course = new Course();
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["InstCon"].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("GetCouseInfo", sqlconnection);
                    cmd.Parameters.Add(new SqlParameter("@CourseID", id));
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            course.CourseName = sdr["Name"].ToString();
                            course.CourseTypeId = Convert.ToInt32(sdr["CourseTypeID"]);
                            course.Duration = sdr["Duration"].ToString();
                            course.Fees = Convert.ToInt32(sdr["Fees"]);
                        }
                    }
                    sqlconnection.Close();
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return course;
        }

        public IList<Course> GetAll()
        {
            List<Course> courses = new List<Course>();
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["InstCon"].ConnectionString))
                {
                    int id = 0;
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("GetCouseInfo", sqlconnection);
                    cmd.Parameters.Add(new SqlParameter("@CourseID", id));
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            var course = new Course();
                            course.CourseId = Convert.ToInt32(sdr["CourseID"]);
                            course.CourseName = sdr["Name"].ToString();
                            course.CourseTypeId = Convert.ToInt32(sdr["CourseTypeID"]);
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
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["InstCon"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_UpdateCouseInfo", sqlconnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", course.CourseName);
                    cmd.Parameters.AddWithValue("@CourseTypeID", course.CourseTypeId);
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
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["InstCon"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_UpdateCouseInfo", sqlconnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", course.CourseName);
                    cmd.Parameters.AddWithValue("@CourseTypeID", course.CourseTypeId);
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


        //Course Type Details
        public CourseType GetCourseType(int id)
        {
            var courseType = new CourseType();
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["InstCon"].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("GetCourseType", sqlconnection);
                    cmd.Parameters.Add(new SqlParameter("@CourseTypeId", id));
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            courseType.CourseTypeName = sdr["CourseTypeName"].ToString();
                        }
                    }
                    sqlconnection.Close();
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return courseType;
        }

        public IList<CourseType> GetAllCourseType()
        {
            List<CourseType> courseTypes = new List<CourseType>();
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["InstCon"].ConnectionString))
                {
                    sqlconnection.Open();
                    SqlCommand cmd = new SqlCommand("GetCouseType", sqlconnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            var course = new CourseType();
                            course.CourseTypeName = sdr["CourseTypeName"].ToString();
                            course.CourseTypeId = Convert.ToInt32(sdr["CourseTypeID"]);
                            courseTypes.Add(course);
                        }
                    }
                    sqlconnection.Close();
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return courseTypes.ToList();
        }
        public int CreateCourseType(CourseType coursetype)
        {
            int res = 0;
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["InstCon"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_UpdateCourseType", sqlconnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@coursetypename", coursetype.CourseTypeName);
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
        public int UpdateCourseType(CourseType coursetype)
        {
            int res = 0;
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["InstCon"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_UpdateCourseType", sqlconnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CourseTypeId", coursetype.CourseTypeId);
                    cmd.Parameters.AddWithValue("@coursetypename", coursetype.CourseTypeName);
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

