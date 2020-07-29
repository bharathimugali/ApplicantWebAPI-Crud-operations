using ApplicantAPI.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ApplicantAPI.DataLayer
{
   public class ApplicantDL :IApplicantDL
    {
        // string connectionString = "Server=MT-9S06QT2;Initial Catalog = ApplicantDb; Integrated security = SSPI";
       public static  IConfiguration _config;
       
       public ApplicantDL(IConfiguration config)
        {
            _config = config;
        }
      readonly  string connectionString = _config.GetConnectionString("DefaultConnection");

        public bool AddApplicantDL(ApplicantInfo applicantInfo)
        {
            try
            {
                int i;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = string.Format("insert into tblApplicantInfo values('{0}','{1}','{2}')",applicantInfo.FirstName,applicantInfo.LastName,applicantInfo.Email);
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        i = cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                if (i >= 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ApplicantInfo GetApplicantByIdDL(int id)
        {
            try
            {
                ApplicantInfo applicantInfo = new ApplicantInfo();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "select * from tblApplicantInfo where ApplicantId=" + id;
                    SqlCommand cmd = new SqlCommand(query, connection);

                    connection.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        applicantInfo.ApplicantId = Convert.ToInt32(dataReader["ApplicantId"]);
                        applicantInfo.FirstName = dataReader["FirstName"].ToString();
                        applicantInfo.LastName = dataReader["LastName"].ToString();
                        applicantInfo.Email = dataReader["Email"].ToString();
                     }

                }
                return applicantInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ApplicantInfo> GetApplicantsDL()
        {
            try
            {
                List<ApplicantInfo> applicants = new List<ApplicantInfo>();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "select * from tblApplicantInfo";
                    SqlCommand cmd = new SqlCommand(query, connection);

                    connection.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        ApplicantInfo applicantInfo = new ApplicantInfo();
                        applicantInfo.ApplicantId = Convert.ToInt32(dataReader["ApplicantId"]);
                        applicantInfo.FirstName = dataReader["FirstName"].ToString();
                        applicantInfo.LastName = dataReader["LastName"].ToString();
                        applicantInfo.Email = dataReader["Email"].ToString();
                        applicants.Add(applicantInfo);
                    }

                }
                return applicants;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteApplicantDL(int id)
        {
            try
            {
                int res;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "delete from tblApplicantInfo where ApplicantId=" + id;
                    SqlCommand cmd = new SqlCommand(query, connection);
                    connection.Open();
                    res = cmd.ExecuteNonQuery();
                           
                }
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateApplicantDL(ApplicantInfo applicantInfo)
        {
            try
            {
                int i;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = string.Format("update tblApplicantInfo set FirstName='{0}', LastName='{1}',Email='{2}' where ApplicantId={3}" , applicantInfo.FirstName, applicantInfo.LastName, applicantInfo.Email,applicantInfo.ApplicantId);
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        i = cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                if (i >= 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
