using ApplicantAPI.DataLayer;
using ApplicantAPI.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicantAPI.BusinessLayer
{
   public class ApplicantBusiness:IApplicantBusiness
    {
        private readonly IApplicantDL _applicantDL;

        public ApplicantBusiness(IApplicantDL applicantDL)
        {
            _applicantDL = applicantDL;
        }
        public bool AddApplicantBL(ApplicantInfo applicantInfo)
        {
            try
            {
                bool result = _applicantDL.AddApplicantDL(applicantInfo);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ApplicantInfo GetApplicantByIdBL(int id)
        {
            try
            {
                ApplicantInfo applicantInfo = _applicantDL.GetApplicantByIdDL(id);
                return applicantInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ApplicantInfo> GetApplicantsBL()
        {
            try
            {
                List<ApplicantInfo> applicantInfos = _applicantDL.GetApplicantsDL();
                return applicantInfos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteApplicantBL(int id)
        {
            try
            {
                int res = _applicantDL.DeleteApplicantDL(id);
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool UpdateApplicantBL(ApplicantInfo applicantInfo)
        {
            try
            {
                bool result = _applicantDL.UpdateApplicantDL(applicantInfo);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
