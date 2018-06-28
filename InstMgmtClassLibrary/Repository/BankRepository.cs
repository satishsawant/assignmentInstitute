using InstMgmtClassLibrary.Domain;
using InstMgmtClassLibrary.Interface;
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
    public class BankRepository: IBankRepository
    {
        public IList<Bank> GetAll()
        {
            List<Bank> banks = new List<Bank>();
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
                            var bank = new Bank();
                            bank.BankName = sdr["BankName"].ToString();
                            bank.AccountNumber = Convert.ToInt32(sdr["AccountNumber"]);
                            bank.Address = sdr["Address"].ToString();
                            bank.ContactNo1 = Convert.ToInt32(sdr["ContactNo1"]);
                            bank.ContactNo2 = Convert.ToInt32(sdr["ContactNo2"]);
                            banks.Add(bank);
                        }
                    }
                    sqlconnection.Close();
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return banks.ToList();
        }
        public int CreateBank(Bank bank)
        {
            int res = 0;
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings[""].ConnectionString))
                {

                    SqlCommand cmd = new SqlCommand("", sqlconnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BankName", bank.BankName);
                    cmd.Parameters.AddWithValue("@AccountNumber", bank.AccountNumber);
                    cmd.Parameters.AddWithValue("@Address", bank.Address);
                    cmd.Parameters.AddWithValue("@ContactNo1", bank.ContactNo1);
                    cmd.Parameters.AddWithValue("@ContactNo2", bank.ContactNo2);
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
        public int CreateBankTrn(BankTrn banktrn)
        {
            int res = 0;
            try
            {
                using (var sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings[""].ConnectionString))
                {

                    SqlCommand cmd = new SqlCommand("", sqlconnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TransactionType", banktrn.TransactionType);
                    cmd.Parameters.AddWithValue("@Amount", banktrn.Amount);
                    cmd.Parameters.AddWithValue("@DateOfTrn", banktrn.DateOfTrn);
                    cmd.Parameters.AddWithValue("@TrnDoneBy", banktrn.TrnDoneBy);
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
