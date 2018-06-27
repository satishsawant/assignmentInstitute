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

    public class RoleRepository : IRoleRepository
    {
        public Role Get(int id)
        {
            var role = new Role() { roleID = 1, RoleType = "Computer"};
            //try
            //{
            //    using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings[""].ConnectionString))
            //    {
            //        sqlconnection.Open();
            //        SqlCommand cmd = new SqlCommand("", sqlconnection);
            //        cmd.Parameters.Add(new SqlParameter("@roleId", id));
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        SqlDataReader sdr = cmd.ExecuteReader();
            //        if (sdr.HasRows)
            //        {
            //            while (sdr.Read())
            //            {
            //                role.RoleType = sdr["RoleType"].ToString();
            //            }
            //        }
            //        sqlconnection.Close();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ex.Message.ToString();
            //}
            return role;
        }

        public IList<Role> GetAll()
        {
            List<Role> roles = new List<Role>();
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
                            var role = new Role();
                            role.RoleType = sdr["RoleType"].ToString();
                            roles.Add(role);
                        }
                    }
                    sqlconnection.Close();
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return roles.ToList();
        }

        public int CreateRole(Role role)
        {
            int res = 0;
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings[""].ConnectionString))
                {

                    SqlCommand cmd = new SqlCommand("", sqlconnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RoleType", role.RoleType);
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

        public int UpdateRole(Role role)
        {
            int res = 0;
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings[""].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("", sqlconnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RoleType", role.RoleType);
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

